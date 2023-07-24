using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    /// <summary>
    /// linked list data structure
    /// </summary>
    public class DefaultList
    {
        /// <summary>
        /// node of the list
        /// </summary>
        protected class Node
        {
            public int Value { get; set; }
            public Node? Next { get; set; }
            public Node(int value, Node? next)
            {
                Value = value;
                Next = next;
            }
        }
        protected Node? head = null;
        public int Size { get; private set; }
        /// <summary>
        /// adds new element to the head of the list
        /// </summary>
        /// <param name="value">value to add</param>
        public virtual void Add(int value)
        {
            head = new Node(value, head);
            Size++;
        }
        /// <summary>
        /// removes element from the list
        /// </summary>
        /// <param name="value">value to delete</param>
        /// <returns>true if element to be removed was in the list, false otherwise</returns>
        public virtual bool Remove(int value)
        {
            if (head == null)
                return false;
            Node? curNode = head;
            Node? prevNode = null;
            while (curNode != null && curNode.Value != value)
            {
                prevNode = curNode;
                curNode = curNode.Next;
            }
            if (curNode == null)
                return false;
            Size--;
            if (prevNode != null)
            {
                prevNode.Next = curNode.Next;
                return true;
            }
            head = head.Next;
            return true;
        }
        /// <summary>
        /// replaces element on a given position
        /// </summary>
        /// <param name="value">value to replace the element with</param>
        /// <param name="position">position of element to replace</param>
        /// <returns>true if element to replace was in the list, false otherwise</returns>
        public virtual bool Replace(int value, int position)
        {
            if (position >= Size)
                return false;
            Node? curNode = head;
            for (int i = 0; curNode != null && i < Size - 1 - position; i++)
            {
                curNode = curNode.Next;
            }
            if (curNode == null)
                return false;
            curNode.Value = value;
            return true;
        }
    }
}
