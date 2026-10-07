namespace DesafioDev;

public static class Calculos
{
    public static ResultadoJuros Juros(decimal valor, DateTime vencimento, DateTime hoje)
    {
        if (valor <= 0) throw new ArgumentException("O valor deve ser positivo.");
        int dias = Math.Max(0, (hoje.Date - vencimento.Date).Days);
        decimal juros = Math.Round(valor * 0.025m * dias, 2, MidpointRounding.AwayFromZero);
        return new ResultadoJuros(dias, juros, valor + juros);
    }
}

