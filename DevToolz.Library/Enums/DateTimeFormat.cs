using System.ComponentModel;

namespace DevToolz.Library.Enums;

public enum DateTimeFormat
{
    [Description( "Padrão Banco de Dados Completo (yyyy-MM-dd HH:mm:ss)" )]
    DateTimeDataBase = 1,

    [Description( "Padrão Banco de Dados Apenas a Data (yyyy-MM-dd)" )]
    DateOnlyDataBse,

    [Description( "Padrão brasileiro Completo (dd/MM/yyyy HH:mm:ss)" )]
    DateTime,

    [Description( "Padrão brasileiro apenas data (dd/MM/yyyy)" )]
    DateOnly
}