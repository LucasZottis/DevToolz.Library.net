namespace DevToolz.Library.Test.Extensions;

public class ArrayExtensionsTests
{
    [Fact]
    public void ForEach_WithIntArray_ExecutesActionForEachElement()
    {
        // Arrange
        Array numbers = new int[] { 1, 2, 3 };
        var result = new List<int>();

        // Act
        numbers.ForEach<int>( value => result.Add( value ) );

        // Assert
        Assert.Equal( new List<int> { 1, 2, 3 }, result );
    }

    [Fact]
    public void ToList_WithStringArray_ReturnsTypedList()
    {
        // Arrange
        Array values = new string[] { "A", "B", "C" };

        // Act
        var result = values.ToList<string>();

        // Assert
        Assert.Equal( new List<string> { "A", "B", "C" }, result );
    }

    [Fact]
    public void ToCharSeparatedList_WithPipeSeparator_ReturnsConcatenatedString()
    {
        // Arrange
        Array values = new int[] { 10, 20, 30 };

        // Act
        var result = values.ToCharSeparatedList( '|' );

        // Assert
        Assert.Equal( "10|20|30", result );
    }

    [Fact]
    public void ToCommaSeparatedList_WithStringArray_ReturnsCommaSeparatedString()
    {
        // Arrange
        Array values = new string[] { "one", "two", "three" };

        // Act
        var result = values.ToCommaSeparatedList();

        // Assert
        Assert.Equal( "one,two,three", result );
    }

    [Fact]
    public void Contains_WithPredicateMatchingElement_ReturnsTrue()
    {
        // Arrange
        Array values = new int[] { 1, 5, 9 };

        // Act
        var result = values.Contains<int>( i => i > 7 );

        // Assert
        Assert.True( result );
    }

    [Fact]
    public void Contains_WithPredicateNotMatchingAnyElement_ReturnsFalse()
    {
        // Arrange
        Array values = new int[] { 2, 4, 6 };

        // Act
        var result = values.Contains<int>( i => i.IsOdd() );

        // Assert
        Assert.False( result );
    }

    [Fact]
    public void ToCharSeparatedList_WithEmptyArray_ReturnsEmptyString()
    {
        // Arrange
        Array values = Array.Empty<int>();

        // Act
        var result = values.ToCharSeparatedList( ',' );

        // Assert
        Assert.Equal( string.Empty, result );
    }
}
