using System.Globalization;
using System.Text;
using DesafioDev;

Console.OutputEncoding = Encoding.UTF8;
CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("pt-BR");

Console.WriteLine("CÁLCULO DE JUROS POR ATRASO\n");
try
{
    if (!decimal.TryParse(LerTexto("Valor: "),
        NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign,
        CultureInfo.CurrentCulture, out decimal valor))
        throw new ArgumentException("Valor inválido. Use vírgula para os centavos.");
    if (!DateTime.TryParseExact(LerTexto("Vencimento (dd/MM/aaaa): "), "dd/MM/yyyy",
        CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime vencimento))
        throw new ArgumentException("Data inválida.");
    var resultado = Calculos.Juros(valor, vencimento, DateTime.Today);
    Console.WriteLine($"Dias de atraso: {resultado.DiasAtraso}\nJuros: {resultado.Juros:C2}\nTotal: {resultado.Total:C2}");
}
catch (ArgumentException ex)
{
    Console.WriteLine(ex.Message);
    Environment.ExitCode = 1;
}
catch (OverflowException)
{
    Console.WriteLine("O valor ultrapassa o limite permitido.");
    Environment.ExitCode = 1;
}

static string LerTexto(string mensagem)
{
    Console.Write(mensagem);
    return (Console.ReadLine() ?? "").Trim();
}

