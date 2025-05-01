class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Demonstração de Tipos de Dados e Operadores em C#\n");

        // Demonstração de Tipos de Dados
        Console.WriteLine("=== Tipos de Dados ===");

        // Tipos numéricos
        int idade = 30;
        double altura = 1.75;
        byte nivelBrilho = 255;
        sbyte temperatura = -10;
        short ano = 2024;
        ushort porta = 8080;
        uint populacao = 3000000000;
        long galaxias = 10000000000;
        ulong estrelas = 900000000000;

        Console.WriteLine($"int: {idade}");
        Console.WriteLine($"double: {altura}");
        Console.WriteLine($"byte: {nivelBrilho}");
        Console.WriteLine($"sbyte: {temperatura}");
        Console.WriteLine($"short: {ano}");
        Console.WriteLine($"ushort: {porta}");
        Console.WriteLine($"uint: {populacao}");
        Console.WriteLine($"long: {galaxias}");
        Console.WriteLine($"ulong: {estrelas}\n");

        // Tipos texto e booleano
        string nome = "Ana";
        char letra = 'A';
        bool ativo = true;

        Console.WriteLine($"string: {nome}");
        Console.WriteLine($"char: {letra}");
        Console.WriteLine($"bool: {ativo}\n");

        // Tipo var (inferência de tipo)
        var salario = 5000.50; // double
        Console.WriteLine($"var (inferido como double): {salario}\n");

        // Demonstração de Operadores
        Console.WriteLine("=== Operadores Aritméticos ===");
        int a = 10, b = 3;
        Console.WriteLine($"a = {a}, b = {b}");
        Console.WriteLine($"Adição: {a} + {b} = {a + b}");
        Console.WriteLine($"Subtração: {a} - {b} = {a - b}");
        Console.WriteLine($"Multiplicação: {a} * {b} = {a * b}");
        Console.WriteLine($"Divisão: {a} / {b} = {a / b}");
        Console.WriteLine($"Módulo: {a} % {b} = {a % b}\n");

        Console.WriteLine("=== Operadores de Incremento/Decremento ===");
        int x = 5;
        Console.WriteLine($"x = {x}");
        Console.WriteLine($"x++ = {x++}"); // Pós-incremento
        Console.WriteLine($"Agora x = {x}");
        Console.WriteLine($"--x = {--x}\n"); // Pré-decremento

        Console.WriteLine("=== Operadores de Comparação ===");
        Console.WriteLine($"{a} == {b}: {a == b}");
        Console.WriteLine($"{a} != {b}: {a != b}");
        Console.WriteLine($"{a} > {b}: {a > b}");
        Console.WriteLine($"{a} < {b}: {a < b}");
        Console.WriteLine($"{a} >= {b}: {a >= b}");
        Console.WriteLine($"{a} <= {b}: {a <= b}\n");

        Console.WriteLine("=== Operadores Lógicos ===");
        bool condicao1 = true, condicao2 = false;
        Console.WriteLine($"AND lógico: {condicao1} && {condicao2} = {condicao1 && condicao2}");
        Console.WriteLine($"OR lógico: {condicao1} || {condicao2} = {condicao1 || condicao2}");
        Console.WriteLine($"NOT lógico: !{condicao1} = {!condicao1}\n");

        Console.WriteLine("=== Operadores de Atribuição ===");
        int numero = 10;
        Console.WriteLine($"Número inicial: {numero}");
        numero += 5; // numero = numero + 5
        Console.WriteLine($"Após += 5: {numero}");
        numero -= 3; // numero = numero - 3
        Console.WriteLine($"Após -= 3: {numero}");
        numero *= 2; // numero = numero * 2
        Console.WriteLine($"Após *= 2: {numero}\n");

        Console.WriteLine("=== Operadores Bitwise ===");
        int num1 = 60;  // 60 = 0011 1100 em binário
        int num2 = 13;  // 13 = 0000 1101 em binário
        Console.WriteLine($"AND bit a bit: {num1} & {num2} = {num1 & num2}");
        Console.WriteLine($"OR bit a bit: {num1} | {num2} = {num1 | num2}");
        Console.WriteLine($"XOR bit a bit: {num1} ^ {num2} = {num1 ^ num2}");
        Console.WriteLine($"Shift left: {num1} << 2 = {num1 << 2}");
        Console.WriteLine($"Shift right: {num1} >> 2 = {num1 >> 2}");

        // Chamando a demonstração de tipos avançados
        ConsoleApp2.DemonstracaoTiposAvancados.ExecutarDemonstracao();

        Console.WriteLine("\n=== Fim da Demonstração ===\n");

        // Espera o usuário pressionar uma tecla antes de fechar o console
        Console.ReadKey();
    }
}
