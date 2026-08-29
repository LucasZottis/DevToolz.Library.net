using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace DevToolz.Library.Extensions;

public static class StringExtensions
{
    public static readonly char[] SpecialCharacters = new char[] { '/', '*', '-', '+', ',', '.', '!', '@', '#', '$', '%', '¬', '&', '(', ')', '_', '+', '\\', '|', '[', ']', '{', '}', ';', ':', '<', '>' };

    /// <summary>
    /// Método que verifica se um string está vazio.
    /// </summary>
    /// <Param name="value">Valor que será verificado.</Param>
    /// <returns>Retorna true se estiver nulo, vazio ou tem apenas espaços.</returns>
    public static bool IsEmpty( [NotNullWhen( false )] this string? value )
        => value.IsNull() || value == string.Empty || value.IsAllWhiteSpaces();

    /// <summary>
    /// Método que verifica se um string está vazio.
    /// </summary>
    /// <Param name="values">Vetor com cadeias de caracteres que serão verificados.</Param>
    /// <returns>Retorna true se estiver nulo, vazio ou tem apenas espaços.</returns>
    public static bool IsEmpty( [NotNullWhen( false )] this string[]? values )
    {
        if ( values!.Length == 0 )
            return true;

        foreach ( string value in values )
            if ( value.IsEmpty() )
                return true;

        return false;
    }

    /// <summary>
    /// Verifica se a string informada é IsEqual ao char informado.
    /// </summary>
    /// <Param name="value">String que será verificada.</Param>
    /// <Param name="caractere">Char comTotivo.</Param>
    /// <returns>
    /// Retorna true se foram iguais.
    /// </returns>
    public static bool IsEqual( this string value, char caractere )
        => value.IsNotEmpty() && value == caractere.ToString();

    /// <summary>
    /// Verifica se uma string é IsEqual a outra informada.
    /// </summary>
    /// <Param name="value">String que será verificada.</Param>
    /// <Param name="cadeiaCaracteres">String comTotiva.</Param>
    /// <returns>
    /// Retorna true se foram iguais.
    /// </returns>
    public static bool IsEqual( this string value, string cadeiaCaracteres )
        => value.IsNotEmpty() && value == cadeiaCaracteres;

    /// <summary>
    /// Verifica se a string informada é IsNotEqual do char informado.
    /// </summary>
    /// <Param name="value">String que será verificada.</Param>
    /// <Param name="caractere">Char comTotivo.</Param>
    /// <returns>
    /// Retorna true se foram diferentes.
    /// </returns>
    public static bool IsNotEqual( this string value, char caractere )
        => value.IsNotEmpty() && value != caractere.ToString();

    /// <summary>
    /// Verifica se uma string é IsNotEqual da outra informada.
    /// </summary>
    /// <Param name="value">String que será verificada.</Param>
    /// <Param name="cadeiaCaracteres">String comTotiva.</Param>
    /// <returns>
    /// Retorna true se foram diferentes.
    /// </returns>
    public static bool IsNotEqual( this string value, string cadeiaCaracteres )
    {
        if ( value.IsNotEmpty() && cadeiaCaracteres.IsNotEmpty() )
            return value != cadeiaCaracteres;

        return true;
    }

    /// <summary>
    /// Verifica se há ocorrência do caractere na string.
    /// </summary>
    /// <Param name="value">String que será verificada.</Param>
    /// <Param name="comparativeValue">Caractere que será procurado.</Param>
    /// <returns>Retorna true se há ocorrência do caractere.</returns>
    public static bool Contains( this string value, char comparativeValue )
    {
        if ( !value.IsNotEmpty() )
            return false;

        for ( int i = 0; i < value.Length; i++ )
            if ( value[ i ].IsEqual( comparativeValue ) )
                return true;

        return false;
    }

    /// <summary>
    /// Verifica se os caracteres informado existe na string.
    /// </summary>
    /// <Param name="value">String a ser verificada.</Param>
    /// <Param name="comparativeValues">Caracteres que serão procurados.</Param>
    /// <returns>Retorna true se houve.</returns>
    public static bool Contains( this string value, char[] comparativeValues )
    {
        if ( !value.IsNotEmpty() )
            return false;

        for ( int i = 0; i < comparativeValues.Length; i++ )
            if ( Contains( value, comparativeValues[ i ] ) )
                return true;

        return false;
    }

    /// <summary>
    /// Verifica se algum dos caracteres da substring informada existe string verificada.
    /// </summary>
    /// <Param name="value">String a ser verificada.</Param>
    /// <Param name="caracteres">Caracteres que serão procurados.</Param>
    /// <returns>Retorna true se houve.</returns>
    public static bool Contains( this string value, string caracteres )
    {
        if ( value.IsEmpty() )
            throw new ArgumentException( "Valor não pode ser vazio" );

        return value.IndexOf( caracteres, 0, value.Length, StringComparison.Ordinal ) >= 0;
    }

