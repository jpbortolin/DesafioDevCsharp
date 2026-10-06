using System.Globalization;
using System.Text;
using System.Text.Json;
using DesafioDev;

Console.OutputEncoding = Encoding.UTF8;
CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("pt-BR");

try
{
    var dados = LerJson<DadosVendas>("vendas.json");
    Console.WriteLine("COMISSÕES POR VENDEDOR\n");
    foreach (var grupo in dados.Vendas.GroupBy(v => v.Vendedor))
        Console.WriteLine($"{grupo.Key}: {grupo.Sum(v => Calculos.Comissao(v.Valor)):C2}");
}
catch (Exception ex) when (ex is IOException or JsonException or UnauthorizedAccessException)
{
    Console.Error.WriteLine($"Não foi possível carregar os dados: {ex.Message}");
    Environment.ExitCode = 1;
}

static T LerJson<T>(string nome)
{
    string caminho = Path.Combine(AppContext.BaseDirectory, "Dados", nome);
    return JsonSerializer.Deserialize<T>(File.ReadAllText(caminho),
        new JsonSerializerOptions { PropertyNameCaseInsensitive = true })
        ?? throw new JsonException("Arquivo JSON vazio.");
}

