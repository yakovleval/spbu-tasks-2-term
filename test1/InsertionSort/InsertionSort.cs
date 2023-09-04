namespace InsertionSort
{
    /// <summary>
    /// Class that implements insertion sort algorithm
    /// </summary>
    public class InsertionSort
    {
        /// <summary>
        /// sorts a list of T values with given comparer
        /// </summary>
        /// <typeparam name="T">type of elements to sort</typeparam>
        /// <param name="listToSort">list of values of type T to sort</param>
        /// <param name="comparer">comparer object to compare values of type T</param>
        public static List<T> Sort<T>(List<T> listToSort, IComparer<T> comparer)
        {
            for (int i = 1; i < listToSort.Count; i++)
            {
                int j = i;
                while (j > 0 && comparer.Compare(listToSort[j - 1], listToSort[j]) > 0)
                {
                    T tmp = listToSort[j - 1];
                    listToSort[j - 1] = listToSort[j];
                    listToSort[j] = tmp;
                    j--;
                }
            }
            return listToSort;
        }
    }
}
