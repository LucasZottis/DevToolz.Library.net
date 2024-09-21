namespace DevToolz.Library.Extensions;

public static class IntExtensions
{
    /// <summary>
    /// Converte um int To bool.
    /// </summary>
    /// <Param name="value">value int.</Param>
    /// <returns>Retorna um value bool.</returns>
    public static bool ToBoolean( this int value )
        => value.IsEqual( 1 );

    /// <summary>
    /// Converte um int To byte.
    /// </summary>
    /// <Param name="value">value int.</Param>
    /// <returns>Retorna um value byte.</returns>
    public static byte ToByte( this int value )
    {
        if ( value > byte.MaxValue )
            return byte.MaxValue;
        else if ( value < byte.MinValue )
            return byte.MinValue;

        return ( byte ) value;
    }

    /// <summary>
    /// Converte de byte int char.
    /// </summary>
    /// <Param name="value">value aue será convertido.</Param>
    /// <returns>Retorna um value do tipo char.</returns>
    public static char ToChar( this int value )
    {
        if ( value.Between( 0, 10 ) )
            throw new ArgumentException( "value informado não é um número. value deve ser um número de 0 à 9." );

        return value.ToString().ToChar();
    }

    /// <summary>
    /// Converte decimal To booleano.
    /// </summary>
    /// <Param name="value">value a ser convertido.</Param>
    /// <returns>Retorna um value decimal.</returns>
    public static decimal ToDecimal( this int value )
        => value;

    public static double ToDouble( this int value )
        => value;

    public static TEnum ToEnum<TEnum>( this int value )
    {
        Type tipo = typeof( TEnum );

        if ( !tipo.IsEnum )
            throw new ArgumentException( "Tipo informado não é enum." );

        return ( TEnum ) Enum.Parse( tipo, value.ToString() );
    }

    public static float ToFloat( this int value )
        => value;

    /// <summary>
    /// Converte de byte To long.
    /// </summary>
    /// <Param name="value">value a ser convertido.</Param>
    /// <returns>Retorna um value do tipo long.</returns>
    public static long ToLong( this int value )
        => value;

    /// <summary>
    /// Converteum value do tipo object To o tipo short.
    /// </summary>
    /// <Param name="value">value a ser convertido.</Param>
    /// <returns>Retorna um value do tipo short.</returns>
    public static short ToShort( this int value )
        => ( ( IConvertible ) value ).ToInt16( null );

    public static decimal BitToByte( this int value )
        => Math.Round( value.ToDecimal() / 8, 2 );

    public static decimal BitToKiloByte( this int value )
        => Math.Round( value.ToDecimal() / 8000, 2 );

    public static decimal BitToMegaBytes( this int value )
        => Math.Round( value.ToDecimal() / 8000000, 2 );

    public static decimal BitToGigaBytes( this int value )
        => Math.Round( value.ToDecimal() / 8000000000, 2 );

    public static decimal ByteToBit( this int value )
        => Math.Round( value.ToDecimal() * 8, 2 );

    public static decimal ByteToKiloByte( this int value )
        => Math.Round( value.ToDecimal() / 1000, 2 );

    public static decimal ByteToMegaByte( this int value )
        => Math.Round( value.ToDecimal() / 1000000, 2 );

    public static decimal ByteToGigaByte( this int value )
        => Math.Round( value.ToDecimal() / 1000000000, 2 );

    public static decimal KiloByteToBit( this int value )
        => Math.Round( value.ToDecimal() * 8000, 2 );

    public static decimal KiloToToByte( this int value )
        => Math.Round( value.ToDecimal() * 1000, 2 );

    public static decimal KiloByteToMegaByte( this int value )
        => Math.Round( value.ToDecimal() / 1000, 2 );

    public static decimal KiloByteToGigaByte( this int value )
        => Math.Round( value.ToDecimal() / 1000000, 2 );

    public static decimal MegaByteToBit( this int value )
        => Math.Round( value.ToDecimal() * 8000000, 2 );

    public static decimal MegaByteToByte( this int value )
        => Math.Round( value.ToDecimal() * 1000000, 2 );

    public static decimal MegaByteToKiloByte( this int value )
        => Math.Round( value.ToDecimal() * 1000, 2 );

    public static decimal MegaByteToGigaByte( this int value )
        => Math.Round( value.ToDecimal() / 1000, 2 );

    public static decimal GigaByteToBit( this int value )
        => Math.Round( value.ToDecimal() * 8000000000, 2 );

    public static decimal GigaByteToByte( this int value )
        => Math.Round( value.ToDecimal() * 1000000000, 2 );

