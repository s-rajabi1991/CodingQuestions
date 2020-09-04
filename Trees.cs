using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Xml;

namespace AmazonTopQuestions
{
    class Trees
    {
        public bool IsValidBST(TreeNode root)
        {
            if (root == null)
                return true;
            return ValidateBST(root, null, null);
        }

        private bool ValidateBST(TreeNode root, int? min, int? max)
        {
            bool isBST = (max == null || root.val < max) &&
                         (min == null || root.val > min) &&
                         (root.left == null || ValidateBST(root.left, min, root.val)) &&
                         (root.right == null || ValidateBST(root.right, root.val, max));

            return isBST;
        }

        public bool IsSymmetric(TreeNode root)
        {
            if (root == null)
                return true;


            return IsSymmetricHelper(root.left, root.right);
        }

        private bool IsSymmetricHelper(TreeNode left, TreeNode right)
        {
            if (left == null && right == null)
                return true;


            if (left == null || right == null)
                return false;

            return (left.val == right.val && IsSymmetricHelper(left.right, right.left) && IsSymmetricHelper(left.left, right.right));

        }
        //public bool IsSymmetric(TreeNode root)
        //{
        //    if (root == null)
        //        return true;

        //    List<string> traverse = new List<string>();
        //    inOrder(traverse, root);

        //    int i = 0;
        //    int j = traverse.Count - 1;

        //    while (i <= j)
        //    {
        //        if (traverse[i] != traverse[j])
        //            return false;
        //        i++;
        //        j--;
        //    }

        //    return true;
        //}

        //private void inOrder(List<string> t, TreeNode node)
        //{
        //    if (node.left != null)
        //        inOrder(t, node.left);
        //    else if (node.right != null)
        //        t.Add("NULL");

        //    t.Add(node.val.ToString());

        //    if (node.right != null)
        //        inOrder(t, node.right);
        //    else if (node.left != null)
        //        t.Add("NULL");

        //}

        public IList<IList<int>> LevelOrder(TreeNode root)
        {
            IList<IList<int>> result = new List<IList<int>>();
            if (root == null)
                return result;

            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);

            while (q.Count > 0)
            {
                List<TreeNode> levelNodes = new List<TreeNode>();
                while (q.Count > 0)
                {
                    var node = q.Dequeue();
                    levelNodes.Add(node);
                }

                List<int> levelVals = new List<int>();
                foreach (var node in levelNodes)
                {
                    levelVals.Add(node.val);

                    if (node.left != null)
                        q.Enqueue(node.left);

                    if (node.right != null)
                        q.Enqueue(node.right);
                }

                result.Add(levelVals);
            }
            return result;
        }

        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            IList<IList<int>> result = new List<IList<int>>();
            if (root == null)
                return result;

            Queue<TreeNode> q = new Queue<TreeNode>();
            q.Enqueue(root);
            bool tog = false;
            while (q.Count > 0)
            {
                List<TreeNode> levelNodes = new List<TreeNode>();
                while (q.Count > 0)
                {
                    var node = q.Dequeue();
                    levelNodes.Add(node);
                }


                List<int> levelVals = new List<int>();
                foreach (var node in levelNodes)
                {
                    levelVals.Add(node.val);

                    if (node.left != null)
                        q.Enqueue(node.left);

                    if (node.right != null)
                        q.Enqueue(node.right);
                }
                if (tog)
                    levelVals.Reverse();

                result.Add(levelVals);
                tog = !tog;
            }
            return result;

        }

        ////Given a non-empty binary tree, find the maximum path sum.
        //public int MaxPathSum(TreeNode root)
        //{

        //}

        public int LadderLength(string beginWord, string endWord, IList<string> wordList)
        {

            if (!wordList.Any())
                return 0;

            int n = wordList[0].Length;

            Queue<string> q = new Queue<string>();
            HashSet<string> visited = new HashSet<string>();

            q.Enqueue(beginWord);

            int rounds = 0;

            while (q.Count > 0)
            {
                int size = q.Count;
                for (int x = 0; x < size; x++)
                {
                    var node = q.Dequeue();
                    if (node == endWord)
                        return rounds + 1;

                    foreach (var word in wordList)
                    {
                        int count = 0;
                        for (int i = 0; i < n; i++)
                        {
                            if (word[i] != node[i])
                                count++;
                        }
                        if (count == 1 && !visited.Contains(word))
                        {
                            q.Enqueue(word);
                            visited.Add(word);
                        }
                    }

                }
                rounds++;
            }


            return 0;
        }

        public int NumIslands(char[][] grid)
        {
            int m = grid.Length;
            if (m == 0) return 0;

            int n = grid[0].Length;
            if (n == 0) return 0;

            List<Node> allOnes = new List<Node>();

            for (int i = 0; i < m; i++)
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] == '1')
                        allOnes.Add(new Node(i, j));
                }

            if (!allOnes.Any())
                return 0;

            bool[,] visited = new bool[m,n];
            Queue<Node> queue = new Queue<Node>();
            int count = 0;

            foreach (var one in allOnes)
            {
                if (!visited[one.Row,one.Col])
                {
                    count++;                    
                    queue.Enqueue(one);
                    visited[one.Row, one.Col] = true;

                    DoBFS(grid, queue, visited, m, n);
                }
            }

            return count;
        }

        private void DoBFS(char[][] grid, Queue<Node> queue, bool[,] visited, int rows, int cols)
        {
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();              

                List<Node> neighbours = GetNodeNeighbours(current, rows, cols);

                foreach (Node neighbour in neighbours)
                {
                    if (!visited[neighbour.Row, neighbour.Col] && grid[neighbour.Row][neighbour.Col] == '1')
                    {
                        queue.Enqueue(neighbour);
                        visited[neighbour.Row, neighbour.Col] = true;
                    }
                }

            }
        }

        private List<Node> GetNodeNeighbours(Node node, int rows, int cols)
        {
            List<Node> nodes = new List<Node>();

            if (node.Row > 0)
                nodes.Add(new Node(node.Row - 1, node.Col));

            if (node.Col > 0)
                nodes.Add(new Node(node.Row, node.Col - 1));

            if (node.Row < rows - 1)
                nodes.Add(new Node(node.Row + 1, node.Col));

            if (node.Col < cols - 1)
                nodes.Add(new Node(node.Row, node.Col + 1));

            return nodes;
        }
    }


    public class Node
    {
        public Node(int row, int col)
        {
            Row = row;
            Col = col;
        }
        public int Row { get; set; }
        public int Col { get; set; }
    }


  //Definition for a binary tree node.
  public class TreeNode {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null) {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
 
}

