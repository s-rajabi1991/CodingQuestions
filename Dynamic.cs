using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;

namespace AmazonTopQuestions
{
    class Dynamic
    {
        public string LongestPalindrome(string s)
        {
            if (string.IsNullOrEmpty(s))
                return "";

            string max = "";
            int n = s.Length;

            bool[,] map = new bool[n, n];


            for (int i = 0; i < n; i++)
                for (int j = i; j >= 0; j--)
                {

                    map[j, i] = i == j || ((i == j + 1 || map[j + 1, i - 1]) && s[j] == s[i]);

                    if (map[j, i] && i - j + 1 > max.Length)
                        max = s.Substring(j, i - j + 1);


                }


            return max;
        }

        public int MaxSubArray(int[] nums)
        {
            int n = nums.Length;
            int max = nums[0];
           
            //GREEDY
            //int sum = nums[0];
            //for (int i = 1; i < n; ++i)
            //{
            //    sum = Math.Max(nums[i], sum + nums[i]);
            //    max = Math.Max(max, sum);
            //}

            for (int i = 1; i < n; ++i)
            {
                if (nums[i - 1] > 0) 
                    nums[i] += nums[i - 1];

                max = Math.Max(nums[i], max);
            }

            return max;
        }

        public int MaxProfit(int[] prices)
        {
            if (prices.Length == 0)
                return 0;

            int maxProfit = 0;
            int minPrice = prices[0];

            for (int i = 1; i < prices.Length; i++)
            {
                if (prices[i] < minPrice)
                    minPrice = prices[i];
                else if (prices[i] - minPrice > maxProfit)
                    maxProfit = prices[i] - minPrice;

            }

            return maxProfit;

        }

        //Given a non-empty string s and a dictionary wordDict containing a list of non-empty words, 
        // determine if s can be segmented into a space-separated sequence of one or more dictionary words.
        public bool WordBreak(string s, IList<string> wordDict)
        {
            
            HashSet<string> hash = wordDict.ToHashSet();
            HashSet<string> dp = new HashSet<string>();
            return WordBreakHelper(s,hash,dp);



        }

        private bool WordBreakHelper(string s, HashSet<string> hash, HashSet<string> dp)
        {
            if (s.Length == 0)
                return true;

            string result = "";
            for (int i = 0; i < s.Length; i++)
            {
                result += s[i];
                if (hash.Contains(result))
                {
                    string sub = s.Substring(i + 1);
                    if (!dp.Contains(sub)) {
                        if (WordBreakHelper(sub, hash, dp))
                            return true;
                    }
                }
            }

            dp.Add(s);
            return false;
        }


        //You are given coins of different denominations and a total amount of money amount.
        //Write a function to compute the fewest number of coins that you need to make up that amount.
        //If that amount of money cannot be made up by any combination of the coins, return -1.
        public int CoinChange(int[] coins, int amount)
        {
            if (amount < 1) 
                return 0;

            return CoinChange(coins, amount, new int[amount]);
        }

        private int CoinChange(int[] coins, int remaining, int[] count)
        {
            if (remaining < 0) 
                return -1;

            if (remaining == 0) 
                return 0;

            if (count[remaining - 1] != 0) 
                return count[remaining - 1];

            int min = Int32.MaxValue;
            foreach (int coin in coins)
            {
                int res = CoinChange(coins, remaining - coin, count);
                if (res >= 0 && res < min)
                    min = 1 + res;
            }
            count[remaining - 1] = (min == Int32.MaxValue) ? -1 : min;
            return count[remaining - 1];
        }
    }


}