    public static decimal GigaByteToKiloByte( this int value )
        => Math.Round( value.ToDecimal() * 1000000, 2 );

    public static decimal GigaByteToMegaByte( this int value )
        => Math.Round( value.ToDecimal() * 1000, 2 );

    /// <summary>
    /// Verifica se um value é IsEqual ao outro.
    /// </summary>
    /// <Param name="value">Inteiro a ser verficado.</Param>
    /// <Param name="valorVerificador">value comTodor.</Param>
    /// <returns>Retorna true se forem iguais.</returns>
    public static bool IsEqual( this int value, byte valorVerificador )
        => value == valorVerificador.ToInt();

    /// <summary>
    /// Verifica se um value é IsEqual ao outro.
    /// </summary>
    /// <Param name="value">Inteiro a ser verficado.</Param>
    /// <Param name="valorVerificador">value comTodor.</Param>
    /// <returns>Retorna true se forem iguais.</returns>
    public static bool IsEqual( this int value, double valorVerificador )
        => value == valorVerificador.ToInt();

    /// <summary>
    /// Verifica se um value é IsEqual ao outro.
    /// </summary>
    /// <Param name="value">Inteiro a ser verficado.</Param>
    /// <Param name="valorVerificador">value comTodor.</Param>
    /// <returns>Retorna true se forem iguais.</returns>
    public static bool IsEqual( this int value, float valorVerificador )
        => value == valorVerificador.ToInt();

    /// <summary>
    /// Verifica se um value é IsEqual ao outro.
    /// </summary>
    /// <Param name="value">Inteiro a ser verficado.</Param>
    /// <Param name="valorVerificador">value comTodor.</Param>
    /// <returns>Retorna true se forem iguais.</returns>
    public static bool IsEqual( this int value, int valorVerificador )
        => value == valorVerificador;

    /// <summary>
    /// Verifica se um value é IsNotEqual do outro.
    /// </summary>
    /// <Param name="value">Inteiro a ser verficado.</Param>
    /// <Param name="valorVerificador">value comTodor.</Param>
    /// <returns>Retorna true se forem diferentes.</returns>
    public static bool IsNotEqual( this int value, byte valorVerificador )
        => value != valorVerificador.ToInt();

    /// <summary>
    /// Verifica se um value é IsNotEqual do outro.
    /// </summary>
    /// <Param name="value">Inteiro a ser verficado.</Param>
    /// <Param name="valorVerificador">value comTodor.</Param>
    /// <returns>Retorna true se forem diferentes.</returns>
    public static bool IsNotEqual( this int value, char valorVerificador )
        => value != valorVerificador.ToInt();

    /// <summary>
    /// Verifica se um value é IsNotEqual do outro.
    /// </summary>
    /// <Param name="value">Inteiro a ser verficado.</Param>
    /// <Param name="valorVerificador">value comTodor.</Param>
    /// <returns>Retorna true se forem diferentes.</returns>
    public static bool IsNotEqual( this int value, double valorVerificador )
        => value != valorVerificador.ToInt();

    /// <summary>
    /// Verifica se um value é IsNotEqual do outro.
    /// </summary>
    /// <Param name="value">Inteiro a ser verficado.</Param>
    /// <Param name="valorVerificador">value comTodor.</Param>
    /// <returns>Retorna true se forem diferentes.</returns>
    public static bool IsNotEqual( this int value, float valorVerificador )
        => value != valorVerificador.ToInt();

    /// <summary>
    /// Verifica se um value é IsNotEqual do outro.
    /// </summary>
    /// <Param name="value">Inteiro a ser verficado.</Param>
    /// <Param name="valorVerificador">value comTodor.</Param>
    /// <returns>Retorna true se forem diferentes.</returns>
    public static bool IsNotEqual( this int value, int valorVerificador )
        => value != valorVerificador;

    /// <summary>
    /// Verifica se o value é maior que o value comTodor.
    /// </summary>
    /// <Param name="value">value principal.</Param>
    /// <Param name="comparativeValue">value a ser comTodo.</Param>
    /// <returns>Retorna true se for maior.</returns>
    public static bool GreaterThan( this int value, byte comparativeValue )
        => value > comparativeValue;

    /// <summary>
    /// Verifica se o value é maior que o value comTodor.
    /// </summary>
    /// <Param name="value">value principal.</Param>
    /// <Param name="comparativeValue">value a ser comTodo.</Param>
    /// <returns>Retorna true se for maior.</returns>
    public static bool GreaterThan( this int value, decimal comparativeValue )
        => value > comparativeValue;

