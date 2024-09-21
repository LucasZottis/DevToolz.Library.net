using System.Configuration;

namespace DevToolz.Library.Extensions;

public static class SettingsExtensions
{
    /// <summary>
    /// Verifica se existe a configuração.
    /// </summary>
    /// <Param name="value">
    /// Chave de AppSettings.
    /// </Param>
    /// <returns>
    /// Retorna true se existir.
    /// </returns>
    public static bool TemConfiguracao( this KeyValueConfigurationElement value )
        => value != null;

    /// <summary>
    /// Verifica se existe o connectionStrings.
    /// </summary>
    /// <Param name="value">
    /// ConnectionString de connectionStrings.
    /// </Param>
    /// <returns>
    /// Retorna true se existir.
    /// </returns>
    public static bool TemConfiguracao( this ConnectionStringSettings value )
        => value != null;
}