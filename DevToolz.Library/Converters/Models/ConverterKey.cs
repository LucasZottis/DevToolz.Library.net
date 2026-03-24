namespace DevToolz.Library.Converters.Models;

internal readonly record struct ConverterKey( string SourceFormat, string TargetFormat )
{
    public ConverterKey Normalize() => new(
        SourceFormat.Trim().ToLowerInvariant(),
        TargetFormat.Trim().ToLowerInvariant() );
}
