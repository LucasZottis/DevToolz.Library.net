using DevToolz.Library.Documents.Brazilian.Shared;

namespace DevToolz.Library.Documents.Brazilian.Cnpj;

internal sealed class CnpjGenerator : IGenerator
{
    public string Generate()
        => Generate( false );

    public string Generate( bool masked )
    {
        string digits;

        do
        {
            digits = string.Empty;

            for ( int i = 0; i < 12; i++ )
                digits += Random.Shared.Next( 0, 10 ).ToString();
        }
        while ( BrazilianDocumentHelper.IsRepeatedDigitPattern( digits ) );

        Func<int, int> counterStep = c => c - 1 < 2 ? 9 : c - 1;

        digits += BrazilianDocumentHelper.ComputeVerifyingDigit( 5, digits, counterStep );
        digits += BrazilianDocumentHelper.ComputeVerifyingDigit( 6, digits, counterStep );

        return masked ? Masked( digits ) : digits;
    }

    public string Masked( string value )
    {
        var unmasked = BrazilianDocumentHelper.RemoveMask( value );
        return unmasked.Insert( 2, "." ).Insert( 6, "." ).Insert( 10, "/" ).Insert( 15, "-" );
    }

    public string Unmasked( string value )
        => BrazilianDocumentHelper.RemoveMask( value );
}
