using System.Diagnostics.CodeAnalysis;

namespace DevToolz.Library.Extensions;

public static class ObjectExtensions
{
    //public static TClass ToModel<TClass>( this object source )
    //    where TClass : class, new()
    //{
    //    var modelReturn = new TClass();
    //    ClassHelper.CopyProperties( source, modelReturn );
    //    return modelReturn;
    //}

    public static bool IsNull( [NotNullWhen( false )] this object? source )
        => source == null;

    public static bool IsNotNull( [NotNullWhen( true )] this object? source )
        => source != null;
}