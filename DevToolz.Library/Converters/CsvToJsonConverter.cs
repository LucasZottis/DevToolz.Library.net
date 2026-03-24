using DevToolz.Library.Converters.Interfaces;
using System.Text;
using System.Text.Json;

namespace DevToolz.Library.Converters;

public class CsvToJsonConverter : IFormatConverter
{
    public string SourceFormat => "csv";

    public string TargetFormat => "json";

    public string Convert( string input )
    {
        if( string.IsNullOrWhiteSpace( input ) )
            throw new ArgumentException( "Conteúdo CSV não pode ser vazio.", nameof( input ) );

        List<string[]> rows = ParseCsvRows( input );

        if( rows.Count == 0 )
            throw new FormatException( "CSV inválido: nenhuma linha encontrada." );

        string[] headers = rows[ 0 ];

        if( headers.Length == 0 || headers.Any( string.IsNullOrWhiteSpace ) )
            throw new FormatException( "CSV inválido: cabeçalho ausente ou inválido." );

        var result = new List<Dictionary<string, string?>>();

        for( int i = 1; i < rows.Count; i++ )
        {
            string[] row = rows[ i ];

            if( row.Length != headers.Length )
                throw new FormatException( $"CSV inválido: linha {i + 1} possui {row.Length} colunas, esperado {headers.Length}." );

            var item = new Dictionary<string, string?>( StringComparer.OrdinalIgnoreCase );

            for( int j = 0; j < headers.Length; j++ )
                item[ headers[ j ] ] = row[ j ];

            result.Add( item );
        }

        return JsonSerializer.Serialize( result );
    }

    private static List<string[]> ParseCsvRows( string csv )
    {
        var rows = new List<string[]>();
        var currentRow = new List<string>();
        var currentCell = new StringBuilder();
        bool insideQuotes = false;

        for( int i = 0; i < csv.Length; i++ )
        {
            char current = csv[ i ];

            if( current == '"' )
            {
                bool isEscapedQuote = insideQuotes && i + 1 < csv.Length && csv[ i + 1 ] == '"';

                if( isEscapedQuote )
                {
                    currentCell.Append( '"' );
                    i++;
                }
                else
                    insideQuotes = !insideQuotes;

                continue;
            }

            if( current == ',' && !insideQuotes )
            {
                currentRow.Add( currentCell.ToString() );
                currentCell.Clear();
                continue;
            }

            if( ( current == '\n' || current == '\r' ) && !insideQuotes )
            {
                if( current == '\r' && i + 1 < csv.Length && csv[ i + 1 ] == '\n' )
                    i++;

                currentRow.Add( currentCell.ToString() );
                currentCell.Clear();

                if( currentRow.Count > 1 || currentRow[ 0 ].Length > 0 )
                    rows.Add( currentRow.ToArray() );

                currentRow.Clear();
                continue;
            }

            currentCell.Append( current );
        }

        currentRow.Add( currentCell.ToString() );

        if( currentRow.Count > 1 || currentRow[ 0 ].Length > 0 )
            rows.Add( currentRow.ToArray() );

        return rows;
    }
}
