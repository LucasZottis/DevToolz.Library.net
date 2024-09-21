namespace DevToolz.Library.Extensions;

public static class ListExtensions
{
    public static bool IsEmptyList<T>( this List<T> list )
        => list == null || list.Count == 0;
}