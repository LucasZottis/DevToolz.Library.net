namespace DevToolz.Library.Extensions;

public static class ByteExtensions
{
    #region Conversões

    /// <summary>
    /// Converte de byte To char.
    /// </summary>
    /// <Param name="value">value aue será convertido.</Param>
    /// <returns>Retorna um value do tipo char.</returns>
    public static char ToChar( this byte value )
    {
        if ( !value.Between( 0, 10 ) )
            throw new ArgumentException( "Valor informado não é um número. value deve ser um número de 0 à 9." );

        return value.ToString().ToChar();
    }

    /// <summary>
    /// Converte um byte To bool.
    /// </summary>
    /// <Param name="value">value byte.</Param>
    /// <returns>Retorna um value bool.</returns>
    public static bool ToBoolean( this byte value )
    {
        return value == 1;
    }

    /// <summary>
    /// Converte decimal To booleano.
    /// </summary>
    /// <Param name="value">value a ser convertido.</Param>
    /// <returns>Retorna um value decimal.</returns>
    public static decimal ToDecimal( this byte value )
    {
        return value;
    }

    public static double ToDouble( this byte value )
    {
        return value;
    }

    public static float ToFloat( this byte value )
    {
        return value;
    }

    public static int ToInt( this byte value )
    {
        return value;
    }

    /// <summary>
    /// Converte de byte To long.
    /// </summary>
    /// <Param name="value">value a ser convertido.</Param>
    /// <returns>Retorna um value do tipo long.</returns>
    public static long ToLong( this byte value )
    {
        return value;
    }

    /// <summary>
    /// Converte um value byte To short.
    /// </summary>
    /// <Param name="value">value a ser convertido.</Param>
    /// <returns>Retorna um value do tipo short.</returns>
    public static short ToShort( this byte value )
    {
        return value;
    }

    public static TEnum ToEnum<TEnum>( this byte value )
    {
        Type tipo = typeof( TEnum );

        if ( !tipo.IsEnum )
            throw new ArgumentException( "Tipo informado não é enum." );

        return ( TEnum ) Enum.Parse( tipo, value.ToString() );
    }

    public static decimal BitToByte( this byte value )
    {
        return Math.Round( value.ToDecimal() / 8, 2 );
    }

    public static decimal BitToKiloByte( this byte value )
    {
        return Math.Round( value.ToDecimal() / 8000, 2 );
    }

    public static decimal BitToMegaBytes( this byte value )
    {
        return Math.Round( value.ToDecimal() / 8000000, 2 );
    }

    public static decimal BitToGigaBytes( this byte value )
    {
        return Math.Round( value.ToDecimal() / 8000000000, 2 );
    }

    public static decimal ByteToBit( this byte value )
    {
        return Math.Round( value.ToDecimal() * 8, 2 );
    }

    public static decimal ByteToKiloByte( this byte value )
    {
        return Math.Round( value.ToDecimal() / 1000, 2 );
    }

    public static decimal ByteToMegaByte( this byte value )
    {
        return Math.Round( value.ToDecimal() / 1000000, 2 );
    }

    public static decimal ByteToGigaByte( this byte value )
    {
        return Math.Round( value.ToDecimal() / 1000000000, 2 );
    }

    public static decimal KiloByteToBit( this byte value )
    {
        return Math.Round( value.ToDecimal() * 8000, 2 );
    }

    public static decimal KiloByteToByte( this byte value )
    {
        return Math.Round( value.ToDecimal() * 1000, 2 );
    }

    public static decimal KiloByteToMegaByte( this byte value )
    {
        return Math.Round( value.ToDecimal() / 1000, 2 );
    }

    public static decimal KiloByteToGigaByte( this byte value )
    {
        return Math.Round( value.ToDecimal() / 1000000, 2 );
    }

    public static decimal MegaByteToBit( this byte value )
    {
        return Math.Round( value.ToDecimal() * 8000000, 2 );
    }

    public static decimal MegaByteToByte( this byte value )
    {
        return Math.Round( value.ToDecimal() * 1000000, 2 );
    }

    public static decimal MegaByteToKiloByte( this byte value )
    {
        return Math.Round( value.ToDecimal() * 1000, 2 );
    }

    public static decimal MegaByteToGigaByte( this byte value )
    {
        return Math.Round( value.ToDecimal() / 1000, 2 );
    }

    public static decimal GigaByteToBit( this byte value )
    {
        return Math.Round( value.ToDecimal() * 8000000000, 2 );
    }

    public static decimal GigaByteToByte( this byte value )
    {
        return Math.Round( value.ToDecimal() * 1000000000, 2 );
    }

    public static decimal GigaByteToKiloByte( this byte value )
    {
        return Math.Round( value.ToDecimal() * 1000000, 2 );
    }

