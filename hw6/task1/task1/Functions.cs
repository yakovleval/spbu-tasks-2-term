namespace task1
{
    /// <summary>
    /// class that implements Map, Filter and Fold functions
    /// </summary>
    public static class Functions
    {
        public static List<R> Map<T, R>(List<T> list, Func<T, R> function)
        {
            List<R> result = new();
            foreach (var elem in list)
                result.Add(function(elem));
            return result;
        }

        public static List<T> Filter<T>(List<T> list, Func<T, bool> function)
        {
            List<T> result = new();
            foreach (var elem in list)
                if (!function(elem))
                    result.Add(elem);
            return result;
        }

        public static R Fold<T, R>(List<T> list, R acc, Func<R, T, R> function)
        {
            foreach (var elem in list)
                acc = function(acc, elem);
            return acc;
        }
    }
}
