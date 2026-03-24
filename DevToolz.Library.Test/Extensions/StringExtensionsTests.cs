namespace DevToolz.Library.Test.Extensions;

public class StringExtensionsTests
{
    #region IsEmpty Tests

    [Fact]
    public void IsEmpty_WithNullString_ReturnsTrue()
    {
        // Arrange
        string? nullString = null;

        // Act
        var result = nullString.IsEmpty();

        // Assert
        Assert.True( result );
    }

    [Fact]
    public void IsEmpty_WithEmptyString_ReturnsTrue()
    {
        // Arrange
        string emptyString = string.Empty;

        // Act
        var result = emptyString.IsEmpty();

        // Assert
        Assert.True( result );
    }

    [Fact]
    public void IsEmpty_WithWhiteSpacesOnly_ReturnsTrue()
    {
        // Arrange
        string whiteSpaceString = "   ";

        // Act
        var result = whiteSpaceString.IsEmpty();

        // Assert
        Assert.True( result );
    }

    [Fact]
    public void IsEmpty_WithValidString_ReturnsFalse()
    {
        // Arrange
        string validString = "test";

        // Act
        var result = validString.IsEmpty();

        // Assert
        Assert.False( result );
    }

    [Fact]
    public void IsEmpty_StringArray_WithEmptyArray_ReturnsTrue()
    {
        // Arrange
        string[] emptyArray = new string[ 0 ];

        // Act
        var result = emptyArray.IsEmpty();

        // Assert
        Assert.True( result );
    }

    [Fact]
    public void IsEmpty_StringArray_WithNullElement_ReturnsTrue()
    {
        // Arrange
        string[] arrayWithNull = new string[] { "valid", null };

        // Act
        var result = arrayWithNull.IsEmpty();

        // Assert
        Assert.True( result );
    }

    [Fact]
    public void IsEmpty_StringArray_WithEmptyElement_ReturnsTrue()
    {
        // Arrange
        string[] arrayWithEmpty = new string[] { "valid", "" };

        // Act
        var result = arrayWithEmpty.IsEmpty();

        // Assert
        Assert.True( result );
    }

    [Fact]
    public void IsEmpty_StringArray_WithAllValidElements_ReturnsFalse()
    {
        // Arrange
        string[] validArray = new string[] { "test1", "test2" };

        // Act
        var result = validArray.IsEmpty();

        // Assert
        Assert.False( result );
    }

    #endregion

    #region IsNotEmpty Tests

    [Fact]
    public void IsNotEmpty_WithNullString_ReturnsFalse()
    {
        // Arrange
        string nullString = null;

        // Act
        var result = nullString.IsNotEmpty();

        // Assert
        Assert.False( result );
    }

    [Fact]
    public void IsNotEmpty_WithEmptyString_ReturnsFalse()
    {
        // Arrange
        string emptyString = string.Empty;

        // Act
        var result = emptyString.IsNotEmpty();

        // Assert
        Assert.False( result );
    }

    [Fact]
    public void IsNotEmpty_WithWhiteSpacesOnly_ReturnsFalse()
    {
        // Arrange
        string whiteSpaceString = "   ";

        // Act
        var result = whiteSpaceString.IsNotEmpty();

        // Assert
        Assert.False( result );
    }

    [Fact]
    public void IsNotEmpty_WithValidString_ReturnsTrue()
    {
        // Arrange
        string validString = "test";

        // Act
        var result = validString.IsNotEmpty();

        // Assert
        Assert.True( result );
    }

    #endregion

    #region IsEqual Tests

    [Fact]
    public void IsEqual_WithChar_WhenEqual_ReturnsTrue()
    {
        // Arrange
        string testString = "A";
        char testChar = 'A';

        // Act
        var result = testString.IsEqual( testChar );

        // Assert
        Assert.True( result );
    }

    [Fact]
    public void IsEqual_WithChar_WhenNotEqual_ReturnsFalse()
    {
        // Arrange
        string testString = "A";
        char testChar = 'B';

        // Act
        var result = testString.IsEqual( testChar );

        // Assert
        Assert.False( result );
    }

