using System.Collections;

namespace SkipList;

public class SkipList<TElement> : IList<TElement>
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
    private int version = 0;

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
                for (int i = 0; i < index; i++)
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

    private KeyNode? RecursiveAdd(Node currentNode, TElement item)
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
        KeyNode? addedToLowerRow = RecursiveAdd(currentNode.Down, item);
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
        KeyNode? addedToLowerRow = RecursiveAdd(head, item);
        Random coin = new();
        int flipResult = coin.Next(2);
        if (flipResult == 1)
        {
            KeyNode newKeyNode = new(item, null, addedToLowerRow);
            Node newStartNode = new(newKeyNode, head);
            head = newStartNode;
        }
        Count++;
        version++;
    }

    public void Clear()
    {
        head = new();
        Count = 0;
        version++;
    }

    private bool RecursiveContains(Node currentNode, TElement item)
    {
        while (currentNode.Next != null && currentNode.Next.Key.CompareTo(item) < 0)
        {
            currentNode = currentNode.Next;
        }
        if (currentNode.Next == null || currentNode.Next.Key.CompareTo(item) > 0)
        {
            if (currentNode.Down == null)
                return false;
            return RecursiveContains(currentNode.Down, item);
        }
        return true;
    }

    public bool Contains(TElement item)
    {
        return RecursiveContains(head, item);
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
        return new SkipListEnumerator(this);
    }

    public int IndexOf(TElement item)
    {
        KeyNode? currentNode = headOfFirstRow.Next;
        for (int i = 0; currentNode != null; i++, currentNode = currentNode.Next)
        {
            if (currentNode.Key.CompareTo(item) == 0)
                return i;
        }
        return -1;
    }

    public void Insert(int index, TElement item)
    {
        throw new NotSupportedException();
    }

    private bool RecursiveRemove(Node currentNode, TElement item)
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
            deleted = RecursiveRemove(currentNode.Down, item);
        }
        return deleted;
    }

    public bool Remove(TElement item)
    {
        bool deleted = RecursiveRemove(head, item);
        if (deleted)
        {
            if (head.Next == null && head.Down != null)
            {
                head = head.Down;
            }
            Count--;
            version++;
        }
        return deleted;
    }

    public void RemoveAt(int index)
    {
        Remove(this[index]);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return (IEnumerator)GetEnumerator();
    }

    public class SkipListEnumerator : IEnumerator<TElement>
    {
        private readonly SkipList<TElement> list;
        private Node? currentNode;
        private int index;
        private TElement? currentElement;
        private readonly int version;

        public SkipListEnumerator(SkipList<TElement> list)
        {
            this.list = list;
            currentNode = list.headOfFirstRow;
            index = -1;
            version = list.version;
        }

        public TElement Current
        {
            get
            {
                if (index == -1 || index == list.Count)
                    throw new InvalidOperationException();
                return currentElement!;
            }
        }

        object? IEnumerator.Current => Current;

        public void Dispose()
        {

        }

        public bool MoveNext()
        {
            if (version != list.version)
            {
                throw new InvalidOperationException("The collection was modified after the enumerator was created.");
            }
            KeyNode? nextNode = currentNode?.Next;
            if (nextNode == null)
            {
                return false;
            }
            currentElement = nextNode.Key;
            currentNode = nextNode;
            index++;
            return true;
        }

        public void Reset()
        {
            if (version != list.version)
            {
                throw new InvalidOperationException("The collection was modified after the enumerator was created.");
            }
            currentNode = list.headOfFirstRow;
            index = -1;
            currentElement = default;
        }
    }
}
