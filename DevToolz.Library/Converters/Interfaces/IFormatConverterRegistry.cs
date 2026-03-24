namespace DevToolz.Library.Converters.Interfaces;

public interface IFormatConverterRegistry
{
    IFormatConverterRegistry Register( IFormatConverter converter );

    IFormatConverter Resolve( string sourceFormat, string targetFormat );
}
