using DevToolz.Library.Documents.Brazilian.Cpf.Interfaces;
using DevToolz.Library.Documents.Brazilian.Shared.Models;
using DevToolz.Library.Documents.Brazilian.Shared.Resolvers;

namespace DevToolz.Library.Documents.Brazilian.Cpf;

public sealed class Cpf : ICpfMetadata, IValidator, IGenerator
{
    private static readonly CpfValidator _validator = new();
    private static readonly CpfGenerator _generator = new();

    private string _value = string.Empty;

    public bool IsValid( string value ) => _validator.IsValid( value );
    public bool IsValid()               => _validator.IsValid( _value );

    public string Generate()              => _value = _generator.Generate();
    public string Generate( bool masked ) => _value = _generator.Generate( masked );

    public string Masked()   => _generator.Masked( _value );
    public string Unmasked() => _generator.Unmasked( _value );

    public string               BaseDigits           => Unmasked()[..9];
    public string               FirstVerifyingDigit  => Unmasked()[9].ToString();
    public string               SecondVerifyingDigit => Unmasked()[10].ToString();
    public int                  IssuingUnitDigit     => int.Parse( Unmasked()[8].ToString() );
    public IReadOnlyList<State> IssuingStates        => StateResolver.Resolve( IssuingUnitDigit );
}