    public static decimal GigaByteToMegaByte( this byte value )
    {
        return Math.Round( value.ToDecimal() * 1000, 2 );
    }

    #endregion Conversões

    /// <summary>
    /// Verifica se um value é Equal ao outro.
    /// </summary>
    /// <Param name="value">Byte a ser verficado.</Param>
    /// <Param name="valueCompare">value comTodor.</Param>
    /// <returns>Retorna true se forem iguais.</returns>
    public static bool IsEqual( this byte value, byte valueCompare )
        => value == valueCompare;

    /// <summary>
    /// Verifica se um value é Equal ao outro.
    /// </summary>
    /// <Param name="value">Byte a ser verficado.</Param>
    /// <Param name="valueCompare">value comTodor.</Param>
    /// <returns>Retorna true se forem iguais.</returns>
    public static bool IsEqual( this byte value, char valueCompare )
        => value == valueCompare.ToByte();

    /// <summary>
    /// Verifica se um value é Equal ao outro.
    /// </summary>
    /// <Param name="value">Byte a ser verficado.</Param>
    /// <Param name="valueCompare">value comTodor.</Param>
    /// <returns>Retorna true se forem iguais.</returns>
    public static bool IsEqual( this byte value, double valueCompare )
        => value == valueCompare.ToByte();

    /// <summary>
    /// Verifica se um value é Equal ao outro.
    /// </summary>
    /// <Param name="value">Byte a ser verficado.</Param>
    /// <Param name="valueCompare">value comTodor.</Param>
    /// <returns>Retorna true se forem iguais.</returns>
    public static bool IsEqual( this byte value, float valueCompare )
        => value == valueCompare.ToByte();

    /// <summary>
    /// Verifica se um value é Equal ao outro.
    /// </summary>
    /// <Param name="value">Byte a ser verficado.</Param>
    /// <Param name="valueCompare">value comTodor.</Param>
    /// <returns>Retorna true se forem iguais.</returns>
    public static bool IsEqual( this byte value, int valueCompare )
        => value == valueCompare.ToByte();

    /// <summary>
    /// Verifica se um value é Equal ao outro.
    /// </summary>
    /// <Param name="value">Byte a ser verficado.</Param>
    /// <Param name="valueCompare">value comTodor.</Param>
    /// <returns>Retorna true se forem iguais.</returns>
    public static bool IsEqual( this byte value, string valueCompare )
        => value == valueCompare.ToByte();

    /// <summary>
    /// Verifica se um value é Equal ao outro.
    /// </summary>
    /// <Param name="value">Byte a ser verficado.</Param>
    /// <Param name="valueCompare">value comTodor.</Param>
    /// <returns>Retorna true se forem iguais.</returns>
    public static bool IsNotEqual( this byte value, byte valueCompare )
        => value != valueCompare;

    /// <summary>
    /// Verifica se um value é NotEqual do outro.
    /// </summary>
    /// <Param name="value">Byte a ser verficado.</Param>
    /// <Param name="valueCompare">value comTodor.</Param>
    /// <returns>Retorna true se forem diferentes.</returns>
    public static bool IsNotEqual( this byte value, char valueCompare )
        => value != valueCompare.ToByte();

    /// <summary>
    /// Verifica se um value é NotEqual do outro.
    /// </summary>
    /// <Param name="value">Byte a ser verficado.</Param>
    /// <Param name="valueCompare">value comTodor.</Param>
    /// <returns>Retorna true se forem diferentes.</returns>
    public static bool IsNotEqual( this byte value, double valueCompare )
        => value != valueCompare.ToByte();

    /// <summary>
    /// Verifica se um value é NotEqual do outro.
    /// </summary>
    /// <Param name="value">Byte a ser verficado.</Param>
    /// <Param name="valueCompare">value comTodor.</Param>
    /// <returns>Retorna true se forem diferentes.</returns>
    public static bool IsNotEqual( this byte value, float valueCompare )
        => value != valueCompare.ToByte();

    /// <summary>
    /// Verifica se um value é NotEqual do outro.
    /// </summary>
    /// <Param name="value">Byte a ser verficado.</Param>
    /// <Param name="valueCompare">value comTodor.</Param>
    /// <returns>Retorna true se forem diferentes.</returns>
    public static bool IsNotEqual( this byte value, int valueCompare )
        => value != valueCompare.ToByte();

    /// <summary>
    /// Verifica se um value é NotEqual do outro.
    /// </summary>
    /// <Param name="value">Byte a ser verficado.</Param>
    /// <Param name="valueCompare">value comTodor.</Param>
    /// <returns>Retorna true se forem diferentes.</returns>
    public static bool IsNotEqual( this byte value, string valueCompare )
        => value != valueCompare.ToByte();

