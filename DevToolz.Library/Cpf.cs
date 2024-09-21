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

    //private string GenerateFirstVerifyingDigit( string digits )
    //{
    //    var result = 0;
    //    var count = 10;
    //    int rest;

    //    foreach ( char digit in digits )
    //    {
    //        result += digit.ToInt() * count;
    //        count--;
    //    }

    //    rest = result % 11;

    //    if ( rest < 2 )
    //        result = 0;
    //    else
    //        result = 11 - rest;

    //    return result.ToString();
    //}

    //private string GenerateSecondVerifyingDigit( string dgitis )
    //{
    //    int result = 0;
    //    int count = 11;
    //    int rest;

    //    foreach ( char digit in dgitis )
    //    {
    //        result += digit.ToInt() * count;
    //        count--;
    //    }

    //    rest = result % 11;

    //    if ( rest < 2 )
    //        result = 0;
    //    else
    //        result = 11 - rest;

    //    return result.ToString();
    //}

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

    //private bool ValidateVerifyingDigit( int startCounter, string digits, string verifyingDigit )
    //{
    //    var result = 0;

    //    foreach ( char digit in digits )
    //        result += digit.ToInt() * startCounter--;

    //    var rest = result % 11;

    //    if ( rest < 2 )
    //        result = 0;
    //    else
    //        result = 11 - rest;

    //    return result.IsEqual( verifyingDigit.ToInt() );
    //}

    private bool ValidateVerifyingDigit( int startCounter, string digits, string firstVerifyingDigit )
    {
        //var checkDigit = GenerateVerifyingDigits( 10, digits );
        var checkDigit = GenerateVerifyingDigits( startCounter, digits );
        return checkDigit.IsEqual( firstVerifyingDigit );
    }

    //private bool ValidateSecondVerifyingDigit( string digits, string secondVerifyingDigit )
    //{
    //    //var checkDigit = GenerateVerifyingDigits( 10, digits );
    //    //return checkDigit.IsEqual( secondVerifyingDigit );
    //    => ValidateVerifyingDigit( 11, digits, secondVerifyingDigit );
    //}

    private bool IsCpfFormatValid( string value )
        => Regex.IsMatch( value, RegexPatterns.Cpf );

    private string RemoveMask( string value )
        => Regex.Replace( value, @"\.|\/|\-", "" );

    public bool IsValid( string value )
    {
        var validFormat = value.IsNotEmpty()
            && IsCpfFormatValid( value )
            && !IsPattern( value );

        if ( !validFormat )
            return false;

        var cpf = RemoveMask( value );
        var calculatingDigits = GetCalculatingDigits( cpf );
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