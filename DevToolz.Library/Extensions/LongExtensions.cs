namespace DevToolz.Library.Extensions;

public static class LongExtensions
{
    public static char ToChar( this long valor )
    {
        if ( valor.Between( 0, 10 ) )
            throw new ArgumentException( "Valor informado não é um número. Valor deve ser um número de 0 à 9." );

        return valor.ToString().ToChar();
    }

    public static decimal ToDecimal( this long valor )
        => valor;

    public static decimal BitToByte( this long valor )
        => Math.Round( valor.ToDecimal() / 8, 2 );

    public static decimal BitToKiloByte( this long valor )
        => Math.Round( valor.ToDecimal() / 8000, 2 );

    public static decimal BitToMegaBytes( this long valor )
        => Math.Round( valor.ToDecimal() / 8000000, 2 );

    public static decimal BitToGigaBytes( this long valor )
        => Math.Round( valor.ToDecimal() / 8000000000, 2 );

    public static decimal ByteToBit( this long valor )
        => Math.Round( valor.ToDecimal() * 8, 2 );

    public static decimal ByteToKiloByte( this long valor )
        => Math.Round( valor.ToDecimal() / 1000, 2 );

    public static decimal ByteToMegaByte( this long valor )
        => Math.Round( valor.ToDecimal() / 1000000, 2 );

    public static decimal ByteToGigaByte( this long valor )
        => Math.Round( valor.ToDecimal() / 1000000000, 2 );

    public static decimal KiloByteToBit( this long valor )
        => Math.Round( valor.ToDecimal() * 8000, 2 );

    public static decimal KiloToToByte( this long valor )
        => Math.Round( valor.ToDecimal() * 1000, 2 );

    public static decimal KiloByteToMegaByte( this long valor )
        => Math.Round( valor.ToDecimal() / 1000, 2 );

    public static decimal KiloByteToGigaByte( this long valor )
        => Math.Round( valor.ToDecimal() / 1000000, 2 );

    public static decimal MegaByteToBit( this long valor )
        => Math.Round( valor.ToDecimal() * 8000000, 2 );

    public static decimal MegaByteToByte( this long valor )
        => Math.Round( valor.ToDecimal() * 1000000, 2 );

    public static decimal MegaByteToKiloByte( this long valor )
        => Math.Round( valor.ToDecimal() * 1000, 2 );

    public static decimal MegaByteToGigaByte( this long valor )
        => Math.Round( valor.ToDecimal() / 1000, 2 );

    public static decimal GigaByteToBit( this long valor )
        => Math.Round( valor.ToDecimal() * 8000000000, 2 );

    public static decimal GigaByteToByte( this long valor )
        => Math.Round( valor.ToDecimal() * 1000000000, 2 );

    public static decimal GigaByteToKiloByte( this long valor )
        => Math.Round( valor.ToDecimal() * 1000000, 2 );

    public static decimal GigaByteToMegaByte( this long valor )
        => Math.Round( valor.ToDecimal() * 1000, 2 );

    /// <summary>
    /// Verifica se um valor está na faixa Between dois números informados.
    /// </summary>
    /// <Param name="valor">Valor a ser verificado.</Param>
    /// <Param name="lowestValue">Menor valor da faixa.</Param>
    /// <Param name="highestValue">Maior valor da faixa.</Param>
    /// <returns>Retorna true se estives.</returns>
    public static bool Between( this long valor, long lowestValue, long highestValue, bool inclusive = true )
    {
        if ( inclusive )
            return valor >= lowestValue && valor <= highestValue;

        return valor > lowestValue && valor < highestValue;
    }
}