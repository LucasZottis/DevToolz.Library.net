using DevToolz.Library.Documents.Brazilian.Cnpj.Interfaces;
using DevToolz.Library.Documents.Brazilian.Shared;

namespace DevToolz.Library.Documents.Brazilian.Cnpj;

internal sealed class CnpjGenerator : ICnpjGenerator
{
    private const string AlphanumericChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

    public string Generate()
        => Generate( false );

    public string Generate( bool masked )
        => Generate( masked, CnpjFormat.Numeric );

    public string Generate( CnpjFormat format )
        => Generate( false, format );

    public string Generate( bool masked, CnpjFormat format )
    {
        string digits;

        do
        {
            digits = string.Empty;

            for ( int i = 0; i < 12; i++ )
            {
                digits += format == CnpjFormat.Alphanumeric
                    ? AlphanumericChars[ Random.Shared.Next( AlphanumericChars.Length ) ].ToString()
                    : Random.Shared.Next( 0, 10 ).ToString();
            }
        }
        while ( BrazilianDocumentHelper.IsRepeatedDigitPattern( digits ) );

        Func<int, int> counterStep = c => c - 1 < 2 ? 9 : c - 1;

        digits += BrazilianDocumentHelper.ComputeVerifyingDigit( 5, digits, counterStep );
        digits += BrazilianDocumentHelper.ComputeVerifyingDigit( 6, digits, counterStep );

        return masked ? BrazilianDocumentHelper.MaskCnpj( digits ) : digits;
    }
}
