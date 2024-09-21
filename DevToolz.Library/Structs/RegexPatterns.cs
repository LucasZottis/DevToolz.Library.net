namespace DevToolz.Library.Structs;

public struct RegexPatterns
{
    public const string DecimalNumber = @"^(\d+(\.)?)+(\,{1}\d{2}){1}$";
    public const string DecimalNumberWithSign = @"(^R\$ )?(\d+(\.)?)+(\,{1}\d{2}){1}$";

    public const string EmailDomain = @"@[a-z0-9]+\.?-?[a-z0-9]+?(\.[a-z0-9]{2,3})+$";
    public const string Email = @"^(\w+\.?|-?\w+?)+@[a-z0-9]+\.?-?[a-z0-9]+?(\.[a-z0-9]{2,3})+$";
    public const string Cnpj = @"^(\d){2}\.?(\d){3}\.?(\d){3}\/?(\d){4}-?(\d){2}$";
    public const string Cpf = @"^(\d){3}\.?(\d){3}\.?(\d){3}-?(\d){2}$";
}