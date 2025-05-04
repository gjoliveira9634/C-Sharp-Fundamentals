class CalculadoraInvestimentos
{
    // Método principal que inicia o programa
    static void Main(string[] args)
    {
        Console.WriteLine("=== Calculadora de Investimentos ===\n");

        // Exemplo de método sem retorno (void) e com parâmetros
        ExibirBoasVindas("Investidor");

        // Exemplo de método com retorno e múltiplos parâmetros
        double investimentoInicial = 1000;
        double taxaJuros = 0.05;
        int anos = 5;

        double valorFinal = CalcularJurosCompostos(investimentoInicial, taxaJuros, anos);
        Console.WriteLine($"\nInvestimento de R${investimentoInicial} por {anos} anos a {taxaJuros * 100}% ao ano:");
        Console.WriteLine($"Valor Final: R${valorFinal:F2}");

        // Exemplo de método com parâmetros opcionais
        double rendimentoMensal = CalcularRendimentoMensal(capital: 2000, taxa: 0.01);
        Console.WriteLine($"\nRendimento mensal de R$2000 a 1%: R${rendimentoMensal:F2}");

        // Exemplo de método com retorno de tupla
        var (tempoParaDobrar, valorFinalDobrado) = CalcularTempoParaDobrarInvestimento(1000, 0.06);
        Console.WriteLine($"\nTempo para dobrar R$1000 a 6% ao ano: {tempoParaDobrar:F1} anos");
        Console.WriteLine($"Valor final: R${valorFinalDobrado:F2}");

        // Exemplo de método com parâmetro ref
        double saldoAtual = 5000;
        AplicarBonusInvestimento(ref saldoAtual);
        Console.WriteLine($"\nSaldo após aplicar bônus: R${saldoAtual:F2}");
    }

    // Método void com um parâmetro
    static void ExibirBoasVindas(string nomePerfil)
    {
        Console.WriteLine($"Bem-vindo(a), {nomePerfil}!");
        Console.WriteLine("Esta é sua calculadora de investimentos pessoal.\n");
    }

    // Método com retorno e múltiplos parâmetros
    static double CalcularJurosCompostos(double principal, double taxa, int periodos)
    {
        return principal * Math.Pow(1 + taxa, periodos);
    }

    // Método com parâmetros opcionais
    static double CalcularRendimentoMensal(double capital, double taxa, int meses = 1)
    {
        return capital * taxa * meses;
    }

    // Método com retorno de tupla
    static (double anos, double valorFinal) CalcularTempoParaDobrarInvestimento(double inicial, double taxaAnual)
    {
        double anos = Math.Log(2) / Math.Log(1 + taxaAnual);
        double valorFinal = inicial * Math.Pow(1 + taxaAnual, anos);
        return (anos, valorFinal);
    }

    // Método com parâmetro ref
    static void AplicarBonusInvestimento(ref double saldo)
    {
        const double TAXA_BONUS = 0.10; // 10% de bônus
        saldo += saldo * TAXA_BONUS;
    }
}
