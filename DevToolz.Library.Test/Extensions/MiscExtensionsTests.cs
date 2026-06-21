using System.Drawing;
using System.Text;

namespace DevToolz.Library.Test.Extensions;

public class MiscExtensionsTests
{
    private enum Status
    {
        [Description("Ativo")]
        Active,
        Inactive
    }

    private class BaseType;

    private class DerivedType : BaseType
    {
        public DerivedType() { }
        public DerivedType(string name) => Name = name;
        public string Name { get; } = string.Empty;
        public T Echo<T>(T value) => value;
    }

    [Fact]
    public void EnumExtensions_GetDescription_ReturnsAttributeOrFallback()
    {
        Assert.Equal("Ativo", Status.Active.GetDescription());
        Assert.Equal(nameof(Status.Inactive), ((object)Status.Inactive).GetDescription());
    }

    [Fact]
    public void EnumExtensions_GetDescription_EnumOverload_WithoutAttribute_ReturnsName()
    {
        Assert.Equal("Ativo", ((Enum)Status.Active).GetDescription());
        Assert.Equal(nameof(Status.Inactive), ((Enum)Status.Inactive).GetDescription());
    }

    [Fact]
    public void DateTimeAndTimeSpanExtensions_FormatExpectedValues()
    {
        var date = new DateTime(2024, 5, 7, 13, 45, 10);
        var span = new TimeSpan(1, 2, 3, 4);

        Assert.Equal("2024-05-07 13:45:10", date.ToStringFormat(DateTimeFormat.DateTimeDataBase));
        Assert.Equal("26:03:04", span.ToString(false));
        Assert.Equal("1 dias - 02:03:04", span.ToString(true));
    }

    [Fact]
    public void StringBuilderTaskColorAndTypeExtensions_Work()
    {
        var sb = new StringBuilder("123");
        var task = Task.FromResult(42);

        Assert.True(sb.IsNotEmpty());
        Assert.Equal(123, sb.ToInt());
        Assert.Equal(42, task.Sync());
        Assert.True(Color.Transparent.IsTransparent());

        var type = typeof(DerivedType);
        Assert.True(type.IsBaseTypeOf<BaseType>());
        Assert.True(typeof(List<int>).IsCollectionType());
        Assert.IsType<DerivedType>(type.CreateInstance());
        var withArg = (DerivedType)type.CreateInstance("Codex")!;
        Assert.Equal("Codex", withArg.Name);
        Assert.NotNull(type.GetGenericMethod(nameof(DerivedType.Echo)));
    }
}
