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
    public class List
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
        private Node? head = null;
        public int Size { get; private set; }
        /// <summary>
        /// adds element to the list
        /// </summary>
        /// <param name="value">value to add</param>
        public void Add(int value)
        {
            head = new Node(value, head);
            Size++;
        }
        /// <summary>
        /// removes element from the list
        /// </summary>
        /// <param name="value">value to delete</param>
        /// <returns>true if element to be removed was in the list, false otherwise</returns>
        public bool Remove(int value)
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
        public bool Replace(int value, int position)
        {
            Node? curNode = head;
            for (int i = 0; curNode != null && i < Size - position; i++)
            {
                curNode = curNode.Next;
            }
            if (curNode == null)
                return false;
            curNode.Value = value;
            return true;
        }
        /// <summary>
        /// Checks if the given value is present in the list
        /// </summary>
        /// <param name="value">value to check</param>
        /// <returns>true if list contains the value, false otherwise</returns>
        public bool Contains(int value)
        {
            Node? curNode = head;
            for (; curNode != null && curNode.Value != value; curNode = curNode.Next) ;
            return curNode != null;
        }
    }
}
