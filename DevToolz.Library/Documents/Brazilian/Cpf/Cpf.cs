using DevToolz.Library.Documents.Brazilian.Cpf.Interfaces;
using DevToolz.Library.Documents.Brazilian.Shared;
using DevToolz.Library.Documents.Brazilian.Shared.Models;
using DevToolz.Library.Documents.Brazilian.Shared.Resolvers;

namespace DevToolz.Library.Documents.Brazilian.Cpf;

public sealed class Cpf : ICpfMetadata, ICpfData
{
    private static readonly IValidator _validator = new CpfValidator();
    private static readonly IGenerator _generator = new CpfGenerator();

    private string _value = string.Empty;
    private string Digits
        => BrazilianDocumentHelper.RemoveMask( _value );

    public string BaseDigits
        => Digits[ ..9 ];

    public string FirstVerifyingDigit
        => Digits[ 9 ].ToString();

    public string SecondVerifyingDigit
        => Digits[ 10 ].ToString();

    public int IssuingUnitDigit
        => int.Parse( Digits[ 8 ].ToString() );

    public IReadOnlyList<State> IssuingStates
        => StateResolver.Resolve( IssuingUnitDigit );

    public Cpf() { }

    public Cpf( string cpf )
    {
        _value = cpf;
    }

    public bool IsValid()
        => _validator.IsValid( _value );

    public string Generate()
        => _value = _generator.Generate();

    public string Masked()
        => BrazilianDocumentHelper.MaskCpf( Digits );

    public string Unmasked() => Digits;
}
