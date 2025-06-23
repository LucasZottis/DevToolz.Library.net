using DevToolz.Library.SqlIdent.Interfaces;

namespace DevToolz.Library.SqlIdent.Models;

internal class ParenthesisNode : ISQLTreeNode
{
    private SqlTree tree;

    internal SqlTree Tree
    {
        get { return tree; }
        set { tree = value; }
    }

    public object Content => tree;

    internal ParenthesisNode( SqlTree sqlTree )
    {
        Tree = sqlTree;
    }

    internal ParenthesisNode() : this( new SqlTree() ) { }
}