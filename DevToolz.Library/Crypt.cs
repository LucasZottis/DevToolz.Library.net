using DevToolz.Library.Encryption;
using DevToolz.Library.Encryption.Interfaces;

namespace DevToolz.Library;

public class Crypt
{
    private readonly ICryptAlgorithm? _algorithm;
    private readonly string           _keySalt;
    private readonly string           _ivSalt;

    public Crypt() : this( CryptFactory.DefaultKeySalt, CryptFactory.DefaultIVSalt ) { }

    public Crypt( string keySalt, string ivSalt )
    {
        _keySalt = keySalt;
        _ivSalt  = ivSalt;
    }

    /// <summary>
    /// Construtor para injeção de dependência. Quando fornecido, o algoritmo injetado
    /// é utilizado independentemente do <see cref="CryptProvider"/> passado nos métodos.
    /// </summary>
    public Crypt( ICryptAlgorithm algorithm )
    {
        _algorithm = algorithm ?? throw new ArgumentNullException( nameof( algorithm ) );
        _keySalt   = CryptFactory.DefaultKeySalt;
        _ivSalt    = CryptFactory.DefaultIVSalt;
    }

    /// <summary>
    /// Encripta o dado solicitado.
    /// </summary>
    /// <param name="value">Texto a ser criptografado.</param>
    /// <param name="key">Chave de criptografia.</param>
    /// <param name="provider">Algoritmo a ser utilizado.</param>
    /// <returns>Texto criptografado em Base64.</returns>
    public string Encrypt( string value, string key, CryptProvider provider )
    {
        var algorithm = _algorithm ?? CryptFactory.Create( provider, _keySalt, _ivSalt );
        return algorithm.Encrypt( value, key );
    }

    /// <summary>
    /// Desencripta o dado solicitado.
    /// </summary>
    /// <param name="value">Texto em Base64 a ser descriptografado.</param>
    /// <param name="key">Chave de criptografia.</param>
    /// <param name="provider">Algoritmo a ser utilizado.</param>
    /// <returns>Texto descriptografado.</returns>
    public string Decrypt( string value, string key, CryptProvider provider )
    {
        var algorithm = _algorithm ?? CryptFactory.Create( provider, _keySalt, _ivSalt );
        return algorithm.Decrypt( value, key );
    }
}
