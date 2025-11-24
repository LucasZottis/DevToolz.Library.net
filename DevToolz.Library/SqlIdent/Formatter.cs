using DevToolz.Library.SqlIdent.Builders;
using System.Text;

namespace DevToolz.Library.SqlIdent;

public static class Formatter
{
    public static string Format( string sql )
    {
        var sqlTree = SqlTreeBuilder.Build( sql );
        var sqlBuilder = new StringBuilder();

        sqlTree.FormatSql( sqlBuilder, string.Empty );
        sqlBuilder.Replace( "' '", "''" );

        return sqlBuilder.ToString();
    }
}