namespace DevToolz.Library.Extensions;

public static class ArrayExtensions
{
    public static void ForEach<T>( this Array array, Action<T> action )
    {
        for ( int i = 0; i < array.Length; i++ )
            action.Invoke( ( T ) array.GetValue( i ) );
    }

    public static List<T> ToList<T>( this Array array )
    {
        var list = new List<T>();
        array.ForEach<T>( i => list.Add( i ) );
        return list;
    }

    public static string ToCharSeparatedList( this Array array, char separatorValue )
    {
        var seTotedList = string.Empty;

        for ( int i = 0; i < array.Length; i++ )
        {
            if ( i.IsEqual( array.Length - 1 ) )
                seTotedList += array.GetValue( i );
            else
                seTotedList += $"{array.GetValue( i )}{separatorValue}";
        }

        return seTotedList;
    }

    public static string ToCommaSeparatedList( this Array array )
        => array.ToCharSeparatedList( ',' );

    public static bool Contains<T>( this Array array, Func<T, bool> predicado )
    {
        for ( int i = 0; i < array.Length; i++ )
            if ( predicado.Invoke( ( T ) array.GetValue( i ) ) )
                return true;

        return false;
    }
}