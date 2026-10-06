namespace DesafioDev;

public class DadosVendas
{
    public List<Venda> Vendas { get; set; } = new();
}

public class Venda
{
    public string Vendedor { get; set; } = "";
    public decimal Valor { get; set; }
}

