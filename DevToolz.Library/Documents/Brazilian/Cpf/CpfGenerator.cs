using DevToolz.Library.Documents.Brazilian.Shared;

namespace DevToolz.Library.Documents.Brazilian.Cpf;

internal sealed class CpfGenerator : IGenerator
{
    public string Generate()
        => Generate( false );

    public string Generate( bool masked )
    {
        string digits;

        do
        {
            digits = string.Empty;

            for ( int i = 0; i < 9; i++ )
                digits += Random.Shared.Next( 0, 10 ).ToString();
        }
        while ( BrazilianDocumentHelper.IsRepeatedDigitPattern( digits ) );

        digits += BrazilianDocumentHelper.ComputeVerifyingDigit( 10, digits, c => c - 1 );
        digits += BrazilianDocumentHelper.ComputeVerifyingDigit( 11, digits, c => c - 1 );

        return masked ? BrazilianDocumentHelper.MaskCpf( digits ) : digits;
    }
}
