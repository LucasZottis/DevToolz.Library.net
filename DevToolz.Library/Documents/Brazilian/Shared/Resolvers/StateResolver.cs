using DevToolz.Library.Documents.Brazilian.Shared.Models;

namespace DevToolz.Library.Documents.Brazilian.Shared.Resolvers;

internal static class StateResolver
{
    private static readonly IReadOnlyDictionary<int, IReadOnlyList<State>> _map =
        new Dictionary<int, IReadOnlyList<State>>
        {
            [0] = new State[] { new() { Code = 43, Name = "Rio Grande do Sul",     Abbreviation = "RS" } },
            [1] = new State[]
            {
                new() { Code = 53, Name = "Distrito Federal",   Abbreviation = "DF" },
                new() { Code = 52, Name = "Goiás",              Abbreviation = "GO" },
                new() { Code = 50, Name = "Mato Grosso do Sul", Abbreviation = "MS" },
                new() { Code = 51, Name = "Mato Grosso",        Abbreviation = "MT" },
                new() { Code = 17, Name = "Tocantins",          Abbreviation = "TO" },
            },
            [2] = new State[]
            {
                new() { Code = 12, Name = "Acre",      Abbreviation = "AC" },
                new() { Code = 13, Name = "Amazonas",  Abbreviation = "AM" },
                new() { Code = 16, Name = "Amapá",     Abbreviation = "AP" },
                new() { Code = 15, Name = "Pará",      Abbreviation = "PA" },
                new() { Code = 11, Name = "Rondônia",  Abbreviation = "RO" },
                new() { Code = 14, Name = "Roraima",   Abbreviation = "RR" },
            },
            [3] = new State[]
            {
                new() { Code = 23, Name = "Ceará",    Abbreviation = "CE" },
                new() { Code = 21, Name = "Maranhão", Abbreviation = "MA" },
                new() { Code = 22, Name = "Piauí",    Abbreviation = "PI" },
            },
            [4] = new State[]
            {
                new() { Code = 27, Name = "Alagoas",              Abbreviation = "AL" },
                new() { Code = 25, Name = "Paraíba",              Abbreviation = "PB" },
                new() { Code = 26, Name = "Pernambuco",           Abbreviation = "PE" },
                new() { Code = 24, Name = "Rio Grande do Norte",  Abbreviation = "RN" },
            },
            [5] = new State[]
            {
                new() { Code = 29, Name = "Bahia",   Abbreviation = "BA" },
                new() { Code = 28, Name = "Sergipe", Abbreviation = "SE" },
            },
            [6] = new State[] { new() { Code = 31, Name = "Minas Gerais",    Abbreviation = "MG" } },
            [7] = new State[]
            {
                new() { Code = 32, Name = "Espírito Santo",  Abbreviation = "ES" },
                new() { Code = 33, Name = "Rio de Janeiro",  Abbreviation = "RJ" },
            },
            [8] = new State[] { new() { Code = 35, Name = "São Paulo",       Abbreviation = "SP" } },
            [9] = new State[]
            {
                new() { Code = 41, Name = "Paraná",          Abbreviation = "PR" },
                new() { Code = 42, Name = "Santa Catarina",  Abbreviation = "SC" },
            },
        };

    public static IReadOnlyList<State> Resolve( int digit )
        => _map.TryGetValue( digit, out var states ) ? states : Array.Empty<State>();
}
