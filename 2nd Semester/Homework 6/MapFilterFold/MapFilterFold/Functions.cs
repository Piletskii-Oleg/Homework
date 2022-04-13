namespace MapFilterFold;

/// <summary>
/// Implementation of Map, Filter and Fold methods.
/// </summary>
/// <typeparam name="T">Input type.</typeparam>
public static class Functions<T>
{
    /// <summary>
    /// Takes a list and a function and transforms all elements of the list according to the given function.
    /// </summary>
    /// <typeparam name="TResult">Resulting type.</typeparam>
    /// <param name="list">Original list.</param>
    /// <param name="function">Functions that takes an element and transforms it.</param>
    /// <returns>New list with transformed elements.</returns>
    public static List<TResult> Map<TResult>(List<T> list, Func<T, TResult> function)
    {
        var result = new List<TResult>();
        foreach (var item in list)
        {
            result.Add(function(item));
        }

        return result;
    }

    /// <summary>
    /// Takes a list and leaves only those elements from which function returned true.
    /// </summary>
    /// <param name="list">Original list.</param>
    /// <param name="predicate">Bool function.</param>
    /// <typeparam name="T">Input type.</typeparam>
    /// <returns>New list that only has elements from which function returned true.</returns>
    public static List<T> Filter(List<T> list, Predicate<T> predicate)
    {
        var result = new List<T>();
        foreach (var item in list)
        {
            if (predicate(item))
            {
                result.Add(item);
            }
        }

        return result;
    }

    /// <summary>
    /// Takes a value and successively applies function to it and all elements of the list, one at a time.
    /// </summary>
    /// <typeparam name="TResult">Resulting type.</typeparam>
    /// <param name="list">Original list.</param>
    /// <param name="startingValue">Starting value of the function.</param>
    /// <param name="function">Function that takes current value and current list element and returns some transformed value which is then passed to the function again.</param>
    /// <returns>Resulting value after going through the list.</returns>
    public static TResult Fold<TResult>(List<T> list, TResult startingValue, Func<TResult, T, TResult> function)
    {
        foreach (var item in list)
        {
            startingValue = function(startingValue, item);
        }

        return startingValue;
    }
}