    [Fact]
    public void IsEqual_WithChar_WhenStringEmpty_ReturnsFalse()
    {
        // Arrange
        string testString = "";
        char testChar = 'A';

        // Act
        var result = testString.IsEqual( testChar );

        // Assert
        Assert.False( result );
    }

    [Fact]
    public void IsEqual_WithString_WhenEqual_ReturnsTrue()
    {
        // Arrange
        string testString = "test";
        string compareString = "test";

        // Act
        var result = testString.IsEqual( compareString );

        // Assert
        Assert.True( result );
    }

    [Fact]
    public void IsEqual_WithString_WhenNotEqual_ReturnsFalse()
    {
        // Arrange
        string testString = "test";
        string compareString = "other";

        // Act
        var result = testString.IsEqual( compareString );

        // Assert
        Assert.False( result );
    }

    [Fact]
    public void IsEqual_WithString_WhenSourceEmpty_ReturnsFalse()
    {
        // Arrange
        string testString = "";
        string compareString = "test";

        // Act
        var result = testString.IsEqual( compareString );

        // Assert
        Assert.False( result );
    }

    #endregion

    #region IsNotEqual Tests

    [Fact]
    public void IsNotEqual_WithChar_WhenNotEqual_ReturnsTrue()
    {
        // Arrange
        string testString = "A";
        char testChar = 'B';

        // Act
        var result = testString.IsNotEqual( testChar );

        // Assert
        Assert.True( result );
    }

    [Fact]
    public void IsNotEqual_WithChar_WhenEqual_ReturnsFalse()
    {
        // Arrange
        string testString = "A";
        char testChar = 'A';

        // Act
        var result = testString.IsNotEqual( testChar );

        // Assert
        Assert.False( result );
    }

    [Fact]
    public void IsNotEqual_WithString_WhenNotEqual_ReturnsTrue()
    {
        // Arrange
        string testString = "test";
        string compareString = "other";

        // Act
        var result = testString.IsNotEqual( compareString );

        // Assert
        Assert.True( result );
    }

    [Fact]
    public void IsNotEqual_WithString_WhenEqual_ReturnsFalse()
    {
        // Arrange
        string testString = "test";
        string compareString = "test";

        // Act
        var result = testString.IsNotEqual( compareString );

        // Assert
        Assert.False( result );
    }

    [Fact]
    public void IsNotEqual_WithString_WhenOneIsEmpty_ReturnsTrue()
    {
        // Arrange
        string testString = "";
        string compareString = "test";

        // Act
        var result = testString.IsNotEqual( compareString );

        // Assert
        Assert.True( result );
    }

    #endregion

    #region Contains Tests

    [Fact]
    public void Contains_WithChar_WhenCharExists_ReturnsTrue()
    {
        // Arrange
        string testString = "hello";
        char searchChar = 'e';

        // Act
        var result = testString.Contains( searchChar );

        // Assert
        Assert.True( result );
    }

    [Fact]
    public void Contains_WithChar_WhenCharNotExists_ReturnsFalse()
    {
        // Arrange
        string testString = "hello";
        char searchChar = 'x';

        // Act
        var result = testString.Contains( searchChar );

        // Assert
        Assert.False( result );
    }

    [Fact]
    public void Contains_WithChar_WhenStringEmpty_ReturnsFalse()
    {
        // Arrange
        string testString = "";
        char searchChar = 'x';

        // Act
        var result = testString.Contains( searchChar );

        // Assert
        Assert.False( result );
    }

    [Fact]
    public void Contains_WithCharArray_WhenAnyCharExists_ReturnsTrue()
    {
        // Arrange
        string testString = "hello";
        char[] searchChars = new char[] { 'x', 'e', 'z' };

        // Act
        var result = testString.Contains( searchChars );

        // Assert
        Assert.True( result );
    }

    [Fact]
    public void Contains_WithCharArray_WhenNoCharExists_ReturnsFalse()
    {
        // Arrange
        string testString = "hello";
        char[] searchChars = new char[] { 'x', 'y', 'z' };

        // Act
        var result = testString.Contains( searchChars );

        // Assert
        Assert.False( result );
    }

