namespace DevToolz.Library.Extensions;

/// <summary>
/// Extensões de conversão entre sistemas numéricos para o tipo int.
/// </summary>
public static class IntNumericSystemExtensions
{
    /// <summary>
    /// Converte um número decimal (int) para binário.
    /// </summary>
    /// <param name="value">Valor decimal a ser convertido.</param>
    /// <returns>Retorna a representação binária do número como string.</returns>
    public static string ToBinary( this int value )
        => Convert.ToString( value, 2 );

    /// <summary>
    /// Converte um número decimal (int) para octal.
    /// </summary>
    /// <param name="value">Valor decimal a ser convertido.</param>
    /// <returns>Retorna a representação octal do número como string.</returns>
    public static string ToOctal( this int value )
        => Convert.ToString( value, 8 );

    /// <summary>
    /// Converte um número decimal (int) para hexadecimal.
    /// </summary>
    /// <param name="value">Valor decimal a ser convertido.</param>
    /// <returns>Retorna a representação hexadecimal do número como string.</returns>
    public static string ToHexadecimal( this int value )
        => Convert.ToString( value, 16 ).ToUpper();
}

/// <summary>
/// Extensões de conversão entre sistemas numéricos para o tipo long.
/// </summary>
public static class LongNumericSystemExtensions
{
    /// <summary>
    /// Converte um número decimal (long) para binário.
    /// </summary>
    /// <param name="value">Valor decimal a ser convertido.</param>
    /// <returns>Retorna a representação binária do número como string.</returns>
    public static string ToBinary( this long value )
        => Convert.ToString( value, 2 );

    /// <summary>
    /// Converte um número decimal (long) para octal.
    /// </summary>
    /// <param name="value">Valor decimal a ser convertido.</param>
    /// <returns>Retorna a representação octal do número como string.</returns>
    public static string ToOctal( this long value )
        => Convert.ToString( value, 8 );

    /// <summary>
    /// Converte um número decimal (long) para hexadecimal.
    /// </summary>
    /// <param name="value">Valor decimal a ser convertido.</param>
    /// <returns>Retorna a representação hexadecimal do número como string.</returns>
    public static string ToHexadecimal( this long value )
        => Convert.ToString( value, 16 ).ToUpper();
}

/// <summary>
/// Extensões de conversão entre sistemas numéricos para o tipo string.
/// </summary>
public static class StringNumericSystemExtensions
{
    /// <summary>
    /// Converte uma string binária para decimal.
    /// </summary>
    /// <param name="value">String binária a ser convertida.</param>
    /// <returns>Retorna o valor decimal equivalente.</returns>
    public static int BinaryToDecimal( this string value )
        => Convert.ToInt32( value, 2 );

    /// <summary>
    /// Converte uma string binária para octal.
    /// </summary>
    /// <param name="value">String binária a ser convertida.</param>
    /// <returns>Retorna a representação octal como string.</returns>
    public static string BinaryToOctal( this string value )
        => Convert.ToInt32( value, 2 ).ToOctal();

    /// <summary>
    /// Converte uma string binária para hexadecimal.
    /// </summary>
    /// <param name="value">String binária a ser convertida.</param>
    /// <returns>Retorna a representação hexadecimal como string.</returns>
    public static string BinaryToHexadecimal( this string value )
        => Convert.ToInt32( value, 2 ).ToHexadecimal();

    /// <summary>
    /// Converte uma string octal para decimal.
    /// </summary>
    /// <param name="value">String octal a ser convertida.</param>
    /// <returns>Retorna o valor decimal equivalente.</returns>
    public static int OctalToDecimal( this string value )
        => Convert.ToInt32( value, 8 );

    /// <summary>
    /// Converte uma string octal para binário.
    /// </summary>
    /// <param name="value">String octal a ser convertida.</param>
    /// <returns>Retorna a representação binária como string.</returns>
    public static string OctalToBinary( this string value )
        => Convert.ToInt32( value, 8 ).ToBinary();

    /// <summary>
    /// Converte uma string octal para hexadecimal.
    /// </summary>
    /// <param name="value">String octal a ser convertida.</param>
    /// <returns>Retorna a representação hexadecimal como string.</returns>
    public static string OctalToHexadecimal( this string value )
        => Convert.ToInt32( value, 8 ).ToHexadecimal();

    /// <summary>
    /// Converte uma string hexadecimal para decimal.
    /// </summary>
    /// <param name="value">String hexadecimal a ser convertida.</param>
    /// <returns>Retorna o valor decimal equivalente.</returns>
    public static int HexadecimalToDecimal( this string value )
        => Convert.ToInt32( value, 16 );

    /// <summary>
    /// Converte uma string hexadecimal para binário.
    /// </summary>
    /// <param name="value">String hexadecimal a ser convertida.</param>
    /// <returns>Retorna a representação binária como string.</returns>
    public static string HexadecimalToBinary( this string value )
        => Convert.ToInt32( value, 16 ).ToBinary();

    /// <summary>
    /// Converte uma string hexadecimal para octal.
    /// </summary>
    /// <param name="value">String hexadecimal a ser convertida.</param>
    /// <returns>Retorna a representação octal como string.</returns>
    public static string HexadecimalToOctal( this string value )
        => Convert.ToInt32( value, 16 ).ToOctal();
}
