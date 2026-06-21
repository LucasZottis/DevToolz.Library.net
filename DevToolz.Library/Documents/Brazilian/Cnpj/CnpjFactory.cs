using DevToolz.Library.Documents.Brazilian.Cnpj.Interfaces;

namespace DevToolz.Library.Documents.Brazilian.Cnpj;

public static class CnpjFactory
{
    public static ICnpjValidator CreateValidator() => new CnpjValidator();
    public static ICnpjGenerator CreateGenerator() => new CnpjGenerator();
}