    /// <summary>
    /// Verifica se o value é maior que o value comTodor.
    /// </summary>
    /// <Param name="value">value principal.</Param>
    /// <Param name="valueCompare">value a ser comTodo.</Param>
    /// <returns>Retorna true se for maior.</returns>
    public static bool GreaterThan( this byte value, byte valueCompare )
        => value > valueCompare;

    /// <summary>
    /// Verifica se o value é maior que o value comTodor.
    /// </summary>
    /// <Param name="value">value principal.</Param>
    /// <Param name="valueCompare">value a ser comTodo.</Param>
    /// <returns>Retorna true se for maior.</returns>
    public static bool GreaterThan( this byte value, decimal valueCompare )
        => value > valueCompare;

    /// <summary>
    /// Verifica se o value é maior que o value comTodor.
    /// </summary>
    /// <Param name="value">value principal.</Param>
    /// <Param name="valueCompare">value a ser comTodo.</Param>
    /// <returns>Retorna true se for maior.</returns>
    public static bool GreaterThan( this byte value, double valueCompare )
        => value > valueCompare;

    /// <summary>
    /// Verifica se o value é maior que o value comTodor.
    /// </summary>
    /// <Param name="value">value principal.</Param>
    /// <Param name="valueCompare">value a ser comTodo.</Param>
    /// <returns>Retorna true se for maior.</returns>
    public static bool GreaterThan( this byte value, float valueCompare )
        => value > valueCompare;

    /// <summary>
    /// Verifica se o value é maior que o value comTodor.
    /// </summary>
    /// <Param name="value">value principal.</Param>
    /// <Param name="valueCompare">value a ser comTodo.</Param>
    /// <returns>Retorna true se for maior.</returns>
    public static bool GreaterThan( this byte value, int valueCompare )
        => value > valueCompare;

    /// <summary>
    /// Verifica se o value é maior que o value comTodor.
    /// </summary>
    /// <Param name="value">value principal.</Param>
    /// <Param name="valueCompare">value a ser comTodo.</Param>
    /// <returns>Retorna true se for maior.</returns>
    public static bool GreaterThan( this byte value, long valueCompare )
        => value > valueCompare;

    /// <summary>
    /// Verifica se o value é menor que o value comTodor.
    /// </summary>
    /// <Param name="value">value principal.</Param>
    /// <Param name="valueCompare">value a ser comTodo.</Param>
    /// <returns>Retorna true se for menor.</returns>
    public static bool LessThan( this byte value, byte valueCompare )
        => value < valueCompare;

    /// <summary>
    /// Verifica se o value é menor que o value comTodor.
    /// </summary>
    /// <Param name="value">value principal.</Param>
    /// <Param name="valueCompare">value a ser comTodo.</Param>
    /// <returns>Retorna true se for menor.</returns>
    public static bool LessThan( this byte value, decimal valueCompare )
        => value < valueCompare;

    /// <summary>
    /// Verifica se o value é menor que o value comTodor.
    /// </summary>
    /// <Param name="value">value principal.</Param>
    /// <Param name="valueCompare">value a ser comTodo.</Param>
    /// <returns>Retorna true se for menor.</returns>
    public static bool LessThan( this byte value, double valueCompare )
        => value < valueCompare;

    /// <summary>
    /// Verifica se o value é menor que o value comTodor.
    /// </summary>
    /// <Param name="value">value principal.</Param>
    /// <Param name="valueCompare">value a ser comTodo.</Param>
    /// <returns>Retorna true se for menor.</returns>
    public static bool LessThan( this byte value, float valueCompare )
        => value < valueCompare;

    /// <summary>
    /// Verifica se o value é menor que o value comTodor.
    /// </summary>
    /// <Param name="value">value principal.</Param>
    /// <Param name="valueCompare">value a ser comTodo.</Param>
    /// <returns>Retorna true se for menor.</returns>
    public static bool LessThan( this byte value, int valueCompare )
        => value < valueCompare;

    /// <summary>
    /// Verifica se o value é menor que o value comTodor.
    /// </summary>
    /// <Param name="value">value principal.</Param>
    /// <Param name="valueCompare">value a ser comTodo.</Param>
    /// <returns>Retorna true se for menor.</returns>
    public static bool LessThan( this byte value, long valueCompare )
        => value < valueCompare;

    /// <summary>
    /// Verifica se um value está na faixa Between dois números informados.
    /// </summary>
    /// <Param name="value">value a ser verificado.</Param>
    /// <Param name="menorValor">Menor value da faixa.</Param>
    /// <Param name="maiorValor">Maior value da faixa.</Param>
    /// <returns>Retorna true se estives.</returns>
    public static bool Between( this byte value, byte lowerValue, byte highestValue, bool inclusive = true )
    {
        if ( inclusive )
            return value >= lowerValue && value <= highestValue;

        return value > lowerValue && value < highestValue;
    }
}