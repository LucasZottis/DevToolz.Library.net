using System.Collections;
using System.Reflection;

namespace DevToolz.Library.Extensions;

public static class TypeExtensions
{
    public static bool IsBaseTypeOf<TBaseType>( this Type type )
        => type != null && type.BaseType == typeof( TBaseType );

    public static bool IsCollectionType( this Type type )
        => typeof( IEnumerable ).IsAssignableFrom( type );

    public static object? CreateInstance( this Type type )
        => Activator.CreateInstance( type );

    public static object? CreateInstance( this Type type, params object[] arguments )
        => Activator.CreateInstance( type, arguments );

    public static MethodInfo? GetGenericMethod( this Type type, string name )
        => type.GetMethods().FirstOrDefault( m => m.Name == name && m.IsGenericMethod );
}