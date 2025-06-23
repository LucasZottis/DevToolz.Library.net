using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevToolz.Library.Test.Extensions;

public class ObjectExtensionsTests
{
    #region IsNull Tests

    [Fact]
    public void IsNull_WithNullObject_ReturnsTrue()
    {
        // Arrange
        object nullObject = null;

        // Act
        var result = nullObject.IsNull();

        // Assert
        Assert.True( result );
    }

    [Fact]
    public void IsNull_WithNonNullObject_ReturnsFalse()
    {
        // Arrange
        var nonNullObject = new object();

        // Act
        var result = nonNullObject.IsNull();

        // Assert
        Assert.False( result );
    }

    [Fact]
    public void IsNull_WithString_WhenNull_ReturnsTrue()
    {
        // Arrange
        string nullString = null;

        // Act
        var result = nullString.IsNull();

        // Assert
        Assert.True( result );
    }

    [Fact]
    public void IsNull_WithString_WhenNotNull_ReturnsFalse()
    {
        // Arrange
        string nonNullString = "test";

        // Act
        var result = nonNullString.IsNull();

        // Assert
        Assert.False( result );
    }

    [Fact]
    public void IsNull_WithEmptyString_ReturnsFalse()
    {
        // Arrange
        string emptyString = string.Empty;

        // Act
        var result = emptyString.IsNull();

        // Assert
        Assert.False( result );
    }

    [Fact]
    public void IsNull_WithInteger_ReturnsFalse()
    {
        // Arrange
        int number = 42;

        // Act
        var result = number.IsNull();

        // Assert
        Assert.False( result );
    }

    [Fact]
    public void IsNull_WithNullableInteger_WhenNull_ReturnsTrue()
    {
        // Arrange
        int? nullableInt = null;

        // Act
        var result = nullableInt.IsNull();

        // Assert
        Assert.True( result );
    }

    [Fact]
    public void IsNull_WithNullableInteger_WhenHasValue_ReturnsFalse()
    {
        // Arrange
        int? nullableInt = 42;

        // Act
        var result = nullableInt.IsNull();

        // Assert
        Assert.False( result );
    }

    #endregion

    #region IsNotNull Tests

    [Fact]
    public void IsNotNull_WithNullObject_ReturnsFalse()
    {
        // Arrange
        object nullObject = null;

        // Act
        var result = nullObject.IsNotNull();

        // Assert
        Assert.False( result );
    }

    [Fact]
    public void IsNotNull_WithNonNullObject_ReturnsTrue()
    {
        // Arrange
        var nonNullObject = new object();

        // Act
        var result = nonNullObject.IsNotNull();

        // Assert
        Assert.True( result );
    }

    [Fact]
    public void IsNotNull_WithString_WhenNull_ReturnsFalse()
    {
        // Arrange
        string nullString = null;

        // Act
        var result = nullString.IsNotNull();

        // Assert
        Assert.False( result );
    }

    [Fact]
    public void IsNotNull_WithString_WhenNotNull_ReturnsTrue()
    {
        // Arrange
        string nonNullString = "test";

        // Act
        var result = nonNullString.IsNotNull();

        // Assert
        Assert.True( result );
    }

    [Fact]
    public void IsNotNull_WithEmptyString_ReturnsTrue()
    {
        // Arrange
        string emptyString = string.Empty;

        // Act
        var result = emptyString.IsNotNull();

        // Assert
        Assert.True( result );
    }

    [Fact]
    public void IsNotNull_WithInteger_ReturnsTrue()
    {
        // Arrange
        int number = 42;

        // Act
        var result = number.IsNotNull();

        // Assert
        Assert.True( result );
    }

    [Fact]
    public void IsNotNull_WithNullableInteger_WhenNull_ReturnsFalse()
    {
        // Arrange
        int? nullableInt = null;

        // Act
        var result = nullableInt.IsNotNull();

        // Assert
        Assert.False( result );
    }

    [Fact]
    public void IsNotNull_WithNullableInteger_WhenHasValue_ReturnsTrue()
    {
        // Arrange
        int? nullableInt = 42;

        // Act
        var result = nullableInt.IsNotNull();

        // Assert
        Assert.True( result );
    }

    #endregion

    #region Null Analysis Attribute Tests

    [Fact]
    public void IsNull_NullAnalysisAttribute_WorksCorrectly()
    {
        // Arrange
        string testString = null;

        // Act & Assert
        if ( !testString.IsNull() )
        {
            // Se chegou aqui, o compilador deveria entender que testString não é null
            // devido ao atributo [NotNullWhen(false)]
            var length = testString.Length; // Isso não deveria gerar warning
            Assert.True( false, "Este código não deveria ser executado" );
        }
        else
        {
            // testString é null
            Assert.True( true );
        }
    }

    [Fact]
    public void IsNotNull_NullAnalysisAttribute_WorksCorrectly()
    {
        // Arrange
        string testString = "test value";

        // Act & Assert
        if ( testString.IsNotNull() )
        {
            // Se chegou aqui, o compilador deveria entender que testString não é null
            // devido ao atributo [NotNullWhen(false)]
            var length = testString.Length; // Isso não deveria gerar warning
            Assert.Equal( 10, length );
        }
        else
        {
            Assert.True( false, "Este código não deveria ser executado" );
        }
    }

    #endregion

    #region Edge Cases

    [Fact]
    public void IsNull_WithDBNull_ReturnsFalse()
    {
        // Arrange
        var dbNull = System.DBNull.Value;

        // Act
        var result = dbNull.IsNull();

        // Assert
        Assert.False( result ); // DBNull.Value não é null, é uma instância
    }

    [Fact]
    public void IsNotNull_WithDBNull_ReturnsTrue()
    {
        // Arrange
        var dbNull = System.DBNull.Value;

        // Act
        var result = dbNull.IsNotNull();

        // Assert
        Assert.True( result ); // DBNull.Value não é null, é uma instância
    }

    #endregion
}