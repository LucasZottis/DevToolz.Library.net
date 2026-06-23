using System.Security.Cryptography;
using System.Text;

namespace DevToolz.Library.Encryption.Algorithms;

#pragma warning disable SYSLIB0041

internal static class CryptKeyHelper
{
    internal static readonly byte[] LegacyIV8  = [0xf, 0x6f, 0x13, 0x2e, 0x35, 0xc2, 0xcd, 0xf9];
    internal static readonly byte[] LegacyIV16 = [0xf, 0x6f, 0x13, 0x2e, 0x35, 0xc2, 0xcd, 0xf9, 0x5, 0x46, 0x9c, 0xea, 0xa8, 0x4b, 0x73, 0xcc];

    private const int Iterations = 1000;

    internal static byte[] DeriveKeyBytes( string password, int byteCount, string salt )
    {
        using var pbkdf2 = new Rfc2898DeriveBytes(
            password,
            Encoding.ASCII.GetBytes( salt ),
            Iterations,
            HashAlgorithmName.SHA256 );
        return pbkdf2.GetBytes( byteCount );
    }

    internal static byte[] DeriveIVBytes( string password, int byteCount, string salt )
    {
        using var pbkdf2 = new Rfc2898DeriveBytes(
            password,
            Encoding.ASCII.GetBytes( salt ),
            Iterations,
            HashAlgorithmName.SHA256 );
        return pbkdf2.GetBytes( byteCount );
    }

    internal static byte[] DeriveLegacyKeyBytes( SymmetricAlgorithm algorithm, string key )
    {
        if ( algorithm.LegalKeySizes.Length > 0 )
        {
            int keySize  = key.Length * 8;
            int minSize  = algorithm.LegalKeySizes[ 0 ].MinSize;
            int maxSize  = algorithm.LegalKeySizes[ 0 ].MaxSize;
            int skipSize = algorithm.LegalKeySizes[ 0 ].SkipSize;

            if ( keySize > maxSize )
                key = key[ ..( maxSize / 8 ) ];
            else if ( keySize < maxSize )
            {
                int validSize = keySize <= minSize ? minSize : keySize - keySize % skipSize + skipSize;
                if ( keySize < validSize )
                    key = key.PadRight( validSize / 8, '*' );
            }
        }

        var keyBytes = new PasswordDeriveBytes( key, Encoding.ASCII.GetBytes( string.Empty ) );
        return keyBytes.GetBytes( key.Length );
    }
}

#pragma warning restore SYSLIB0041