    /// <summary>
    /// Verifica se o tamanho da string é IsEqual ao informado.
    /// </summary>
    /// <Param name="value">String que será verificada.</Param>
    /// <Param name="length">Valor de comToção.</Param>
    /// <returns>
    /// Retorna true se for do tamanho informado.
    /// </returns>
    public static bool LengthIsEqual( this string value, int length )
        => value.Length == length && value.IsNotEmpty();

    /// <summary>
    /// Verifica se o tamanho da string é IsEqual ao informado.
    /// </summary>
    /// <Param name="value">String que será verificada.</Param>
    /// <Param name="length">Valor de comToção.</Param>
    /// <returns>
    /// Retorna true se for do tamanho informado.
    /// </returns>
    public static bool LengthIsEqual( this string value, byte length )
        => value.Length == length && value.IsNotEmpty();

    /// <summary>
    /// Verifica se o tamanho da string é IsNotEqual ao informado.
    /// </summary>
    /// <Param name="value">String que será verificada.</Param>
    /// <Param name="tamanho">Valor de comToção.</Param>
    /// <returns>
    /// Retorna true se for IsNotEqual do tamanho informado.
    /// </returns>
    public static bool LengthIsNotEqual( this string value, int length )
        => value.IsNotEmpty() && value.Length != length;

    /// <summary>
    /// Verifica se o tamanho da string é maior que o informado.
    /// </summary>
    /// <Param name="value">String que será verificada.</Param>
    /// <Param name="tamanho">Valor de comToção.</Param>
    /// <returns>
    /// Retorna true se for maior que o tamanho informado.
    /// </returns>
    public static bool IsGreaterThan( this string value, int length )
        => value.IsNotEmpty() && value.Length > length;

    /// <summary>
    /// Verifica se o tamanho da string é menor que o informado.
    /// </summary>
    /// <Param name="value">String que será verificada.</Param>
    /// <Param name="tamanho">Valor de comToção.</Param>
    /// <returns>
    /// Retorna true se for menor que o informado.
    /// </returns>
    public static bool IsLessThan( this string value, int length )
        => value.IsNotEmpty() && value.Length < length;

    /// <summary>
    /// Verifica se uma string está vazia.
    /// </summary>
    /// <Param name="value"></Param>
    /// <returns>Retorna true se não estiver vazia, nula ou só com espaços em branco.</returns>
    public static bool IsNotEmpty( [NotNullWhen( true )] this string? value )
        => !value.IsEmpty();

    /// <summary>
    /// Verifica se em uma string contém apenas números.
    /// </summary>
    /// <Param name="value">String que será verificada.</Param>
    /// <returns>Retorna true se conter apenas números.</returns>
    public static bool IsAllNumbers( this string value )
    {
        return value.ToCharArray().IsNumber();
    }

    /// <summary>
    /// Converte um string To bool.
    /// </summary>
    /// <Param name="value">Valor string.</Param>
    /// <returns>Retorna um value bool.</returns>
    public static bool ToBoolean( this string value )
    {
        if ( value.IsNotEmpty() )
        {
            if ( value.IsEqual( "1" ) )
                return true;

            if ( value.ToLower().IsEqual( "true" ) )
                return true;
        }

        return false;
    }

    /// <summary>
    /// Converte um string To byte.
    /// </summary>
    /// <Param name="value">Valor string.</Param>
    /// <returns>Retorna um value byte.</returns>
    public static byte ToByte( this string value )
    {
        if ( !value.IsNotEmpty() )
            throw new ArgumentNullException( "Valor informado não pode ser nulo" );
        else if ( value.IsGreaterThan( 3 ) )
            throw new ArgumentException( "String informado tem mais que 3 caracteres e não pode ser convertida To byte." );
        else if ( !value.IsAllNumbers() )
            throw new ArgumentException( "String informado não é um value que pode ser convertido." );

        if ( byte.Parse( value, CultureInfo.CurrentCulture ) > byte.MaxValue )
            return byte.MaxValue;
        else if ( byte.Parse( value, CultureInfo.CurrentCulture ) < byte.MinValue )
            return byte.MinValue;
        else
            return byte.Parse( value, CultureInfo.CurrentCulture );

        throw new ArgumentOutOfRangeException( "String informado não contem value numérico." );
    }

    /// <summary>
    /// Converte de string To char.
    /// </summary>
    /// <Param name="value">Valor aue será convertido.</Param>
    /// <returns>Retorna um value do tipo char.</returns>
    public static char ToChar( this string value )
    {
        if ( value.IsNotEmpty() )
            return value[ 0 ];

        throw new ArgumentException( "Não é possível convertar a string To char pois a mesma não tem conteúdo.", nameof( value ) );
    }

