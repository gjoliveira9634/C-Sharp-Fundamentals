// Exemplo de uso de IF, LOOPs e Arrays em C#
Console.WriteLine("### Sistema de Gerenciamento de Notas ###\n");

// Definindo arrays para armazenar informações
string[] alunos = new string[5];
double[] notas = new double[5];

// Loop FOR para entrada de dados
for (int i = 0; i < alunos.Length; i++)
{
    Console.Write($"Digite o nome do {i + 1}º aluno: ");
    alunos[i] = Console.ReadLine() ?? "Sem nome";

    bool notaValida = false;
    while (!notaValida) // Loop WHILE para validação
    {
        Console.Write($"Digite a nota de {alunos[i]} (0-10): ");
        string entrada = Console.ReadLine() ?? "0";

        if (double.TryParse(entrada, out double nota))
        {
            if (nota >= 0 && nota <= 10)
            {
                notas[i] = nota;
                notaValida = true;
            }
            else
            {
                Console.WriteLine("A nota deve estar entre 0 e 10!");
            }
        }
        else
        {
            Console.WriteLine("Por favor, digite um número válido!");
        }
    }
}

// Calculando estatísticas usando loops e condicionais
double somaNotas = 0;
double maiorNota = double.MinValue;
double menorNota = double.MaxValue;
string alunoMaiorNota = "";
string alunoMenorNota = "";

foreach (var nota in notas) // Loop FOREACH para soma
{
    somaNotas += nota;
}

// Loop FOR para encontrar maior e menor nota
for (int i = 0; i < notas.Length; i++)
{
    if (notas[i] > maiorNota)
    {
        maiorNota = notas[i];
        alunoMaiorNota = alunos[i];
    }

    if (notas[i] < menorNota)
    {
        menorNota = notas[i];
        alunoMenorNota = alunos[i];
    }
}

double media = somaNotas / notas.Length;

// Exibindo resultados
Console.WriteLine("\n### Resultados ###");
Console.WriteLine($"Média da turma: {media:F2}");
Console.WriteLine($"Maior nota: {maiorNota:F2} ({alunoMaiorNota})");
Console.WriteLine($"Menor nota: {menorNota:F2} ({alunoMenorNota})");

Console.WriteLine("\nSituação dos alunos:");
// Loop FOR com IF para mostrar situação de cada aluno
for (int i = 0; i < alunos.Length; i++)
{
    string situacao = notas[i] >= 7 ? "Aprovado" : "Reprovado";
    Console.WriteLine($"{alunos[i]}: {notas[i]:F2} - {situacao}");
}

Console.WriteLine("\nPressione qualquer tecla para sair...");
Console.ReadKey();
