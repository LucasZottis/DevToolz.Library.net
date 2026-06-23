using System.Security.Cryptography;
using DevToolz.Library.Encryption.Interfaces;

namespace DevToolz.Library.Encryption.Algorithms;

#pragma warning disable SYSLIB0022

internal sealed class DesAlgorithm : ICryptAlgorithm
{
    private readonly string _keySalt;
    private readonly string _ivSalt;

    internal DesAlgorithm( string keySalt, string ivSalt )
    {
        _keySalt = keySalt;
        _ivSalt  = ivSalt;
    }

    public string Encrypt( string value, string key )
    {
        using var algorithm = new DESCryptoServiceProvider { Mode = CipherMode.CBC, Padding = PaddingMode.PKCS7 };

        algorithm.Key = CryptKeyHelper.DeriveKeyBytes( key, 8, _keySalt );
        algorithm.IV  = CryptKeyHelper.DeriveIVBytes( key, 8, _ivSalt );

        return CryptStreamHelper.Encrypt( algorithm, value );
    }

    public string Decrypt( string value, string key )
    {
        try
        {
            return DecryptCurrent( value, key );
        }
        catch ( CryptographicException )
        {
            return DecryptLegacy( value, key );
        }
    }

    private string DecryptCurrent( string value, string key )
    {
        using var algorithm = new DESCryptoServiceProvider { Mode = CipherMode.CBC, Padding = PaddingMode.PKCS7 };

        algorithm.Key = CryptKeyHelper.DeriveKeyBytes( key, 8, _keySalt );
        algorithm.IV  = CryptKeyHelper.DeriveIVBytes( key, 8, _ivSalt );

        return CryptStreamHelper.Decrypt( algorithm, value );
    }

    private string DecryptLegacy( string value, string key )
    {
        using var algorithm = new DESCryptoServiceProvider { Mode = CipherMode.CBC, Padding = PaddingMode.PKCS7 };

        algorithm.Key = CryptKeyHelper.DeriveLegacyKeyBytes( algorithm, key );
        algorithm.IV  = CryptKeyHelper.LegacyIV8;

        return CryptStreamHelper.Decrypt( algorithm, value );
    }
}

#pragma warning restore SYSLIB0022
