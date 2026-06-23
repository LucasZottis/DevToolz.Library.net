using System.Security.Cryptography;
using DevToolz.Library.Encryption.Interfaces;

namespace DevToolz.Library.Encryption.Algorithms;

internal sealed class AesAlgorithm : ICryptAlgorithm
{
    private readonly string _keySalt;
    private readonly string _ivSalt;

    internal AesAlgorithm( string keySalt, string ivSalt )
    {
        _keySalt = keySalt;
        _ivSalt  = ivSalt;
    }

    public string Encrypt( string value, string key )
    {
        using var algorithm = System.Security.Cryptography.Aes.Create();

        algorithm.Mode    = CipherMode.CBC;
        algorithm.Padding = PaddingMode.PKCS7;
        algorithm.KeySize = 256;
        algorithm.Key     = CryptKeyHelper.DeriveKeyBytes( key, 32, _keySalt );
        algorithm.IV      = CryptKeyHelper.DeriveIVBytes( key, 16, _ivSalt );

        return CryptStreamHelper.Encrypt( algorithm, value );
    }

    public string Decrypt( string value, string key )
    {
        using var algorithm = System.Security.Cryptography.Aes.Create();

        algorithm.Mode    = CipherMode.CBC;
        algorithm.Padding = PaddingMode.PKCS7;
        algorithm.KeySize = 256;
        algorithm.Key     = CryptKeyHelper.DeriveKeyBytes( key, 32, _keySalt );
        algorithm.IV      = CryptKeyHelper.DeriveIVBytes( key, 16, _ivSalt );

        return CryptStreamHelper.Decrypt( algorithm, value );
    }
}
