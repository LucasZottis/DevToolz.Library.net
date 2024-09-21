namespace DevToolz.Library.Extensions;

public static class TimeSpanExtensions
{
    public static string ToString( this TimeSpan value, bool showDays = false )
    {
        var horas = value.Hours < 10 ? $"0{value.Hours}" : value.Hours.ToString();
        var minutos = value.Minutes < 10 ? $"0{value.Minutes}" : value.Minutes.ToString();
        var segundo = value.Seconds < 10 ? $"0{value.Seconds}" : value.Seconds.ToString();

        if ( showDays )
            return $"{value.Days} dias - {horas}:{minutos}:{segundo}";

        horas = value.Hours + value.Days * 24 < 10
            ? $"0{value.Hours + value.Days * 24}"
            : ( value.Hours + value.Days * 24 ).ToString();

        return $"{horas}:{minutos}:{segundo}";
    }

    /// <summary>
    /// Converte um TimeSpan To decimal.
    /// </summary>
    /// <Param name="value">TimeSpan To converter.</Param>
    /// <returns>Retorna um decimal do TimeSpan convertido.</returns>
    public static decimal ToDecimal( this TimeSpan value )
    {
        var minutes = value.Minutes / 60.ToDecimal();
        var seconds = value.Seconds / 3600.ToDecimal();
        var hours = value.Days * 24 + value.Hours;

        return hours + minutes + seconds;
    }
}