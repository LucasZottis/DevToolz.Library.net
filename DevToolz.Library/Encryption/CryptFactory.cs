using DevToolz.Library.Encryption.Algorithms;
using DevToolz.Library.Encryption.Interfaces;

namespace DevToolz.Library.Encryption;

public static class CryptFactory
{
    public static ICryptAlgorithm Create( CryptProvider provider ) => provider switch
    {
        CryptProvider.Rijndael  => new RijndaelAlgorithm(),
        CryptProvider.RC2       => new RC2Algorithm(),
        CryptProvider.DES       => new DesAlgorithm(),
        CryptProvider.TripleDES => new TripleDesAlgorithm(),
        CryptProvider.Aes       => new AesAlgorithm(),
        _                       => throw new NotSupportedException( $"CryptProvider '{provider}' não é suportado." )
    };
}
