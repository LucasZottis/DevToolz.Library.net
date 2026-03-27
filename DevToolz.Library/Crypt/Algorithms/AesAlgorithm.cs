using System.Security.Cryptography;
using System.Text;
using DevToolz.Library.Crypt.Interfaces;

namespace DevToolz.Library.Crypt.Algorithms;

internal sealed class AesAlgorithm : ICryptAlgorithm
{
    public string Encrypt( string value, string key )
    {
        using var algorithm = System.Security.Cryptography.Aes.Create();

        algorithm.Mode    = CipherMode.CBC;
        algorithm.Padding = PaddingMode.PKCS7;
        algorithm.KeySize = 256;
        algorithm.Key     = CryptKeyHelper.DeriveKeyBytes( key, 32 );
        algorithm.IV      = CryptKeyHelper.DeriveIVBytes( key, 16 );

        var plainBytes = Encoding.UTF8.GetBytes( value );
        var encryptor  = algorithm.CreateEncryptor();

        using var memoryStream = new MemoryStream();
        using var cryptoStream = new CryptoStream( memoryStream, encryptor, CryptoStreamMode.Write );

        cryptoStream.Write( plainBytes, 0, plainBytes.Length );
        cryptoStream.FlushFinalBlock();

        return Convert.ToBase64String( memoryStream.ToArray() );
    }

    public string Decrypt( string value, string key )
    {
        using var algorithm = System.Security.Cryptography.Aes.Create();

        algorithm.Mode    = CipherMode.CBC;
        algorithm.Padding = PaddingMode.PKCS7;
        algorithm.KeySize = 256;
        algorithm.Key     = CryptKeyHelper.DeriveKeyBytes( key, 32 );
        algorithm.IV      = CryptKeyHelper.DeriveIVBytes( key, 16 );

        var cipherBytes = Convert.FromBase64String( value );
        var decryptor   = algorithm.CreateDecryptor();

        using var memoryStream = new MemoryStream( cipherBytes );
        using var cryptoStream = new CryptoStream( memoryStream, decryptor, CryptoStreamMode.Read );
        using var reader       = new StreamReader( cryptoStream, Encoding.UTF8 );

        return reader.ReadToEnd();
    }
}
