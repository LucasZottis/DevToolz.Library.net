namespace DevToolz.Library.Test;

public class TextLetterCounterTests
{
    [Fact]
    public void Count_WithMixedText_ReturnsExpectedTotals()
    {
        // Arrange
        var counter = new TextLetterCounter();
        var text = "Hello world 123. How are you?";

        // Act
        var result = counter.Count( text, "o" );

        // Assert
        Assert.Equal( 29, result.TotalCharacters );
        Assert.Equal( 25, result.TotalCharactersWithoutSpaces );
        Assert.Equal( 4, result.TotalSpaces );
        Assert.Equal( 11, result.TotalConsonants );
        Assert.Equal( 8, result.TotalVowels );
        Assert.Equal( 3, result.TotalNumbers );
        Assert.Equal( 6, result.TotalWords );
        Assert.Equal( 2, result.TotalSentences );
        Assert.Equal( 4, result.TotalTextRepetitions );
    }

    [Fact]
    public void Count_WithNullText_ReturnsAllTotalsAsZero()
    {
        // Arrange
        var counter = new TextLetterCounter();

        // Act
        var result = counter.Count( null, "test" );

        // Assert
        Assert.Equal( 0, result.TotalCharacters );
        Assert.Equal( 0, result.TotalCharactersWithoutSpaces );
        Assert.Equal( 0, result.TotalSpaces );
        Assert.Equal( 0, result.TotalConsonants );
        Assert.Equal( 0, result.TotalVowels );
        Assert.Equal( 0, result.TotalNumbers );
        Assert.Equal( 0, result.TotalWords );
        Assert.Equal( 0, result.TotalSentences );
        Assert.Equal( 0, result.TotalTextRepetitions );
    }

    [Fact]
    public void Count_WithEmptySearchText_ReturnsZeroRepetitions()
    {
        // Arrange
        var counter = new TextLetterCounter();

        // Act
        var result = counter.Count( "banana", "" );

        // Assert
        Assert.Equal( 0, result.TotalTextRepetitions );
    }

    [Fact]
    public void Count_WithCaseInsensitiveSearch_ReturnsExpectedRepetitions()
    {
        // Arrange
        var counter = new TextLetterCounter();

        // Act
        var result = counter.Count( "Test test TEST", "test" );

        // Assert
        Assert.Equal( 3, result.TotalTextRepetitions );
    }
}
