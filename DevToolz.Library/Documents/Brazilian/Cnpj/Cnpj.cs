using DevToolz.Library.Documents.Brazilian.Cnpj.Interfaces;
using DevToolz.Library.Documents.Brazilian.Shared;

namespace DevToolz.Library.Documents.Brazilian.Cnpj;

public sealed class Cnpj : ICnpjMetadata, IValidator, IGenerator
{
    private static readonly CnpjValidator _validator = new();
    private static readonly CnpjGenerator _generator = new();

    private string _value = string.Empty;

    public bool IsValid( string value ) => _validator.IsValid( value );
    public bool IsValid()               => _validator.IsValid( _value );

    public string Generate()              => _value = _generator.Generate();
    public string Generate( bool masked ) => _value = _generator.Generate( masked );

    public string Masked()   => BrazilianDocumentHelper.MaskCnpj( BrazilianDocumentHelper.RemoveMask( _value ) );
    public string Unmasked() => BrazilianDocumentHelper.RemoveMask( _value );

    public string BaseDigits           => Unmasked()[..12];
    public string FirstVerifyingDigit  => Unmasked()[12].ToString();
    public string SecondVerifyingDigit => Unmasked()[13].ToString();
}
