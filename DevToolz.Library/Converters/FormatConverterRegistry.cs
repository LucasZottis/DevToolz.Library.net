using DevToolz.Library.Converters.Interfaces;
using DevToolz.Library.Converters.Models;

namespace DevToolz.Library.Converters;

public class FormatConverterRegistry
{
    private readonly Dictionary<ConverterKey, IFormatConverter> _converters = new();

    public FormatConverterRegistry Register( IFormatConverter converter )
    {
        ArgumentNullException.ThrowIfNull( converter );

        var key = new ConverterKey( converter.SourceFormat, converter.TargetFormat ).Normalize();
        _converters[ key ] = converter;

        return this;
    }

    public IFormatConverter Resolve( string sourceFormat, string targetFormat )
    {
        var key = new ConverterKey( sourceFormat, targetFormat ).Normalize();

        if( _converters.TryGetValue( key, out var converter ) )
            return converter;

        throw new NotSupportedException( $"Conversão de '{sourceFormat}' para '{targetFormat}' não registrada." );
    }
}
