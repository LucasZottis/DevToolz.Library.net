using DevToolz.Library.Crypt;
using DevToolz.Library.Crypt.Interfaces;

namespace DevToolz.Library;

public class Crypt
{
    private readonly ICryptAlgorithm? _algorithm;

    public Crypt() { }

    /// <summary>
    /// Construtor para injeção de dependência. Quando fornecido, o algoritmo injetado
    /// é utilizado independentemente do <see cref="CryptProvider"/> passado nos métodos.
    /// </summary>
    public Crypt( ICryptAlgorithm algorithm )
    {
        _algorithm = algorithm ?? throw new ArgumentNullException( nameof( algorithm ) );
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
        var algorithm = _algorithm ?? CryptFactory.Create( provider );
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
        var algorithm = _algorithm ?? CryptFactory.Create( provider );
        return algorithm.Decrypt( value, key );
    }
}
