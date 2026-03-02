using DevToolz.Library.Converters.Interfaces;

namespace DevToolz.Library.Converters;

public class FormatConversionService
{
    private readonly FormatConverterRegistry _registry;

    public FormatConversionService( FormatConverterRegistry registry )
    {
        _registry = registry ?? throw new ArgumentNullException( nameof( registry ) );
    }

    public string Convert( string sourceFormat, string targetFormat, string input )
    {
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
