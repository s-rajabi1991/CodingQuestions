using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmazonTopQuestions
{
    class LinkedLists
    {
        //You are given two non-empty linked lists representing two non-negative integers.The digits are stored in reverse order and each of their nodes contain a single digit.Add the two numbers and return it as a linked list.
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            //solve again
            // [2,4,3]
            // [5,6,4]
            //Expected answer [7,0,8]

            ListNode dummyHead = new ListNode(0);
            ListNode p = l1, q = l2, curr = dummyHead;
            int carry = 0;
            while (p != null || q != null)
            {
                int x = (p != null) ? p.val : 0;
                int y = (q != null) ? q.val : 0;
                int sum = carry + x + y;
                carry = sum / 10;
                curr.next = new ListNode(sum % 10);
                curr = curr.next;
                if (p != null) p = p.next;
                if (q != null) q = q.next;
            }
            if (carry > 0)
            {
                curr.next = new ListNode(carry);
            }
            return dummyHead.next;

        }

        //Given a linked list, reverse the nodes of a linked list k at a time and return its modified list.
        //public ListNode ReverseKGroup(ListNode head, int k)
        //{
        //}
    }

    //Definition for singly-linked list.
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

}

