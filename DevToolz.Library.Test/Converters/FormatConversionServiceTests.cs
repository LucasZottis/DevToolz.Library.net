using DevToolz.Library.Converters;
using DevToolz.Library.Converters.Interfaces;
using System.Text.Json;

namespace DevToolz.Library.Test.Converters;

public class FormatConversionServiceTests
{
    [Fact]
    public void Convert_CsvToJson_WithValidContent_ShouldConvertSuccessfully()
    {
        // Arrange
        string csv = "nome,idade\nAna,30\nBruno,25";
        var service = FormatConversionService.CreateDefault();

        // Act
        string json = service.Convert( "csv", "json", csv );
        using JsonDocument document = JsonDocument.Parse( json );

        // Assert
        Assert.Equal( 2, document.RootElement.GetArrayLength() );
        Assert.Equal( "Ana", document.RootElement[ 0 ].GetProperty( "nome" ).GetString() );
        Assert.Equal( "25", document.RootElement[ 1 ].GetProperty( "idade" ).GetString() );
    }

    [Fact]
    public void Convert_CsvToJson_WithQuotedValues_ShouldHandleCommaInsideCell()
    {
        // Arrange
        string csv = "nome,observacao\n\"Ana\",\"gosta de, testes\"";
        var service = FormatConversionService.CreateDefault();

        // Act
        string json = service.Convert( "csv", "json", csv );
        using JsonDocument document = JsonDocument.Parse( json );

        // Assert
        Assert.Equal( "gosta de, testes", document.RootElement[ 0 ].GetProperty( "observacao" ).GetString() );
    }


    [Fact]
    public void Convert_CsvToJson_WithInconsistentColumns_ShouldThrowFormatException()
    {
        // Arrange
        string csv = "nome,idade\nAna";
        var service = FormatConversionService.CreateDefault();

        // Act & Assert
        Assert.Throws<FormatException>( () => service.Convert( "csv", "json", csv ) );
    }

    [Fact]
    public void Convert_WhenConverterNotRegistered_ShouldThrowNotSupportedException()
    {
        // Arrange
        var service = new FormatConversionService( new FormatConverterRegistry() );

        // Act & Assert
        Assert.Throws<NotSupportedException>( () => service.Convert( "xml", "json", "<name>Ana</name>" ) );
    }

    [Fact]
    public void Convert_WhenRegisteringCustomConverter_ShouldSupportNewFormats()
    {
        // Arrange
        var registry = new FormatConverterRegistry()
            .Register( new ReverseTextConverter() );

        var service = new FormatConversionService( registry );

        // Act
        string output = service.Convert( "txt", "rev", "abc" );

        // Assert
        Assert.Equal( "cba", output );
    }

    private sealed class ReverseTextConverter : IFormatConverter
    {
        public string SourceFormat => "txt";

        public string TargetFormat => "rev";

        public string Convert( string input ) => new( input.Reverse().ToArray() );
    }
}
