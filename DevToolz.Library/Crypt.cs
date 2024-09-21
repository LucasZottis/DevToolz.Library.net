using System.Security.Cryptography;
using System.Text;

namespace DevToolz.Library;

public class Crypt
{
    /// <summary>
    /// Inicialização do vetor do algoritmo simétrico
    /// </summary>
    private byte[] GetIV( CryptProvider cryptProvider )
    {
        switch ( cryptProvider )
        {
            case CryptProvider.Rijndael:
                return [0xf, 0x6f, 0x13, 0x2e, 0x35, 0xc2, 0xcd, 0xf9, 0x5, 0x46, 0x9c, 0xea, 0xa8, 0x4b, 0x73, 0xcc];
            default:
                return [0xf, 0x6f, 0x13, 0x2e, 0x35, 0xc2, 0xcd, 0xf9];
        }
    }

    private SymmetricAlgorithm GetAlgorithm( CryptProvider provide )
    {
        SymmetricAlgorithm algorithm = null;

        // Seleciona algoritmo simétrico
        switch ( provide )
        {
            case CryptProvider.Rijndael:
                algorithm = new RijndaelManaged();
                break;
            case CryptProvider.RC2:
                algorithm = new RC2CryptoServiceProvider();
                break;
            case CryptProvider.DES:
                algorithm = new DESCryptoServiceProvider();
                break;
            case CryptProvider.TripleDES:
                algorithm = new TripleDESCryptoServiceProvider();
                break;
        }

        algorithm.Mode = CipherMode.CBC;

        return algorithm;
    }

    /// <summary>
    /// Gera a chave de criptografia válida dentro do array.
    /// </summary>
    /// <returns>Chave com array de bytes.</returns>
    private byte[] GetKeyBytes( SymmetricAlgorithm algorithm, string key )
    {
        var salt = string.Empty;

        // Ajusta o tamanho da chave se necessário e retorna uma chave válida
        if ( algorithm.LegalKeySizes.Length > 0 )
        {
            // Tamanho das chaves em bits
            int keySize = key.Length * 8;
            int minSize = algorithm.LegalKeySizes[ 0 ].MinSize;
            int maxSize = algorithm.LegalKeySizes[ 0 ].MaxSize;
            int skipSize = algorithm.LegalKeySizes[ 0 ].SkipSize;

            if ( keySize > maxSize )
                // Busca o valor máximo da chave
                key = key.Substring( 0, maxSize / 8 );
            else if ( keySize < maxSize )
            {
                // Seta um tamanho válido
                int validSize = keySize <= minSize ? minSize : keySize - keySize % skipSize + skipSize;

                if ( keySize < validSize )
                    // Preenche a chave com arterisco To corrigir o tamanho
                    key = key.PadRight( validSize / 8, '*' );
            }
        }

        var keyBytes = new PasswordDeriveBytes( key, Encoding.ASCII.GetBytes( salt ) );

        return keyBytes.GetBytes( key.Length );
    }

    /// <summary>
    /// Encripta o dado solicitado.
    /// </summary>
    /// <Param name="plainText">Texto a ser criptografado.</Param>
    /// <returns>Texto criptografado.</returns>
    public string Encrypt( string value, string key, CryptProvider provider )
    {
        var algorithm = GetAlgorithm( provider );
        var plainByte = Encoding.UTF8.GetBytes( value );
        var keyByte = GetKeyBytes( algorithm, key );

        // Seta a chave privada
        algorithm.Key = keyByte;
        algorithm.IV = GetIV( provider );

        // Interface de criptografia / Cria objeto de criptografia
        var cryptoTransform = algorithm.CreateEncryptor();
        var memoryStream = new MemoryStream();
        var cryptoStream = new CryptoStream( memoryStream, cryptoTransform, CryptoStreamMode.Write );

        // Grava os dados criptografados no MemoryStream
        cryptoStream.Write( plainByte, 0, plainByte.Length );
        cryptoStream.FlushFinalBlock();

        // Busca o tamanho dos bytes encriptados
        var cryptoByte = memoryStream.ToArray();

        // Converte To a base 64 string To uso posterior em um xml
        return Convert.ToBase64String( cryptoByte, 0, cryptoByte.GetLength( 0 ) );
    }

    /// <summary>
    /// Desencripta o dado solicitado.
    /// </summary>
    /// <Param name="cryptoText">Texto a ser descriptografado.</Param>
    /// <returns>Texto descriptografado.</returns>
    public string Decrypt( string value, string key, CryptProvider provider )
    {
        var algorithm = GetAlgorithm( provider );

        // Converte a base 64 string em num array de bytes
        byte[] cryptoByte = Convert.FromBase64String( value );
        byte[] keyByte = GetKeyBytes( algorithm, key );

        // Seta a chave privada
        algorithm.Key = keyByte;
        algorithm.IV = GetIV( provider );

        // Interface de criptografia / Cria objeto de descriptografia
        var cryptoTransform = algorithm.CreateDecryptor();

        try
        {
            var memoryStream = new MemoryStream( cryptoByte, 0, cryptoByte.Length );
            var cryptoStream = new CryptoStream( memoryStream, cryptoTransform, CryptoStreamMode.Read );

            // Busca resultado do CryptoStream
            var streamReader = new StreamReader( cryptoStream );

            return streamReader.ReadToEnd();
        }
        catch
        {
            return null;
        }
    }
}