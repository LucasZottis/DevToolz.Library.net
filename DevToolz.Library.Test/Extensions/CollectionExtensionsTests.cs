using System.Data;

namespace DevToolz.Library.Test.Extensions;

public class CollectionExtensionsTests
{
    [Fact]
    public void ArrayExtensions_ToList_AndContains_Work()
    {
        Array values = new[] { 1, 2, 3 };

        var list = values.ToList<int>();

        Assert.Equal( new List<int> { 1, 2, 3 }, list );
        Assert.True( values.Contains<int>( x => x == 2 ) );
        Assert.Equal( "1,2,3", values.ToCommaSeparatedList() );
    }

    [Fact]
    public void EnumerableExtensions_CountAnyAndForEach_Work()
    {
        IEnumerable<int> values = new[] { 3, 4, 5 };
        var sum = 0;

        Assert.Equal( 3, values.Count() );
        Assert.True( values.Any() );

        values.ForEach<int>( x => sum += x );

        Assert.Equal( 12, sum );
    }

    [Fact]
    public void DataTableExtensions_IsNotEmpty_RespectsDeletedRows()
    {
        var table = new DataTable();
        table.Columns.Add( "Id", typeof( int ) );

        var row = table.Rows.Add( 1 );
        row.Delete();

        Assert.True( table.IsNotEmpty( true ) );
        Assert.False( table.IsNotEmpty( false ) );
    }

    [Fact]
    public void ListExtensions_IsEmptyList_WorksForNullAndData()
    {
        List<int>? nullList = null;

        Assert.True( nullList.IsEmptyList() );
        Assert.True( new List<int>().IsEmptyList() );
        Assert.False( new List<int> { 1 }.IsEmptyList() );
    }
}
