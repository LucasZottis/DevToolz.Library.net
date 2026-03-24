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
    public void Convert_CsvToJson_WithCrLfLineEndings_ShouldConvertSuccessfully()
    {
        // Arrange
        string csv = "nome,idade\r\nAna,30\r\nBruno,25";
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
    public void Convert_CsvToJson_WithHeadersOnly_ShouldReturnEmptyArray()
    {
        // Arrange
        string csv = "nome,idade";
        var service = FormatConversionService.CreateDefault();

        // Act
        string json = service.Convert( "csv", "json", csv );
        using JsonDocument document = JsonDocument.Parse( json );

        // Assert
        Assert.Equal( 0, document.RootElement.GetArrayLength() );
    }

    [Fact]
    public void Convert_CsvToJson_WithSingleColumn_ShouldConvertSuccessfully()
    {
        // Arrange
        string csv = "nome\nAna\nBruno";
        var service = FormatConversionService.CreateDefault();

        // Act
        string json = service.Convert( "csv", "json", csv );
        using JsonDocument document = JsonDocument.Parse( json );

        // Assert
        Assert.Equal( 2, document.RootElement.GetArrayLength() );
        Assert.Equal( "Ana", document.RootElement[ 0 ].GetProperty( "nome" ).GetString() );
    }

    [Fact]
    public void Convert_CsvToJson_WithEscapedQuotes_ShouldHandleDoubleQuote()
    {
        // Arrange
        string csv = "nome,descricao\nAna,\"diz \"\"olá\"\"\"";
        var service = FormatConversionService.CreateDefault();

        // Act
        string json = service.Convert( "csv", "json", csv );
        using JsonDocument document = JsonDocument.Parse( json );

        // Assert
        Assert.Equal( "diz \"olá\"", document.RootElement[ 0 ].GetProperty( "descricao" ).GetString() );
    }

    [Fact]
    public void Convert_CsvToJson_WithUnclosedQuote_ShouldThrowFormatException()
    {
        // Arrange
        string csv = "nome,idade\n\"Ana,30";
        var service = FormatConversionService.CreateDefault();

        // Act & Assert
        Assert.Throws<FormatException>( () => service.Convert( "csv", "json", csv ) );
    }

    [Fact]
    public void Convert_CsvToJson_WithDuplicateHeaders_ShouldThrowFormatException()
    {
        // Arrange
        string csv = "nome,Nome\nAna,Ana";
        var service = FormatConversionService.CreateDefault();

        // Act & Assert
        Assert.Throws<FormatException>( () => service.Convert( "csv", "json", csv ) );
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
    public void Convert_WhenSourceFormatIsNull_ShouldThrowArgumentNullException()
    {
        // Arrange
        var service = FormatConversionService.CreateDefault();

        // Act & Assert
        Assert.Throws<ArgumentNullException>( () => service.Convert( null!, "json", "a,b" ) );
    }

    [Fact]
    public void Convert_WhenTargetFormatIsNull_ShouldThrowArgumentNullException()
    {
        // Arrange
        var service = FormatConversionService.CreateDefault();

        // Act & Assert
        Assert.Throws<ArgumentNullException>( () => service.Convert( "csv", null!, "a,b" ) );
    }

    [Fact]
    public void Register_WhenDuplicateConverter_ShouldThrowInvalidOperationException()
    {
        // Arrange
        var registry = new FormatConverterRegistry();
        registry.Register( new ReverseTextConverter() );

        // Act & Assert
        Assert.Throws<InvalidOperationException>( () => registry.Register( new ReverseTextConverter() ) );
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
