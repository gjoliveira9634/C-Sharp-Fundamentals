/*
 * ===========================================
 * FUNDAMENTOS C# - MÓDULO 1: CONCEITOS BÁSICOS
 * ===========================================
 * 
 * Este programa demonstra os conceitos mais fundamentais do C#:
 * - Declaração de variáveis
 * - Tipos de dados primitivos
 * - Entrada e saída de dados
 * - Formatação de strings
 * - Conversão entre tipos
 * 
 * Objetivo: Familiarizar-se com a sintaxe básica do C#
 * Nível: Iniciante
 */

using System;

namespace FundamentosBasicos
{
    class Program
    {
        static void Main(string[] args)
        {
            // Configuração inicial do console
            Console.Title = "C# Fundamentals - Módulo 1: Básicos";
            Console.WriteLine("=".PadLeft(50, '='));
            Console.WriteLine(" FUNDAMENTOS C# - CONCEITOS BÁSICOS ");
            Console.WriteLine("=".PadLeft(50, '='));
            Console.WriteLine();

            // 1. DECLARAÇÃO DE VARIÁVEIS E TIPOS PRIMITIVOS
            DemonstrarTiposPrimitivos();

            // 2. ENTRADA E SAÍDA DE DADOS
            DemonstrarEntradaSaida();

            // 3. FORMATAÇÃO DE STRINGS
            DemonstrarFormatacao();

            // 4. CONVERSÃO ENTRE TIPOS
            DemonstrarConversoes();

            // Finalização
            Console.WriteLine("\n" + "=".PadLeft(50, '='));
            Console.WriteLine("✅ Módulo 1 concluído! Próximo: ConsoleApp2");
            Console.WriteLine("=".PadLeft(50, '='));
            Console.WriteLine("\nPressione qualquer tecla para sair...");
            Console.ReadKey();
        }

        /// <summary>
        /// Demonstra a declaração e uso dos tipos primitivos do C#
        /// </summary>
        static void DemonstrarTiposPrimitivos()
        {
            Console.WriteLine("📋 1. TIPOS PRIMITIVOS DE DADOS");
            Console.WriteLine(new string('-', 40));

            // Tipos numéricos inteiros
            byte idade = 25;                    // 0 a 255
            int populacao = 1000000;            // -2.1 bi a 2.1 bi  
            long habitantes = 7800000000L;      // Números muito grandes

            // Tipos numéricos decimais
            float altura = 1.75f;               // Precisão simples
            double peso = 70.5;                 // Precisão dupla (mais comum)
            decimal salario = 3500.50m;         // Alta precisão (financeiro)

            // Tipos texto e lógico
            char inicial = 'J';                 // Um único caractere
            string nome = "João Silva";         // Sequência de caracteres
            bool ativo = true;                  // Verdadeiro ou falso

            // Exibindo os valores
            Console.WriteLine($"Idade (byte): {idade} anos");
            Console.WriteLine($"População (int): {populacao:N0} habitantes");
            Console.WriteLine($"Habitantes globais (long): {habitantes:N0}");
            Console.WriteLine($"Altura (float): {altura} m");
            Console.WriteLine($"Peso (double): {peso} kg");
            Console.WriteLine($"Salário (decimal): {salario:C}");
            Console.WriteLine($"Inicial do nome (char): '{inicial}'");
            Console.WriteLine($"Nome completo (string): \"{nome}\"");
            Console.WriteLine($"Status ativo (bool): {ativo}");

            Console.WriteLine();
        }

        /// <summary>
        /// Demonstra como receber dados do usuário
        /// </summary>
        static void DemonstrarEntradaSaida()
        {
            Console.WriteLine("⌨️  2. ENTRADA E SAÍDA DE DADOS");
            Console.WriteLine(new string('-', 40));

            // Entrada de dados do usuário
            Console.Write("Digite seu nome: ");
            string? nomeUsuario = Console.ReadLine();

            // Tratamento de entrada nula ou vazia
            if (string.IsNullOrWhiteSpace(nomeUsuario))
            {
                nomeUsuario = "Usuário Anônimo";
            }

            Console.Write("Digite sua idade: ");
            string? idadeTexto = Console.ReadLine();

            // Conversão segura de string para número
            bool conversaoSucesso = int.TryParse(idadeTexto, out int idadeUsuario);

            if (conversaoSucesso)
            {
                Console.WriteLine($"\nOlá, {nomeUsuario}!");
                Console.WriteLine($"Você tem {idadeUsuario} anos.");
                Console.WriteLine($"Em 2030, você terá {idadeUsuario + 5} anos.");
            }
            else
            {
                Console.WriteLine($"\nOlá, {nomeUsuario}!");
                Console.WriteLine("Idade inválida informada.");
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Demonstra diferentes formas de formatação de strings
        /// </summary>
        static void DemonstrarFormatacao()
        {
            Console.WriteLine("🎨 3. FORMATAÇÃO DE STRINGS");
            Console.WriteLine(new string('-', 40));

            string produto = "Notebook";
            double preco = 2500.99;
            int quantidade = 3;

            // 1. Concatenação simples (não recomendada)
            Console.WriteLine("1. Concatenação: " + produto + " custa R$ " + preco);

            // 2. String interpolation (mais moderna e legível)
            Console.WriteLine($"2. Interpolação: {produto} custa {preco:C}");

            // 3. Método String.Format (útil para templates)
            Console.WriteLine("3. String.Format: {0} - Quantidade: {1:N0}", produto, quantidade);

            // 4. Formatações especiais
            DateTime hoje = DateTime.Now;
            Console.WriteLine($"4. Data formatada: {hoje:dd/MM/yyyy HH:mm}");
            Console.WriteLine($"5. Percentual: {0.85:P}");
            Console.WriteLine($"6. Número com casas decimais: {preco:F2}");

            Console.WriteLine();
        }

        /// <summary>
        /// Demonstra conversões entre diferentes tipos de dados
        /// </summary>
        static void DemonstrarConversoes()
        {
            Console.WriteLine("🔄 4. CONVERSÕES ENTRE TIPOS");
            Console.WriteLine(new string('-', 40));

            // Conversões implícitas (automáticas e seguras)
            int numeroInteiro = 100;
            double numeroDecimal = numeroInteiro; // int → double (OK)
            Console.WriteLine($"Conversão implícita: {numeroInteiro} → {numeroDecimal}");

            // Conversões explícitas (cast)
            double valorDouble = 99.87;
            int valorInt = (int)valorDouble; // Perde a parte decimal
            Console.WriteLine($"Conversão explícita: {valorDouble} → {valorInt}");

            // Conversões usando métodos Convert
            string textoNumero = "456";
            int numeroConvertido = Convert.ToInt32(textoNumero);
            Console.WriteLine($"Convert.ToInt32: \"{textoNumero}\" → {numeroConvertido}");

            // Conversões seguras usando TryParse
            string entrada = "123.45";
            bool sucesso = double.TryParse(entrada, out double resultado);

            if (sucesso)
            {
                Console.WriteLine($"TryParse bem-sucedido: \"{entrada}\" → {resultado}");
            }
            else
            {
                Console.WriteLine($"TryParse falhou para: \"{entrada}\"");
            }

            // Demonstração de falha na conversão
            string entradaInvalida = "abc123";
            bool sucessoInvalido = int.TryParse(entradaInvalida, out int resultadoInvalido);
            Console.WriteLine($"TryParse com entrada inválida \"{entradaInvalida}\": {sucessoInvalido}");

            Console.WriteLine();
        }
    }
}
