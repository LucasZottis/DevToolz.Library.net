using DevToolz.Library.Converters.Interfaces;

namespace DevToolz.Library.Converters;

public sealed class FormatConversionService
{
    private readonly IFormatConverterRegistry _registry;

    public FormatConversionService( IFormatConverterRegistry registry )
    {
        _registry = registry ?? throw new ArgumentNullException( nameof( registry ) );
    }

    public string Convert( string sourceFormat, string targetFormat, string input )
    {
        ArgumentNullException.ThrowIfNull( sourceFormat );
        ArgumentNullException.ThrowIfNull( targetFormat );

        IFormatConverter converter = _registry.Resolve( sourceFormat, targetFormat );
        return converter.Convert( input );
    }

    public static FormatConversionService CreateDefault()
    {
        var registry = new FormatConverterRegistry()
            .Register( new CsvToJsonConverter() );

        return new FormatConversionService( registry );
    }
}
