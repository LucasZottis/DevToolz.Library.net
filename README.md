# DevToolz Library .NET

Biblioteca de funcionalidades gerais para desenvolvedores .NET 8. Oferece validação e geração de documentos brasileiros (CPF e CNPJ numérico e alfanumérico), criptografia, extensões de tipos nativos, conversão entre sistemas numéricos, análise de texto, conversão de formatos e utilitários de data.

---

## Índice

- [CNPJ](#cnpj)
- [CPF](#cpf)
- [Email](#email)
- [Criptografia](#criptografia)
- [Extensions — String](#extensions--string)
- [Extensions — Tipos Numéricos](#extensions--tipos-numéricos)
- [Extensions — Char e Bool](#extensions--char-e-bool)
- [Extensions — DateTime e TimeSpan](#extensions--datetime-e-timespan)
- [Extensions — Coleções](#extensions--coleções)
- [Conversão de Sistemas Numéricos](#conversão-de-sistemas-numéricos)
- [Contador de Letras](#contador-de-letras)
- [Conversor de Formatos](#conversor-de-formatos)

---

## CNPJ

Suporte completo ao CNPJ **numérico** (formato atual) e **alfanumérico** (IN RFB nº 2.229/2024, vigência julho/2026). O algoritmo de cálculo dos dígitos verificadores é o mesmo para os dois formatos.

### Enum `CnpjFormat`

```csharp
CnpjFormat.Numeric       // padrão — apenas dígitos (0-9)
CnpjFormat.Alphanumeric  // posições 1-12 aceitam [A-Z0-9]; DVs sempre numéricos
```

### Facade `Cnpj`

```csharp
// Construtor vazio — formato Numeric por padrão
var cnpj = new Cnpj();

// Com valor — formato autodetectado pela presença de letras nas 12 primeiras posições
var cnpj = new Cnpj( "72.799.201/0001-01" );
var cnpj = new Cnpj( "12ABC34501DE35" );

// Com formato explícito
var cnpj = new Cnpj( CnpjFormat.Alphanumeric );
var cnpj = new Cnpj( "12ABC34501DE35", CnpjFormat.Alphanumeric );
```

#### Validação

```csharp
// Numérico — com e sem máscara
new Cnpj( "72.799.201/0001-01" ).IsValid(); // true
new Cnpj( "28777566000143" ).IsValid();      // true
new Cnpj( "00.000.000/0000-00" ).IsValid();  // false

// Alfanumérico — autodetectado pelo construtor
new Cnpj( "12ABC34501DE35" ).IsValid();      // true
new Cnpj( "12.ABC.345/01DE-35" ).IsValid(); // true

// Alfanumérico — formato explícito
new Cnpj( "12ABC34501DE35", CnpjFormat.Alphanumeric ).IsValid(); // true

// Forçar Numeric rejeita letras nas posições da raiz
new Cnpj( "12ABC34501DE35", CnpjFormat.Numeric ).IsValid(); // false
```

#### Geração

```csharp
var cnpj = new Cnpj();
cnpj.Generate();          // gera CNPJ numérico; armazena internamente

var cnpj = new Cnpj( CnpjFormat.Alphanumeric );
cnpj.Generate();          // gera CNPJ alfanumérico

cnpj.Masked();            // "AB.CDE.FGH/0001-42"
cnpj.Unmasked();          // "ABCDEFGH000142"
```

#### Metadados

```csharp
var cnpj = new Cnpj( "12ABC34501DE35" );
cnpj.BaseDigits;            // "12ABC34501DE"
cnpj.FirstVerifyingDigit;   // "3"
cnpj.SecondVerifyingDigit;  // "5"
```

### `CnpjFactory` + interfaces

Use o factory para obter validadores e geradores sem depender da classe facade.

```csharp
using DevToolz.Library.Documents.Brazilian.Cnpj.Interfaces;

ICnpjValidator validator = CnpjFactory.CreateValidator();
ICnpjGenerator generator = CnpjFactory.CreateGenerator();

// IValidator — autodetecta o formato pelo conteúdo
validator.IsValid( "72.799.201/0001-01" );  // true  (numérico)
validator.IsValid( "12ABC34501DE35" );      // true  (alfanumérico autodetectado)

// ICnpjValidator — formato explícito
validator.IsValid( "12ABC34501DE35", CnpjFormat.Alphanumeric ); // true
validator.IsValid( "12ABC34501DE35", CnpjFormat.Numeric );      // false

// IGenerator
string numerico    = generator.Generate();                          // sem máscara
string mascarado   = generator.Generate( true );                    // com máscara

// ICnpjGenerator
string alfa        = generator.Generate( CnpjFormat.Alphanumeric );       // sem máscara
string alfaMask    = generator.Generate( true, CnpjFormat.Alphanumeric ); // com máscara

// Round-trip garantido
validator.IsValid( generator.Generate( CnpjFormat.Alphanumeric ), CnpjFormat.Alphanumeric ); // true
```

> `CnpjFactory.CreateValidator()` retorna `ICnpjValidator`, que herda de `IValidator`. Código existente que armazena o resultado como `IValidator` continua funcionando sem alteração.

---

## CPF

### Facade `Cpf`

```csharp
var cpf = new Cpf();
var cpf = new Cpf( "123.456.789-10" );
```

#### Validação e geração

```csharp
new Cpf( "529.982.247-25" ).IsValid(); // true
new Cpf( "111.111.111-11" ).IsValid(); // false

var cpf = new Cpf();
cpf.Generate();     // gera CPF válido; armazena internamente
cpf.Masked();       // "529.982.247-25"
cpf.Unmasked();     // "52998224725"
```

#### Metadados

```csharp
var cpf = new Cpf( "529.982.247-25" );
cpf.BaseDigits;            // "529982247"
cpf.FirstVerifyingDigit;   // "2"
cpf.SecondVerifyingDigit;  // "5"
cpf.IssuingUnitDigit;      // 4  (8º dígito — define a região emissora)
cpf.IssuingStates;         // IReadOnlyList<State> com estado(s) emissor(es)
```

#### `State`

```csharp
cpf.IssuingStates[0].Code;         // ex.: 4
cpf.IssuingStates[0].Name;         // ex.: "Rio Grande do Sul"
cpf.IssuingStates[0].Abbreviation; // ex.: "RS"
```

### `CpfFactory` + interfaces

```csharp
IValidator validator = CpfFactory.CreateValidator();
IGenerator generator = CpfFactory.CreateGenerator();

validator.IsValid( "529.982.247-25" ); // true
validator.IsValid( generator.Generate() ); // true
validator.IsValid( generator.Generate( true ) ); // true (com máscara)
```

---

## Email

```csharp
var email = new Email { Value = "usuario@exemplo.com.br" };
email.IsValid();                          // true
email.IsValid( "invalido@" );            // false
email.ValidateEmailDomain( "usuario@exemplo.com.br" ); // true
```

---

## Criptografia

Cinco algoritmos simétricos com entrada e saída em Base64. A derivação de chave usa PBKDF2-SHA256 com salts configuráveis — dados criptografados com um salt só podem ser descriptografados com o mesmo salt.

### `CryptProvider`

```csharp
CryptProvider.Aes
CryptProvider.Rijndael
CryptProvider.TripleDES
CryptProvider.DES
CryptProvider.RC2
```

### `Crypt`

```csharp
// Usa salts padrão da biblioteca
var crypt = new Crypt();

// Usa salts personalizados
var crypt = new Crypt( keySalt: "minha-aplicacao.key", ivSalt: "minha-aplicacao.iv" );

string encrypted = crypt.Encrypt( "dados sensíveis", "minhaChave", CryptProvider.Aes );
string decrypted = crypt.Decrypt( encrypted, "minhaChave", CryptProvider.Aes );
```

### `CryptFactory` + injeção de algoritmo

```csharp
ICryptAlgorithm algoritmo = CryptFactory.Create( CryptProvider.Aes );
// ou com salts personalizados:
ICryptAlgorithm algoritmo = CryptFactory.Create( CryptProvider.Aes, "minha-aplicacao.key", "minha-aplicacao.iv" );

var crypt = new Crypt( algoritmo );
string encrypted = crypt.Encrypt( "texto", "chave", CryptProvider.Aes );
```

### Compatibilidade com versões anteriores

`Rijndael`, `DES`, `RC2` e `TripleDES` descriptografam automaticamente dados gerados pela versão anterior da biblioteca, sem necessidade de migração.

---

## Extensions — String

Métodos de extensão sobre `string`.

### Verificação

```csharp
"".IsEmpty();                    // true  (nulo, vazio ou só espaços)
"texto".IsNotEmpty();            // true
"abc".IsEqual( "abc" );          // true
"abc".IsNotEqual( "xyz" );       // true
"hello".Contains( 'e' );         // true
"hello".Contains( new[]{'e','x'} ); // true
"123".IsAllNumbers();            // true
"   ".IsAllWhiteSpaces();        // true
"abc".LengthIsEqual( 3 );        // true
"abc".IsGreaterThan( 2 );        // true
"ab".IsLessThan( 5 );            // true
```

### Conversão de tipo

```csharp
"1".ToBoolean();    // true  ("1" ou "true")
"42".ToInt();
"3.14".ToDouble();
"3,14".ToDecimal(); // suporta vírgula como separador
"A".ToChar();
"01/01/2025".ToDateTime();
"Ativo".ToEnum<Status>();
```

### Limpeza

```csharp
"123.456.789-10".RemoveMask();   // "12345678910"  (remove . - / \)
"São Paulo".RemoveAccents();     // "Sao Paulo"
"1.234".RemovePeriods();
"1,234".RemoveComma();
"abc/def".RemoveSlashes();
"abc-def".RemoveHyphens();
"a_b".RemoverUnderline();
```

---

## Extensions — Tipos Numéricos

### `int`

```csharp
42.ToBoolean();   // true (≠ 0)
42.ToDecimal();
42.ToLong();
42.IsEqual( 42 );
42.GreaterThan( 10 );   // true
42.LessThan( 100 );     // true
42.Between( 10, 100 );  // true

// Unidades de armazenamento
1024.BitToByte();       // 128
1.BitToKiloByte();
1.BitToMegaBytes();
1.BitToGigaBytes();
```

### `double` / `decimal` / `float`

```csharp
3.14.Between( 3.0, 4.0 );  // true
3.14.IsEqual( 3.14 );

// decimal — conversão de horas decimais
1.5m.ToTimeSpan(); // TimeSpan de 1h30min
```

### `long`

```csharp
1024L.BitToByte();
```

### `byte`

```csharp
(byte)65 .ToChar();    // 'A'
(byte)1  .ToBoolean(); // true
```

---

## Extensions — Char e Bool

### `char`

```csharp
'5'.IsNumber();          // true
'A'.IsLetter();          // true
'A'.IsCapitalLetter();   // true
'a'.IsLowerCase();       // true
'!'.IsSymbol();          // true
'A'.IsEqual( 'A' );      // true
'A'.ToInt();             // 65
```

### `bool`

```csharp
true.ToInt();     // 1
false.ToByte();   // 0
true.ToDecimal(); // 1m
```

---

## Extensions — DateTime e TimeSpan

### `DateTime`

```csharp
DateTime hoje = DateTime.Today;
hoje.FirstDayOfTheWeek();    // domingo da semana
hoje.LastDayOfTheWeek();     // sábado da semana
hoje.FirstDayOfTheMonth();
hoje.LastDayOfTheMonth();
hoje.GetStartDateOfDayFromDate(); // 00:00:00
hoje.GetEndDateOfDayFromDate();   // 23:59:59

hoje.ToStringFormat( DateTimeFormat.DateTime );    // "21/06/2026 10:30:00"
hoje.ToStringFormat( DateTimeFormat.DateOnly );    // "21/06/2026"
hoje.ToStringFormat( DateTimeFormat.DateTimeDataBase ); // "2026-06-21 10:30:00"
```

### `DateTimeFormat`

```csharp
DateTimeFormat.DateTime         // "dd/MM/yyyy HH:mm:ss"
DateTimeFormat.DateOnly         // "dd/MM/yyyy"
DateTimeFormat.DateTimeDataBase // "yyyy-MM-dd HH:mm:ss"
DateTimeFormat.DateOnlyDataBse  // "yyyy-MM-dd"
```

### `TimeSpan`

```csharp
TimeSpan ts = TimeSpan.FromHours( 26.5 );
ts.ToString( showDays: false ); // "26:30:00"
ts.ToString( showDays: true );  // "1 dias - 02:30:00"
ts.ToDecimal();                 // 26.5m
```

---

## Extensions — Coleções

### Array

```csharp
int[] numeros = { 1, 2, 3 };
numeros.ForEach<int>( n => Console.Write( n ) );
numeros.ToList<int>();
numeros.ToCommaSeparatedList();      // "1,2,3"
numeros.ToCharSeparatedList( ';' );  // "1;2;3"
numeros.Contains<int>( n => n > 2 ); // true
```

### `List<T>`

```csharp
List<string> lista = null;
lista.IsEmptyList(); // true

lista = new List<string>();
lista.IsEmptyList(); // true
```

### `IEnumerable`

```csharp
IEnumerable items = new[] { 1, 2, 3 };
items.Count();    // 3
items.Any();      // true
items.ForEach<int>( i => Console.WriteLine( i ) );
```

### `DataTable`

```csharp
DataTable dt = /* ... */;
dt.IsNotEmpty();                       // true se Rows.Count > 0
dt.IsNotEmpty( considerDeletedLines: true );
```

### `object`

```csharp
object obj = null;
obj.IsNull();    // true
obj.IsNotNull(); // false
```

---

## Conversão de Sistemas Numéricos

Conversões diretas entre decimal, binário, octal e hexadecimal.

### De `int` ou `long`

```csharp
255.ToBinary();       // "11111111"
255.ToOctal();        // "377"
255.ToHexadecimal();  // "FF"

255L.ToBinary();
255L.ToOctal();
255L.ToHexadecimal();
```

### De `string`

```csharp
// Binário
"11111111".BinaryToDecimal();     // 255
"11111111".BinaryToOctal();       // "377"
"11111111".BinaryToHexadecimal(); // "FF"

// Octal
"377".OctalToDecimal();           // 255
"377".OctalToBinary();            // "11111111"
"377".OctalToHexadecimal();       // "FF"

// Hexadecimal
"FF".HexadecimalToDecimal();      // 255
"FF".HexadecimalToBinary();       // "11111111"
"FF".HexadecimalToOctal();        // "377"
```

---

## Contador de Letras

Analisa um texto e retorna contagem detalhada de caracteres, palavras e sentenças.

```csharp
var counter = new TextLetterCounter();
TextLetterCountResult result = counter.Count( "Olá mundo! Como você está?" );

result.TotalCharacters;              // total de caracteres
result.TotalCharactersWithoutSpaces; // sem espaços
result.TotalSpaces;                  // espaços
result.TotalVowels;                  // vogais (a e i o u)
result.TotalConsonants;              // consoantes
result.TotalNumbers;                 // dígitos numéricos
result.TotalWords;                   // palavras
result.TotalSentences;               // sentenças (., !, ?)
```

#### Com busca de repetições

```csharp
TextLetterCountResult result = counter.Count( "banana", "an" );
result.TotalTextRepetitions; // ocorrências de "an" no texto
```

---

## Conversor de Formatos

### CSV para JSON

```csharp
string csv = "Nome,Idade\nJoão,30\nMaria,25";

var converter = new CsvToJsonConverter();
string json = converter.Convert( csv );
// [{"Nome":"João","Idade":"30"},{"Nome":"Maria","Idade":"25"}]
```

### Via `FormatConversionService`

```csharp
var service = FormatConversionService.CreateDefault();
string json = service.Convert( "csv", "json", csvContent );
```

#### Implementando conversor personalizado

```csharp
public class MeuConverter : IFormatConverter
{
    public string SourceFormat => "xml";
    public string TargetFormat => "json";
    public string Convert( string input ) { /* ... */ }
}

var registry = new FormatConverterRegistry();
registry.Register( new MeuConverter() );
var service = new FormatConversionService( registry );
```
