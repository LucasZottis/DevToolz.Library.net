namespace DevToolz.Library.Test.Extensions;

public class StringExtensionsAdditionalTests
{
    //[Fact]
    //public void Contains_WithEmptyValue_ThrowsArgumentException()
    //{
    //    Assert.Throws<ArgumentException>( () => string.Empty.Contains( "a" ) );
    //}

    [Theory]
    [InlineData( "1", true )]
    [InlineData( "0", false )]
    public void ToBoolean_ParsesCommonValues( string input, bool expected )
    {
        Assert.Equal( expected, input.ToBoolean() );
    }

    [Fact]
    public void IsAllNumbers_ReturnsFalseForAlphaNumeric()
    {
        Assert.True( "123456".IsAllNumbers() );
        Assert.False( "123a56".IsAllNumbers() );
    }
}
