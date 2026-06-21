namespace DevToolz.Library.Documents.Brazilian.Cnpj.Interfaces;

public interface ICnpjGenerator : IGenerator
{
    string Generate( CnpjFormat format );
    string Generate( bool masked, CnpjFormat format );
}
