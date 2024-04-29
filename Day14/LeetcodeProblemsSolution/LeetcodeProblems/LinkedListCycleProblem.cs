using System;

namespace LeetcodeProblems
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x)
        {
            val = x;
            next = null;
        }
    }

    internal class LinkedListCycleProblem
    {
        public async Task<ListNode> GenerateLinkedListAsync(int[] nums, int posAtWhichCycleHappens)
        {
            ListNode head = new ListNode(nums[0]);
            ListNode tail = head;

            for (int i=1; i<nums.Length; i++)
            {
                tail.next = new ListNode(nums[i]);
                tail = tail.next;
            }
            if(posAtWhichCycleHappens>=0)
            {
                ListNode temp = head;
                for (int i = 0; i < posAtWhichCycleHappens; i++)
                {
                    temp.next = temp.next.next;
                }
                tail.next = temp;
            }            
            return head;            
        }

        public async Task<bool> HasCycleOrNotAsync(ListNode head)
        {
            if (head == null || head.next == null)
            {
                return false;
            }

            var slow = head;
            var fast = head;
            while (fast != null && fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
                if (slow == fast)
                {
                    return true;
                }
            }
            return false;
        }

        public static async Task Main(string[] args)
        {
            LinkedListCycleProblem linkedList = new LinkedListCycleProblem();
            ListNode head = await linkedList.GenerateLinkedListAsync([3, 2, 0, -4], 1);
            bool result = await linkedList.HasCycleOrNotAsync(head);
            Console.WriteLine(result);
        }
    }
}