    [Fact]
    public void Contains_WithString_WhenSubstringExists_ReturnsTrue()
    {
        // Arrange
        string testString = "hello world";
        string searchString = "world";

        // Act
        var result = testString.Contains( searchString );

        // Assert
        Assert.True( result );
    }

    [Fact]
    public void Contains_WithString_WhenSubstringNotExists_ReturnsFalse()
    {
        // Arrange
        string testString = "hello world";
        string searchString = "xyz";

        // Act
        var result = testString.Contains( searchString );

        // Assert
        Assert.False( result );
    }

    //[Fact]
    //public void Contains_WithString_WhenSourceEmpty_ThrowsArgumentException()
    //{
    //    // Arrange
    //    string testString = "";
    //    string searchString = "test";

    //    // Act & Assert
    //    Assert.Throws<ArgumentException>( () => testString.Contains( searchString ) );
    //}

    #endregion

    #region Length Tests

    [Fact]
    public void LengthIsEqual_WithInt_WhenEqual_ReturnsTrue()
    {
        // Arrange
        string testString = "hello";
        int expectedLength = 5;

        // Act
        var result = testString.LengthIsEqual( expectedLength );

        // Assert
        Assert.True( result );
    }

    [Fact]
    public void LengthIsEqual_WithInt_WhenNotEqual_ReturnsFalse()
    {
        // Arrange
        string testString = "hello";
        int expectedLength = 3;

        // Act
        var result = testString.LengthIsEqual( expectedLength );

        // Assert
        Assert.False( result );
    }

    [Fact]
    public void LengthIsEqual_WithByte_WhenEqual_ReturnsTrue()
    {
        // Arrange
        string testString = "hi";
        byte expectedLength = 2;

        // Act
        var result = testString.LengthIsEqual( expectedLength );

        // Assert
        Assert.True( result );
    }

    [Fact]
    public void LengthIsNotEqual_WhenNotEqual_ReturnsTrue()
    {
        // Arrange
        string testString = "hello";
        int length = 3;

        // Act
        var result = testString.LengthIsNotEqual( length );

        // Assert
        Assert.True( result );
    }

    [Fact]
    public void LengthIsNotEqual_WhenEqual_ReturnsFalse()
    {
        // Arrange
        string testString = "hello";
        int length = 5;

        // Act
        var result = testString.LengthIsNotEqual( length );

        // Assert
        Assert.False( result );
    }

    [Fact]
    public void IsGreaterThan_WhenGreater_ReturnsTrue()
    {
        // Arrange
        string testString = "hello";
        int length = 3;

        // Act
        var result = testString.IsGreaterThan( length );

        // Assert
        Assert.True( result );
    }

    [Fact]
    public void IsGreaterThan_WhenNotGreater_ReturnsFalse()
    {
        // Arrange
        string testString = "hi";
        int length = 5;

        // Act
        var result = testString.IsGreaterThan( length );

        // Assert
        Assert.False( result );
    }

    [Fact]
    public void IsLessThan_WhenLess_ReturnsTrue()
    {
        // Arrange
        string testString = "hi";
        int length = 5;

        // Act
        var result = testString.IsLessThan( length );

        // Assert
        Assert.True( result );
    }

    [Fact]
    public void IsLessThan_WhenNotLess_ReturnsFalse()
    {
        // Arrange
        string testString = "hello";
        int length = 3;

        // Act
        var result = testString.IsLessThan( length );

        // Assert
        Assert.False( result );
    }

    #endregion

    #region IsAllNumbers Tests

    [Fact]
    public void IsAllNumbers_WithOnlyNumbers_ReturnsTrue()
    {
        // Arrange
        string testString = "12345";

        // Act
        var result = testString.IsAllNumbers();

        // Assert
        Assert.True( result );
    }

    [Fact]
    public void IsAllNumbers_WithLetters_ReturnsFalse()
    {
        // Arrange
        string testString = "123a5";

        // Act
        var result = testString.IsAllNumbers();

        // Assert
        Assert.False( result );
    }

