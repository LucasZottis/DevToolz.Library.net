namespace DevToolz.Library.Test.Extensions;

public class DateTimeExtensionsTests
{
    [Fact]
    public void FirstDayOfTheWeek_Sunday_ReturnsSameDay()
    {
        var sunday = new DateTime( 2024, 3, 3 ); // domingo
        var result = sunday.FirstDayOfTheWeek();
        Assert.Equal( sunday.Date, result.Date );
    }

    [Fact]
    public void FirstDayOfTheWeek_Wednesday_ReturnsSundayOfSameWeek()
    {
        var wednesday = new DateTime( 2024, 3, 6 ); // quarta
        var expectedSunday = new DateTime( 2024, 3, 3 );
        var result = wednesday.FirstDayOfTheWeek();
        Assert.Equal( expectedSunday.Date, result.Date );
    }

    [Fact]
    public void FirstDayOfTheWeek_Saturday_ReturnsSundayOfSameWeek()
    {
        var saturday = new DateTime( 2024, 3, 9 ); // sábado
        var expectedSunday = new DateTime( 2024, 3, 3 );
        var result = saturday.FirstDayOfTheWeek();
        Assert.Equal( expectedSunday.Date, result.Date );
    }

    [Fact]
    public void FirstDayOfTheWeek_UsesValueNotNow()
    {
        var pastDate = new DateTime( 2020, 1, 6 ); // segunda-feira
        var result = pastDate.FirstDayOfTheWeek();
        Assert.Equal( new DateTime( 2020, 1, 5 ).Date, result.Date );
    }

    [Fact]
    public void LastDayOfTheWeek_Sunday_ReturnsSaturdayOfSameWeek()
    {
        var sunday = new DateTime( 2024, 3, 3 );
        var expectedSaturday = new DateTime( 2024, 3, 9 );
        var result = sunday.LastDayOfTheWeek();
        Assert.Equal( expectedSaturday.Date, result.Date );
    }

    [Fact]
    public void LastDayOfTheWeek_Saturday_ReturnsSameDay()
    {
        var saturday = new DateTime( 2024, 3, 9 );
        var result = saturday.LastDayOfTheWeek();
        Assert.Equal( saturday.Date, result.Date );
    }

    [Fact]
    public void LastDayOfTheWeek_Monday_ReturnsSaturdayOfSameWeek()
    {
        var monday = new DateTime( 2024, 3, 4 );
        var expectedSaturday = new DateTime( 2024, 3, 9 );
        var result = monday.LastDayOfTheWeek();
        Assert.Equal( expectedSaturday.Date, result.Date );
    }

    [Fact]
    public void LastDayOfTheWeek_UsesValueNotNow()
    {
        var pastDate = new DateTime( 2020, 1, 8 ); // quarta-feira
        var result = pastDate.LastDayOfTheWeek();
        Assert.Equal( new DateTime( 2020, 1, 11 ).Date, result.Date );
    }

    [Fact]
    public void FirstDayOfTheMonth_ReturnsFirstDay()
    {
        var date = new DateTime( 2024, 5, 15 );
        var result = date.FirstDayOfTheMonth();
        Assert.Equal( new DateTime( 2024, 5, 1 ), result );
    }

    [Fact]
    public void LastDayOfTheMonth_ReturnsLastDay()
    {
        Assert.Equal( new DateTime( 2024, 2, 29 ), new DateTime( 2024, 2, 10 ).LastDayOfTheMonth() );
        Assert.Equal( new DateTime( 2024, 1, 31 ), new DateTime( 2024, 1, 1 ).LastDayOfTheMonth() );
        Assert.Equal( new DateTime( 2024, 4, 30 ), new DateTime( 2024, 4, 15 ).LastDayOfTheMonth() );
    }

    [Fact]
    public void GetStartDateOfDayFromDate_ReturnsMidnight()
    {
        var date = new DateTime( 2024, 6, 10, 14, 30, 45 );
        var result = date.GetStartDateOfDayFromDate();
        Assert.Equal( new DateTime( 2024, 6, 10, 0, 0, 0 ), result );
    }

    [Fact]
    public void GetEndDateOfDayFromDate_ReturnsEndOfDay()
    {
        var date = new DateTime( 2024, 6, 10, 8, 0, 0 );
        var result = date.GetEndDateOfDayFromDate();
        Assert.Equal( new DateTime( 2024, 6, 10, 23, 59, 59 ), result );
    }
}
