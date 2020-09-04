using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace AmazonTopQuestions
{

    //Design a search autocomplete system for a search engine.Users may input a sentence(at least one word and end with a special character '#'). For each character they type except '#', you need to return the top 3 historical hot sentences that have prefix the same as the part of sentence already typed.Here are the specific rules:


    //The hot degree for a sentence is defined as the number of times a user typed the exactly same sentence before.
    //The returned top 3 hot sentences should be sorted by hot degree (The first is the hottest one). If several sentences have the same degree of hot, you need to use ASCII-code order(smaller one appears first).
    //If less than 3 hot sentences exist, then just return as many as you can.
    //When the input is a special character, it means the sentence ends, and in this case, you need to return an empty list.
    //Your job is to implement the following functions:

    //The constructor function:

    //AutocompleteSystem(String[] sentences, int[] times): This is the constructor. The input is historical data. Sentences is a string array consists of previously typed sentences.Times is the corresponding times a sentence has been typed. Your system should record these historical data.

    //Now, the user wants to input a new sentence.The following function will provide the next character the user types:

    //List<String> input(char c): The input c is the next character typed by the user.The character will only be lower-case letters('a' to 'z'), blank space(' ') or a special character('#'). Also, the previously typed sentence should be recorded in your system.The output will be the top 3 historical hot sentences that have prefix the same as the part of sentence already typed.

    public class AutocompleteSystem
    {
        private bool _idle;
        private readonly TrieNode _root;
        private TrieNode _node;
        private StringBuilder _prefix;
        private readonly SortedSet<(int times, string sentence)> _set;
        public AutocompleteSystem(string[] sentences, int[] times)
        {
            _prefix = new StringBuilder();
            _root = new TrieNode();
            _node = _root;
            _set = new SortedSet<(int times, string sentence)>(new SentenceComparer());

            for (int i = 0; i < sentences.Length; i++)
            {
                AddValue(sentences[i], times[i]);
            }
        }
        private void AddValue(TrieNode node, ref string val, int idx, int times)
        {
            if (idx == val.Length)
            {
                node.Times += times;
                return;
            }

            char c = val[idx];
            TrieNode nextNode = null;

            if (node.Next.ContainsKey(c))
            {
                nextNode = node.Next[c];
            }
            else
            {
                nextNode = new TrieNode();
                node.Next[c] = nextNode;
            }

            AddValue(nextNode, ref val, idx + 1, times);
        }

        private void AddValue(string val, int times)
        {
            AddValue(_root, ref val, 0, times);
        }

        private void Search(TrieNode node, char c)
        {
            _prefix.Append(c);

            if (node.Times > 0)
            {
                (int times, string sentence) data = (node.Times, _prefix.ToString());
                _set.Add(data);

                if (_set.Count > 3)
                {
                    _set.Remove(_set.Last());
                }
            }

            foreach (var next in node.Next)
            {
                Search(next.Value, next.Key);
            }

            _prefix.Remove(_prefix.Length - 1, 1);
        }

        public IList<string> Input(char c)
        {
            if (c == '#')
            {
                AddValue(_prefix.ToString(), 1);

                _idle = false;
                _node = _root;
                _prefix.Clear();
                return new List<string>();
            }

            if (_idle)
            {
                _prefix.Append(c);
                return new List<string>();
            }

            _set.Clear();

            if (!_node.Next.ContainsKey(c))
            {
                _idle = true;
                _prefix.Append(c);
                return new List<string>();
            }

            _node = _node.Next[c];
            Search(_node, c);

            IList<string> res = new List<string>();
            foreach (var data in _set)
            {
                res.Add(data.sentence);
            }

            _prefix.Append(c);
            return res;
        }
    }
    public class SentenceComparer : IComparer<(int times, string sentence)>
    {
        public int Compare((int times, string sentence) x, (int times, string sentence) y)
        {
            var timesCmp = y.times.CompareTo(x.times);
            if (timesCmp != 0)
            {
                return timesCmp;
            }

            return string.Compare(x.sentence, y.sentence, StringComparison.Ordinal);
        }
    }

    public class TrieNode
    {
        public int Times = 0;
        public readonly Dictionary<char, TrieNode> Next = new Dictionary<char, TrieNode>();
    }
}

