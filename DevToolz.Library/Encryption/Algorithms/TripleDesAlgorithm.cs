using System.Security.Cryptography;
using System.Text;
using DevToolz.Library.Encryption.Interfaces;

namespace DevToolz.Library.Encryption.Algorithms;

#pragma warning disable SYSLIB0022

internal sealed class TripleDesAlgorithm : ICryptAlgorithm
{
    public string Encrypt( string value, string key )
    {
        using var algorithm = new TripleDESCryptoServiceProvider { Mode = CipherMode.CBC, Padding = PaddingMode.PKCS7 };

        algorithm.Key = CryptKeyHelper.DeriveKeyBytes( key, 24 );
        algorithm.IV  = CryptKeyHelper.DeriveIVBytes( key, 8 );

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
        using var algorithm = new TripleDESCryptoServiceProvider { Mode = CipherMode.CBC, Padding = PaddingMode.PKCS7 };

        algorithm.Key = CryptKeyHelper.DeriveKeyBytes( key, 24 );
        algorithm.IV  = CryptKeyHelper.DeriveIVBytes( key, 8 );

        var cipherBytes = Convert.FromBase64String( value );
        var decryptor   = algorithm.CreateDecryptor();

        using var memoryStream = new MemoryStream( cipherBytes );
        using var cryptoStream = new CryptoStream( memoryStream, decryptor, CryptoStreamMode.Read );
        using var reader       = new StreamReader( cryptoStream, Encoding.UTF8 );

        return reader.ReadToEnd();
    }
}

#pragma warning restore SYSLIB0022
