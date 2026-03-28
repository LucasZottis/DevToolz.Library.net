namespace DevToolz.Library.Converters.Interfaces;

public interface IFormatConverter
{
    string SourceFormat { get; }

    string TargetFormat { get; }

    string Convert( string input );
}
