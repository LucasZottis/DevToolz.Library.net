using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo( "DevToolz.Library.Test" )]

namespace DevToolz.Library.Documents.Brazilian.Shared;

internal static class BrazilianDocumentHelper
{
    public static bool IsRepeatedDigitPattern( string value )
        => value.Length > 0 && value.Distinct().Count() == 1;

    public static string RemoveMask( string value )
        => value.Replace( ".", "" ).Replace( "-", "" ).Replace( "/", "" );

    public static string MaskCpf( string unmasked )
        => unmasked.Insert( 3, "." ).Insert( 7, "." ).Insert( 11, "-" );

    public static string MaskCnpj( string unmasked )
        => unmasked.Insert( 2, "." ).Insert( 6, "." ).Insert( 10, "/" ).Insert( 15, "-" );

    public static string ComputeVerifyingDigit( int startCounter, string digits, Func<int, int> counterStep )
    {
        var result = 0;
        var counter = startCounter;

        foreach ( char digit in digits )
        {
            result += ( digit - '0' ) * counter;
            counter = counterStep( counter );
        }

        var rest = result % 11;
        return ( rest < 2 ? 0 : 11 - rest ).ToString();
    }
}
