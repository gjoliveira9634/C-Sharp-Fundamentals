// Programa demonstrativo de entrada/saída e manipulação de strings em C#
Console.WriteLine("=== Bem-vindo ao Programa de Demonstração C# ===\n");

// 1. Recebendo dados do usuário
Console.Write("Por favor, digite seu nome: ");
string? nome = Console.ReadLine();

// Tratamento de string vazia ou nula
nome = string.IsNullOrWhiteSpace(nome) ? "Visitante" : nome.Trim();

// 2. Demonstração de diferentes formas de formatação de strings
// a. Usando concatenação simples
Console.WriteLine("Olá " + nome + "!");

// b. Usando interpolação de string (mais moderna e legível)
Console.WriteLine($"Que bom ter você aqui, {nome}!");

// c. Usando string.Format
Console.WriteLine(string.Format("Sabia que seu nome tem {0} letras?", nome.Length));

// 3. Manipulação de strings
Console.WriteLine($"\nVamos brincar um pouco com seu nome:");
Console.WriteLine($"Em maiúsculas: {nome.ToUpper()}");
Console.WriteLine($"Em minúsculas: {nome.ToLower()}");

if (nome.Length > 1)
{
    string nomeReverso = new string(nome.Reverse().ToArray());
    Console.WriteLine($"Seu nome ao contrário: {nomeReverso}");
}

// 4. Demonstração de formatação de saída
Console.WriteLine("\nAgora, vamos fazer uma pequena demonstração de formatação:");
double numero = 123.456;
Console.WriteLine($"Número com 2 casas decimais: {numero:F2}");
Console.WriteLine($"Número em formato monetário: {numero:C}");

// 5. Entrada de dados com conversão
Console.Write("\nDigite sua idade: ");
string? idadeStr = Console.ReadLine();
if (int.TryParse(idadeStr, out int idade))
{
    Console.WriteLine($"Em 2030, você terá {idade + 5} anos!");
}
else
{
    Console.WriteLine("Idade inválida!");
}

// 6. Finalizando com uma mensagem formatada
Console.WriteLine("\n" + new string('=', 40));
Console.WriteLine("Obrigado por participar desta demonstração!");
Console.WriteLine("Pressione qualquer tecla para sair...");
Console.ReadKey();
