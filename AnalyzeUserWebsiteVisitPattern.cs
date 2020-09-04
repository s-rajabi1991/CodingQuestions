using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace AmazonTopQuestions
{
//We are given some website visits: the user with name username[i] visited the website website[i] at time timestamp[i].

//A 3-sequence is a list of websites of length 3 sorted in ascending order by the time of their visits.  (The websites in a 3-sequence are not necessarily distinct.)

//Find the 3-sequence visited by the largest number of users.If there is more than one solution, return the lexicographically smallest such 3-sequence.
    class AnalyzeUserWebsiteVisitPattern
    {
        public List<String> mostVisitedPattern(String[] username, int[] timestamp, String[] website)
        {
            Dictionary<String, List<Pair>> map = new Dictionary<String, List<Pair>>();
            int n = username.Length;
            // collect the website info for every user, key: username, value: (timestamp, website)
            for (int i = 0; i < n; i++)
            {
                if (!map.ContainsKey(username[i]))
                    map.Add(username[i], new List<Pair>());

                map[username[i]].Add(new Pair(timestamp[i], website[i]));
            }
            // count map to record every 3 combination occuring time for the different user.
            Dictionary<String, int> count = new Dictionary<String, int>();
            String res = "";
            foreach (string key in map.Select(i=>i.Key))
            {
                HashSet<string> set = new HashSet<string>();
                // this set is to avoid visit the same 3-seq in one user
                List<Pair> list = map[key];
                list = list.OrderByDescending(i => i.time).ToList();

                for (int i = 0; i < list.Count; i++)
                {
                    for (int j = i + 1; j < list.Count; j++)
                    {
                        for (int k = j + 1; k < list.Count; k++)
                        {
                            String str = list[i].web + " " + list[j].web + " " + list[k].web;
                            if (!set.Contains(str))
                            {
                                count.Add(str, count.GetValueOrDefault(str, 0) + 1);
                                set.Add(str);
                            }
                            if (res.Equals("") || count[res] < count[str] || (count[res] == count[str] && res.CompareTo(str) > 0))
                            {
                                // make sure the right lexi order
                                res = str;
                            }
                        }
                    }
                }
            }
            // grab the right answer
            String[] r = res.Split(" ");
            List<String> result = new List<string>();
            foreach (String str in r)
            {
                result.Add(str);
            }
            return result;
        }
    }


    class Pair
    {
        public int time;
        public String web;
        public Pair(int time, String web)
        {
            this.time = time;
            this.web = web;
        }
    }

}

