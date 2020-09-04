using System;
using System.Collections.Generic;
using System.Linq;

namespace AmazonTopQuestions
{
    class Program
    {
        static void Main(string[] args)
        {

            //  var output = new Arrays().MyAtoi("2147483648");
            //var output = new Arrays().ThreeSumClosest(new int[] { 1, 1, -1, -1, 3 }, 1);

            //var output = new Arrays().Trap(new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 });

            //int[][] input = new int[][] { new int[] { 5, 1, 9, 11 }, new int[] { 2, 4, 8, 10 }, new int[] { 13, 3, 6, 7 }, new int[] { 15, 14, 12, 16 } };
            //new Arrays().Rotate(input);

            //ListNode l1 = new ListNode(2, (new ListNode(4, new ListNode(3))));
            //ListNode l2 = new ListNode(5, (new ListNode(6, new ListNode(4))));
            //new LinkedLists().AddTwoNumbers(l1, l2);

            //new Arrays().IsPalindrome("0P");

            //TreeNode l = new TreeNode(2, new TreeNode(3), new TreeNode(4));
            //TreeNode r = new TreeNode(2, new TreeNode(4), new TreeNode(3));
            //new Trees().IsSymmetric(new TreeNode(1, l, r));

            //TreeNode r = new TreeNode(1, new TreeNode(2,new TreeNode(4)),new TreeNode(3,null,new TreeNode(5)));
            //new Trees().ZigzagLevelOrder(r);


            //var output = new Trees().LadderLength("hit", "cog", new List<string> { "hot", "dot", "dog", "lot", "log", "cog" });

            //var input = new char[][] { new char[] { '1', '1', '0', '0', '0' }, new char[] { '1', '1', '0', '0', '0' }, new char[] { '0', '0', '1', '0', '0' }, new char[] { '0', '0', '0', '1', '1' } };
            //var output = new Trees().NumIslands(input);


            //var output = new SortAndSearch().Merge(new int[][] { new int[] { 2, 3 }, new int[] { 2, 2 }, new int[] { 3, 3 }, new int[] { 1, 3 }, new int[] { 5, 7 }, new int[] { 2, 2 }, new int[] { 4, 6 } });
            //MovingAverage obj = new MovingAverage(3);
            //  double param_1 = obj.Next(1);
            //   param_1 = obj.Next(10);
            //   param_1 = obj.Next(3);
            //   param_1 = obj.Next(5);

            //var output = new Arrays().ProductExceptSelf(new int[] { 1, 2, 3, 4 });
            //int output = new Arrays().NumEquivDominoPairs(new int[][] { new int[] { 1, 2 }, new int[] { 2, 1 }, new int[] { 2,1 }, new int[] { 5, 6 } });

            ////var output = new Arrays().ReorderLogFiles(new string[] { "0uoj 9 8896814034171", "0 81650258784962331", "t3df gjjn nxbrryos b" });
            //TicTacToe obj = new TicTacToe(3);

            //int param_1 = obj.Move(0, 0, 1);
            //param_1 = obj.Move(0, 2, 2);
            //param_1 = obj.Move(2, 2, 1);
            //param_1 = obj.Move(1, 1, 2);
            //param_1 = obj.Move(2, 0, 1);
            //param_1 = obj.Move(1, 0, 2);
            //param_1 = obj.Move(2, 1, 1);


            //var output = new Dynamic().LongestPalindrome("aba");

            //var output = new Dynamic().WordBreak("leetcode", new List<string> { "leet", "code" });

            var oitput = new Dynamic().CoinChange(new int[] { 6,3,1}, 10);
        }
    }



    public class MovingAverage
    {
        public int Size { get; set; }
        public Queue<int> q { get; set; }

        /** Initialize your data structure here. */
        public MovingAverage(int size)
        {
            this.Size = size;
            q = new Queue<int>();
        }

        public double Next(int val)
        {
            q.Enqueue(val);

            if (q.Count>Size)
            {
                q.Dequeue();
            }

            
            
            return (double)q.Sum()/(double)q.Count;

        }
    }
}