    [Fact]
    public void IsAllNumbers_WithSpecialCharacters_ReturnsFalse()
    {
        // Arrange
        string testString = "123-5";

        // Act
        var result = testString.IsAllNumbers();

        // Assert
        Assert.False( result );
    }

    #endregion

    #region ToBoolean Tests

    [Fact]
    public void ToBoolean_WithS_ReturnsTrue()
    {
        // Arrange
        string testString = "s";

        // Act
        var result = testString.ToBoolean();

        // Assert
        Assert.True( result );
    }

    [Fact]
    public void ToBoolean_WithOne_ReturnsTrue()
    {
        // Arrange
        string testString = "1";

        // Act
        var result = testString.ToBoolean();

        // Assert
        Assert.True( result );
    }

    [Fact]
    public void ToBoolean_WithTrue_ReturnsTrue()
    {
        // Arrange
        string testString = "true";

        // Act
        var result = testString.ToBoolean();

        // Assert
        Assert.True( result );
    }

    [Fact]
    public void ToBoolean_WithFalse_ReturnsFalse()
    {
        // Arrange
        string testString = "false";

        // Act
        var result = testString.ToBoolean();

        // Assert
        Assert.False( result );
    }

    [Fact]
    public void ToBoolean_WithEmpty_ReturnsFalse()
    {
        // Arrange
        string testString = "";

        // Act
        var result = testString.ToBoolean();

        // Assert
        Assert.False( result );
    }

    #endregion

    #region ToByte Tests

    [Fact]
    public void ToByte_WithValidNumber_ReturnsCorrectByte()
    {
        // Arrange
        string testString = "123";

        // Act
        var result = testString.ToByte();

        // Assert
        Assert.Equal( 123, result );
    }

    [Fact]
    public void ToByte_WithNull_ThrowsArgumentNullException()
    {
        // Arrange
        string testString = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>( () => testString.ToByte() );
    }

    [Fact]
    public void ToByte_WithLongString_ThrowsArgumentException()
    {
        // Arrange
        string testString = "1234";

        // Act & Assert
        Assert.Throws<ArgumentException>( () => testString.ToByte() );
    }

    [Fact]
    public void ToByte_WithNonNumeric_ThrowsArgumentException()
    {
        // Arrange
        string testString = "abc";

        // Act & Assert
        Assert.Throws<ArgumentException>( () => testString.ToByte() );
    }

    #endregion

    #region ToChar Tests

    [Fact]
    public void ToChar_WithValidString_ReturnsFirstChar()
    {
        // Arrange
        string testString = "hello";

        // Act
        var result = testString.ToChar();

        // Assert
        Assert.Equal( 'h', result );
    }

    [Fact]
    public void ToChar_WithEmptyString_ThrowsArgumentException()
    {
        // Arrange
        string testString = "";

        // Act & Assert
        Assert.Throws<ArgumentException>( () => testString.ToChar() );
    }

    #endregion

    #region ToDateTime Tests

    [Fact]
    public void ToDateTime_WithValidDate_ReturnsDateTime()
    {
        // Arrange
        string testString = "01/01/2023";

        // Act
        var result = testString.ToDateTime();

        // Assert
        Assert.Equal( new DateTime( 2023, 1, 1 ), result );
    }

    [Fact]
    public void ToDateTime_WithNull_ReturnsDefault()
    {
        // Arrange
        string testString = null;

        // Act
        var result = testString.ToDateTime();

        // Assert
        Assert.Equal( new DateTime(), result );
    }

    [Fact]
    public void ToDateTime_WithInvalidLength_ReturnsDefault()
    {
        // Arrange
        string testString = "2023";

        // Act
        var result = testString.ToDateTime();

        // Assert
        Assert.Equal( new DateTime(), result );
    }

    #endregion

    #region ToDecimal Tests

    [Fact]
    public void ToDecimal_WithValidNumber_ReturnsDecimal()
    {
        // Arrange
        string testString = "123,45";

        // Act
        var result = testString.ToDecimal();

        // Assert
        Assert.Equal( 123.45m, result );
    }

