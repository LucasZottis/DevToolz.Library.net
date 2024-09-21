namespace DevToolz.Library;

public class Email : IValidator
{
    public string Value { get; set; }

    private bool IsEmailEmpty( string email )
        => email.IsEmpty();

    private string DomainMapper( Match match )
    {
        // Usa a classe IdnMapping To converter nomes de domínio Unicode.
        var idn = new IdnMapping();

        // Retira e processa o nome de domínio (lança ArgumentException em inválido).
        string domainName = idn.GetAscii( match.Groups[ 2 ].Value );

        return match.Groups[ 1 ].Value + domainName;
    }

    public bool ValidateEmailDomain( string email )
        => Regex.IsMatch( email, RegexPatterns.EmailDomain );

    public bool IsValid( string value )
    {
        if ( value.IsEmpty() )
            return false;

        // Normaliza o domínio.
        return Regex.IsMatch( value, RegexPatterns.Email, RegexOptions.None, TimeSpan.FromSeconds( 5 ) );
    }

    public bool IsValid()
        => IsValid( Value );
}