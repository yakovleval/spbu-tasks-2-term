using System.Collections;
using System.Reflection.Metadata.Ecma335;

namespace SkipList
{
    internal class SkipList<TElement> : IList<TElement>
        where TElement : IComparable<TElement>
    {
        private class Node
        {
            public KeyNode? Next { get; set; }
            public Node? Down { get; set; }

            public Node(KeyNode? next = null, Node? down = null)
            {
                Next = next;
                Down = down;
            }
        }
        private class KeyNode : Node
        {
            public TElement Key { get; init; }
            public KeyNode(TElement key, KeyNode? next = null, Node? down = null) : base(next, down)
            {
                Key = key;
            }
        }

        private Node head = new();
        private Node headOfFirstRow;

        public SkipList()
        {
            headOfFirstRow = head;
        }
        public TElement this[int index] 
        { 
            get
            {
                if (index < 0 || index >= Count)
                {
                    throw new IndexOutOfRangeException(nameof(index));
                }
                if (headOfFirstRow.Next != null)
                {
                    KeyNode currentNode = headOfFirstRow.Next;
                    for (int i = 1; i < Count; i++)
                    {
                        currentNode = currentNode.Next ?? throw new IndexOutOfRangeException(nameof(index));
                    }
                    return currentNode.Key;
                }
                throw new IndexOutOfRangeException(nameof(index));
            } 
            set => throw new NotSupportedException(); 
        }

        public int Count { get; private set; } = 0;

        public bool IsReadOnly => false;

        private KeyNode? _Add(Node currentNode, TElement item)
        {
            while (currentNode.Next != null && currentNode.Next.Key.CompareTo(item) < 0)
            {
                currentNode = currentNode.Next;
            }
            if (currentNode.Down == null)
            {
                KeyNode newNode = new(item, currentNode.Next);
                currentNode.Next = newNode;
                return newNode;
            }
            KeyNode? addedToLowerRow = _Add(currentNode.Down, item);
            if (addedToLowerRow != null)
            {
                Random coin = new();
                int flipResult = coin.Next(2);
                if (flipResult == 1)
                {
                    KeyNode newNode = new(item, currentNode.Next, addedToLowerRow);
                    currentNode.Next = newNode;
                    return newNode;
                }
            }
            return null;
        }

        public void Add(TElement item)
        {
            KeyNode? addedToLowerRow = _Add(head, item);
            Random coin = new();
            int flipResult = coin.Next(2);
            if (flipResult == 1)
            {
                KeyNode newKeyNode = new(item, null, addedToLowerRow);
                Node newStartNode = new(newKeyNode, head);
                head = newStartNode;
            }
            Count++;
        }

        public void Clear()
        {
            head = new();
            Count = 0;
        }

        private bool _Contains(Node currentNode, TElement item)
        {
            while (currentNode.Next != null && currentNode.Next.Key.CompareTo(item) < 0)
            {
                currentNode = currentNode.Next;
            }
            if (currentNode.Next == null || currentNode.Next.Key.CompareTo(item) > 0)
            {
                if (currentNode.Down == null)
                    return false;
                return _Contains(currentNode.Down, item);
            }
            return true;
        }

        public bool Contains(TElement item)
        {
            return _Contains(head, item);
        }

        public void CopyTo(TElement[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentException(nameof(array));
            if (arrayIndex < 0 || arrayIndex >= array.Length)
                throw new IndexOutOfRangeException(nameof(arrayIndex));
            if (array.Length - arrayIndex < Count)
                throw new ArgumentException("""
                    The number of elements in the source 
                    list is greater than the available space 
                    from index to the end of the destination array
                    """);
            
            KeyNode? currentNode = headOfFirstRow.Next;
            while (currentNode != null)
            {
                array[arrayIndex] = currentNode.Key;
                arrayIndex++;
                currentNode = currentNode.Next;
            }
        }

        public IEnumerator<TElement> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int IndexOf(TElement item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, TElement item)
        {
            throw new NotSupportedException();
        }

        private bool _Remove(Node currentNode, TElement item)
        {
            while (currentNode.Next != null && currentNode.Next.Key.CompareTo(item) < 0)
            {
                currentNode = currentNode.Next;
            }
            bool deleted = false;
            if (currentNode.Next != null && currentNode.Next.Key.CompareTo(item) == 0)
            {
                currentNode.Next = currentNode.Next.Next;
                deleted = true;
            }
            if (currentNode.Down != null)
            {
                deleted = _Remove(currentNode.Down, item);
            }
            return deleted;
        }

        public bool Remove(TElement item)
        {
            bool deleted = _Remove(head, item);
            if (deleted)
            {
                Count--;
                if (head.Next == null && head.Down != null)
                {
                    head = head.Down;
                }
            }
            return deleted;
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