    /// <summary>
    /// Verifica se o value é maior que o value comTodor.
    /// </summary>
    /// <Param name="value">value principal.</Param>
    /// <Param name="comparativeValue">value a ser comTodo.</Param>
    /// <returns>Retorna true se for maior.</returns>
    public static bool GreaterThan( this int value, double comparativeValue )
        => value > comparativeValue;

    /// <summary>
    /// Verifica se o value é maior que o value comTodor.
    /// </summary>
    /// <Param name="value">value principal.</Param>
    /// <Param name="comparativeValue">value a ser comTodo.</Param>
    /// <returns>Retorna true se for maior.</returns>
    public static bool GreaterThan( this int value, float comparativeValue )
        => value > comparativeValue;

    /// <summary>
    /// Verifica se o value é maior que o value comTodor.
    /// </summary>
    /// <Param name="value">value principal.</Param>
    /// <Param name="comparativeValue">value a ser comTodo.</Param>
    /// <returns>Retorna true se for maior.</returns>
    public static bool GreaterThan( this int value, int comparativeValue )
        => value > comparativeValue;

    /// <summary>
    /// Verifica se o value é maior que o value comTodor.
    /// </summary>
    /// <Param name="value">value principal.</Param>
    /// <Param name="comparativeValue">value a ser comTodo.</Param>
    /// <returns>Retorna true se for maior.</returns>
    public static bool GreaterThan( this int value, long comparativeValue )
        => value > comparativeValue;

    /// <summary>
    /// Verifica se o value é menor que o value comTodor.
    /// </summary>
    /// <Param name="value">value principal.</Param>
    /// <Param name="comparativeValue">value a ser comTodo.</Param>
    /// <returns>Retorna true se for menor.</returns>
    public static bool LessThan( this int value, byte comparativeValue )
        => value < comparativeValue;

    /// <summary>
    /// Verifica se o value é menor que o value comTodor.
    /// </summary>
    /// <Param name="value">value principal.</Param>
    /// <Param name="comparativeValue">value a ser comTodo.</Param>
    /// <returns>Retorna true se for menor.</returns>
    public static bool LessThan( this int value, char comparativeValue )
        => value < comparativeValue;

    /// <summary>
    /// Verifica se o value é menor que o value comTodor.
    /// </summary>
    /// <Param name="value">value principal.</Param>
    /// <Param name="comparativeValue">value a ser comTodo.</Param>
    /// <returns>Retorna true se for menor.</returns>
    public static bool LessThan( this int value, decimal comparativeValue )
        => value < comparativeValue;

    /// <summary>
    /// Verifica se o value é menor que o value comTodor.
    /// </summary>
    /// <Param name="value">value principal.</Param>
    /// <Param name="comparativeValue">value a ser comTodo.</Param>
    /// <returns>Retorna true se for menor.</returns>
    public static bool LessThan( this int value, double comparativeValue )
        => value < comparativeValue;

    /// <summary>
    /// Verifica se o value é menor que o value comTodor.
    /// </summary>
    /// <Param name="value">value principal.</Param>
    /// <Param name="comparativeValue">value a ser comTodo.</Param>
    /// <returns>Retorna true se for menor.</returns>
    public static bool LessThan( this int value, float comparativeValue )
        => value < comparativeValue;

    /// <summary>
    /// Verifica se o value é menor que o value comTodor.
    /// </summary>
    /// <Param name="value">value principal.</Param>
    /// <Param name="comparativeValue">value a ser comTodo.</Param>
    /// <returns>Retorna true se for menor.</returns>
    public static bool LessThan( this int value, int comparativeValue )
        => value < comparativeValue;

    /// <summary>
    /// Verifica se o value é menor que o value comTodor.
    /// </summary>
    /// <Param name="value">value principal.</Param>
    /// <Param name="comparativeValue">value a ser comTodo.</Param>
    /// <returns>Retorna true se for menor.</returns>
    public static bool LessThan( this int value, long comparativeValue )
        => value < comparativeValue;

    /// <summary>
    /// Verifica se um value está na faixa Between dois números informados.
    /// </summary>
    /// <Param name="value">value a ser verificado.</Param>
    /// <Param name="menorValor">Menor value da faixa.</Param>
    /// <Param name="highestValue">Maior value da faixa.</Param>
    /// <returns>Retorna true se estives.</returns>
    public static bool Between( this int value, int lowestValue, int highestValue, bool inclusive = true )
    {
        if ( inclusive )
            return value >= lowestValue && value <= highestValue;

        return value > lowestValue && value < highestValue;
    }
}