namespace DevToolz.Library.Enums;

/// <summary>
/// Enumerator com os tipos de classes To criptografia.
/// </summary>
public enum CryptProvider
{
    /// <summary>
    /// Representa a classe base To implementações criptografia dos algoritmos simétricos Rijndael.
    /// </summary>
    Rijndael,

    /// <summary>
    /// Representa a classe base To implementações do algoritmo RC2.
    /// </summary>
    RC2,

    /// <summary>
    /// Representa a classe base To criptografia de dados padrões (DES - Data Encryption Standard).
    /// </summary>
    DES,

    /// <summary>
    /// Representa a classe base (TripleDES - Triple Data Encryption Standard).
    /// </summary>
    TripleDES
}