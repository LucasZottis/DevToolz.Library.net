using System.Security.Cryptography;
using System.Text;

namespace DevToolz.Library.Encryption.Algorithms;

internal static class CryptStreamHelper
{
    internal static string Encrypt( SymmetricAlgorithm algorithm, string value )
    {
        var plainBytes = Encoding.UTF8.GetBytes( value );
        var encryptor  = algorithm.CreateEncryptor();

        using var memoryStream = new MemoryStream();
        using var cryptoStream = new CryptoStream( memoryStream, encryptor, CryptoStreamMode.Write );

        cryptoStream.Write( plainBytes, 0, plainBytes.Length );
        cryptoStream.FlushFinalBlock();

        return Convert.ToBase64String( memoryStream.ToArray() );
    }

    internal static string Decrypt( SymmetricAlgorithm algorithm, string value )
    {
        var cipherBytes = Convert.FromBase64String( value );
        var decryptor   = algorithm.CreateDecryptor();

        using var memoryStream = new MemoryStream( cipherBytes );
        using var cryptoStream = new CryptoStream( memoryStream, decryptor, CryptoStreamMode.Read );
        using var reader       = new StreamReader( cryptoStream, Encoding.UTF8 );

        return reader.ReadToEnd();
    }
}
