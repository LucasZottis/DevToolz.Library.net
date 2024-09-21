using System.Collections;

namespace DevToolz.Library.Extensions;

public static class EnumerableExtensions
{
    public static int Count( this IEnumerable list )
    {
        var count = 0;

        foreach ( var item in list )
            count++;

        return count;
    }

    public static bool Any( this IEnumerable list )
    {
        foreach ( var item in list )
            return true;

        return false;
    }

    public static void ForEach<T>( this IEnumerable list, Action<T> action )
    {
        foreach ( var item in list.Cast<T>() )
            action( item );
    }
}