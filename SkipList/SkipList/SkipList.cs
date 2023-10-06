using System.Collections;

namespace SkipList;

/// <summary>
/// class that implements 'skip list' data structure
/// </summary>
/// <typeparam name="TElement">type of elements to be stored in the list</typeparam>
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
    private static Random coin = new();

    /// <summary>
    /// default constructor, creates an empty list
    /// </summary>
    public SkipList()
    {
        headOfFirstRow = head;
    }

    /// <summary>
    /// gets element stored in a given index
    /// </summary>
    /// <param name="index">index of element to return</param>
    /// <returns></returns>
    /// <exception cref="IndexOutOfRangeException">thrown if index is out of range of the list</exception>
    /// <exception cref="NotSupportedException">thrown if an attempt to change the element by index was made</exception>
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

    /// <summary>
    /// return number of elements in the list
    /// </summary>
    public int Count { get; private set; } = 0;

    /// <summary>
    /// returns if the structure is read-only
    /// </summary>
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

    /// <summary>
    /// adds given element to the list
    /// </summary>
    /// <param name="item">element to add</param>
    public void Add(TElement item)
    {
        KeyNode? addedToLowerRow = RecursiveAdd(head, item);
        if (addedToLowerRow != null)
        {
            int flipResult = coin.Next(2);
            if (flipResult == 1)
            {
                KeyNode newKeyNode = new(item, null, addedToLowerRow);
                Node newStartNode = new(newKeyNode, head);
                head = newStartNode;
            }
        }
        Count++;
        version++;
    }

    /// <summary>
    /// clears the list
    /// </summary>
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

    /// <summary>
    /// returns if the element is in the list
    /// </summary>
    /// <param name="item">element to check presence of</param>
    /// <returns></returns>
    public bool Contains(TElement item)
    {
        return RecursiveContains(head, item);
    }

    /// <summary>
    /// copies the list to the given array starting from given index in the array
    /// </summary>
    /// <param name="array">array to copy to list to</param>
    /// <param name="arrayIndex">index in the array from which copied list should start</param>
    /// <exception cref="ArgumentException">thrown if array is null or there's not enough space in the array</exception>
    /// <exception cref="IndexOutOfRangeException">thrown if index is out of range of the array</exception>
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

    /// <summary>
    /// gets the enumerator in the list
    /// </summary>
    /// <returns>the enumerator in the list</returns>
    public IEnumerator<TElement> GetEnumerator()
    {
        return new SkipListEnumerator(this);
    }

    /// <summary>
    /// returns the index of the first occurence of given element
    /// </summary>
    /// <param name="item">element to find the index of</param>
    /// <returns>the found index</returns>
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

    /// <summary>
    /// inserts the element after the given index
    /// </summary>
    /// <param name="index">index to insert the element after</param>
    /// <param name="item">element to insert</param>
    /// <exception cref="NotSupportedException">this operation is not supported by the structure</exception>
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

    /// <summary>
    /// removes the element from the list
    /// </summary>
    /// <param name="item">element to remove</param>
    /// <returns>true if the element was removed, false otherwise</returns>
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

    /// <summary>
    /// removes the element at the specified index
    /// </summary>
    /// <param name="index">index of the element to remove</param>
    public void RemoveAt(int index)
    {
        Remove(this[index]);
    }

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator)GetEnumerator();

    /// <summary>
    /// enumerator of the list
    /// </summary>
    public class SkipListEnumerator : IEnumerator<TElement>
    {
        private readonly SkipList<TElement> list;
        private Node? currentNode;
        private int index;
        private TElement? currentElement;
        private readonly int version;

        /// <summary>
        /// creates a list enumerator
        /// </summary>
        /// <param name="list">list of which enumerator should be created</param>
        public SkipListEnumerator(SkipList<TElement> list)
        {
            this.list = list;
            currentNode = list.headOfFirstRow;
            index = -1;
            version = list.version;
        }

        /// <summary>
        /// return the element to which enumerator points
        /// </summary>
        public TElement Current
        {
            get
            {
                if (index == -1 || index == list.Count)
                    throw new InvalidOperationException();
                return currentElement!;
            }
        }

        /// <summary>
        /// return the element to which enumerator points
        /// </summary>
        object? IEnumerator.Current => Current;

        /// <summary>
        /// Disposes the enumerator
        /// </summary>
        public void Dispose()
        {

        }

        /// <summary>
        /// moves enumerator to the next element
        /// </summary>
        /// <returns>true if enumerator was moved to the next element, false if current element was the last</returns>
        /// <exception cref="InvalidOperationException">thrown if the collection was modified after creation of enumerator</exception>
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

        /// <summary>
        /// ressets the enumberator to first element in the list
        /// </summary>
        /// <exception cref="InvalidOperationException">thrown if the collection was modified after creation of enumerator</exception>
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
