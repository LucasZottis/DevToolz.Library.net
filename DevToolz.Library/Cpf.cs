using DevToolz.Library.Extensions;
using DevToolz.Library.Interfaces;
using DevToolz.Library.Structs;
using System.Data.SqlTypes;
using System.Text.RegularExpressions;

namespace DevToolz.Library;

public class Cpf : INumber, IGenerator, IValidator
{
    private string _cpf;
    public string Number { get => _cpf; set => _cpf = value; }

    private bool IsPattern( string value )
    {
        return value.IsEqual( "000000000" ) 
            || value.IsEqual( "111111111" ) 
            || value.IsEqual( "222222222" ) 
            || value.IsEqual( "333333333" ) 
            || value.IsEqual( "444444444" ) 
            || value.IsEqual( "555555555" ) 
            || value.IsEqual( "666666666" ) 
            || value.IsEqual( "777777777" ) 
            || value.IsEqual( "888888888" ) 
            || value.IsEqual( "999999999" );
    }

    private string GenerateCalculatingDigits()
    {
        var rrandomDigits = new Random( DateTime.Now.Second );
        string digits;

        do
        {
            digits = string.Empty;

            for ( int i = 0; i < 9; i++ )
                digits += rrandomDigits.Next( 0, 9 ).ToString();

        } while ( IsPattern( digits ) );

        return digits;
    }

    private string GenerateFirstVerifyingDigit( string digits )
    {
        var result = 0;
        var count = 10;
        int rest;

        foreach ( char digit in digits )
        {
            result += digit.ToInt() * count;
            count--;
        }

        rest = result % 11;

        if ( rest < 2 )
        {
            result = 0;
        }
        else
        {
            result = 11 - rest;
        }

        return result.ToString();
    }

    private string GenerateSecondVerifyingDigit( string dgitis )
    {
        int result = 0;
        int count = 11;
        int rest;

        foreach ( char digit in dgitis )
        {
            result += digit.ToInt() * count;
            count--;
        }

        rest = result % 11;

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
        var result = 0;

        foreach ( char digit in digits )
            result += digit.ToInt() * startCounter--;

        var rest = result % 11;

        if ( rest < 2 )
            result = 0;
        else
            result = 11 - rest;

        return result.IsEqual( verifyingDigit.ToInt() );
    }

    private bool ValidateFirstVerifyingDigit( string digits, string firstVerifyingDigit )
        => ValidateVerifyingDigit( 10, digits, firstVerifyingDigit );

    private bool ValidateSecondVerifyingDigit( string digits, string secondVerifyingDigit )
        => ValidateVerifyingDigit( 11, digits, secondVerifyingDigit );

    private bool IsCpfFormatValid( string value )
    {
        return Regex.IsMatch( value, RegexPatterns.Cpf );
    }

    private string RemoveMask( string value )
        => Regex.Replace( value, @"\.|\/|\-", "" );

    public string Generate()
    {
        _cpf = GenerateCalculatingDigits();
        _cpf += GenerateFirstVerifyingDigit( _cpf );
        _cpf += GenerateSecondVerifyingDigit( _cpf );

        return _cpf;
    }

    public bool IsValid()
    {
        var validFormat = _cpf.IsNotEmpty()
            && IsCpfFormatValid( _cpf )
            && !IsPattern( _cpf );

        if ( !validFormat )
            return false;

        var cpf = RemoveMask( _cpf );

        var calculatingDigits = GetCalculatingDigits( cpf );
        var firstVerifyingDigit = GetFirstVerifyingDigit( cpf );
        var secondVerifyingDigit = GetSecondVerifyingDigit( cpf );

        return ValidateFirstVerifyingDigit( calculatingDigits, firstVerifyingDigit )
            && ValidateSecondVerifyingDigit( calculatingDigits + firstVerifyingDigit, secondVerifyingDigit );
    }
}