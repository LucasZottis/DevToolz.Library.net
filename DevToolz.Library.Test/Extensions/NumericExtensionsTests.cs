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
        Assert.Equal( (byte)1, true.ToByte() );
        Assert.Equal( 0m, false.ToDecimal() );
        Assert.Equal( 1, true.ToInt() );
        Assert.Equal( 0L, false.ToLong() );
    }

    [Fact]
    public void ByteAndIntExtensions_BetweenAndEnum_Work()
    {
        byte value = 2;
        int number = 5;

        Assert.True( value.Between( 1, 3 ) );
        Assert.True( number.Between( 1, 10 ) );
        Assert.Equal( SampleEnum.Two, value.ToEnum<SampleEnum>() );
        Assert.Equal( SampleEnum.One, 1.ToEnum<SampleEnum>() );
    }

    [Fact]
    public void DecimalDoubleFloatLongShort_Conversions_Work()
    {
        decimal dec = 1.6m;
        double dbl = 2.4;
        float flt = 3.5f;
        long lng = 9;
        short sht = 7;

        Assert.Equal( 2, dec.ToInt() );
        Assert.Equal( 2, dbl.ToInt() );
        Assert.Equal( 4, flt.ToInt() );
        Assert.Equal( '9', lng.ToChar() );
        Assert.True( sht.Between( 5, 8 ) );
    }

    [Fact]
    public void CharExtensions_IdentifyCharacterTypes()
    {
        Assert.True( '8'.IsNumber() );
        Assert.True( 'A'.IsLetter() );
        Assert.True( 'A'.IsCapitalLetter() );
        Assert.True( 'a'.IsLowerCase() );
        Assert.True( '\n'.IsReturnChar() );
    }
}