    [Fact]
    public void ToDecimal_WithEmpty_ReturnsZero()
    {
        // Arrange
        string testString = "";

        // Act
        var result = testString.ToDecimal();

        // Assert
        Assert.Equal( 0m, result );
    }

    #endregion

    #region ToDouble Tests

    [Fact]
    public void ToDouble_WithValidNumber_ReturnsDouble()
    {
        // Arrange
        string testString = "123,45";

        // Act
        var result = testString.ToDouble();

        // Assert
        Assert.Equal( 123.45, result );
    }

    [Fact]
    public void ToDouble_WithEmpty_ReturnsZero()
    {
        // Arrange
        string testString = "";

        // Act
        var result = testString.ToDouble();

        // Assert
        Assert.Equal( 0.0, result );
    }

    #endregion

    #region ToEnum Tests

    public enum TestEnum
    {
        Value1,
        Value2
    }

    [Fact]
    public void ToEnum_WithValidEnumValue_ReturnsEnum()
    {
        // Arrange
        string testString = "Value1";

        // Act
        var result = testString.ToEnum<TestEnum>();

        // Assert
        Assert.Equal( TestEnum.Value1, result );
    }

    [Fact]
    public void ToEnum_WithNonEnum_ThrowsArgumentException()
    {
        // Arrange
        string testString = "Value1";

        // Act & Assert
        Assert.Throws<ArgumentException>( () => testString.ToEnum<int>() );
    }

    #endregion

    #region ToFloat Tests

    [Fact]
    public void ToFloat_WithValidNumber_ReturnsFloat()
    {
        // Arrange
        string testString = "123,45";

        // Act
        var result = testString.ToFloat();

        // Assert
        Assert.Equal( 123.45f, result );
    }

    [Fact]
    public void ToFloat_WithEmpty_ReturnsZero()
    {
        // Arrange
        string testString = "";

        // Act
        var result = testString.ToFloat();

        // Assert
        Assert.Equal( 0f, result );
    }

    #endregion

    #region ToInt Tests

    [Fact]
    public void ToInt_WithValidNumber_ReturnsInt()
    {
        // Arrange
        string testString = "123";

        // Act
        var result = testString.ToInt();

        // Assert
        Assert.Equal( 123, result );
    }

    [Fact]
    public void ToInt_WithEmpty_ReturnsZero()
    {
        // Arrange
        string testString = "";

        // Act
        var result = testString.ToInt();

        // Assert
        Assert.Equal( 0, result );
    }

    #endregion

    #region ToLong Tests

    [Fact]
    public void ToLong_WithValidNumber_ReturnsLong()
    {
        // Arrange
        string testString = "123456789";

        // Act
        var result = testString.ToLong();

        // Assert
        Assert.Equal( 123456789L, result );
    }

    [Fact]
    public void ToLong_WithEmpty_ReturnsZero()
    {
        // Arrange
        string testString = "";

        // Act
        var result = testString.ToLong();

        // Assert
        Assert.Equal( 0L, result );
    }

    #endregion

    #region ToShort Tests

    [Fact]
    public void ToShort_WithValidNumber_ReturnsShort()
    {
        // Arrange
        string testString = "123";

        // Act
        var result = testString.ToShort();

        // Assert
        Assert.Equal( ( short ) 123, result );
    }

    [Fact]
    public void ToShort_WithEmpty_ReturnsZero()
    {
        // Arrange
        string testString = "";

        // Act
        var result = testString.ToShort();

        // Assert
        Assert.Equal( ( short ) 0, result );
    }

    #endregion

    #region IsAllWhiteSpaces Tests

    [Fact]
    public void IsAllWhiteSpaces_WithOnlySpaces_ReturnsTrue()
    {
        // Arrange
        string testString = "   ";

        // Act
        var result = testString.IsAllWhiteSpaces();

        // Assert
        Assert.True( result );
    }

