using DevToolz.Library.Converters.Interfaces;
using DevToolz.Library.Converters.Models;
using System.Collections.Concurrent;

namespace DevToolz.Library.Converters;

public sealed class FormatConverterRegistry : IFormatConverterRegistry
{
    private readonly ConcurrentDictionary<ConverterKey, IFormatConverter> _converters = new();

    public IFormatConverterRegistry Register( IFormatConverter converter )
    {
        ArgumentNullException.ThrowIfNull( converter );

        var key = new ConverterKey( converter.SourceFormat, converter.TargetFormat ).Normalize();

        if( !_converters.TryAdd( key, converter ) )
            throw new InvalidOperationException( $"Já existe um conversor registrado para '{converter.SourceFormat}' → '{converter.TargetFormat}'." );

        return this;
    }

    public IFormatConverter Resolve( string sourceFormat, string targetFormat )
    {
        ArgumentNullException.ThrowIfNull( sourceFormat );
        ArgumentNullException.ThrowIfNull( targetFormat );

        var key = new ConverterKey( sourceFormat, targetFormat ).Normalize();

        if( _converters.TryGetValue( key, out var converter ) )
            return converter;

        throw new NotSupportedException( $"Conversão de '{sourceFormat}' para '{targetFormat}' não registrada." );
    }
}
