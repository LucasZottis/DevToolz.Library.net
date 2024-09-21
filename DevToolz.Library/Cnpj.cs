namespace DevToolz.Library;

public class Cnpj : INumber, IValidator, IGenerator
{
    private string _cnpj;

    public string Number
    {
        get => _cnpj;
        set => _cnpj = value;
    }

    private bool IsPattern( string value )
    {
        return value.IsEqual( "000000000000" )
            || value.IsEqual( "111111111111" )
            || value.IsEqual( "222222222222" )
            || value.IsEqual( "333333333333" )
            || value.IsEqual( "444444444444" )
            || value.IsEqual( "555555555555" )
            || value.IsEqual( "666666666666" )
            || value.IsEqual( "777777777777" )
            || value.IsEqual( "888888888888" )
            || value.IsEqual( "999999999999" );
    }

    private string GenerateCalculatingDigits()
    {
        var randomDigits = new Random( DateTime.Now.Second );
        string digits;

        do
        {
            digits = string.Empty;

            for ( int i = 0; i < 12; i++ )
                digits += randomDigits.Next( 0, 9 ).ToString();

        } while ( IsPattern( digits ) );

        return digits;
    }

    private string GenerateVerifyingDigits( int startCounter, string digits )
    {
        var result = 0;

        foreach ( char digito in digits )
        {
            result += digito.ToByte() * startCounter;
            startCounter--;

            if ( startCounter < 2 )
                startCounter = 9;
        }

        var rest = result % 11;

        if ( rest < 2 )
            result = 0;
        else
            result = 11 - rest;

        return result.ToString();
    }

    private string GetCalculatingDigits( string value )
        => value.Substring( 0, 12 );

    private string GetFirstVerifyingDigit( string cnpj )
        => cnpj[ 12 ].ToString();

    private string GetSecondVerifyingDigit( string cnpj )
        => cnpj[ 13 ].ToString();

    private bool ValidateVerifyingDigit( int startCounter, string digits, string verifyingDigit )
    {
        var checkDigit = GenerateVerifyingDigits( startCounter, digits );
        return checkDigit.IsEqual( verifyingDigit );
    }

    private bool IsCnpjFormatValid( string cnpj )
        => Regex.IsMatch( cnpj, RegexPatterns.Cnpj );

    private string RemoveMask( string cnpj )
        => Regex.Replace( cnpj, @"\.|\/|\-", "" );

    public string Generate( bool masked )
    {
        _cnpj = GenerateCalculatingDigits();
        _cnpj += GenerateVerifyingDigits( 5, _cnpj );
        _cnpj += GenerateVerifyingDigits( 6, _cnpj );

        if ( masked )
            _cnpj = _cnpj.Insert( 2, "." ).Insert( 6, "." ).Insert( 10, "/" ).Insert( 15, "-" );

        return _cnpj;
    }

    public string Generate()
        => Generate( false );

    public bool IsValid( string value )
    {
        var validFormat = value.IsNotEmpty()
            && IsCnpjFormatValid( value )
            && !IsPattern( value );

        if ( !validFormat )
            return false;

        var cnpj = RemoveMask( value );

        var calculatingDigits = GetCalculatingDigits( cnpj );
        var firstVerifyingDigit = GetFirstVerifyingDigit( cnpj );
        var secondVerifyingDigit = GetSecondVerifyingDigit( cnpj );

        return ValidateVerifyingDigit( 5, calculatingDigits, firstVerifyingDigit )
            && ValidateVerifyingDigit( 6, calculatingDigits + firstVerifyingDigit, secondVerifyingDigit );
    }

    public bool IsValid()
        => IsValid( _cnpj );
}