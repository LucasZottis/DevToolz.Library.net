using DevToolz.Library.Encryption.Algorithms;
using DevToolz.Library.Encryption.Interfaces;

namespace DevToolz.Library.Encryption;

public static class CryptFactory
{
    internal const string DefaultKeySalt = "DevToolz.Crypt.Key";
    internal const string DefaultIVSalt  = "DevToolz.Crypt.IV";

    public static ICryptAlgorithm Create( CryptProvider provider ) =>
        Create( provider, DefaultKeySalt, DefaultIVSalt );

    public static ICryptAlgorithm Create( CryptProvider provider, string keySalt, string ivSalt ) =>
        provider switch
        {
            CryptProvider.Rijndael  => new RijndaelAlgorithm( keySalt, ivSalt ),
            CryptProvider.RC2       => new RC2Algorithm( keySalt, ivSalt ),
            CryptProvider.DES       => new DesAlgorithm( keySalt, ivSalt ),
            CryptProvider.TripleDES => new TripleDesAlgorithm( keySalt, ivSalt ),
            CryptProvider.Aes       => new AesAlgorithm( keySalt, ivSalt ),
            _                       => throw new NotSupportedException( $"CryptProvider '{provider}' não é suportado." )
        };
}
