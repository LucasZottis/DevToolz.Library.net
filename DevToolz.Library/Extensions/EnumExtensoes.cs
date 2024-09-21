namespace DevToolz.Library.Extensions;

public static class EnumExtensions
{
    public static string GetDescription( this object value )
    {
        var attributes = value.GetType().GetField( value.ToString() )
            .GetCustomAttributes( typeof( DescriptionAttribute ), false ) as DescriptionAttribute[];

        if ( attributes.Length > 0 )
            return attributes[ 0 ].Description;

        return value.ToString();
    }

    public static string GetDescription( this Enum value )
    {
        var attributes = value.GetType().GetField( value.ToString() )
            .GetCustomAttributes( typeof( DescriptionAttribute ), false ) as DescriptionAttribute[];

        if ( attributes.Length > 0 )
            return attributes[ 0 ].Description;

        return string.Empty;
    }
}