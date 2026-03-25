namespace DevToolz.Library.Documents.Brazilian.Cpf;

public static class CpfFactory
{
    public static IValidator CreateValidator() => new CpfValidator();
    public static IGenerator CreateGenerator() => new CpfGenerator();
}
