namespace DevToolz.Library.Documents.Brazilian.Cnpj;

public static class CnpjFactory
{
    public static IValidator CreateValidator() => new CnpjValidator();
    public static IGenerator CreateGenerator() => new CnpjGenerator();
}
