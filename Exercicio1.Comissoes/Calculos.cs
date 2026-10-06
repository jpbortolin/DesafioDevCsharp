namespace DesafioDev;

public static class Calculos
{
    public static decimal Comissao(decimal valor)
    {
        if (valor < 0) throw new ArgumentException("A venda não pode ser negativa.");
        decimal taxa = valor < 100m ? 0m : valor < 500m ? 0.01m : 0.05m;
        // Decisão: arredondar cada comissão antes de somar por vendedor.
        return Math.Round(valor * taxa, 2, MidpointRounding.AwayFromZero);
    }

}
