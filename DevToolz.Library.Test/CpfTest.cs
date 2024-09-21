using DevToolz.Library.Interfaces;

namespace DevToolz.Library.Test;

public class CpfTest
{
    [Fact]
    public void ValidateTest()
    {
        IValidator validator = new Cpf();

        Assert.True( validator.IsValid( "816.784.690-33" ) );
        Assert.True( validator.IsValid( "38235836033" ) );
        Assert.False( validator.IsValid( "997.918.830-85" ) );
        Assert.False( validator.IsValid( "41916364056" ) );
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