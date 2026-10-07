using System.Text.Json.Serialization;

namespace DesafioDev;

public class DadosEstoque
{
    public List<Produto> Estoque { get; set; } = new();
}

public class Produto
{
    public int CodigoProduto { get; set; }
    public string DescricaoProduto { get; set; } = "";
    [JsonPropertyName("estoque")]
    public int Quantidade { get; set; }
}

public record Movimentacao(long Id, int CodigoProduto, string Tipo,
    string Descricao, int Quantidade, int SaldoFinal);

