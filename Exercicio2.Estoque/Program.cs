using System.Globalization;
using System.Text;
using System.Text.Json;
using DesafioDev;

Console.OutputEncoding = Encoding.UTF8;
CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("pt-BR");

try
{
    var controle = new ControleEstoque(LerJson<DadosEstoque>("estoque.json").Estoque);
    while (true)
    {
        Console.WriteLine("\n1 - Consultar estoque\n2 - Movimentar estoque\n3 - Histórico\n0 - Sair");
        Console.Write("Opção: ");
        string? opcao = Console.ReadLine();
        if (opcao is null or "0") break;
        try
        {
            switch (opcao)
            {
                case "1":
                    foreach (var p in controle.Produtos)
                        Console.WriteLine($"{p.CodigoProduto} - {p.DescricaoProduto}: {p.Quantidade} unidades");
                    break;
                case "2":
                    int codigo = LerInteiro("Código do produto: ");
                    string tipo = LerTexto("Tipo (1 = Entrada; 2 = Saída): ") switch
                    {
                        "1" => "Entrada", "2" => "Saída",
                        _ => throw new ArgumentException("Escolha 1 ou 2.")
                    };
                    int quantidade = LerInteiro("Quantidade: ");
                    string descricao = LerTexto("Descrição: ");
                    var m = controle.Movimentar(codigo, tipo, quantidade, descricao);
                    Console.WriteLine($"Movimentação nº {m.Id} | {m.Tipo} | {m.Descricao} | Estoque final: {m.SaldoFinal}");
                    break;
                case "3":
                    if (controle.Historico.Count == 0) Console.WriteLine("Nenhuma movimentação registrada.");
                    foreach (var h in controle.Historico)
                        Console.WriteLine($"#{h.Id} | Produto {h.CodigoProduto} | {h.Tipo}: {h.Quantidade} | {h.Descricao} | Saldo: {h.SaldoFinal}");
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }
        catch (ArgumentException ex) { Console.WriteLine(ex.Message); }
        catch (OverflowException) { Console.WriteLine("O número informado ultrapassa o limite permitido."); }
    }
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

static string LerTexto(string mensagem)
{
    Console.Write(mensagem);
    return (Console.ReadLine() ?? "").Trim();
}

static int LerInteiro(string mensagem)
{
    if (!int.TryParse(LerTexto(mensagem), out int valor))
        throw new ArgumentException("Informe um número inteiro válido.");
    return valor;
}
