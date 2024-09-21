using System.Globalization;

namespace DevToolz.Library.Extensions;

public static class CharExtensions
{
    private readonly static byte[] CategoriaCaracereLatino = {
        (byte)UnicodeCategory.Control, (byte)UnicodeCategory.Control, (byte)UnicodeCategory.Control, (byte)UnicodeCategory.Control, (byte)UnicodeCategory.Control, (byte)UnicodeCategory.Control, (byte)UnicodeCategory.Control, (byte)UnicodeCategory.Control,    // 0000 - 0007
        (byte)UnicodeCategory.Control, (byte)UnicodeCategory.Control, (byte)UnicodeCategory.Control, (byte)UnicodeCategory.Control, (byte)UnicodeCategory.Control, (byte)UnicodeCategory.Control, (byte)UnicodeCategory.Control, (byte)UnicodeCategory.Control,    // 0008 - 000F
        (byte)UnicodeCategory.Control, (byte)UnicodeCategory.Control, (byte)UnicodeCategory.Control, (byte)UnicodeCategory.Control, (byte)UnicodeCategory.Control, (byte)UnicodeCategory.Control, (byte)UnicodeCategory.Control, (byte)UnicodeCategory.Control,    // 0010 - 0017
        (byte)UnicodeCategory.Control, (byte)UnicodeCategory.Control, (byte)UnicodeCategory.Control, (byte)UnicodeCategory.Control, (byte)UnicodeCategory.Control, (byte)UnicodeCategory.Control, (byte)UnicodeCategory.Control, (byte)UnicodeCategory.Control,    // 0018 - 001F
        (byte)UnicodeCategory.SpaceSeparator, (byte)UnicodeCategory.OtherPunctuation, (byte)UnicodeCategory.OtherPunctuation, (byte)UnicodeCategory.OtherPunctuation, (byte)UnicodeCategory.CurrencySymbol, (byte)UnicodeCategory.OtherPunctuation, (byte)UnicodeCategory.OtherPunctuation, (byte)UnicodeCategory.OtherPunctuation,    // 0020 - 0027
        (byte)UnicodeCategory.OpenPunctuation, (byte)UnicodeCategory.ClosePunctuation, (byte)UnicodeCategory.OtherPunctuation, (byte)UnicodeCategory.MathSymbol, (byte)UnicodeCategory.OtherPunctuation, (byte)UnicodeCategory.DashPunctuation, (byte)UnicodeCategory.OtherPunctuation, (byte)UnicodeCategory.OtherPunctuation,    // 0028 - 002F
        (byte)UnicodeCategory.DecimalDigitNumber, (byte)UnicodeCategory.DecimalDigitNumber, (byte)UnicodeCategory.DecimalDigitNumber, (byte)UnicodeCategory.DecimalDigitNumber, (byte)UnicodeCategory.DecimalDigitNumber, (byte)UnicodeCategory.DecimalDigitNumber, (byte)UnicodeCategory.DecimalDigitNumber, (byte)UnicodeCategory.DecimalDigitNumber,    // 0030 - 0037
        (byte)UnicodeCategory.DecimalDigitNumber, (byte)UnicodeCategory.DecimalDigitNumber, (byte)UnicodeCategory.OtherPunctuation, (byte)UnicodeCategory.OtherPunctuation, (byte)UnicodeCategory.MathSymbol, (byte)UnicodeCategory.MathSymbol, (byte)UnicodeCategory.MathSymbol, (byte)UnicodeCategory.OtherPunctuation,    // 0038 - 003F
        (byte)UnicodeCategory.OtherPunctuation, (byte)UnicodeCategory.UppercaseLetter, (byte)UnicodeCategory.UppercaseLetter, (byte)UnicodeCategory.UppercaseLetter, (byte)UnicodeCategory.UppercaseLetter, (byte)UnicodeCategory.UppercaseLetter, (byte)UnicodeCategory.UppercaseLetter, (byte)UnicodeCategory.UppercaseLetter,    // 0040 - 0047
        (byte)UnicodeCategory.UppercaseLetter, (byte)UnicodeCategory.UppercaseLetter, (byte)UnicodeCategory.UppercaseLetter, (byte)UnicodeCategory.UppercaseLetter, (byte)UnicodeCategory.UppercaseLetter, (byte)UnicodeCategory.UppercaseLetter, (byte)UnicodeCategory.UppercaseLetter, (byte)UnicodeCategory.UppercaseLetter,    // 0048 - 004F
        (byte)UnicodeCategory.UppercaseLetter, (byte)UnicodeCategory.UppercaseLetter, (byte)UnicodeCategory.UppercaseLetter, (byte)UnicodeCategory.UppercaseLetter, (byte)UnicodeCategory.UppercaseLetter, (byte)UnicodeCategory.UppercaseLetter, (byte)UnicodeCategory.UppercaseLetter, (byte)UnicodeCategory.UppercaseLetter,    // 0050 - 0057
        (byte)UnicodeCategory.UppercaseLetter, (byte)UnicodeCategory.UppercaseLetter, (byte)UnicodeCategory.UppercaseLetter, (byte)UnicodeCategory.OpenPunctuation, (byte)UnicodeCategory.OtherPunctuation, (byte)UnicodeCategory.ClosePunctuation, (byte)UnicodeCategory.ModifierSymbol, (byte)UnicodeCategory.ConnectorPunctuation,    // 0058 - 005F
        (byte)UnicodeCategory.ModifierSymbol, (byte)UnicodeCategory.LowercaseLetter, (byte)UnicodeCategory.LowercaseLetter, (byte)UnicodeCategory.LowercaseLetter, (byte)UnicodeCategory.LowercaseLetter, (byte)UnicodeCategory.LowercaseLetter, (byte)UnicodeCategory.LowercaseLetter, (byte)UnicodeCategory.LowercaseLetter,    // 0060 - 0067
        (byte)UnicodeCategory.LowercaseLetter, (byte)UnicodeCategory.LowercaseLetter, (byte)UnicodeCategory.LowercaseLetter, (byte)UnicodeCategory.LowercaseLetter, (byte)UnicodeCategory.LowercaseLetter, (byte)UnicodeCategory.LowercaseLetter, (byte)UnicodeCategory.LowercaseLetter, (byte)UnicodeCategory.LowercaseLetter,    // 0068 - 006F
        (byte)UnicodeCategory.LowercaseLetter, (byte)UnicodeCategory.LowercaseLetter, (byte)UnicodeCategory.LowercaseLetter, (byte)UnicodeCategory.LowercaseLetter, (byte)UnicodeCategory.LowercaseLetter, (byte)UnicodeCategory.LowercaseLetter, (byte)UnicodeCategory.LowercaseLetter, (byte)UnicodeCategory.LowercaseLetter,    // 0070 - 0077
        (byte)UnicodeCategory.LowercaseLetter, (byte)UnicodeCategory.LowercaseLetter, (byte)UnicodeCategory.LowercaseLetter, (byte)UnicodeCategory.OpenPunctuation, (byte)UnicodeCategory.MathSymbol, (byte)UnicodeCategory.ClosePunctuation, (byte)UnicodeCategory.MathSymbol, (byte)UnicodeCategory.Control,    // 0078 - 007F
        (byte)UnicodeCategory.Control, (byte)UnicodeCategory.Control, (byte)UnicodeCategory.Control, (byte)UnicodeCategory.Control, (byte)UnicodeCategory.Control, (byte)UnicodeCategory.Control, (byte)UnicodeCategory.Control, (byte)UnicodeCategory.Control,    // 0080 - 0087
        (byte)UnicodeCategory.Control, (byte)UnicodeCategory.Control, (byte)UnicodeCategory.Control, (byte)UnicodeCategory.Control, (byte)UnicodeCategory.Control, (byte)UnicodeCategory.Control, (byte)UnicodeCategory.Control, (byte)UnicodeCategory.Control,    // 0088 - 008F
        (byte)UnicodeCategory.Control, (byte)UnicodeCategory.Control, (byte)UnicodeCategory.Control, (byte)UnicodeCategory.Control, (byte)UnicodeCategory.Control, (byte)UnicodeCategory.Control, (byte)UnicodeCategory.Control, (byte)UnicodeCategory.Control,    // 0090 - 0097
        (byte)UnicodeCategory.Control, (byte)UnicodeCategory.Control, (byte)UnicodeCategory.Control, (byte)UnicodeCategory.Control, (byte)UnicodeCategory.Control, (byte)UnicodeCategory.Control, (byte)UnicodeCategory.Control, (byte)UnicodeCategory.Control,    // 0098 - 009F
        (byte)UnicodeCategory.SpaceSeparator, (byte)UnicodeCategory.OtherPunctuation, (byte)UnicodeCategory.CurrencySymbol, (byte)UnicodeCategory.CurrencySymbol, (byte)UnicodeCategory.CurrencySymbol, (byte)UnicodeCategory.CurrencySymbol, (byte)UnicodeCategory.OtherSymbol, (byte)UnicodeCategory.OtherSymbol,    // 00A0 - 00A7
        (byte)UnicodeCategory.ModifierSymbol, (byte)UnicodeCategory.OtherSymbol, (byte)UnicodeCategory.LowercaseLetter, (byte)UnicodeCategory.InitialQuotePunctuation, (byte)UnicodeCategory.MathSymbol, (byte)UnicodeCategory.DashPunctuation, (byte)UnicodeCategory.OtherSymbol, (byte)UnicodeCategory.ModifierSymbol,    // 00A8 - 00AF
        (byte)UnicodeCategory.OtherSymbol, (byte)UnicodeCategory.MathSymbol, (byte)UnicodeCategory.OtherNumber, (byte)UnicodeCategory.OtherNumber, (byte)UnicodeCategory.ModifierSymbol, (byte)UnicodeCategory.LowercaseLetter, (byte)UnicodeCategory.OtherSymbol, (byte)UnicodeCategory.OtherPunctuation,    // 00B0 - 00B7
        (byte)UnicodeCategory.ModifierSymbol, (byte)UnicodeCategory.OtherNumber, (byte)UnicodeCategory.LowercaseLetter, (byte)UnicodeCategory.FinalQuotePunctuation, (byte)UnicodeCategory.OtherNumber, (byte)UnicodeCategory.OtherNumber, (byte)UnicodeCategory.OtherNumber, (byte)UnicodeCategory.OtherPunctuation,    // 00B8 - 00BF
        (byte)UnicodeCategory.UppercaseLetter, (byte)UnicodeCategory.UppercaseLetter, (byte)UnicodeCategory.UppercaseLetter, (byte)UnicodeCategory.UppercaseLetter, (byte)UnicodeCategory.UppercaseLetter, (byte)UnicodeCategory.UppercaseLetter, (byte)UnicodeCategory.UppercaseLetter, (byte)UnicodeCategory.UppercaseLetter,    // 00C0 - 00C7
        (byte)UnicodeCategory.UppercaseLetter, (byte)UnicodeCategory.UppercaseLetter, (byte)UnicodeCategory.UppercaseLetter, (byte)UnicodeCategory.UppercaseLetter, (byte)UnicodeCategory.UppercaseLetter, (byte)UnicodeCategory.UppercaseLetter, (byte)UnicodeCategory.UppercaseLetter, (byte)UnicodeCategory.UppercaseLetter,    // 00C8 - 00CF
        (byte)UnicodeCategory.UppercaseLetter, (byte)UnicodeCategory.UppercaseLetter, (byte)UnicodeCategory.UppercaseLetter, (byte)UnicodeCategory.UppercaseLetter, (byte)UnicodeCategory.UppercaseLetter, (byte)UnicodeCategory.UppercaseLetter, (byte)UnicodeCategory.UppercaseLetter, (byte)UnicodeCategory.MathSymbol,    // 00D0 - 00D7
        (byte)UnicodeCategory.UppercaseLetter, (byte)UnicodeCategory.UppercaseLetter, (byte)UnicodeCategory.UppercaseLetter, (byte)UnicodeCategory.UppercaseLetter, (byte)UnicodeCategory.UppercaseLetter, (byte)UnicodeCategory.UppercaseLetter, (byte)UnicodeCategory.UppercaseLetter, (byte)UnicodeCategory.LowercaseLetter,    // 00D8 - 00DF
        (byte)UnicodeCategory.LowercaseLetter, (byte)UnicodeCategory.LowercaseLetter, (byte)UnicodeCategory.LowercaseLetter, (byte)UnicodeCategory.LowercaseLetter, (byte)UnicodeCategory.LowercaseLetter, (byte)UnicodeCategory.LowercaseLetter, (byte)UnicodeCategory.LowercaseLetter, (byte)UnicodeCategory.LowercaseLetter,    // 00E0 - 00E7
        (byte)UnicodeCategory.LowercaseLetter, (byte)UnicodeCategory.LowercaseLetter, (byte)UnicodeCategory.LowercaseLetter, (byte)UnicodeCategory.LowercaseLetter, (byte)UnicodeCategory.LowercaseLetter, (byte)UnicodeCategory.LowercaseLetter, (byte)UnicodeCategory.LowercaseLetter, (byte)UnicodeCategory.LowercaseLetter,    // 00E8 - 00EF
        (byte)UnicodeCategory.LowercaseLetter, (byte)UnicodeCategory.LowercaseLetter, (byte)UnicodeCategory.LowercaseLetter, (byte)UnicodeCategory.LowercaseLetter, (byte)UnicodeCategory.LowercaseLetter, (byte)UnicodeCategory.LowercaseLetter, (byte)UnicodeCategory.LowercaseLetter, (byte)UnicodeCategory.MathSymbol,    // 00F0 - 00F7
        (byte)UnicodeCategory.LowercaseLetter, (byte)UnicodeCategory.LowercaseLetter, (byte)UnicodeCategory.LowercaseLetter, (byte)UnicodeCategory.LowercaseLetter, (byte)UnicodeCategory.LowercaseLetter, (byte)UnicodeCategory.LowercaseLetter, (byte)UnicodeCategory.LowercaseLetter, (byte)UnicodeCategory.LowercaseLetter,    // 00F8 - 00FF
    };

