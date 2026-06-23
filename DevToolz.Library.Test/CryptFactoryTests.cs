namespace DevToolz.Library.Test;

public class CryptFactoryTests
{
    [Theory]
    [InlineData( CryptProvider.Rijndael )]
    [InlineData( CryptProvider.RC2 )]
    [InlineData( CryptProvider.DES )]
    [InlineData( CryptProvider.TripleDES )]
    [InlineData( CryptProvider.Aes )]
    public void Create_ShouldReturnNonNullAlgorithm( CryptProvider provider )
    {
        // Act
        ICryptAlgorithm algorithm = CryptFactory.Create( provider );

        // Assert
        Assert.NotNull( algorithm );
    }

    [Theory]
    [InlineData( CryptProvider.Rijndael )]
    [InlineData( CryptProvider.RC2 )]
    [InlineData( CryptProvider.DES )]
    [InlineData( CryptProvider.TripleDES )]
    [InlineData( CryptProvider.Aes )]
    public void Create_CalledTwice_ShouldReturnDistinctInstances( CryptProvider provider )
    {
        // Act
        ICryptAlgorithm first  = CryptFactory.Create( provider );
        ICryptAlgorithm second = CryptFactory.Create( provider );

        // Assert
        Assert.NotSame( first, second );
    }

    [Theory]
    [InlineData( CryptProvider.Rijndael )]
    [InlineData( CryptProvider.RC2 )]
    [InlineData( CryptProvider.DES )]
    [InlineData( CryptProvider.TripleDES )]
    [InlineData( CryptProvider.Aes )]
    public void Create_ShouldReturnFunctionalAlgorithm( CryptProvider provider )
    {
        // Arrange
        ICryptAlgorithm algorithm = CryptFactory.Create( provider );
        const string original     = "factory functional test";
        const string key          = "testKey";

        // Act
        string encrypted = algorithm.Encrypt( original, key );
        string decrypted = algorithm.Decrypt( encrypted, key );

        // Assert
        Assert.Equal( original, decrypted );
    }

    [Fact]
    public void Create_WithUnsupportedProvider_ShouldThrowNotSupportedException()
    {
        // Act & Assert
        Assert.Throws<NotSupportedException>( () => CryptFactory.Create( (CryptProvider) 999 ) );
    }
}
