namespace DevToolz.Library;

public class Cpf : INumber, IGenerator, IValidator
{
    private string _cpf;
    public string Number { get => _cpf; set => _cpf = value; }

    private bool IsPattern( string value )
        => value.IsNotEmpty() && value.Distinct().Count() == 1;

    private string GenerateCalculatingDigits()
    {
        var randomDigits = Random.Shared;
        string digits;

        do
        {
            digits = string.Empty;

            for ( int i = 0; i < 9; i++ )
                digits += randomDigits.Next( 0, 10 ).ToString();

        } while ( IsPattern( digits ) );

        return digits;
    }

    private string GenerateVerifyingDigits( int startCounter, string digits )
    {
        var result = 0;

        foreach ( char digit in digits )
            result += digit.ToInt() * startCounter--;

        var rest = result % 11;

        if ( rest < 2 )
            result = 0;
        else
            result = 11 - rest;

        return result.ToString();
    }

    private string GetFirstVerifyingDigit( string cpf )
        => cpf[ 9 ].ToString();

    private string GetSecondVerifyingDigit( string cpf )
        => cpf[ 10 ].ToString();

    private string GetCalculatingDigits( string cpf )
        => cpf.Substring( 0, 9 );

    private bool ValidateVerifyingDigit( int startCounter, string digits, string verifyingDigit )
    {
        var checkDigit = GenerateVerifyingDigits( startCounter, digits );
        return checkDigit.IsEqual( verifyingDigit );
    }

    private bool IsCpfFormatValid( string value )
        => Regex.IsMatch( value, RegexPatterns.Cpf );

    private string RemoveMask( string value )
        => Regex.Replace( value, @"\.|\/|\-", "" );

    public bool IsValid( string value )
    {
        var cpf = RemoveMask( value );
        var calculatingDigits = GetCalculatingDigits( cpf );

        var validFormat = value.IsNotEmpty()
            && IsCpfFormatValid( value )
            && !IsPattern( calculatingDigits );

        if ( !validFormat )
            return false;

        var firstVerifyingDigit = GetFirstVerifyingDigit( cpf );
        var secondVerifyingDigit = GetSecondVerifyingDigit( cpf );

        return ValidateVerifyingDigit( 10, calculatingDigits, firstVerifyingDigit )
            && ValidateVerifyingDigit( 11, calculatingDigits + firstVerifyingDigit, secondVerifyingDigit );
    }

    public bool IsValid()
        => IsValid( _cpf );

    public string Generate( bool masked )
    {
        _cpf = GenerateCalculatingDigits();
        _cpf += GenerateVerifyingDigits( 10, _cpf );
        _cpf += GenerateVerifyingDigits( 11, _cpf );

        if ( masked )
            _cpf = _cpf.Insert( 3, "." ).Insert( 7, "." ).Insert( 11, "-" );

        return _cpf;
    }

    public string Generate()
        => Generate( false );
}
