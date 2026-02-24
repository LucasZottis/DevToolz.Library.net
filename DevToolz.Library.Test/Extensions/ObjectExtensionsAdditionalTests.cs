namespace DevToolz.Library.Test.Extensions;

public class ObjectExtensionsAdditionalTests
{
    [Fact]
    public void IsNullAndIsNotNull_AreComplementary()
    {
        object? value = "abc";
        Assert.False( value.IsNull() );
        Assert.True( value.IsNotNull() );

        value = null;
        Assert.True( value.IsNull() );
        Assert.False( value.IsNotNull() );
    }
}
