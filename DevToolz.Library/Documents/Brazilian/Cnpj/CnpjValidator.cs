using DevToolz.Library.Documents.Brazilian.Shared;

namespace DevToolz.Library.Documents.Brazilian.Cnpj;

internal sealed class CnpjValidator : IValidator
{
    public bool IsValid( string value )
    {
        if ( value.IsEmpty() )
            return false;

        if ( !Regex.IsMatch( value, RegexPatterns.Cnpj ) )
            return false;

        var cnpj       = BrazilianDocumentHelper.RemoveMask( value );
        var baseDigits = cnpj[..12];

        if ( BrazilianDocumentHelper.IsRepeatedDigitPattern( baseDigits ) )
            return false;

        Func<int, int> counterStep = c => c - 1 < 2 ? 9 : c - 1;

        var first = BrazilianDocumentHelper.ComputeVerifyingDigit( 5, baseDigits, counterStep );
        if ( first != cnpj[12].ToString() )
            return false;

        var second = BrazilianDocumentHelper.ComputeVerifyingDigit( 6, cnpj[..13], counterStep );
        return second == cnpj[13].ToString();
    }

    public bool IsValid()
        => IsValid( string.Empty );
}
