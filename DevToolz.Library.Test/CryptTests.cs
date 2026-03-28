using System.Security.Cryptography;
using DevToolz.Library.Encryption;
using DevToolz.Library.Encryption.Interfaces;

namespace DevToolz.Library.Test;

public class CryptTests
{
    [Theory]
    [InlineData( CryptProvider.Rijndael )]
    [InlineData( CryptProvider.RC2 )]
    [InlineData( CryptProvider.DES )]
    [InlineData( CryptProvider.TripleDES )]
    [InlineData( CryptProvider.Aes )]
    public void Encrypt_ThenDecrypt_ShouldReturnOriginalValue( CryptProvider provider )
    {
        // Arrange
        var crypt = new Crypt();
        const string original = "Hello, DevToolz!";
        const string key      = "mySecretKey";

        // Act
        string encrypted = crypt.Encrypt( original, key, provider );
        string decrypted = crypt.Decrypt( encrypted, key, provider );

        // Assert
        Assert.Equal( original, decrypted );
    }

    [Theory]
    [InlineData( CryptProvider.Rijndael )]
    [InlineData( CryptProvider.RC2 )]
    [InlineData( CryptProvider.DES )]
    [InlineData( CryptProvider.TripleDES )]
    [InlineData( CryptProvider.Aes )]
    public void Encrypt_ShouldReturnValidBase64( CryptProvider provider )
    {
        // Arrange
        var crypt = new Crypt();

        // Act
        string encrypted = crypt.Encrypt( "test value", "key123", provider );

        // Assert — não deve lançar exceção
        var bytes = Convert.FromBase64String( encrypted );
        Assert.NotEmpty( bytes );
    }

    [Theory]
    [InlineData( CryptProvider.Rijndael )]
    [InlineData( CryptProvider.RC2 )]
    [InlineData( CryptProvider.DES )]
    [InlineData( CryptProvider.TripleDES )]
    [InlineData( CryptProvider.Aes )]
    public void Encrypt_ShouldNotReturnPlaintext( CryptProvider provider )
    {
        // Arrange
        var crypt = new Crypt();
        const string original = "SensitiveData";

        // Act
        string encrypted = crypt.Encrypt( original, "key123", provider );

        // Assert
        Assert.NotEqual( original, encrypted );
    }

    [Theory]
    [InlineData( CryptProvider.Rijndael )]
    [InlineData( CryptProvider.Aes )]
    public void Encrypt_WithDifferentKeys_ShouldProduceDifferentCiphertext( CryptProvider provider )
    {
        // Arrange
        var crypt = new Crypt();
        const string value = "SameData";

        // Act
        string enc1 = crypt.Encrypt( value, "key1", provider );
        string enc2 = crypt.Encrypt( value, "key2", provider );

        // Assert
        Assert.NotEqual( enc1, enc2 );
    }

    [Theory]
    [InlineData( CryptProvider.Rijndael )]
    [InlineData( CryptProvider.RC2 )]
    [InlineData( CryptProvider.DES )]
    [InlineData( CryptProvider.TripleDES )]
    [InlineData( CryptProvider.Aes )]
    public void Decrypt_WithWrongKey_ShouldThrowCryptographicException( CryptProvider provider )
    {
        // Arrange
        var crypt = new Crypt();
        string encrypted = crypt.Encrypt( "secret", "correctKey", provider );

        // Act & Assert
        Assert.Throws<CryptographicException>(
            () => crypt.Decrypt( encrypted, "wrongKey", provider ) );
    }

    [Fact]
    public void Constructor_WithNullAlgorithm_ShouldThrowArgumentNullException()
    {
        // Act & Assert
        Assert.Throws<ArgumentNullException>( () => new Crypt( null! ) );
    }

    [Fact]
    public void Constructor_WithInjectedAlgorithm_ShouldUseItForEncryptDecrypt()
    {
        // Arrange
        ICryptAlgorithm algorithm = CryptFactory.Create( CryptProvider.Aes );
        var crypt = new Crypt( algorithm );
        const string original = "Injected algorithm test";
        const string key      = "injectionKey";

        // Act — provider passado é ignorado pois o algoritmo foi injetado
        string encrypted = crypt.Encrypt( original, key, CryptProvider.DES );
        string decrypted = crypt.Decrypt( encrypted, key, CryptProvider.DES );

        // Assert
        Assert.Equal( original, decrypted );
    }

    [Fact]
    public void Aes_Encrypt_ThenDecrypt_WithLongKey_ShouldReturnOriginalValue()
    {
        // Arrange
        var crypt = new Crypt();
        const string value = "AES rocks with a 256-bit key!";
        const string key   = "this-is-a-very-long-passphrase-for-aes-256";

        // Act
        string encrypted = crypt.Encrypt( value, key, CryptProvider.Aes );
        string decrypted = crypt.Decrypt( encrypted, key, CryptProvider.Aes );

        // Assert
        Assert.Equal( value, decrypted );
    }

    [Theory]
    [InlineData( CryptProvider.Rijndael )]
    [InlineData( CryptProvider.RC2 )]
    [InlineData( CryptProvider.DES )]
    [InlineData( CryptProvider.TripleDES )]
    [InlineData( CryptProvider.Aes )]
    public void CryptFactory_Create_ShouldReturnNonNullAlgorithm( CryptProvider provider )
    {
        // Act
        ICryptAlgorithm algorithm = CryptFactory.Create( provider );

        // Assert
        Assert.NotNull( algorithm );
    }
}