    private static bool LatinChar( char value )
        => value <= '\x00ff';

    private static UnicodeCategory GetLatinChar( char value )
        => ( UnicodeCategory ) CategoriaCaracereLatino[ value ];

    private static bool IsSymbol( UnicodeCategory unicodeValue )
    {
        switch ( unicodeValue )
        {
            case UnicodeCategory.MathSymbol:
            case UnicodeCategory.CurrencySymbol:
            case UnicodeCategory.ModifierSymbol:
            case UnicodeCategory.OtherSymbol:
            case UnicodeCategory.ConnectorPunctuation:
            case UnicodeCategory.DashPunctuation:
            case UnicodeCategory.OpenPunctuation:
            case UnicodeCategory.ClosePunctuation:
            case UnicodeCategory.InitialQuotePunctuation:
            case UnicodeCategory.FinalQuotePunctuation:
            case UnicodeCategory.OtherPunctuation:
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Verifica se um caractere é Equal ao outro.
    /// </summary>
    /// <Param name="value">Char a ser verficado.</Param>
    /// <Param name="comTotiveValue">value comTodor.</Param>
    /// <returns>Retorna true se forem iguais.</returns>
    public static bool IsEqual( this char value, char comTotiveValue )
        => value == comTotiveValue;

    /// <summary>
    /// Verifica se um caractere é Equal ao outro.
    /// </summary>
    /// <Param name="value">Char a ser verficado.</Param>
    /// <Param name="comTotiveValue">value comTodor.</Param>
    /// <returns>Retorna true se forem iguais.</returns>
    public static bool IsEqual( this char value, string comTotiveValue )
    {
        if ( comTotiveValue.LengthIsEqual( 1 ) )
            return value == char.Parse( comTotiveValue );
        else
            return false;
    }

    /// <summary>
    /// Verifica se um caractere é IsNotEqual do outro.
    /// </summary>
    /// <Param name="value">Char a ser verficado.</Param>
    /// <Param name="caractere">value comTodor.</Param>
    /// <returns>Retorna true se forem diferentes.</returns>
    public static bool IsNotEqual( this char value, char comTotiveValue )
        => value != comTotiveValue;

    /// <summary>
    /// Verifica se um caractere é IsNotEqual do outro.
    /// </summary>
    /// <Param name="value">Char a ser verficado.</Param>
    /// <Param name="caractere">value comTodor.</Param>
    /// <returns>Retorna true se forem diferentes.</returns>
    public static bool IsNotEqual( this char value, string comTotiveValue )
    {
        if ( comTotiveValue.LengthIsEqual( 1 ) )
            return value != char.Parse( comTotiveValue );

        return false;
    }

    /// <summary>
    /// Verifica se o value é menor que o value comTodor.
    /// </summary>
    /// <Param name="value">value principal.</Param>
    /// <Param name="comTotiveValue">value a ser comTodo.</Param>
    /// <returns>Retorna true se for menor.</returns>
    public static bool LessThan( this char value, byte comTotiveValue )
        => value.ToByte() < comTotiveValue;

    /// <summary>
    /// Verifica se o value é menor que o value comTodor.
    /// </summary>
    /// <Param name="value">value principal.</Param>
    /// <Param name="comTotiveValue">value a ser comTodo.</Param>
    /// <returns>Retorna true se for menor.</returns>
    public static bool LessThan( this char value, char comTotiveValue )
        => value < comTotiveValue;

    /// <summary>
    /// Verifica se o value é menor que o value comTodor.
    /// </summary>
    /// <Param name="value">value principal.</Param>
    /// <Param name="comTotiveValue">value a ser comTodo.</Param>
    /// <returns>Retorna true se for menor.</returns>
    public static bool LessThan( this char value, decimal comTotiveValue )
        => value < comTotiveValue;

    /// <summary>
    /// Verifica se o value é menor que o value comTodor.
    /// </summary>
    /// <Param name="value">value principal.</Param>
    /// <Param name="comTotiveValue">value a ser comTodo.</Param>
    /// <returns>Retorna true se for menor.</returns>
    public static bool LessThan( this char value, double comTotiveValue )
        => value < comTotiveValue;

    /// <summary>
    /// Verifica se o value é menor que o value comTodor.
    /// </summary>
    /// <Param name="value">value principal.</Param>
    /// <Param name="comTotiveValue">value a ser comTodo.</Param>
    /// <returns>Retorna true se for menor.</returns>
    public static bool LessThan( this char value, float comTotiveValue )
        => value < comTotiveValue;

    /// <summary>
    /// Verifica se o value é menor que o value comTodor.
    /// </summary>
    /// <Param name="value">value principal.</Param>
    /// <Param name="comTotiveValue">value a ser comTodo.</Param>
    /// <returns>Retorna true se for menor.</returns>
    public static bool LessThan( this char value, int comTotiveValue )
        => value < comTotiveValue;

    /// <summary>
    /// Verifica se o value é menor que o value comTodor.
    /// </summary>
    /// <Param name="value">value principal.</Param>
    /// <Param name="comTotiveValue">value a ser comTodo.</Param>
    /// <returns>Retorna true se for menor.</returns>
    public static bool LessThan( this char value, long comTotiveValue )
        => value < comTotiveValue;

    /// <summary>
    /// Verifica se o caractere é um número.
    /// </summary>
    /// <Param name="value">Caractere que será verificado.</Param>
    /// <returns>Retorna true se um número.</returns>
    public static bool IsNumber( this char value )
        => value >= '0' && value <= '9';

    /// <summary>
    /// Verifica se um vetor de caracteres são números.
    /// </summary>
    /// <Param name="values">Vetor a ser verificado.</Param>
    /// <returns>Retorna true se todos os caracteres forem números.</returns>
    public static bool IsNumber( this char[] values )
    {
        foreach ( char caractere in values )
            if ( !caractere.IsNumber() )
                return false;

        return true;
    }

    /// <summary>
    /// Verifica se o caractere é uma letra.
    /// </summary>
    /// <Param name="value">Caractere que será verificado.</Param>
    /// <returns>Retorna true se for uma letra.</returns>
    public static bool IsLetter( this char value )
        => value.IsLowerCase() || value.IsCapitalLetter();

    /// <summary>
    /// Verifica se o caractere é uma letra maiúscula.
    /// </summary>
    /// <Param name="value">Caractere que será verificado.</Param>
    /// <returns>Retorna true se for uma letra maiúscula.</returns>
    public static bool IsCapitalLetter( this char value )
        => value >= 'A' && value <= 'Z';

    /// <summary>
    /// Verifica se o caractere é uma letra minúscula.
    /// </summary>
    /// <Param name="value">Caractere que será verificado.</Param>
    /// <returns>Retorna true se for uma letra minúscula.</returns>
    public static bool IsLowerCase( this char value )
        => value >= 'a' && value <= 'z';

    /// <summary>
    /// Verifica se o caractere é um símbolo.
    /// </summary>
    /// <Param name="value">Caractere que será verificado.</Param>
    /// <returns>Retorna true se for um símbolo.</returns>
    public static bool IsSymbol( this char value )
        => value.IsSymbol( false );

    /// <summary>
    /// Verifica se o caractere é um símbolo.
    /// </summary>
    /// <Param name="value">Caractere que será verificado.</Param>
    /// <Param name="permitirSimboloNegativo">Define se deve ignorar o símbolo de negativo ( - ).</Param>
    /// <returns>Retorna true se for um símbolo.</returns>
    public static bool IsSymbol( this char value, bool permitirSimboloNegativo )
    {
        if ( permitirSimboloNegativo && value.IsNegativeSymbol() )
            return false;

        if ( LatinChar( value ) )
            return IsSymbol( GetLatinChar( value ) );

        return IsSymbol( CharUnicodeInfo.GetUnicodeCategory( value ) );
    }

    // U+0009 = <control> HORIZONTAL TAB
    // U+000a = <control> LINE FEED
    // U+000b = <control> VERTICAL TAB
    // U+000c = <contorl> FORM FEED
    // U+000d = <control> CARRIAGE RETURN
    // U+0085 = <control> NEXT LINE
    // U+00a0 = NO-BREAK SPACE

    /// <summary>
    /// Verifica se o caractere é um espaço em branco.
    /// </summary>
    /// <Param name="value">Caractere a ser verificado.</Param>
    /// <returns>Retorna true se for espaço em branco.</returns>
    public static bool IsOnlyWhiteSpaces( this char value )
        => value == ' ' ||
            value >= '\x0009' &&
            value <= '\x000d' ||
            value == '\x00a0' ||
            value == '\x0085';

    /// <summary>
    /// Verifica se o caractere é retorno "tecla apagar".
    /// </summary>
    /// <Param name="value">Caractere que será verificado.</Param>
    /// <returns>Retorna true se for caractere de retorno ( Backspace / tecla To apagar ).</returns>
    public static bool IsReturnChar( this char value )
        => value == '\b';

    /// <summary>
    /// Verifica se o caractere é retorno "tecla apagar".
    /// </summary>
    /// <Param name="value">Caractere que será verificado.</Param>
    /// <returns>Retorna true se for símbolo de negativo ( - ).</returns>
    public static bool IsNegativeSymbol( this char value )
        => value == 45;

    /// <summary>
    /// Verifica se um value está na faixa Between dois números informados.
    /// </summary>
    /// <Param name="value">value a ser verificado.</Param>
    /// <Param name="lowestValue">Menor value da faixa.</Param>
    /// <Param name="highestValue">Maior value da faixa.</Param>
    /// <returns>Retorna true se estives.</returns>
    public static bool Between( this char value, char lowestValue, char highestValue )
        => value > lowestValue && value < highestValue;

    /// <summary>
    /// Converte um char To bool.
    /// </summary>
    /// <Param name="value">value char.</Param>
    /// <returns>Retorna um value bool.</returns>
    public static bool ToBoolean( this char value )
        => value.IsEqual( 's' ) ||
            value.IsEqual( 'S' ) ||
            value.IsEqual( '1' );

    /// <summary>
    /// Converte um char To byte.
    /// </summary>
    /// <Param name="value">value char.</Param>
    /// <returns>Retorna um value byte.</returns>
    public static byte ToByte( this char value )
    {
        if ( !value.IsNumber() )
            return 0;

        return value.ToString()
                    .ToByte();
    }

    /// <summary>
    /// Converte decimal To booleano.
    /// </summary>
    /// <Param name="value">value a ser convertido.</Param>
    /// <returns>Retorna um value decimal.</returns>
    public static decimal ToDecimal( this char value )
    {
        if ( !value.IsNumber() )
            return 0m;

        return value.ToString().ToDecimal();
    }

    public static double ToDouble( this char value )
    {
        if ( !value.IsNumber() )
            return 0;

        return value.ToString().ToDouble();
    }

    public static float ToFloat( this char value )
    {
        if ( !value.IsNumber() )
            return 0f;

        return value.ToString().ToFloat();
    }

    public static int ToInt( this char value )
    {
        if ( !value.IsNumber() )
            return 0;

        return value.ToString().ToInt();
    }

    /// <summary>
    /// Converte de char To long.
    /// </summary>
    /// <Param name="value">value a ser convertido.</Param>
    /// <returns>Retorna um value do tipo long.</returns>
    public static long ToLong( this char value )
    {
        if ( !value.IsNumber() )
            return 0;

        return value.ToString().ToLong();
    }

    /// <summary>
    /// Converte um char To o tipo short.
    /// </summary>
    /// <Param name="value">value a ser convertido.</Param>
    /// <returns>Retorna o caractere no tipo short.</returns>
    public static short ToShort( this char value )
    {
        if ( !value.IsNumber() )
            return 0;

        return value.ToString().ToShort();
    }
}