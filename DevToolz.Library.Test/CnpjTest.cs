using DevToolz.Library.Documents.Brazilian.Cnpj;
using DevToolz.Library.Documents.Brazilian.Cnpj.Interfaces;
using DevToolz.Library.Interfaces;

namespace DevToolz.Library.Test;

public class CnpjTest
{
    [Fact]
    public void ValidateTest()
    {
        IValidator validator = new CnpjValidator();
        IGenerator generator = new CnpjGenerator();

        Assert.True( validator.IsValid( "72.799.201/0001-01" ) );
        Assert.True( validator.IsValid( "28777566000143" ) );
        Assert.False( validator.IsValid( "50.523.085/0001-61" ) );
        Assert.False( validator.IsValid( "41909961000100" ) );
        Assert.False( validator.IsValid( "00.000.000/0000-00" ) );
        Assert.False( validator.IsValid( "00000000000000" ) );
        Assert.False( validator.IsValid( "11.111.111/1111-11" ) );
        Assert.False( validator.IsValid( "11111111111111" ) );

        Assert.True( validator.IsValid( generator.Generate() ) );
        Assert.True( validator.IsValid( generator.Generate( true ) ) );
    }

    [Fact]
    public void GenerateTest()
    {
        IGenerator generator = new CnpjGenerator();
        IValidator validator = new CnpjValidator();

        var cnpj = generator.Generate();
        var cnpjMasked = generator.Generate( true );

        Assert.True( validator.IsValid( cnpj ) );
        Assert.True( validator.IsValid( cnpjMasked ) );
    }

    [Theory]
    [InlineData( "00.000.000/0000-00" )]
    [InlineData( "11.111.111/1111-11" )]
    [InlineData( "22.222.222/2222-22" )]
    [InlineData( "33.333.333/3333-33" )]
    [InlineData( "44.444.444/4444-44" )]
    [InlineData( "55.555.555/5555-55" )]
    [InlineData( "66.666.666/6666-66" )]
    [InlineData( "77.777.777/7777-77" )]
    [InlineData( "88.888.888/8888-88" )]
    [InlineData( "99.999.999/9999-99" )]
    [InlineData( "00000000000000" )]
    [InlineData( "11111111111111" )]
    [InlineData( "22222222222222" )]
    [InlineData( "33333333333333" )]
    [InlineData( "44444444444444" )]
    [InlineData( "55555555555555" )]
    [InlineData( "66666666666666" )]
    [InlineData( "77777777777777" )]
    [InlineData( "88888888888888" )]
    [InlineData( "99999999999999" )]
    public void Validate_ShouldBeFalse_WhenCnpjHasRepeatedDigits( string value )
    {
        IValidator validator = new CnpjValidator();

        Assert.False( validator.IsValid( value ) );
    }

    [Fact]
    public void MaskedAndUnmasked_ShouldReturnCorrectFormats()
    {
        var cnpj = new Cnpj();
        cnpj.Generate();

        var unmasked = cnpj.Unmasked();
        var masked = cnpj.Masked();

        Assert.Equal( 14, unmasked.Length );
        Assert.True( unmasked.All( char.IsDigit ) );
        Assert.Matches( @"^\d{2}\.\d{3}\.\d{3}/\d{4}-\d{2}$", masked );
    }

    [Fact]
    public void Metadata_BaseDigits_ShouldReturnFirst12Digits()
    {
        var cnpj = new Cnpj();
        cnpj.Generate();

        ICnpjMetadata metadata = cnpj;

        Assert.Equal( 12, metadata.BaseDigits.Length );
        Assert.Equal( cnpj.Unmasked()[ ..12 ], metadata.BaseDigits );
    }

    [Fact]
    public void Metadata_FirstVerifyingDigit_ShouldReturnDigitAtIndex12()
    {
        var cnpj = new Cnpj();
        cnpj.Generate();

        ICnpjMetadata metadata = cnpj;

        Assert.Equal( cnpj.Unmasked()[ 12 ].ToString(), metadata.FirstVerifyingDigit );
    }

    [Fact]
    public void Metadata_SecondVerifyingDigit_ShouldReturnDigitAtIndex13()
    {
        var cnpj = new Cnpj();
        cnpj.Generate();

        ICnpjMetadata metadata = cnpj;

        Assert.Equal( cnpj.Unmasked()[ 13 ].ToString(), metadata.SecondVerifyingDigit );
    }
}
