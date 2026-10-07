namespace DesafioDev;

public class ControleEstoque
{
    private readonly List<Produto> produtos;
    private readonly List<Movimentacao> historico = new();
    private long proximoId = 1;

    public ControleEstoque(List<Produto> produtos)
    {
        this.produtos = produtos;
    }

    public IReadOnlyList<Produto> Produtos => produtos.AsReadOnly();
    public IReadOnlyList<Movimentacao> Historico => historico.AsReadOnly();

    public Movimentacao Movimentar(int codigo, string tipo, int quantidade, string descricao)
    {
        Produto produto = produtos.Find(p => p.CodigoProduto == codigo)
            ?? throw new ArgumentException("Produto não encontrado.");
        if (tipo != "Entrada" && tipo != "Saída")
            throw new ArgumentException("Tipo de movimentação inválido.");
        if (quantidade <= 0) throw new ArgumentException("A quantidade deve ser positiva.");
        if (string.IsNullOrWhiteSpace(descricao))
            throw new ArgumentException("Informe uma descrição.");
        if (tipo == "Saída" && quantidade > produto.Quantidade)
            throw new ArgumentException("Estoque insuficiente.");

        int saldo = tipo == "Entrada"
            ? checked(produto.Quantidade + quantidade)
            : produto.Quantidade - quantidade;
        var movimento = new Movimentacao(proximoId, codigo, tipo,
            descricao.Trim(), quantidade, saldo);
        historico.Add(movimento);
        produto.Quantidade = saldo;
        proximoId++;
        return movimento;
    }
}
