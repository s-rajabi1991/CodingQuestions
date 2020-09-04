using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace AmazonTopQuestions
{
    public class MovingAverage
    {
        public int Size { get; set; }
        public Queue<int> q { get; set; }

        public MovingAverage(int size)
        {
            this.Size = size;
            q = new Queue<int>();
        }

        public double Next(int val)
        {
            q.Enqueue(val);

            if (q.Count > Size)
            {
                q.Dequeue();
            }



            return (double)q.Sum() / (double)q.Count;

        }
    }
}

