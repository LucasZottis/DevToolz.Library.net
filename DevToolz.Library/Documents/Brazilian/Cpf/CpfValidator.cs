using DevToolz.Library.Documents.Brazilian.Shared;

namespace DevToolz.Library.Documents.Brazilian.Cpf;

internal sealed class CpfValidator : IValidator
{
    public bool IsValid( string value )
    {
        if ( value.IsEmpty() )
            return false;

        if ( !Regex.IsMatch( value, RegexPatterns.Cpf ) )
            return false;

        var cpf        = BrazilianDocumentHelper.RemoveMask( value );
        var baseDigits = cpf[..9];

        if ( BrazilianDocumentHelper.IsRepeatedDigitPattern( baseDigits ) )
            return false;

        var first = BrazilianDocumentHelper.ComputeVerifyingDigit( 10, baseDigits, c => c - 1 );
        if ( first != cpf[9].ToString() )
            return false;

        var second = BrazilianDocumentHelper.ComputeVerifyingDigit( 11, cpf[..10], c => c - 1 );
        return second == cpf[10].ToString();
    }

    public bool IsValid()
        => IsValid( string.Empty );
}
