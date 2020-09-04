using DotNetty.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml;

namespace AmazonTopQuestions
{
    class SortAndSearch
    {
        public int MinMeetingRooms(int[][] intervals)
        {
            if (intervals.Length == 0) return 0;

            intervals = intervals.OrderBy(i => i[0]).ToArray();

            int[] end = new int[intervals.Length];
            for(int i = 0; i < intervals.Length; i++)
            {
                end[i] = intervals[i][1];
            }

            Array.Sort(end);

            int end_pointer = 0;

            int min = 0;

            for (int i = 0; i < intervals.Length; i++)
            {
                if (intervals[i][0] >= end[end_pointer])
                    end_pointer++;
                else
                    min++;
            }

            return min;

        }


        public int FindKthLargest(int[] nums, int k)
        {
            nums = nums.OrderByDescending(i => i).ToArray();

            return nums[k-1];
        }

        public int[] TopKFrequent(int[] nums, int k)
        {
            Dictionary<int, int> freq = new Dictionary<int, int>();

            foreach (var num in nums)
            {
                if (freq.ContainsKey(num))
                    freq[num]++;
                else
                    freq.Add(num, 1);
            }

            return freq.OrderByDescending(i => i.Value).Take(k).Select(i => i.Key).ToArray();

        }

        public int[][] KClosest(int[][] points, int K)
        {
            var result = points.OrderBy(i => Math.Sqrt(Math.Pow(i[0], 2) + Math.Pow(i[1], 2))).Take(K).ToArray();

            return result;

        }

        public int[] TwoSum(int[] numbers, int target)
        {
            int[] result = new int[2];

            int i = 0;
            int j = numbers.Length - 1;

            while (i < j)
            {
                int current = numbers[i] + numbers[j];

                if (current < target)
                    i++;

                else if (current > target)
                    j--;

                else
                {
                    result[0] = i+1;
                    result[1] = j+1;
                    break;
                }

            }

            return result;

        }

        public int[][] Merge(int[][] intervals)
        {
            if (intervals.Length == 0)
                return intervals;

            intervals = intervals.OrderBy(i => i[0]).ToArray();

            List<int[]> merged = new List<int[]> { new int[] { intervals[0][0], intervals[0][1] } };

            int i = 1;
            while (i < intervals.Length)
            {
                if(merged.Last()[1]>= intervals[i][0])
                {
                    merged.Last()[1] = Math.Max(merged.Last()[1], intervals[i][1]);
                }
                else
                {
                    merged.Add(new int[] { intervals[i][0], intervals[i][1] });
                }

                i++;
            }
            return merged.ToArray();
        }

    }


}


