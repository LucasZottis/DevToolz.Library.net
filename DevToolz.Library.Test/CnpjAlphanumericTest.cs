using DevToolz.Library.Documents.Brazilian.Cnpj;
using DevToolz.Library.Documents.Brazilian.Cnpj.Interfaces;

namespace DevToolz.Library.Test;

public class CnpjAlphanumericTest
{
    // --- Validação com autodetecção (via IValidator.IsValid(string)) ---

    [Theory]
    [InlineData( "12ABC34501DE35" )]
    [InlineData( "12.ABC.345/01DE-35" )]
    [InlineData( "1345C3A5000106" )]
    [InlineData( "R55231B3000757" )]
    [InlineData( "ABCDEFGHIJKL80" )]
    public void Validate_ShouldBeTrue_WhenAlphanumericCnpjIsValid_Autodetect( string value )
    {
        IValidator validator = CnpjFactory.CreateValidator();

        Assert.True( validator.IsValid( value ) );
    }

    [Theory]
    [InlineData( "00000000000191" )]
    [InlineData( "90021382000122" )]
    [InlineData( "90024778000123" )]
    [InlineData( "90025108000121" )]
    [InlineData( "90025255000100" )]
    [InlineData( "90024420000109" )]
    [InlineData( "90024781000147" )]
    [InlineData( "04740714000197" )]
    [InlineData( "44108058000129" )]
    [InlineData( "90024780000100" )]
    [InlineData( "90024779000178" )]
    public void Validate_ShouldBeTrue_WhenNumericCnpjIsValid_Autodetect( string value )
    {
        IValidator validator = CnpjFactory.CreateValidator();

        Assert.True( validator.IsValid( value ) );
    }

    // --- Validação com formato explícito ---

    [Theory]
    [InlineData( "12ABC34501DE35" )]
    [InlineData( "12.ABC.345/01DE-35" )]
    [InlineData( "1345C3A5000106" )]
    [InlineData( "R55231B3000757" )]
    [InlineData( "ABCDEFGHIJKL80" )]
    public void Validate_ShouldBeTrue_WhenAlphanumericCnpjIsValid_ExplicitFormat( string value )
    {
        ICnpjValidator validator = CnpjFactory.CreateValidator();

        Assert.True( validator.IsValid( value, CnpjFormat.Alphanumeric ) );
    }

    [Theory]
    [InlineData( "00000000000191" )]
    [InlineData( "90021382000122" )]
    [InlineData( "90024778000123" )]
    public void Validate_ShouldBeTrue_WhenNumericCnpjValidatedAsAlphanumeric( string value )
    {
        ICnpjValidator validator = CnpjFactory.CreateValidator();

        Assert.True( validator.IsValid( value, CnpjFormat.Alphanumeric ) );
    }

    [Theory]
    [InlineData( "12ABC34501DE35" )]
    [InlineData( "1345C3A5000106" )]
    [InlineData( "ABCDEFGHIJKL80" )]
    public void Validate_ShouldBeFalse_WhenAlphanumericCnpjPassedAsNumericFormat( string value )
    {
        ICnpjValidator validator = CnpjFactory.CreateValidator();

        Assert.False( validator.IsValid( value, CnpjFormat.Numeric ) );
    }

    // --- Casos inválidos ---

    [Theory]
    [InlineData( "R55231B3000700" )]
    [InlineData( "ABCDEFGHIJKL81" )]
    public void Validate_ShouldBeFalse_WhenAlphanumericDvIsWrong( string value )
    {
        ICnpjValidator validator = CnpjFactory.CreateValidator();

        Assert.False( validator.IsValid( value, CnpjFormat.Alphanumeric ) );
    }

    [Theory]
    [InlineData( "0000000000019L" )]
    [InlineData( "000000000001P1" )]
    public void Validate_ShouldBeFalse_WhenLetterInDvPosition( string value )
    {
        ICnpjValidator validator = CnpjFactory.CreateValidator();

        Assert.False( validator.IsValid( value, CnpjFormat.Alphanumeric ) );
    }

