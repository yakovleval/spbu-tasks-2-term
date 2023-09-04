namespace task2
{
    /// <summary>
    /// extends List class: stores only unique elements
    /// </summary>
    public class UniqueList : DefaultList
    {
        private bool Contains(int value)
        {
            Node? curNode = head;
            for (; curNode != null && curNode.Value != value; curNode = curNode.Next) ;
            return curNode != null;
        }

        /// <summary>
        /// overrides List.Add method
        /// </summary>
        /// <param name="value">value to add</param>
        /// <exception cref="AdditionOfExistentElementException">thrown if element to add already exists in the list</exception>
        public override void Add(int value)
        {
            if (Contains(value))
                throw new AdditionOfExistentElementException();
            base.Add(value);
        }

        /// <summary>
        /// overrides List.Remove method
        /// </summary>
        /// <param name="value">value to remove</param>
        /// <returns></returns>
        /// <exception cref="DeletingNonExistingElementException">thrown if element to remove doesn't exist in the list</exception>
        public override bool Remove(int value)
        {
            if (!Contains(value))
                throw new DeletingNonExistingElementException();
            return base.Remove(value);
        }

        /// <summary>
        /// overrides List.Replace method
        /// </summary>
        /// <param name="value">value to replace the element with</param>
        /// <param name="position">position of element to replace</param>
        /// <returns>true if element to replace was in the list, false otherwise</returns>
        public override bool Replace(int value, int position)
        {
            return base.Replace(value, position);
        }
    }
}