    [Fact]
    public void IsAllWhiteSpaces_WithNull_ReturnsTrue()
    {
        // Arrange
        string testString = null;

        // Act
        var result = testString.IsAllWhiteSpaces();

        // Assert
        Assert.True( result );
    }

    [Fact]
    public void IsAllWhiteSpaces_WithEmpty_ReturnsTrue()
    {
        // Arrange
        string testString = "";

        // Act
        var result = testString.IsAllWhiteSpaces();

        // Assert
        Assert.True( result );
    }

    [Fact]
    public void IsAllWhiteSpaces_WithContent_ReturnsFalse()
    {
        // Arrange
        string testString = " a ";

        // Act
        var result = testString.IsAllWhiteSpaces();

        // Assert
        Assert.False( result );
    }

    #endregion

    #region IsNull Tests

    [Fact]
    public void IsNull_WithNull_ReturnsTrue()
    {
        // Arrange
        string testString = null;

        // Act
        var result = testString.IsNull();

        // Assert
        Assert.True( result );
    }

    [Fact]
    public void IsNull_WithValue_ReturnsFalse()
    {
        // Arrange
        string testString = "test";

        // Act
        var result = testString.IsNull();

        // Assert
        Assert.False( result );
    }

    #endregion

    #region Remove Methods Tests

    [Fact]
    public void RemovePeriods_RemovesAllPeriods()
    {
        // Arrange
        string testString = "1.2.3.4";

        // Act
        var result = testString.RemovePeriods();

        // Assert
        Assert.Equal( "1234", result );
    }

    [Fact]
    public void RemoveComma_RemovesAllCommas()
    {
        // Arrange
        string testString = "1,2,3,4";

        // Act
        var result = testString.RemoveComma();

        // Assert
        Assert.Equal( "1234", result );
    }

    [Fact]
    public void RemoveSlashes_RemovesAllSlashes()
    {
        // Arrange
        string testString = "1/2/3/4";

        // Act
        var result = testString.RemoveSlashes();

        // Assert
        Assert.Equal( "1234", result );
    }

    [Fact]
    public void RemoveBackSlashes_RemovesAllBackSlashes()
    {
        // Arrange
        string testString = "1\\2\\3\\4";

        // Act
        var result = testString.RemoveBackSlashes();

        // Assert
        Assert.Equal( "1234", result );
    }

    [Fact]
    public void RemoveHyphens_RemovesAllHyphens()
    {
        // Arrange
        string testString = "1-2-3-4";

        // Act
        var result = testString.RemoveHyphens();

        // Assert
        Assert.Equal( "1234", result );
    }

    [Fact]
    public void RemoverUnderline_RemovesAllUnderlines()
    {
        // Arrange
        string testString = "1_2_3_4";

        // Act
        var result = testString.RemoverUnderline();

        // Assert
        Assert.Equal( "1234", result );
    }

    [Fact]
    public void RemoveMask_RemovesAllMaskCharacters()
    {
        // Arrange
        string testString = "1/2\\3-4.5_6,7";

        // Act
        var result = testString.RemoveMask();

        // Assert
        Assert.Equal( "1234567", result );
    }

    [Fact]
    public void RemoveAccents_RemovesDiacriticsFromString()
    {
        // Arrange
        string testString = "áàãâä éèêë íìîï óòõôö úùûü ç ñ";

        // Act
        var result = testString.RemoveAccents();

        // Assert
        Assert.Equal( "aaaaa eeee iiii ooooo uuuu c n", result );
    }

    [Theory]
    [InlineData( "", "" )]
    [InlineData( null, null )]
    public void RemoveAccents_WithNullOrEmpty_ReturnsSameValue( string? input, string? expected )
    {
        // Act
        var result = StringExtensions.RemoveAccents( input! );

        // Assert
        Assert.Equal( expected, result );
    }

    [Fact]
    public void RemoveAccents_WithWhitespaceAndAccents_RemovesDiacritics()
    {
        // Arrange
        string testString = "  á  ç  ";

        // Act
        var result = testString.RemoveAccents();

        // Assert
        Assert.Equal( "  a  c  ", result );
    }

    #endregion
}
