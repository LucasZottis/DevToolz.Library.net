using DevToolz.Library.Documents.Brazilian.Cpf;
using DevToolz.Library.Documents.Brazilian.Cpf.Interfaces;

namespace DevToolz.Library.Test;

public class CpfTest
{
    [Fact]
    public void ValidateTest()
    {
        IValidator validator = CpfFactory.CreateValidator();
        IGenerator generator = CpfFactory.CreateGenerator();

        Assert.True( validator.IsValid( "816.784.690-33" ) );
        Assert.True( validator.IsValid( "38235836033" ) );
        Assert.False( validator.IsValid( "997.918.830-85" ) );
        Assert.False( validator.IsValid( "41916364056" ) );
        Assert.False( validator.IsValid( "000.000.000-00" ) );
        Assert.False( validator.IsValid( "00000000000" ) );
        Assert.False( validator.IsValid( "111.111.111-11" ) );
        Assert.False( validator.IsValid( "11111111111" ) );

        Assert.True( validator.IsValid( generator.Generate() ) );
        Assert.True( validator.IsValid( generator.Generate( true ) ) );
    }

    [Theory]
    [InlineData( "00000000000" )]
    [InlineData( "11111111111" )]
    [InlineData( "99999999999" )]
    [InlineData( "000.000.000-00" )]
    [InlineData( "111.111.111-11" )]
    [InlineData( "999.999.999-99" )]
    public void Validate_ShouldReturnFalse_ForRepeatedDigitsPatterns( string cpf )
    {
        IValidator validator = CpfFactory.CreateValidator();

        Assert.False( validator.IsValid( cpf ) );
    }

    [Fact]
    public void GenerateTest()
    {
        IGenerator generator = CpfFactory.CreateGenerator();
        IValidator validator = CpfFactory.CreateValidator();

        var cpf = generator.Generate();
        var cpfMasked = generator.Generate( true );

        Assert.True( validator.IsValid( cpf ) );
        Assert.True( validator.IsValid( cpfMasked ) );
    }

    [Fact]
    public void MaskedAndUnmasked_ShouldReturnCorrectFormats()
    {
        var cpf = new Cpf();
        cpf.Generate();

        var unmasked = cpf.Unmasked();
        var masked = cpf.Masked();

        Assert.Equal( 11, unmasked.Length );
        Assert.True( unmasked.All( char.IsDigit ) );
        Assert.Matches( @"^\d{3}\.\d{3}\.\d{3}-\d{2}$", masked );
    }

    [Fact]
    public void Metadata_BaseDigits_ShouldReturnFirst9Digits()
    {
        var cpf = new Cpf();
        cpf.Generate();

        ICpfMetadata metadata = cpf;

        Assert.Equal( 9, metadata.BaseDigits.Length );
        Assert.Equal( cpf.Unmasked()[ ..9 ], metadata.BaseDigits );
    }

    [Fact]
    public void Metadata_FirstVerifyingDigit_ShouldReturnDigitAtIndex9()
    {
        var cpf = new Cpf();
        cpf.Generate();

        ICpfMetadata metadata = cpf;

        Assert.Equal( cpf.Unmasked()[ 9 ].ToString(), metadata.FirstVerifyingDigit );
    }

    [Fact]
    public void Metadata_SecondVerifyingDigit_ShouldReturnDigitAtIndex10()
    {
        var cpf = new Cpf();
        cpf.Generate();

        ICpfMetadata metadata = cpf;

        Assert.Equal( cpf.Unmasked()[ 10 ].ToString(), metadata.SecondVerifyingDigit );
    }

    [Fact]
    public void Metadata_IssuingUnitDigit_ShouldReturnDigitAtIndex8()
    {
        var cpf = new Cpf();
        cpf.Generate();

        ICpfMetadata metadata = cpf;

        Assert.Equal( int.Parse( cpf.Unmasked()[ 8 ].ToString() ), metadata.IssuingUnitDigit );
    }

    [Fact]
    public void Metadata_IssuingStates_ShouldReturnNonEmptyList()
    {
        var cpf = new Cpf();
        cpf.Generate();

        ICpfMetadata metadata = cpf;

        Assert.NotEmpty( metadata.IssuingStates );
        Assert.All( metadata.IssuingStates, state => Assert.NotEmpty( state.Abbreviation ) );
    }
}
