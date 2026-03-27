using System.Security.Cryptography;
using System.Text;

namespace DevToolz.Library.Crypt.Algorithms;

internal static class CryptKeyHelper
{
    private static readonly byte[] KeySalt = Encoding.ASCII.GetBytes( "DevToolz.Crypt.Key" );
    private static readonly byte[] IVSalt  = Encoding.ASCII.GetBytes( "DevToolz.Crypt.IV" );

    private const int Iterations = 1000;

    internal static byte[] DeriveKeyBytes( string password, int byteCount )
    {
        using var pbkdf2 = new Rfc2898DeriveBytes(
            password,
            KeySalt,
            Iterations,
            HashAlgorithmName.SHA256 );
        return pbkdf2.GetBytes( byteCount );
    }

    internal static byte[] DeriveIVBytes( string password, int byteCount )
    {
        using var pbkdf2 = new Rfc2898DeriveBytes(
            password,
            IVSalt,
            Iterations,
            HashAlgorithmName.SHA256 );
        return pbkdf2.GetBytes( byteCount );
    }
}
