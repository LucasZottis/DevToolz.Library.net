using DevToolz.Library.Interfaces;

namespace DevToolz.Library.Test;

public class CnpjTest
{
    [Fact]
    public void ValidateTest()
    {
        IValidator validator = new Cnpj();
        IGenerator generator = new Cnpj();

        Assert.True( validator.IsValid( "72.799.201/0001-01" ) );
        Assert.True( validator.IsValid( "28777566000143" ) );
        Assert.False( validator.IsValid( "50.523.085/0001-61" ) );
        Assert.False( validator.IsValid( "41909961000100" ) );

        Assert.True( validator.IsValid( generator.Generate() ) );
        Assert.True( validator.IsValid( generator.Generate( true ) ) );
    }

    [Fact]
    public void GenerateTest()
    {
        IGenerator generator = new Cnpj();
        IValidator validator = new Cnpj();

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
    [InlineData( "99999999999999" )]
    public void Validate_ShouldBeFalse_WhenCnpjHasRepeatedDigits( string value )
    {
        IValidator validator = new Cnpj();

        Assert.False( validator.IsValid( value ) );
    }
}
