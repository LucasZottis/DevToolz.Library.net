namespace DevToolz.Library.Extensions;

public static class FloatExtensions
{
    /// <summary>
    /// Converte um float To bool.
    /// </summary>
    /// <Param name="value">value float.</Param>
    /// <returns>Retorna um value bool.</returns>
    public static bool ToBoolean( this float value )
        => Math.Abs( value ).IsEqual( 1 );

    /// <summary>
    /// Converte um float To byte.
    /// </summary>
    /// <Param name="value">value float.</Param>
    /// <returns>Retorna um value byte.</returns>
    public static byte ToByte( this float value )
    {
        if ( value > byte.MaxValue )
            return byte.MaxValue;
        else if ( value < byte.MinValue )
            return byte.MinValue;

        return value.ToInt().ToByte();
    }

    /// <summary>
    /// Converte de float To char.
    /// </summary>
    /// <Param name="value">value aue será convertido.</Param>
    /// <returns>Retorna um value do tipo char.</returns>
    public static char ToChar( this float value )
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
    public static decimal ToDecimal( this float value )
        => ( decimal ) value;

    public static double ToDouble( this float value )
        => ( float ) value;

    public static TEnum ToEnum<TEnum>( this float value )
    {
        Type tipo = typeof( TEnum );

        if ( !tipo.IsEnum )
            throw new ArgumentException( "Tipo informado não é enum." );

        return ( TEnum ) Enum.Parse( tipo, value.ToString() );
    }

    public static int ToInt( this float value )
        => ( ( double ) value ).ToInt();

    /// <summary>
    /// Converte de float To long.
    /// </summary>
    /// <Param name="value">value a ser convertido.</Param>
    /// <returns>Retorna um value do tipo long.</returns>
    public static long ToLong( this float value )
        => ( ( double ) value ).ToLong();

    /// <summary>
    /// Converte um value do float To o tipo short.
    /// </summary>
    /// <Param name="value">value a ser convertido.</Param>
    /// <returns>Retorna um value do tipo short.</returns>
    public static short ToShort( this float value )
        => ( ( double ) value ).ToShort();

    /// <summary>
    /// Verifica se um value está na faixa Between dois números informados.
    /// </summary>
    /// <Param name="value">value a ser verificado.</Param>
    /// <Param name="menorValor">Menor value da faixa.</Param>
    /// <Param name="maiorValor">Maior value da faixa.</Param>
    /// <returns>Retorna true se estives.</returns>
    public static bool Between( this float value, float menorValor, float maiorValor, bool inclusivo = true )
    {
        if ( inclusivo )
            return value >= menorValor && value <= maiorValor;

        return value > menorValor && value < maiorValor;
    }

    public static bool IsEqual( this float value, decimal comTotiveValue )
=> value == comTotiveValue.ToDouble();

    public static bool IsEqual( this float value, double comTotiveValue )
        => value == comTotiveValue;

    public static bool IsEqual( this float value, float comTotiveValue )
        => value == comTotiveValue;

    public static bool IsEqual( this float value, int comTotiveValue )
        => value == comTotiveValue;
}