    /// <summary>
    /// Converte string To DateTime.
    /// </summary>
    /// <Param name="value">String que será convertida.</Param>
    /// <returns>Retorna um DateTime.</returns>
    public static DateTime ToDateTime( this string value )
    {
        if ( value == null )
            return new DateTime();

        if ( value.LengthIsNotEqual( 10 ) )
            return new DateTime();

        return DateTime.Parse( value, CultureInfo.CurrentCulture );
    }

    /// <summary>
    /// Converte decimal To booleano.
    /// </summary>
    /// <Param name="value">value a ser convertido.</Param>
    /// <returns>Retorna um value decimal.</returns>
    public static decimal ToDecimal( this string value )
    {
        if ( value.IsEmpty() )
            return 0m;

        value = value.Replace( ",", "." );

        if ( decimal.TryParse( value, CultureInfo.InvariantCulture, out var result ) )
            return result;

        return 0m;
    }

    public static double ToDouble( this string value )
    {
        if ( value.IsEmpty() )
            return 0;

        value = value.Replace( ",", "." );

        if ( double.TryParse( value, CultureInfo.InvariantCulture, out var result ) )
            return result;

        return 0;
    }

    public static TEnum ToEnum<TEnum>( this string value )
    {
        Type tipo = typeof( TEnum );

        if ( !tipo.IsEnum )
            throw new ArgumentException( "Tipo informado não é enum." );

        return ( TEnum ) Enum.Parse( tipo, value );
    }

    // TODO: Verificação se tem apenas números.
    public static float ToFloat( this string value )
    {
        if ( value.IsEmpty() )
            return 0f;

        value = value.Replace( ",", "." );

        if ( float.TryParse( value, CultureInfo.InvariantCulture, out var result ) )
            return result;

        return 0f;
    }

    /// <summary>
    /// Converte de string To Int.
    /// </summary>
    /// <Param name="value">Valor a ser convertido.</Param>
    /// <returns>Retorna um value do tipo int.</returns>
    public static int ToInt( this string value )
    {
        if ( value.IsEmpty() )
            return 0;

        if ( int.TryParse( value, out var result ) )
            return result;

        return 0;
    }

    /// <summary>
    /// Converte de string To long.
    /// </summary>
    /// <Param name="value">Valor a ser convertido.</Param>
    /// <returns>Retorna um value do tipo long.</returns>
    public static long ToLong( this string value )
    {
        if ( value.IsEmpty() )
            return 0L;

        if (long.TryParse(value, out var result ) )
            return result;

        return 0L;
    }

    /// <summary>
    /// Converte um string To o tipo short.
    /// </summary>
    /// <Param name="value">Valor a ser convertido.</Param>
    /// <returns>Retorna um value do tipo short.</returns>
    public static short ToShort( this string value )
    {
        if ( value.IsEmpty() )
            return 0;

        if ( short.TryParse( value, out var result ) )
            return result;

        return 0;
    }

    /// <summary>
    /// Verifica se a string informada tem apenas espaços.
    /// </summary>
    /// <Param name="value">String a ser verificada.</Param>
    /// <returns>Retorna true se só tiver espaços.</returns>
    public static bool IsAllWhiteSpaces( [NotNullWhen( false )] this string? value )
    {
        if ( value.IsNull() || value == string.Empty )
            return true;

        bool apenasEspacos = true;

        for ( int i = 0; i < value.Length; i++ )
            if ( !char.IsWhiteSpace( value[ i ] ) )
            {
                apenasEspacos = false;
                break;
            }

        if ( apenasEspacos )
            return true;

        return false;

    }

    /// <summary>
    /// Verifica se a cadeia de caracteres está nula.
    /// </summary>
    /// <Param name="value">Cadeia de caracteres a ser verificada.</Param>
    /// <returns>Retorna true se estiver nula.</returns>
    public static bool IsNull( [NotNullWhen( false )] this string? value )
        => value == null;

    public static string RemovePeriods( this string value )
        => value.Replace( ".", "" );

    public static string RemoveComma( this string value )
        => value.Replace( ",", "" );

    public static string RemoveSlashes( this string value )
        => value.Replace( "/", "" );

    public static string RemoveBackSlashes( this string value )
        => value.Replace( "\\", "" );

    public static string RemoveHyphens( this string value )
        => value.Replace( "-", "" );

    public static string RemoverUnderline( this string value )
        => value.Replace( "_", "" );

    public static string RemoveMask( this string value )
        => value.RemoveSlashes()
            .RemoveBackSlashes()
            .RemoveHyphens()
            .RemovePeriods()
            .RemoverUnderline()
            .RemoveComma();
  
    public static string RemoveAccents( this string value )
    {
        if ( value.IsEmpty() )
            return value;

        string normalizedString = value.Normalize( NormalizationForm.FormD );
        StringBuilder stringBuilder = new();

        foreach ( char character in normalizedString )
            if ( CharUnicodeInfo.GetUnicodeCategory( character ) != UnicodeCategory.NonSpacingMark )
                stringBuilder.Append( character );

        return stringBuilder
            .ToString()
            .Normalize( NormalizationForm.FormC );
    }
}