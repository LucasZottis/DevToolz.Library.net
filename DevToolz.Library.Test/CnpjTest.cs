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
        IGenerator generator = new Cnpj();
        IValidator validator = new Cnpj();

        var cnpj = generator.Generate();
        var cnpjMasked = generator.Generate( true );

        Assert.True( validator.IsValid( cnpj ) );
        Assert.True( validator.IsValid( cnpjMasked ) );
    }
}