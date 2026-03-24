using DevToolz.Library.Interfaces;

namespace DevToolz.Library.Test;

public class CpfTest
{
    [Fact]
    public void ValidateTest()
    {
        IValidator validator = new Cpf();
        IGenerator generator = new Cpf();

        Assert.True( validator.IsValid( "816.784.690-33" ) );
        Assert.True( validator.IsValid( "38235836033" ) );
        Assert.False( validator.IsValid( "997.918.830-85" ) );
        Assert.False( validator.IsValid( "41916364056" ) );

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
        IValidator validator = new Cpf();

        Assert.False( validator.IsValid( cpf ) );
    }

    [Fact]
    public void GenerateTest()
    {
        IGenerator generator = new Cpf();
        IValidator validator = new Cpf();

        var cpf = generator.Generate();
        var cpfMasked = generator.Generate( true );

        Assert.True( validator.IsValid( cpf ) );
        Assert.True( validator.IsValid( cpfMasked ) );
    }
}