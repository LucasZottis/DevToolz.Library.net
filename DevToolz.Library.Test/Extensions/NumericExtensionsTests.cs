namespace DevToolz.Library.Test.Extensions;

public class NumericExtensionsTests
{
    private enum SampleEnum
    {
        Zero = 0,
        One = 1,
        Two = 2
    }

    [Fact]
    public void BooleanExtensions_ConvertExpectedValues()
    {
        Assert.Equal((byte)1, true.ToByte());
        Assert.Equal(0m, false.ToDecimal());
        Assert.Equal(1, true.ToInt());
        Assert.Equal(0L, false.ToLong());
    }

    [Fact]
    public void ByteAndIntExtensions_BetweenAndEnum_Work()
    {
        byte value = 2;
        int number = 5;

        Assert.True(value.Between(1, 3));
        Assert.True(number.Between(1, 10));
        Assert.Equal(SampleEnum.Two, value.ToEnum<SampleEnum>());
        Assert.Equal(SampleEnum.One, 1.ToEnum<SampleEnum>());
    }

    [Fact]
    public void DecimalDoubleFloatLongShort_Conversions_Work()
    {
        decimal dec = 1.6m;
        double dbl = 2.4;
        float flt = 3.5f;
        long lng = 9;
        short sht = 7;

        Assert.Equal(2, dec.ToInt());
        Assert.Equal(2, dbl.ToInt());
        Assert.Equal(4, flt.ToInt());
        Assert.Equal('9', lng.ToChar());
        Assert.True(sht.Between(5, 8));
    }

    [Fact]
    public void CharExtensions_IdentifyCharacterTypes()
    {
        Assert.True('8'.IsNumber());
        Assert.True('A'.IsLetter());
        Assert.True('A'.IsCapitalLetter());
        Assert.True('a'.IsLowerCase());
        Assert.True('\b'.IsReturnChar());
        Assert.False('\n'.IsReturnChar());
    }

    [Theory]
    [InlineData(0, '0')]
    [InlineData(5, '5')]
    [InlineData(9, '9')]
    public void IntToChar_WithValidDigit_ReturnsExpectedChar( int value, char expected )
        => Assert.Equal( expected, value.ToChar() );

    [Theory]
    [InlineData(-1)]
    [InlineData(10)]
    [InlineData(100)]
    public void IntToChar_WithInvalidValue_ThrowsArgumentException( int value )
        => Assert.Throws<ArgumentException>( () => value.ToChar() );

    [Theory]
    [InlineData(0, '0')]
    [InlineData(5, '5')]
    [InlineData(9, '9')]
    public void LongToChar_WithValidDigit_ReturnsExpectedChar( long value, char expected )
        => Assert.Equal( expected, value.ToChar() );

    [Theory]
    [InlineData(-1L)]
    [InlineData(10L)]
    public void LongToChar_WithInvalidValue_ThrowsArgumentException( long value )
        => Assert.Throws<ArgumentException>( () => value.ToChar() );

    [Theory]
    [InlineData((short)0, '0')]
    [InlineData((short)5, '5')]
    [InlineData((short)9, '9')]
    public void ShortToChar_WithValidDigit_ReturnsExpectedChar( short value, char expected )
        => Assert.Equal( expected, value.ToChar() );

    [Theory]
    [InlineData((short)-1)]
    [InlineData((short)10)]
    public void ShortToChar_WithInvalidValue_ThrowsArgumentException( short value )
        => Assert.Throws<ArgumentException>( () => value.ToChar() );

    [Theory]
    [InlineData((byte)0, '0')]
    [InlineData((byte)5, '5')]
    [InlineData((byte)9, '9')]
    public void ByteToChar_WithValidDigit_ReturnsExpectedChar( byte value, char expected )
        => Assert.Equal( expected, value.ToChar() );

    [Fact]
    public void ByteToChar_WithInvalidValue_ThrowsArgumentException()
        => Assert.Throws<ArgumentException>( () => ((byte)10).ToChar() );

    [Theory]
    [InlineData(0.0, '0')]
    [InlineData(5.0, '5')]
    [InlineData(9.0, '9')]
    public void DoubleToChar_WithValidDigit_ReturnsExpectedChar( double value, char expected )
        => Assert.Equal( expected, value.ToChar() );

    [Theory]
    [InlineData(-1.0)]
    [InlineData(10.0)]
    public void DoubleToChar_WithInvalidValue_ThrowsArgumentException( double value )
        => Assert.Throws<ArgumentException>( () => value.ToChar() );

    [Theory]
    [InlineData(0f, '0')]
    [InlineData(5f, '5')]
    [InlineData(9f, '9')]
    public void FloatToChar_WithValidDigit_ReturnsExpectedChar( float value, char expected )
        => Assert.Equal( expected, value.ToChar() );

    [Theory]
    [InlineData(-1f)]
    [InlineData(10f)]
    public void FloatToChar_WithInvalidValue_ThrowsArgumentException( float value )
        => Assert.Throws<ArgumentException>( () => value.ToChar() );

    [Fact]
    public void DecimalToChar_WithValidDigit_ReturnsExpectedChar()
    {
        Assert.Equal( '0', 0m.ToChar() );
        Assert.Equal( '5', 5m.ToChar() );
        Assert.Equal( '9', 9m.ToChar() );
    }

    [Fact]
    public void DecimalToChar_WithInvalidValue_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>( () => (-1m).ToChar() );
        Assert.Throws<ArgumentException>( () => 10m.ToChar() );
    }
}
