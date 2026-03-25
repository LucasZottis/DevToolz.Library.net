namespace DevToolz.Library.Documents.Brazilian.Cnpj.Interfaces;

public interface ICnpjMetadata : ICnpjData
{
    string BaseDigits           { get; }
    string FirstVerifyingDigit  { get; }
    string SecondVerifyingDigit { get; }
}
