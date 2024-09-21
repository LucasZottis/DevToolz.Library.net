namespace DevToolz.Library.Test;

public class EmailTest
{
    [Fact]
    public void IsVald_EmailEmpty_ReturnsFalse()
    {
        // Arrange
        IValidator validator = new Email();

        // Assert
        Assert.False( validator.IsValid( string.Empty ) );
    }

    [Fact]
    public void IsVald_WrongEmail_ReturnsFalse()
    {
        // Arrange
        IValidator validator = new Email();

        // Assert
        Assert.False( validator.IsValid( "compras@miguelecalebelavanderiame.combr" ) );
    }

    [Fact]
    public void IsValid_EmailDomain_ReturnsTrue()
    {
        // Arrange
        IValidator validator = new Email();

        // Assert
        Assert.True( validator.IsValid( "compras@miguelecalebelavanderiame.com.br" ) );
    }
}