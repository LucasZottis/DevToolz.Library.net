using DevToolz.Library.Documents.Brazilian.Cpf.Interfaces;
using DevToolz.Library.Documents.Brazilian.Shared;
using DevToolz.Library.Documents.Brazilian.Shared.Models;
using DevToolz.Library.Documents.Brazilian.Shared.Resolvers;

namespace DevToolz.Library.Documents.Brazilian.Cpf;

public sealed class Cpf : ICpfMetadata, IValidator, IGenerator
{
    private static readonly CpfValidator _validator = new();
    private static readonly CpfGenerator _generator = new();

    private string _value = string.Empty;

    private string Digits => BrazilianDocumentHelper.RemoveMask( _value );

    public bool IsValid( string value ) => _validator.IsValid( value );
    public bool IsValid() => _validator.IsValid( _value );

    public string Generate() => _value = _generator.Generate();
    public string Generate( bool masked ) => _value = _generator.Generate( masked );

    public string Masked()   => BrazilianDocumentHelper.MaskCpf( Digits );
    public string Unmasked() => Digits;

    public string               BaseDigits           => Digits[..9];
    public string               FirstVerifyingDigit  => Digits[9].ToString();
    public string               SecondVerifyingDigit => Digits[10].ToString();
    public int                  IssuingUnitDigit     => int.Parse( Digits[8].ToString() );
    public IReadOnlyList<State> IssuingStates        => StateResolver.Resolve( IssuingUnitDigit );
}
