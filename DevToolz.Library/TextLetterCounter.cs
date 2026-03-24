using System.Text.RegularExpressions;

namespace DevToolz.Library;

public class TextLetterCounter
{
    private static readonly HashSet<char> Vowels = new()
    {
        'a', 'e', 'i', 'o', 'u'
    };

    public TextCountResult Count( string? text, string? textToCountRepetitions = null )
    {
        text ??= string.Empty;

        var result = new TextCountResult
        {
            TotalCharacters = text.Length,
            TotalSpaces = text.Count( c => c == ' ' ),
            TotalNumbers = text.Count( char.IsDigit ),
            TotalWords = CountWords( text ),
            TotalSentences = CountSentences( text ),
            TotalTextRepetitions = CountTextRepetitions( text, textToCountRepetitions )
        };

        foreach ( var character in text )
        {
            if ( !char.IsLetter( character ) )
                continue;

            if ( Vowels.Contains( char.ToLowerInvariant( character ) ) )
                result.TotalVowels++;
            else
                result.TotalConsonants++;
        }

        result.TotalCharactersWithoutSpaces = result.TotalCharacters - result.TotalSpaces;

        return result;
    }

    private static int CountWords( string text )
        => Regex.Matches( text, @"\b[\p{L}\p{N}']+\b" ).Count;

    private static int CountSentences( string text )
        => Regex.Matches( text, @"[.!?]+" ).Count;

    private static int CountTextRepetitions( string text, string? searchText )
    {
        if ( string.IsNullOrWhiteSpace( searchText ) )
            return 0;

        int count = 0;
        int startIndex = 0;

        while ( true )
        {
            int index = text.IndexOf( searchText, startIndex, StringComparison.OrdinalIgnoreCase );

            if ( index < 0 )
                break;

            count++;
            startIndex = index + searchText.Length;
        }

        return count;
    }
}
