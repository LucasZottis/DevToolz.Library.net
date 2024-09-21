using DevToolz.Library.Extensions;
using DevToolz.Library.Interfaces;
using DevToolz.Library.Structs;
using System.Text.RegularExpressions;

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

    private string GenerateFirstVerifyingDigit( string digits )
    {
        var resultado = 0;
        var contador = 5;
        int resto;

        foreach ( char digito in digits )
        {
            resultado += digito.ToInt() * contador;
            contador--;
            if ( contador < 2 )
                contador = 9;
        }

        resto = resultado % 11;

        if ( resto < 2 )
            resultado = 0;
        else
            resultado = 11 - resto;

        return resultado.ToString();
    }

    private string GenerateSecondVerifyingDigit( string digits )
    {
        int resultado = 0;
        int contador = 6;
        int resto;

        foreach ( char digito in digits )
        {
            resultado += digito.ToInt() * contador;
            contador--;

            if ( contador < 2 )
                contador = 9;
        }

        resto = resultado % 11;

        if ( resto < 2 )
            resultado = 0;
        else
            resultado = 11 - resto;

        return resultado.ToString();
    }

    private string GetCalculatingDigits( string value )
        => value.Substring( 0, 12 );

    private string GetFirstVerifyingDigit( string cnpj )
        => cnpj[ 12 ].ToString();

    private string GetSecondVerifyingDigit( string cnpj )
        => cnpj[ 13 ].ToString();

    private bool ValidateVerifyingDigit( int startConuter, string digits, string verifyingDigit )
    {
        var result = 0;

        foreach ( char digito in digits )
        {
            result += digito.ToByte() * startConuter;
            startConuter--;

            if ( startConuter < 2 )
                startConuter = 9;
        }

        var rest = result % 11;

        if ( rest < 2 )
            result = 0;
        else
            result = 11 - rest;

        return result.IsEqual( verifyingDigit.ToInt() );
    }

    private bool ValidateFirstVerifyingDigit( string digits, string firstVerifyingDigit )
        => ValidateVerifyingDigit( 5, digits, firstVerifyingDigit );

    private bool ValidateSecondVerifyingDigit( string digits, string secondVerifyingDigit )
        => ValidateVerifyingDigit( 6, digits, secondVerifyingDigit );

    private bool IsCnpjFormatValid( string cnpj )
    {
        return Regex.IsMatch( cnpj, RegexPatterns.Cnpj );
    }

    private string RemoveMask( string cnpj )
        => Regex.Replace( cnpj, @"\.|\/|\-", "" );

    public string Generate()
    {
        _cnpj = GenerateCalculatingDigits();
        _cnpj += GenerateFirstVerifyingDigit( _cnpj );
        _cnpj += GenerateSecondVerifyingDigit( _cnpj );

        return _cnpj;
    }

    public bool IsValid()
    {
        var validFormat = _cnpj.IsNotEmpty()
            && IsCnpjFormatValid( _cnpj )
            && !IsPattern( _cnpj );

        if ( !validFormat )
            return false;

        var cnpj = RemoveMask( _cnpj );

        var calculatingDigits = GetCalculatingDigits( cnpj );
        var firstVerifyingDigit = GetFirstVerifyingDigit( cnpj );
        var secondVerifyingDigit = GetSecondVerifyingDigit( cnpj );

        return ValidateFirstVerifyingDigit( calculatingDigits, firstVerifyingDigit )
            && ValidateSecondVerifyingDigit( calculatingDigits + firstVerifyingDigit, secondVerifyingDigit );
    }

    public bool IsValid( string value )
    {
        throw new NotImplementedException();
    }

    public string Generate( bool masked )
    {
        throw new NotImplementedException();
    }
}