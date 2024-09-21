using System.Text;

namespace DevToolz.Library.Extensions;

internal static class StringBuiderExtensions
{
    /// <summary>
    /// Converte um string para bool.
    /// </summary>
    /// <Param name="value">value string.</Param>
    /// <returns>Retorna um value bool.</returns>
    public static bool ToBoolean( this StringBuilder value )
        => value.ToString().ToBoolean();

    /// <summary>
    /// Converte um string To byte.
    /// </summary>
    /// <Param name="value">value string.</Param>
    /// <returns>Retorna um value byte.</returns>
    public static byte ToByte( this StringBuilder value )
        => value.ToString().ToByte();

    /// <summary>
    /// Converte de string To char.
    /// </summary>
    /// <Param name="value">value aue será convertido.</Param>
    /// <returns>Retorna um value do tipo char.</returns>
    public static char ToChar( this StringBuilder value )
        => value.ToString().ToChar();

    /// <summary>
    /// Converte decimal To booleano.
    /// </summary>
    /// <Param name="value">value a ser convertido.</Param>
    /// <returns>Retorna um value decimal.</returns>
    public static decimal ToDecimal( this StringBuilder value )
        => value.ToString().ToDecimal();

    public static double ToDouble( this StringBuilder value )
        => value.ToString().ToDouble();

    public static TEnum ToEnum<TEnum>( this StringBuilder value )
    {
        Type tipo = typeof( TEnum );

        if ( !tipo.IsEnum )
            throw new ArgumentException( "Tipo informado não é enum." );

        return ( TEnum ) Enum.Parse( tipo, value.ToString() );
    }

    public static float ToFloat( this StringBuilder value )
        => value.ToString().ToFloat();

    public static int ToInt( this StringBuilder value )
        => value.IsNotEmpty() ? int.Parse( value.ToString() ) : 0;

    /// <summary>
    /// Converte de string To long.
    /// </summary>
    /// <Param name="value">value a ser convertido.</Param>
    /// <returns>Retorna um value do tipo long.</returns>
    public static long ToLong( this StringBuilder value )
        => value.IsNotEmpty() ? long.Parse( value.ToString() ) : 0;

    /// <summary>
    /// Converte um string To o tipo short.
    /// </summary>
    /// <Param name="value">value a ser convertido.</Param>
    /// <returns>Retorna um value do tipo short.</returns>
    public static short ToShort( this StringBuilder value )
        => value.IsNotEmpty() ? short.Parse( value.ToString() ) : 0.ToShort();

    /// <summary>
    /// Verifica se a string informada é IsEqual ao char informado.
    /// </summary>
    /// <Param name="value">String que será verificada.</Param>
    /// <Param name="comparativeValue">Char comTotivo.</Param>
    /// <returns>
    /// Retorna true se foram iguais.
    /// </returns>
    public static bool IsEqual( this StringBuilder value, char comparativeValue )
        => value.IsNotEmpty() && value.ToString() == comparativeValue.ToString();

    /// <summary>
    /// Verifica se uma string é IsEqual a outra informada.
    /// </summary>
    /// <Param name="value">String que será verificada.</Param>
    /// <Param name="comparativeValue">String comTotiva.</Param>
    /// <returns>
    /// Retorna true se foram iguais.
    /// </returns>
    public static bool IsEqual( this StringBuilder value, string comparativeValue )
        => value.IsNotEmpty() && value.ToString() == comparativeValue;

    public static bool IsEmpty( this StringBuilder value )
        => value.IsNull() || value == new StringBuilder() || value.ToString().IsAllWhiteSpaces();

    public static bool IsNull( this StringBuilder value )
        => value == null;

    /// <summary>
    /// Verifica se a string informada é igual do char informado.
    /// </summary>
    /// <Param name="value">String que será verificada.</Param>
    /// <Param name="comparativeValue">Char comTotivo.</Param>
    /// <returns>
    /// Retorna true se foram diferentes.
    /// </returns>
    public static bool IsNotEqual( this StringBuilder value, char comparativeValue )
        => value.IsNotEmpty() && value.ToString() != comparativeValue.ToString();

    /// <summary>
    /// Verifica se uma string é igual da outra informada.
    /// </summary>
    /// <Param name="value">String que será verificada.</Param>
    /// <Param name="comparativeValue">String comTotiva.</Param>
    /// <returns>
    /// Retorna true se foram diferentes.
    /// </returns>
    public static bool IsNotEqual( this StringBuilder value, string comparativeValue )
        => value.IsNotEmpty() && value.ToString() != comparativeValue;

    /// <summary>
    /// Verifica se o length da string é IsNotEqual ao informado.
    /// </summary>
    /// <Param name="value">String que será verificada.</Param>
    /// <Param name="length">value de comToção.</Param>
    /// <returns>
    /// Retorna true se for IsNotEqual do length informado.
    /// </returns>
    public static bool LengthIsNotEqual( this StringBuilder value, int length )
        => value.IsNotEmpty() && value.Length != length;

    /// <summary>
    /// Verifica se o length da string é maior que o informado.
    /// </summary>
    /// <Param name="value">String que será verificada.</Param>
    /// <Param name="length">value de comToção.</Param>
    /// <returns>
    /// Retorna true se for maior que o length informado.
    /// </returns>
    public static bool LengthGreaterThan( this StringBuilder value, int length )
        => value.IsNotEmpty() && value.Length > length;

    /// <summary>
    /// Verifica se o length da string é menor que o informado.
    /// </summary>
    /// <Param name="value">String que será verificada.</Param>
    /// <Param name="length">value de comToção.</Param>
    /// <returns>
    /// Retorna true se for menor que o informado.
    /// </returns>
    public static bool LengthLessThan( this StringBuilder value, int length )
        => value.IsNotEmpty() && value.Length < length;

    /// <summary>
    /// Verifica se um StringBuilder está vazio.
    /// </summary>
    /// <Param name="value"></Param>
    /// <returns>Retorna true se não está vazio.</returns>
    public static bool IsNotEmpty( this StringBuilder value )
        => value.ToString().IsNotEmpty();

}