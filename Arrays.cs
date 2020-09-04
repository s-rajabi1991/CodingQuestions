using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace AmazonTopQuestions
{
    public class Arrays
    {
        //Given an array of integers, return indices of the two numbers such that they add up to a specific target.
        //You may assume that each input would have exactly one solution, and you may not use the same element twice.
        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, int> map = new Dictionary<int, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                int complement = target - nums[i];
                if (map.ContainsKey(complement))
                    return new int[] { map[complement], i };

                if (!map.ContainsKey(nums[i]))
                    map.Add(nums[i], i);
            }

            return new int[2];

        }

        //Given an array of integers that is already sorted in ascending order,
        //find two numbers such that they add up to a specific target number.
        public int[] TwoSum2(int[] numbers, int target)
        {
            int i = 0;
            int j = numbers.Length - 1;

            while (i < j)
            {
                int sum = numbers[i] + numbers[j];
                if (sum < target)
                    i++;
                else if (sum > target)
                    j--;
                else
                    return new int[] { i + 1, j + 1 };

            }

            return new int[2];
        }



        //Given a string, find the length of the longest substring without repeating characters.
        //public int LengthOfLongestSubstring(string s)
        //{//solve again
        //    #region Solution
        //    //int n = s.Length;
        //    //int ans = 0;
        //    //Dictionary<char, int> map = new Dictionary<char, int>();
        //    //int i = 0;

        //    //for (int j = 0; j < n; j++)
        //    //{
        //    //    if (map.ContainsKey(s[j]))
        //    //    {
        //    //        i = Math.Max(map[s[j]], i);
        //    //        map[s[j]] = j + 1;
        //    //    }
        //    //    else
        //    //    {
        //    //        map.Add(s[j], j + 1);
        //    //    }
        //    //    ans = Math.Max(ans, j - i + 1);

        //    //}
        //    //return ans;
        //    #endregion
        //}

        public int LengthOfLongestSubstring(string s)
        {
            int result = 0;
            Dictionary<char, int> dict = new Dictionary<char, int>();

            int start = 0;
            int end = 0;

            while (end < s.Length)
            {
                if (dict.ContainsKey(s[end]))
                {
                    start = Math.Max(start, dict[s[end]] + 1);
                    dict[s[end]] = end;
                }
                else
                {
                    dict.Add(s[end], end);
                }

                result = Math.Max(result, (end - start) + 1);
                end++;
            }

            return result;
        }

        public int MyAtoi(string str)
        {
            if (string.IsNullOrWhiteSpace(str)) return 0;
            str = str.TrimStart();
            bool isMinus = false;
            int start = 0;
            if (str[0] == '-') {
                isMinus = true;
                start = 1;
            }
            else if (str[0] == '+')
            {
                start = 1;
            }
            else if (!char.IsDigit(str[start]))
                return 0;


            string number = "";
            int i = start;
            while (i < str.Length)
            {
                if (!char.IsDigit(str[i]))
                    break;

                number += str[i];
                i++;

            }
            if (string.IsNullOrWhiteSpace(number)) return 0;

            if (int.TryParse(number, out int numberInt))
                return isMinus ? -1 * numberInt : numberInt;
            else
                return isMinus ? Int32.MinValue : Int32.MaxValue;

        }


        //Given an array nums of n integers, are there elements a, b, c in nums such that a + b + c = 0? 
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            IList<IList<int>> result = new List<IList<int>>();

            if (nums.Length < 3)
                return result;

            Array.Sort(nums);

            for (int i = 0; i < nums.Length - 2; i++)
            {
                if (nums[i] > 0)
                    break;

                if (i > 0 && nums[i] == nums[i - 1])
                    continue;

                int j = i + 1;
                int k = nums.Length - 1;

                while (j < k)
                {
                    if (nums[j] + nums[k] > -nums[i])
                        k--;
                    else if (nums[j] + nums[k] < -nums[i])
                        j++;
                    else
                    {
                        result.Add(new List<int> { nums[i], nums[j], nums[k] });
                        k--;
                        j++;

                        while (j < k && nums[j] == nums[j - 1])
                            j++;

                        continue;
                    }
                }

            }

            return result;
        }


        //find three integers in nums such that the sum is closest to target
        //Return the sum of the three integers. You may assume that each input would have exactly one solution.
        public int ThreeSumClosest(int[] nums, int target)
        {
            int sum = nums[0] + nums[1] + nums[2];
            Array.Sort(nums);

            for (int i = 0; i < nums.Length; i++)
            {
                int j = i + 1;
                int k = nums.Length - 1;

                while (j < k)
                {
                    int curr = nums[i] + nums[j] + nums[k];

                    if (Math.Abs(curr - target) < Math.Abs(sum - target))
                        sum = curr;

                    if (curr < target)
                        j++;
                    else
                        k--;

                }
            }

            return sum;
        }

        //Given an array of strings, group anagrams together.
        public IList<IList<string>> GroupAnagrams(string[] strs)
        {
            Dictionary<string, IList<string>> map = new Dictionary<string, IList<string>>();

            foreach (var str in strs)
            {
                string ordered = new string(str.OrderBy(i => i).ToArray());

                if (map.ContainsKey(ordered))
                    map[ordered].Add(str);

                else
                    map.Add(ordered, new List<string> { str });
            }

            return map.Values.ToList();
        }

        //Given a string S and a string T, find the minimum window in S which will contain all the characters in T in complexity O(n).
        public String minWindow(String s, String t)
        {
            if (s.Length == 0 || t.Length == 0)
                return "";

            Dictionary<char, int> dictT = new Dictionary<char, int>();

            for (int i = 0; i < t.Length; i++)
                AddToDictionary(dictT, t[i]);

            int l = 0, r = 0;
            int formed = 0;

            Dictionary<char, int> windowCounts = new Dictionary<char, int>();

            // ans list of the form (window length, left, right)
            int[] ans = { -1, 0, 0 };

            while (r < s.Length)
            {
                AddToDictionary(windowCounts, s[r]);

                if (dictT.ContainsKey(s[r]) && windowCounts[s[r]] == dictT[s[r]])
                    formed++;

                // Try and contract the window till the point where it ceases to be 'desirable'.
                while (l <= r && formed == dictT.Count)
                {
                    // Save the smallest window until now.
                    if (ans[0] == -1 || r - l + 1 < ans[0])
                    {
                        ans[0] = r - l + 1;
                        ans[1] = l;
                        ans[2] = r;
                    }

                    // The character at the position pointed by the
                    // `Left` pointer is no longer a part of the window.
                    windowCounts[s[l]]--;

                    if (dictT.ContainsKey(s[l]) && windowCounts[s[l]] < dictT[s[l]])
                        formed--;

                    // Move the left pointer ahead, this would help to look for a new window.
                    l++;
                }

                // Keep expanding the window once we are done contracting.
                r++;
            }

            return ans[0] == -1 ? "" : s.Substring(ans[1], ans[2] + 1);
        }


        private void AddToDictionary(Dictionary<char, int> d, char c)
        {
            if (d.ContainsKey(c))
                d[c]++;
            else
                d.Add(c, 1);
        }


        public int StrStr(string haystack, string needle)
        {
            if (string.IsNullOrEmpty(needle))
                return 0;

            if (string.IsNullOrEmpty(haystack))
                return -1;

            for (int i = 0; i < haystack.Length - needle.Length + 1; i++)
            {
                var sub = haystack.Substring(i, needle.Length);
                if (sub.Equals(needle))
                    return i;
            }

            return -1;
        }


        public int MaxArea(int[] height)
        {
            int area = 0;
            int i = 0;
            int j = height.Length - 1;

            while (i < j)
            {
                int currArea = (j - i) * Math.Min(height[i], height[j]);
                area = currArea > area ? currArea : area;

                if (height[i] < height[j])
                    i++;
                else
                    j--;
            }
            return area;

            //for(int i=0;i<height.Length-1;i++)
            //    for(int j = i + 1; j < height.Length; j++)
            //    {
            //        int currArea = (j - i) * Math.Min(height[i], height[j]);
            //        area = currArea > area ? currArea : area;
            //    }

            //return area;
        }
        public int CompareVersion(string version1, string version2)
        {
            string[] v1 = version1.Split('.');
            string[] v2 = version2.Split('.');


            var n = Math.Max(v1.Length, v2.Length);

            for (int i = 0; i < n; i++)
            {
                int d1 = i < v1.Length ? int.Parse(v1[i]) : 0;
                int d2 = i < v2.Length ? int.Parse(v2[i]) : 0;
                if (d1 > d2)
                    return 1;
                else if (d2 > d1)
                    return -1;

            }
            return 0;
        }


        //Given an array containing n distinct numbers taken from 0, 1, 2, ..., n, find the one that is missing from the array.
        //Your algorithm should run in linear runtime complexity. Could you implement it using only constant extra space complexity?
        public int MissingNumber(int[] nums)
        {
            HashSet<int> map = new HashSet<int>();

            for (int i = 0; i <= nums.Length; i++)
            {
                map.Add(i);
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (map.Contains(nums[i]))
                    map.Remove(nums[i]);
            }

            return map.First();
        }


        public bool IsParenthesesValid(string s)
        {
            Stack<char> stack = new Stack<char>();
            Dictionary<char, char> map = new Dictionary<char, char>();
            map.Add(')', '(');
            map.Add('}', '{');
            map.Add(']', '[');


            foreach (char c in s)
            {
                if (map.ContainsKey(c))
                {
                    if (stack.Pop() != map[c])
                        return false;
                }
                else
                {
                    stack.Push(c);
                }
            }
            return stack.Count == 0;
        }
        public string MostCommonWord(string paragraph, string[] banned)
        {
            HashSet<string> punc = new HashSet<string> { "!", "?", "'", ",", ";", "." };
            Dictionary<string, int> d = new Dictionary<string, int>();
            foreach (var p in punc)
            {
                paragraph = paragraph.Replace(p, " ");
            }
            string[] list = paragraph.ToLower().Split(' ');

            foreach (string word in list)
            {
                if (!string.IsNullOrWhiteSpace(word) && !banned.Any(i => i.ToLower() == word))
                {
                    if (d.ContainsKey(word))
                        d[word]++;
                    else
                        d.Add(word, 1);
                }

            }

            return d.OrderByDescending(i => i.Value).First().Key;
        }

        //Given a string, find the first non-repeating character in it and return its index. If it doesn't exist, return -1.
        public int FirstUniqChar(string s)
        {
            Dictionary<char, int> freq = new Dictionary<char, int>();

            foreach (char c in s)
            {
                if (freq.ContainsKey(c))
                    freq[c]++;
                else
                    freq.Add(c, 1);
            }

            for (int i = 0; i < s.Length; i++)
            {
                if (freq[s[i]] == 1)
                    return i;
            }

            return -1;
        }

        //Given n non-negative integers representing an elevation map where the width of each bar is 1, compute how much water it is able to trap after raining.
        public int Trap(int[] height)
        {
            //Input:[0,1,0,2,1,0,1,3,2,1,2,1]
            //Output: 6
            int n = height.Length;
            if (height == null || n == 0 || n==1)
                return 0;

            int[] maxLeft = new int[n];
            int[] maxRight = new int[n];

            maxLeft[0] = height[0];
            for (int i=1; i < n; i++)
            {
                maxLeft[i] = Math.Max(maxLeft[i - 1], height[i]);
            }

            maxRight[n - 1] = height[n - 1];
            for (int i = n - 2; i >=0; i--)
            {
                maxRight[i] = Math.Max(maxRight[i + 1], height[i]);
            }

            int ans = 0;
            for (int i = 0; i < n; i++)
            {
                ans += Math.Min(maxLeft[i], maxRight[i]) - height[i];
            }

            return ans;
        }

        //You are given an n x n 2D matrix representing an image. Rotate the image by 90 degrees (clockwise)  in-place.
        public void Rotate(int[][] matrix)
        {

        }

        public bool IsPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s))
                return true;

            s = s.ToLower();

            int i = 0;
            int j = s.Length - 1;
            while (i < j)
            {
                if (!char.IsLetterOrDigit(s[i]))
                {
                    i++;
                    continue;
                }
                if (!char.IsLetterOrDigit(s[j]))
                {
                    j--;
                    continue;
                }
                if (s[i]!=s[j])
                {
                    return false;
                }
                i++;
                j--;
            }

            return true;
        }


        public int NumEquivDominoPairs(int[][] dominoes)
        {
            if (dominoes.Length == 0) return 0;

            Dictionary<string,int> hash = new Dictionary<string,int>();
            Dictionary<string,int> result = new Dictionary<string,int>();
             
            for(int i =0; i < dominoes.Length; i++)
            {
                int x = dominoes[i][0];
                int y = dominoes[i][1];
                string key = (x < y ? x : y) + "_" + (x < y ? y : x);
                if (hash.ContainsKey(key))
                {
                    int val = hash[key];
                    result[key] = ((val + 1) * val) / 2;
                    hash[key]++;
                }
                else
                {
                    hash.Add(key, 1);
                    result.Add(key, 0);
                }
            }

            int sum = result.Where(i => i.Value > 0).Sum(i => i.Value);
            return sum;
        }

        public int[] ProductExceptSelf(int[] nums)
        {
            int[] l = new int[nums.Length];
            int[] r = new int[nums.Length];
            int[] result = new int[nums.Length];

            l[0] = 1;
            for (int i = 1; i < nums.Length; i++)
                l[i] = nums[i - 1] * l[i - 1];

            r[nums.Length - 1] = 1;
            for (int i = nums.Length - 2; i >= 0; i--)
                r[i] = nums[i + 1] * r[i + 1];

            for (int i = 0; i < nums.Length; i++)
            {
                result[i] = l[i] * r[i];
            }

            return result;
        }

        public string[] ReorderLogFiles(string[] logs)
        {

            var c = new OrderLogs();
            return logs.OrderBy(x => x, c).ToArray();
        }
    }


    public class OrderLogs : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            var words_x = x.ToString().Split(' ');
            var words_y = y.ToString().Split(' ');

            if (Char.IsDigit(words_x[1][0]) && Char.IsLetter(words_y[1][0]))
                return 1;

            if (Char.IsLetter(words_x[1][0]) && Char.IsDigit(words_y[1][0]))
                return -1;

            if (Char.IsLetter(words_x[1][0]) && Char.IsLetter(words_y[1][0]))
            {
                string without_id_x = x.ToString().Substring(words_x[0].Length + 1);
                string without_id_y = y.ToString().Substring(words_y[0].Length + 1);

                if (without_id_x == without_id_y)
                    return String.Compare(words_x[0], words_y[0]);

                else
                    return String.Compare(without_id_x, without_id_y);

            }

            return 0;
        }
    }
}
