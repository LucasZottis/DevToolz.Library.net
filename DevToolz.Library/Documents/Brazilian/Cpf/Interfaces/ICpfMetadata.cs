using DevToolz.Library.Documents.Brazilian.Shared.Models;

namespace DevToolz.Library.Documents.Brazilian.Cpf.Interfaces;

public interface ICpfMetadata : ICpfData
{
    string               BaseDigits           { get; }
    string               FirstVerifyingDigit  { get; }
    string               SecondVerifyingDigit { get; }
    int                  IssuingUnitDigit     { get; }
    IReadOnlyList<State> IssuingStates        { get; }
}
