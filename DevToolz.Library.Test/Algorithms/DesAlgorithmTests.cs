namespace DevToolz.Library.Test.Algorithms;

public class DesAlgorithmTests
{
    private ICryptAlgorithm Algorithm => CryptFactory.Create( CryptProvider.DES );

    [Fact]
    public void Encrypt_ThenDecrypt_ShouldReturnOriginalValue()
    {
        // Arrange
        var algorithm         = Algorithm;
        const string original = "Hello, DES!";
        const string key      = "mySecretKey";

        // Act
        string encrypted = algorithm.Encrypt( original, key );
        string decrypted = algorithm.Decrypt( encrypted, key );

        // Assert
        Assert.Equal( original, decrypted );
    }

    [Fact]
    public void Encrypt_ShouldReturnValidBase64()
    {
        // Act
        string encrypted = Algorithm.Encrypt( "test value", "key123" );

        // Assert — não deve lançar exceção
        byte[] bytes = Convert.FromBase64String( encrypted );
        Assert.NotEmpty( bytes );
    }

    [Fact]
    public void Encrypt_ShouldNotReturnPlaintext()
    {
        // Arrange
        const string original = "SensitiveData";

        // Act
        string encrypted = Algorithm.Encrypt( original, "key123" );

        // Assert
        Assert.NotEqual( original, encrypted );
    }

    [Fact]
    public void Encrypt_WithSameInputAndKey_ShouldBeDeterministic()
    {
        // Arrange
        var algorithm      = Algorithm;
        const string value = "determinism test";
        const string key   = "fixedKey";

        // Act
        string first  = algorithm.Encrypt( value, key );
        string second = algorithm.Encrypt( value, key );

        // Assert
        Assert.Equal( first, second );
    }

    [Fact]
    public void Encrypt_WithDifferentKeys_ShouldProduceDifferentCiphertext()
    {
        // Arrange
        var algorithm      = Algorithm;
        const string value = "SameData";

        // Act
        string enc1 = algorithm.Encrypt( value, "key1" );
        string enc2 = algorithm.Encrypt( value, "key2" );

        // Assert
        Assert.NotEqual( enc1, enc2 );
    }

    [Fact]
    public void Encrypt_ThenDecrypt_WithEmptyString_ShouldReturnEmptyString()
    {
        // Arrange
        var algorithm = Algorithm;

        // Act
        string encrypted = algorithm.Encrypt( string.Empty, "key" );
        string decrypted = algorithm.Decrypt( encrypted, "key" );

        // Assert
        Assert.Equal( string.Empty, decrypted );
    }

    [Fact]
    public void Encrypt_ThenDecrypt_WithUnicodeCharacters_ShouldReturnOriginalValue()
    {
        // Arrange
        var algorithm         = Algorithm;
        const string original = "Texto: ção, ã, é, ü, 中文, 日本語, 한국어";

        // Act
        string encrypted = algorithm.Encrypt( original, "unicodeKey" );
        string decrypted = algorithm.Decrypt( encrypted, "unicodeKey" );

        // Assert
        Assert.Equal( original, decrypted );
    }

    [Fact]
    public void Decrypt_WithWrongKey_ShouldThrowCryptographicException()
    {
        // Arrange
        var algorithm    = Algorithm;
        string encrypted = algorithm.Encrypt( "secret", "correctKey" );

        // Act & Assert
        Assert.Throws<CryptographicException>( () => algorithm.Decrypt( encrypted, "wrongKey" ) );
    }

    [Fact]
    public void Encrypt_WithNullValue_ShouldThrowArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>( () => Algorithm.Encrypt( null!, "key" ) );
    }

    [Fact]
    public void Encrypt_WithNullKey_ShouldThrowArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>( () => Algorithm.Encrypt( "value", null! ) );
    }

    [Fact]
    public void Decrypt_WithNullValue_ShouldThrowArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>( () => Algorithm.Decrypt( null!, "key" ) );
    }

    [Fact]
    public void Decrypt_WithNullKey_ShouldThrowArgumentNullException()
    {
        // Arrange
        string encrypted = Algorithm.Encrypt( "value", "key" );

        // Act & Assert
        Assert.Throws<ArgumentNullException>( () => Algorithm.Decrypt( encrypted, null! ) );
    }

    [Fact]
    public void Decrypt_WithInvalidBase64_ShouldThrowFormatException()
    {
        Assert.Throws<FormatException>( () => Algorithm.Decrypt( "!!!not-base64!!!", "key" ) );
    }

    [Fact]
    public void Encrypt_ThenDecrypt_WithEmptyKey_ShouldReturnOriginalValue()
    {
        // Arrange
        var algorithm         = Algorithm;
        const string original = "chave vazia é permitida";

        // Act
        string encrypted = algorithm.Encrypt( original, string.Empty );
        string decrypted = algorithm.Decrypt( encrypted, string.Empty );

        // Assert
        Assert.Equal( original, decrypted );
    }
}
