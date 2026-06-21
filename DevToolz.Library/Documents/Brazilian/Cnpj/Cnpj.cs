using DevToolz.Library.Documents.Brazilian.Cnpj.Interfaces;
using DevToolz.Library.Documents.Brazilian.Shared;

namespace DevToolz.Library.Documents.Brazilian.Cnpj;

public sealed class Cnpj : ICnpjMetadata, ICnpjData
{
    private static readonly ICnpjValidator _validator = CnpjFactory.CreateValidator();
    private static readonly ICnpjGenerator _generator = CnpjFactory.CreateGenerator();

    private string _value = string.Empty;
    private readonly CnpjFormat _format;

    private string Digits
        => BrazilianDocumentHelper.RemoveMask( _value );

    public string BaseDigits
        => Digits[ ..12 ];

    public string FirstVerifyingDigit
        => Digits[ 12 ].ToString();

    public string SecondVerifyingDigit
        => Digits[ 13 ].ToString();

    public Cnpj() { }

    public Cnpj( string cnpj )
    {
        _value  = cnpj;
        _format = BrazilianDocumentHelper.DetectCnpjFormat( cnpj );
    }

    public Cnpj( CnpjFormat format )
    {
        _format = format;
    }

    public Cnpj( string cnpj, CnpjFormat format )
    {
        _value  = cnpj;
        _format = format;
    }

    public bool IsValid()
        => _validator.IsValid( _value, _format );

    public string Generate()
        => _value = _generator.Generate( _format );

    public string Masked()
        => BrazilianDocumentHelper.MaskCnpj( Digits );

    public string Unmasked()
        => Digits;
}
