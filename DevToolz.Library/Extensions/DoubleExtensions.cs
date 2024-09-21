namespace DevToolz.Library.Extensions;

public static class DoubleExtensions
{
    /// <summary>
    /// Converte um double To bool.
    /// </summary>
    /// <Param name="value">value double.</Param>
    /// <returns>Retorna um value bool.</returns>
    public static bool ToBoolean( this double value )
        => Math.Abs( value ).IsEqual( 1 );

    /// <summary>
    /// Converte um double To byte.
    /// </summary>
    /// <Param name="value">value double.</Param>
    /// <returns>Retorn um value byte.</returns>
    public static byte ToByte( this double value )
    {
        if ( value > byte.MaxValue )
            return byte.MaxValue;
        else if ( value < byte.MinValue )
            return byte.MinValue;

        return value.ToInt().ToByte();
    }

    /// <summary>
    /// Converte de double To char.
    /// </summary>
    /// <Param name="value">value aue será convertido.</Param>
    /// <returns>Retorna um value do tipo char.</returns>
    public static char ToChar( this double value )
    {
        if ( value.Between( 0, 10 ) )
            throw new ArgumentException( "value informado não é um número. value deve ser um número de 0 à 9." );

        return value.ToString()
                    .ToChar();
    }

    /// <summary>
    /// Converte decimal To booleano.
    /// </summary>
    /// <Param name="value">value a ser convertido.</Param>
    /// <returns>Retorna um value decimal.</returns>
    public static decimal ToDecimal( this double value )
        => ( decimal ) value;

    public static float ToFloat( this double value )
        => ( float ) value;

    public static int ToInt( this double value )
    {
        if ( value == 0 )
            return 0;

        if ( value > int.MaxValue )
            value = int.MaxValue;
        else if ( value < int.MinValue )
            value = int.MinValue;

        if ( value < int.MaxValue && value > 0 )
        {
            int resultado = ( int ) value;
            double diferenca = value - resultado;

            if ( Math.Round( diferenca, 1 ) > 0.4 /*&& (resultado & 1) != 0*/)
                resultado++;

            return resultado;
        }

        if ( value > int.MinValue && value < 0 )
        {
            int resultado = ( int ) value;
            double diferenca = value - resultado;

            if ( Math.Round( diferenca, 1 ) > -0.4 /*&& (resultado & 1) != 0*/)
                resultado--;

            return resultado;
        }

        throw new OverflowException( "Não foi possível fazer a conversão To double." );
    }

    /// <summary>
    /// Converte de double To long.
    /// </summary>
    /// <Param name="value">value a ser convertido.</Param>
    /// <returns>Retorna um value do tipo long.</returns>
    public static long ToLong( this double value )
    {
        if ( value > long.MaxValue )
            value = long.MaxValue;
        else if ( value < long.MinValue )
            value = long.MinValue;

        if ( value < long.MaxValue && value > 0 )
        {
            long resultado = ( long ) value;
            double diferenca = value - resultado;

            if ( Math.Round( diferenca, 1 ) > 0.4 /*&& (resultado & 1) != 0*/)
                resultado++;

            return resultado;
        }

        if ( value > long.MinValue && value < 0 )
        {
            long resultado = ( long ) value;
            double diferenca = value - resultado;

            if ( Math.Round( diferenca, 1 ) > -0.4 /*&& (resultado & 1) != 0*/)
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
    public static short ToShort( this double value )
    {
        if ( value > short.MaxValue )
            value = short.MaxValue;
        else if ( value < short.MinValue )
            value = short.MinValue;

        if ( value < short.MaxValue && value > 0 )
        {
            short resultado = ( short ) value;
            double diferenca = value - resultado;

            if ( Math.Round( diferenca, 1 ) > 0.4 /*&& (resultado & 1) != 0*/)
                resultado++;

            return resultado;
        }

        if ( value > short.MinValue && value < 0 )
        {
            short resultado = ( short ) value;
            double diferenca = value - resultado;

            if ( Math.Round( diferenca, 1 ) > -0.4 /*&& (resultado & 1) != 0*/)
                resultado--;

            return resultado;
        }

        throw new OverflowException( "Não foi possível fazer a conversão To double." );
    }

    public static TEnum ToEnum<TEnum>( this double value )
    {
        Type tipo = typeof( TEnum );

        if ( !tipo.IsEnum )
            throw new ArgumentException( "Tipo informado não é enum." );

        return ( TEnum ) Enum.Parse( tipo, value.ToString() );
    }

    /// <summary>
    /// Verifica se um value está na faixa Between dois números informados.
    /// </summary>
    /// <Param name="value">value a ser verificado.</Param>
    /// <Param name="menorValor">Menor value da faixa.</Param>
    /// <Param name="maiorValor">Maior value da faixa.</Param>
    /// <returns>Retorna true se estives.</returns>
    public static bool Between( this double value, double menorValor, double maiorValor, bool inclusivo = true )
    {
        if ( inclusivo )
            return value >= menorValor && value <= maiorValor;

        return value > menorValor && value < maiorValor;
    }

    public static bool IsEqual( this double value, decimal comTotiveValue )
        => value == comTotiveValue.ToDouble();

    public static bool IsEqual( this double value, double comTotiveValue )
        => value == comTotiveValue;

    public static bool IsEqual( this double value, int comTotiveValue )
        => value == comTotiveValue;
}