using System.Data;

namespace DevToolz.Library.Extensions;

public static class DataTableExtensions
{
    /// <summary>
    /// Verifica se tem registros na tabela informada.
    /// </summary>
    /// <Param name="table">
    /// DataTable que deseja verificar.
    /// </Param>
    /// <returns>
    /// Retorna true se tiver registros.
    /// </returns>
    public static bool IsNotEmpty( this DataTable table )
    {
        if ( table == null )
            return false;

        return table.Rows.Count > 0;
    }

    /// <summary>
    /// Verifica se tem registros na tabela informada.
    /// </summary>
    /// <Param name="table">
    /// DataTable que deseja verificar.
    /// </Param>
    /// <Param name="considerDeletedLines">
    /// Se deve contar as linhas excluídas ou não.
    /// </Param>
    /// <returns>
    /// Retorna true se tiver registros.
    /// </returns>
    public static bool IsNotEmpty( this DataTable table, bool considerDeletedLines )
        => considerDeletedLines
            ? table.IsNotEmpty()
            : table.AsEnumerable().Where( item => item.RowState != DataRowState.Deleted ).Count() > 0;
}