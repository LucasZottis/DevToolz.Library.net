namespace DevToolz.Library.Documents.Brazilian.Cnpj.Interfaces;

public interface ICnpjValidator : IValidator
{
    bool IsValid( string value, CnpjFormat format );
}
