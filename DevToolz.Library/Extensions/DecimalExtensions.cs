namespace DevToolz.Library.Extensions;

public static class DecimalExtensions
{
    /// <summary>
    /// Converte um decimal To bool.
    /// </summary>
    /// <Param name="value">value decimal.</Param>
    /// <returns>Retorna um value bool.</returns>
    public static bool ToBoolean( this decimal value )
        => Math.Abs( value ).IsEqual( 1 );

    /// <summary>
    /// Converte um double To byte.
    /// </summary>
    /// <Param name="value">value double.</Param>
    /// <returns>Retorn um value byte.</returns>
    public static byte ToByte( this decimal value )
    {
        if ( value > byte.MaxValue )
            return byte.MaxValue;
        else if ( value < byte.MinValue )
            return byte.MinValue;

        return ToByte( value.ToInt() );
    }

    /// <summary>
    /// Converte de byte To char.
    /// </summary>
    /// <Param name="value">value aue será convertido.</Param>
    /// <returns>Retorna um value do tipo char.</returns>
    public static char ToChar( this decimal value )
    {
        if ( value.Between( 0, 10 ) )
            throw new ArgumentException( "value informado não é um número. value deve ser um número de 0 à 9." );

        return value.ToString().ToChar();
    }

    public static double ToDouble( this decimal value )
        => ( double ) value;

    public static float ToFloat( this decimal value )
        => ( float ) value;

    public static int ToInt( this decimal value )
    {
        if ( value == 0 )
            return 0;

        if ( value > int.MaxValue )
            value = decimal.MaxValue - 0.1m;
        else if ( value < int.MinValue )
            value = decimal.MinValue + 0.1m;

        if ( value < int.MaxValue && value > 0 )
        {
            int resultado = ( int ) value;
            decimal diferenca = value - resultado;

            if ( Math.Round( diferenca, 1 ) > 0.4m /*&& (resultado & 1) != 0*/)
                resultado++;

            return resultado;
        }

        if ( value > int.MinValue && value < 0 )
        {
            int resultado = ( int ) value;
            decimal diferenca = value - resultado;

            if ( Math.Round( diferenca, 1 ) > -0.4m /*&& (resultado & 1) != 0*/)
                resultado--;

            return resultado;
        }

        throw new OverflowException( "Não foi possível fazer a conversão To decimal." );
    }

    /// <summary>
    /// Converte de decimal To long.
    /// </summary>
    /// <Param name="value">value a ser convertido.</Param>
    /// <returns>Retorna um value do tipo long.</returns>
    public static long ToLong( this decimal value )
    {
        if ( value > long.MaxValue )
            value = long.MaxValue - 1;
        else if ( value < long.MinValue )
            value = long.MinValue + 1;

        if ( value < long.MaxValue && value > 0 )
        {
            long resultado = ( long ) value;
            decimal diferenca = value - resultado;

            if ( Math.Round( diferenca, 1 ) > 0.4m /*&& (resultado & 1) != 0*/)
                resultado++;

            return resultado;
        }

        if ( value > long.MinValue && value < 0 )
        {
            long resultado = ( long ) value;
            decimal diferenca = value - resultado;

            if ( Math.Round( diferenca, 1 ) > -0.4m /*&& (resultado & 1) != 0*/)
                resultado--;

            return resultado;
        }

        throw new OverflowException( "Não foi possível fazer a conversão To double." );
    }

    /// <summary>
    /// Converte um value double To o tipo short.
    /// </summary>
    /// <Param name="value">value a ser convertido.</Param>
    /// <returns>Retorna um value do tipo short.</returns>
    public static short ToShort( this decimal value )
    {
        if ( value > short.MaxValue )
            value = short.MaxValue - 1;
        else if ( value < short.MinValue )
            value = short.MinValue + 1;

        if ( value < short.MaxValue && value > 0 )
        {
            short resultado = ( short ) value;
            decimal diferenca = value - resultado;

            if ( Math.Round( diferenca, 1 ) > 0.4m /*&& (resultado & 1) != 0*/)
                resultado++;

            return resultado;
        }

        if ( value > short.MinValue && value < 0 )
        {
            short resultado = ( short ) value;
            decimal diferenca = value - resultado;

            if ( Math.Round( diferenca, 1 ) > -0.4m /*&& (resultado & 1) != 0*/)
                resultado--;

            return resultado;
        }

        throw new OverflowException( "Não foi possível fazer a conversão To double." );
    }

    public static TEnum ToEnum<TEnum>( this decimal value )
    {
        var type = typeof( TEnum );

        if ( !type.IsEnum )
            throw new ArgumentException( "Tipo informado não é enum." );

        return ( TEnum ) Enum.Parse( type, value.ToString() );
    }

    /// <summary>
    /// Verifica se um value está na faixa Between dois números informados.
    /// </summary>
    /// <Param name="value">value a ser verificado.</Param>
    /// <Param name="menorvalue">Menor value da faixa.</Param>
    /// <Param name="maiorvalue">Maior value da faixa.</Param>
    /// <returns>Retorna true se estives.</returns>
    public static bool Between( this decimal value, decimal menorvalue, decimal maiorvalue, bool inclusivo = true )
    {
        if ( inclusivo )
            return value >= menorvalue && value <= maiorvalue;

        return value > menorvalue && value < maiorvalue;
    }

    public static bool IsEqual( this decimal value, decimal valueComTotivo )
        => value == valueComTotivo;

    /// <summary>
    /// Converte um value decimal To TimeSpan.
    /// </summary>
    /// <Param name="value">value que será convertido.</Param>
    /// <returns>Retorna um value do tipo TimeSpan.</returns>
    public static TimeSpan ToTimeSpan( this decimal value )
    {
        var decimalMinutes = value - value.ToInt();
        var minutes = decimalMinutes * 60;
        var decimalSeconds = minutes - minutes.ToInt();
        var seconds = Math.Round( decimalSeconds * 60, 0 );

        return new TimeSpan( value.ToInt(), minutes.ToInt(), seconds.ToInt() );
    }
}