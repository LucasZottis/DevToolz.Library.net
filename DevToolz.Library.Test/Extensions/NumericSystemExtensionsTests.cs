namespace DevToolz.Library.Test.Extensions;

public class NumericSystemExtensionsTests
{
    #region int -> Binary

    [Fact]
    public void ToBinary_Int_Zero_ReturnsZero()
        => Assert.Equal( "0", 0.ToBinary() );

    [Fact]
    public void ToBinary_Int_Ten_ReturnsBinaryString()
        => Assert.Equal( "1010", 10.ToBinary() );

    [Fact]
    public void ToBinary_Int_255_Returns8Bits()
        => Assert.Equal( "11111111", 255.ToBinary() );

    #endregion

    #region int -> Octal

    [Fact]
    public void ToOctal_Int_Zero_ReturnsZero()
        => Assert.Equal( "0", 0.ToOctal() );

    [Fact]
    public void ToOctal_Int_Eight_Returns10()
        => Assert.Equal( "10", 8.ToOctal() );

    [Fact]
    public void ToOctal_Int_255_Returns377()
        => Assert.Equal( "377", 255.ToOctal() );

    #endregion

    #region int -> Hexadecimal

    [Fact]
    public void ToHexadecimal_Int_Zero_ReturnsZero()
        => Assert.Equal( "0", 0.ToHexadecimal() );

    [Fact]
    public void ToHexadecimal_Int_255_ReturnsFF()
        => Assert.Equal( "FF", 255.ToHexadecimal() );

    [Fact]
    public void ToHexadecimal_Int_16_Returns10()
        => Assert.Equal( "10", 16.ToHexadecimal() );

    [Fact]
    public void ToHexadecimal_Int_ReturnsUpperCase()
        => Assert.Equal( "1A2B", 6699.ToHexadecimal() );

    #endregion

    #region long -> Binary, Octal, Hexadecimal

    [Fact]
    public void ToBinary_Long_LargeValue_ReturnsCorrectBinary()
        => Assert.Equal( "10000000000000000000000000000000", 2147483648L.ToBinary() );

    [Fact]
    public void ToOctal_Long_LargeValue_ReturnsCorrectOctal()
        => Assert.Equal( "20000000000", 2147483648L.ToOctal() );

    [Fact]
    public void ToHexadecimal_Long_LargeValue_ReturnsCorrectHex()
        => Assert.Equal( "80000000", 2147483648L.ToHexadecimal() );

    #endregion

    #region Binary string conversions

    [Fact]
    public void BinaryToDecimal_1010_Returns10()
        => Assert.Equal( 10, "1010".BinaryToDecimal() );

    [Fact]
    public void BinaryToDecimal_11111111_Returns255()
        => Assert.Equal( 255, "11111111".BinaryToDecimal() );

    [Fact]
    public void BinaryToOctal_11111111_Returns377()
        => Assert.Equal( "377", "11111111".BinaryToOctal() );

    [Fact]
    public void BinaryToHexadecimal_11111111_ReturnsFF()
        => Assert.Equal( "FF", "11111111".BinaryToHexadecimal() );

    [Fact]
    public void BinaryToOctal_1010_Returns12()
        => Assert.Equal( "12", "1010".BinaryToOctal() );

    [Fact]
    public void BinaryToHexadecimal_1010_ReturnsA()
        => Assert.Equal( "A", "1010".BinaryToHexadecimal() );

    #endregion

    #region Octal string conversions

    [Fact]
    public void OctalToDecimal_377_Returns255()
        => Assert.Equal( 255, "377".OctalToDecimal() );

    [Fact]
    public void OctalToDecimal_10_Returns8()
        => Assert.Equal( 8, "10".OctalToDecimal() );

    [Fact]
    public void OctalToBinary_377_Returns11111111()
        => Assert.Equal( "11111111", "377".OctalToBinary() );

    [Fact]
    public void OctalToBinary_10_Returns1000()
        => Assert.Equal( "1000", "10".OctalToBinary() );

    [Fact]
    public void OctalToHexadecimal_377_ReturnsFF()
        => Assert.Equal( "FF", "377".OctalToHexadecimal() );

    [Fact]
    public void OctalToHexadecimal_10_Returns8()
        => Assert.Equal( "8", "10".OctalToHexadecimal() );

    #endregion

    #region Hexadecimal string conversions

    [Fact]
    public void HexadecimalToDecimal_FF_Returns255()
        => Assert.Equal( 255, "FF".HexadecimalToDecimal() );

    [Fact]
    public void HexadecimalToDecimal_LowerCase_ff_Returns255()
        => Assert.Equal( 255, "ff".HexadecimalToDecimal() );

    [Fact]
    public void HexadecimalToDecimal_10_Returns16()
        => Assert.Equal( 16, "10".HexadecimalToDecimal() );

    [Fact]
    public void HexadecimalToBinary_FF_Returns11111111()
        => Assert.Equal( "11111111", "FF".HexadecimalToBinary() );

    [Fact]
    public void HexadecimalToBinary_10_Returns10000()
        => Assert.Equal( "10000", "10".HexadecimalToBinary() );

    [Fact]
    public void HexadecimalToOctal_FF_Returns377()
        => Assert.Equal( "377", "FF".HexadecimalToOctal() );

    [Fact]
    public void HexadecimalToOctal_10_Returns20()
        => Assert.Equal( "20", "10".HexadecimalToOctal() );

    #endregion

    #region Round-trip conversions

    [Fact]
    public void RoundTrip_DecimalToBinaryAndBack()
    {
        int original = 42;
        string binary = original.ToBinary();
        int result = binary.BinaryToDecimal();
        Assert.Equal( original, result );
    }

    [Fact]
    public void RoundTrip_DecimalToOctalAndBack()
    {
        int original = 255;
        string octal = original.ToOctal();
        int result = octal.OctalToDecimal();
        Assert.Equal( original, result );
    }

    [Fact]
    public void RoundTrip_DecimalToHexadecimalAndBack()
    {
        int original = 1000;
        string hex = original.ToHexadecimal();
        int result = hex.HexadecimalToDecimal();
        Assert.Equal( original, result );
    }

    #endregion
}
