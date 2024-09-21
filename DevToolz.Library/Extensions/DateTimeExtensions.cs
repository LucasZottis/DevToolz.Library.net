using DevToolz.Library.Enums;
using System.Globalization;

namespace DevToolz.Library.Extensions;

public static class DateTimeExtensions
{
    private static string ToStringFullDataBaseFormat( this DateTime value )
        => value.ToString( "yyyy-MM-dd HH:mm:ss" );

    private static string ToStringShortDataBaseFormat( this DateTime value )
        => value.ToString( "yyyy-MM-dd" );

    private static string ToStringFullLocaleFormat( this DateTime value )
        => value.ToString( CultureInfo.CurrentCulture );

    private static string ToStringShortFormat( this DateTime value )
        => value.ToString( "dd/MM/yyyy" );

    public static DateTime FirstDayOfTheWeek( this DateTime value )
        => DateTime.Now.AddDays( ( byte ) value.DayOfWeek * -1 );

    public static DateTime LastDayOfTheWeek( this DateTime value )
    {
        switch ( value.DayOfWeek )
        {
            case DayOfWeek.Sunday:
                return DateTime.Now.AddDays( 6 );
            case DayOfWeek.Monday:
                return DateTime.Now.AddDays( 5 );
            case DayOfWeek.Tuesday:
                return DateTime.Now.AddDays( 4 );
            case DayOfWeek.Wednesday:
                return DateTime.Now.AddDays( 3 );
            case DayOfWeek.Thursday:
                return DateTime.Now.AddDays( 2 );
            case DayOfWeek.Friday:
                return DateTime.Now.AddDays( 1 );
            case DayOfWeek.Saturday:
            default:
                return DateTime.Now.AddDays( 0 );
        }
    }

    public static DateTime FirstDayOfTheMonth( this DateTime value )
        => new DateTime( value.Year, value.Month, 1 );

    public static DateTime LastDayOfTheMonth( this DateTime value )
    {
        var daysInMonth = DateTime.DaysInMonth( value.Year, value.Month );
        return new DateTime( value.Year, value.Month, daysInMonth );
    }

    public static DateTime GetStartDateOfDayFromDate( this DateTime value )
        => new DateTime( value.Year, value.Month, value.Day, 0, 0, 0 );

    public static DateTime GetEndDateOfDayFromDate( this DateTime value )
        => new DateTime( value.Year, value.Month, value.Day, 23, 59, 59 );

    public static string ToStringFormat( this DateTime value, DateTimeFormat format )
    {
        switch ( format )
        {
            case DateTimeFormat.DateTimeDataBase:
                return value.ToStringFullDataBaseFormat();
            case DateTimeFormat.DateOnlyDataBse:
                return value.ToStringShortDataBaseFormat();
            case DateTimeFormat.DateTime:
                return value.ToStringFullLocaleFormat();
            case DateTimeFormat.DateOnly:
                return value.ToStringShortFormat();
        }

        return "";
    }
}