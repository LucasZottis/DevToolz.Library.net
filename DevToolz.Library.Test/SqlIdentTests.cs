using DevToolz.Library.SqlIdent;

namespace DevToolz.Library.Test;

public class SqlIdentTests
{
    [Fact]
    public void Format_WithSimpleSelectStatement_ShouldReturnFormattedSql()
    {
        // Arrange
        string sql = "SELECT * FROM Users WHERE Id = 1";

        // Act
        string result = Formatter.Format( sql );

        // Assert
        Assert.NotNull( result );
        Assert.NotEmpty( result );
        Assert.Contains( "SELECT", result );
        Assert.Contains( "FROM", result );
        Assert.Contains( "WHERE", result );
    }

    [Fact]
    public void Format_WithEmptyString_ShouldReturnEmptyOrValidResult()
    {
        // Arrange
        string sql = string.Empty;

        // Act
        string result = Formatter.Format( sql );

        // Assert
        Assert.NotNull( result );
    }

    [Fact]
    public void Format_WithNullInput_ShouldThrowArgumentNullException()
    {
        // Arrange
        string sql = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>( () => Formatter.Format( sql ) );
    }

    [Fact]
    public void Format_WithWhitespaceOnlyInput_ShouldReturnValidResult()
    {
        // Arrange
        string sql = "   \t\n   ";

        // Act
        string result = Formatter.Format( sql );

        // Assert
        Assert.NotNull( result );
    }

    [Fact]
    public void Format_WithComplexSelectStatement_ShouldReturnFormattedSql()
    {
        // Arrange
        string sql = "SELECT u.Name, u.Email, p.Title FROM Users u INNER JOIN Posts p ON u.Id = p.UserId WHERE u.Active = 1 ORDER BY u.Name";

        // Act
        string result = Formatter.Format( sql );

        // Assert
        Assert.NotNull( result );
        Assert.NotEmpty( result );
        Assert.Contains( "SELECT", result );
        Assert.Contains( "INNER", result );
        Assert.Contains( "JOIN", result );
        Assert.Contains( "ORDER", result );
        Assert.Contains( "BY", result );
    }

    [Fact]
    public void Format_WithInsertStatement_ShouldReturnFormattedSql()
    {
        // Arrange
        string sql = "INSERT INTO Users (Name, Email) VALUES ('John Doe', 'john@example.com')";

        // Act
        string result = Formatter.Format( sql );

        // Assert
        Assert.NotNull( result );
        Assert.NotEmpty( result );
        Assert.Contains( "INSERT", result );
        Assert.Contains( "INTO", result );
        Assert.Contains( "VALUES", result );
    }

    [Fact]
    public void Format_WithUpdateStatement_ShouldReturnFormattedSql()
    {
        // Arrange
        string sql = "UPDATE Users SET Name = 'Jane Doe' WHERE Id = 1";

        // Act
        string result = Formatter.Format( sql );

        // Assert
        Assert.NotNull( result );
        Assert.NotEmpty( result );
        Assert.Contains( "UPDATE", result );
        Assert.Contains( "SET", result );
        Assert.Contains( "WHERE", result );
    }

    [Fact]
    public void Format_WithDeleteStatement_ShouldReturnFormattedSql()
    {
        // Arrange
        string sql = "DELETE FROM Users WHERE Id = 1";

        // Act
        string result = Formatter.Format( sql );

        // Assert
        Assert.NotNull( result );
        Assert.NotEmpty( result );
        Assert.Contains( "DELETE", result );
        Assert.Contains( "FROM", result );
        Assert.Contains( "WHERE", result );
    }

    [Fact]
    public void Format_WithStringContainingQuotes_ShouldReplaceEmptyQuotesCorrectly()
    {
        // Arrange
        string sql = "SELECT * FROM Users WHERE Name = ' '";

        // Act
        string result = Formatter.Format( sql );

        // Assert
        Assert.NotNull( result );
        Assert.NotEmpty( result );
        // Verifica se a substituição "' '" por "''" foi aplicada
        Assert.DoesNotContain( "' '", result );
    }

    [Fact]
    public void Format_WithMultipleStatements_ShouldReturnFormattedSql()
    {
        // Arrange
        string sql = "SELECT * FROM Users; SELECT * FROM Posts;";

        // Act
        string result = Formatter.Format( sql );

        // Assert
        Assert.NotNull( result );
        Assert.NotEmpty( result );
        Assert.Contains( "SELECT", result );
    }

    [Fact]
    public void Format_WithSubquery_ShouldReturnFormattedSql()
    {
        // Arrange
        string sql = "SELECT * FROM Users WHERE Id IN (SELECT UserId FROM Posts WHERE Active = 1)";

        // Act
        string result = Formatter.Format( sql );

        // Assert
        Assert.NotNull( result );
        Assert.NotEmpty( result );
        Assert.Contains( "SELECT", result );
        Assert.Contains( "WHERE", result );
        Assert.Contains( "IN", result );
    }

    [Fact]
    public void Format_WithUnformattedSql_ShouldImproveFormatting()
    {
        // Arrange
        string sql = "select*from users where id=1and name='test'";

        // Act
        string result = Formatter.Format( sql );

        // Assert
        Assert.NotNull( result );
        Assert.NotEmpty( result );
        // O resultado deve ser diferente do input original (formatado)
        Assert.NotEqual( sql, result );
    }

    [Theory]
    [InlineData( "SELECT 1" )]
    [InlineData( "SELECT * FROM Table1" )]
    [InlineData( "INSERT INTO Table1 VALUES (1)" )]
    [InlineData( "UPDATE Table1 SET Col1 = 1" )]
    [InlineData( "DELETE FROM Table1" )]
    public void Format_WithVariousSqlStatements_ShouldReturnValidResults( string sql )
    {
        // Act
        string result = Formatter.Format( sql );

        // Assert
        Assert.NotNull( result );
        Assert.NotEmpty( result );
    }

    [Fact]
    public void Format_WithLongComplexQuery_ShouldHandleCorrectly()
    {
        // Arrange
        string sql = @"
                SELECT 
                    u.Id, u.Name, u.Email, 
                    COUNT(p.Id) as PostCount,
                    MAX(p.CreatedDate) as LastPostDate
                FROM Users u 
                LEFT JOIN Posts p ON u.Id = p.UserId 
                WHERE u.Active = 1 
                    AND u.CreatedDate > '2023-01-01'
                GROUP BY u.Id, u.Name, u.Email
                HAVING COUNT(p.Id) > 0
                ORDER BY u.Name ASC";

        // Act
        string result = Formatter.Format( sql );

        // Assert
        Assert.NotNull( result );
        Assert.NotEmpty( result );
        Assert.Contains( "SELECT", result );
        Assert.Contains( "GROUP", result );
        Assert.Contains( "BY", result );
        Assert.Contains( "HAVING", result );
    }

    [Fact]
    public void Format_ResultShouldNotContainOriginalWhitespacePattern()
    {
        // Arrange
        string sql = "SELECT    *    FROM    Users    WHERE    Id    =    1";

        // Act
        string result = Formatter.Format( sql );

        // Assert
        Assert.NotNull( result );
        Assert.NotEmpty( result );
        // O resultado formatado não deve conter múltiplos espaços consecutivos
        Assert.DoesNotContain( "    ", result );
    }

}