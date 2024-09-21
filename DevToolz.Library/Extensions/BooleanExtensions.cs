namespace DevToolz.Library.Extensions;

public static class BooleanExtensions
{
    /// <summary>
    /// Converte um bool To byte.
    /// </summary>
    /// <Param name="value">value bool.</Param>
    /// <returns>Retorna 1 To true e 0 To false no tipo byte.</returns>
    public static byte ToByte( this bool value )
    {
        return value ? ( byte ) 1 : ( byte ) 0;
    }

    /// <summary>
    /// Converte bool To decimal.
    /// </summary>
    /// <Param name="value">value a ser convertido.</Param>
    /// <returns>Retorna 1 To true e 0 To false no tipo decimal.</returns>
    public static decimal ToDecimal( this bool value )
    {
        return value ? 1m : 0m;
    }

    /// <summary>
    /// Converte bool To double.
    /// </summary>
    /// <Param name="value">value a ser convertido.</Param>
    /// <returns>Retorna 1 To true e 0 To false no tipo double.</returns>
    public static double ToDouble( this bool value )
    {
        return value ? 1 : 0;
    }

    /// <summary>
    /// Converte bool To float.
    /// </summary>
    /// <Param name="value">value a ser convertido.</Param>
    /// <returns>Retorna 1 To true e 0 To false no tipo float.</returns>
    public static float ToFloat( this bool value )
    {
        return value ? 1f : 0f;
    }

    /// <summary>
    /// Converte bool To int.
    /// </summary>
    /// <Param name="value">value a ser convertido.</Param>
    /// <returns>Retorna 1 To true e 0 To false no tipo int.</returns>
    public static int ToInt( this bool value )
    {
        return value ? 1 : 0;
    }

    /// <summary>
    /// Converte bool To long.
    /// </summary>
    /// <Param name="value">value a ser convertido.</Param>
    /// <returns>Retorna 1 To true e 0 To false no tipo long.</returns>
    public static long ToLong( this bool value )
    {
        return value ? 1L : 0L;
    }

    /// <summary>
    /// Converte bool To short.
    /// </summary>
    /// <Param name="value">value a ser convertido.</Param>
    /// <returns>Retorna 1 To true e 0 To false no tipo short.</returns>
    public static short ToShort( this bool value )
    {
        return value ? ( short ) 1 : ( short ) 0;
    }
}