    [Theory]
    [InlineData( "1345c3A5000106" )]
    [InlineData( "12.ABc.345/01DE-35" )]
    public void Validate_ShouldBeFalse_WhenLowercaseLetter( string value )
    {
        ICnpjValidator validator = CnpjFactory.CreateValidator();

        Assert.False( validator.IsValid( value, CnpjFormat.Alphanumeric ) );
    }

    [Fact]
    public void Validate_ShouldBeFalse_WhenAllZeros_AlphanumericFormat()
    {
        ICnpjValidator validator = CnpjFactory.CreateValidator();

        Assert.False( validator.IsValid( "00000000000000", CnpjFormat.Alphanumeric ) );
        Assert.False( validator.IsValid( "00.000.000/0000-00", CnpjFormat.Alphanumeric ) );
    }

    // --- Geração e round-trip ---

    [Fact]
    public void Generate_ShouldProduceValidAlphanumericCnpj_OnRoundTrip()
    {
        ICnpjGenerator generator = CnpjFactory.CreateGenerator();
        ICnpjValidator validator = CnpjFactory.CreateValidator();

        for ( int i = 0; i < 20; i++ )
        {
            var cnpj = generator.Generate( CnpjFormat.Alphanumeric );
            Assert.True( validator.IsValid( cnpj, CnpjFormat.Alphanumeric ), $"Round-trip falhou para: {cnpj}" );
        }
    }

    [Fact]
    public void Generate_ShouldProduceValidMaskedAlphanumericCnpj()
    {
        ICnpjGenerator generator = CnpjFactory.CreateGenerator();
        ICnpjValidator validator = CnpjFactory.CreateValidator();

        var masked = generator.Generate( true, CnpjFormat.Alphanumeric );

        Assert.True( validator.IsValid( masked, CnpjFormat.Alphanumeric ) );
        Assert.Matches( @"^[A-Z0-9]{2}\.[A-Z0-9]{3}\.[A-Z0-9]{3}/[A-Z0-9]{4}-\d{2}$", masked );
    }

    [Fact]
    public void Generate_AlphanumericCnpj_ShouldEventuallyContainLetter()
    {
        ICnpjGenerator generator = CnpjFactory.CreateGenerator();

        var foundLetter = false;
        for ( int i = 0; i < 50; i++ )
        {
            var cnpj = generator.Generate( CnpjFormat.Alphanumeric );
            if ( cnpj[ ..12 ].Any( c => c is >= 'A' and <= 'Z' ) )
            {
                foundLetter = true;
                break;
            }
        }

        Assert.True( foundLetter, "Nenhuma letra gerada em 50 tentativas — improvável se o gerador estiver correto." );
    }

    // --- Facade Cnpj ---

    [Fact]
    public void Facade_Cnpj_IsValid_ShouldAutodetectAlphanumericFormat()
    {
        var cnpj = new Cnpj( "12ABC34501DE35" );

        Assert.True( cnpj.IsValid() );
    }

    [Fact]
    public void Facade_Cnpj_IsValid_ShouldAutodetectNumericFormat()
    {
        var cnpj = new Cnpj( "72.799.201/0001-01" );

        Assert.True( cnpj.IsValid() );
    }

    [Fact]
    public void Facade_Cnpj_Generate_ShouldUseAlphanumericFormat()
    {
        ICnpjValidator validator = CnpjFactory.CreateValidator();

        var cnpj = new Cnpj( CnpjFormat.Alphanumeric );
        cnpj.Generate();

        Assert.True( validator.IsValid( cnpj.Unmasked(), CnpjFormat.Alphanumeric ) );
    }

    [Fact]
    public void Facade_Cnpj_IsValid_WithExplicitFormat_ShouldRespectOverride()
    {
        var cnpj = new Cnpj( "12ABC34501DE35", CnpjFormat.Alphanumeric );

        Assert.True( cnpj.IsValid() );
    }

    [Fact]
    public void Facade_Cnpj_IsValid_ShouldReturnFalse_WhenAlphanumericPassedAsNumeric()
    {
        var cnpj = new Cnpj( "12ABC34501DE35", CnpjFormat.Numeric );

        Assert.False( cnpj.IsValid() );
    }
}
