/*
 * ===========================================
 * FUNDAMENTOS C# - MÓDULO 2: OPERADORES E ESTRUTURAS DE CONTROLE
 * ===========================================
 * 
 * Este programa demonstra:
 * - Operadores aritméticos, relacionais e lógicos
 * - Estruturas condicionais (if/else, switch)
 * - Estruturas de repetição (for, while, foreach)
 * - Operadores especiais (??, ?., etc.)
 * 
 * Objetivo: Dominar o controle de fluxo de execução
 * Nível: Iniciante
 */

using System;

namespace OperadoresEControle
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "C# Fundamentals - Módulo 2: Operadores e Controle";
            Console.WriteLine("=".PadLeft(55, '='));
            Console.WriteLine(" OPERADORES E ESTRUTURAS DE CONTROLE ");
            Console.WriteLine("=".PadLeft(55, '='));
            Console.WriteLine();

            // 1. OPERADORES ARITMÉTICOS
            DemonstrarOperadoresAritmeticos();

            // 2. OPERADORES RELACIONAIS E LÓGICOS
            DemonstrarOperadoresRelacionais();

            // 3. ESTRUTURAS CONDICIONAIS
            DemonstrarEstruturasCondicionais();

            // 4. ESTRUTURAS DE REPETIÇÃO
            DemonstrarEstruturasRepeticao();

            // 5. OPERADORES ESPECIAIS
            DemonstrarOperadoresEspeciais();

            Console.WriteLine("\n" + "=".PadLeft(55, '='));
            Console.WriteLine("✅ Módulo 2 concluído! Próximo: ConsoleApp3");
            Console.WriteLine("=".PadLeft(55, '='));
            Console.WriteLine("\nPressione qualquer tecla para sair...");
            Console.ReadKey();
        }

        /// <summary>
        /// Demonstra operadores aritméticos básicos e avançados
        /// </summary>
        static void DemonstrarOperadoresAritmeticos()
        {
            Console.WriteLine("🔢 1. OPERADORES ARITMÉTICOS");
            Console.WriteLine(new string('-', 40));

            int a = 15, b = 4;
            Console.WriteLine($"Valores: a = {a}, b = {b}\n");

            // Operadores básicos
            Console.WriteLine("Operadores básicos:");
            Console.WriteLine($"Adição: {a} + {b} = {a + b}");
            Console.WriteLine($"Subtração: {a} - {b} = {a - b}");
            Console.WriteLine($"Multiplicação: {a} * {b} = {a * b}");
            Console.WriteLine($"Divisão: {a} / {b} = {a / b}");
            Console.WriteLine($"Resto da divisão: {a} % {b} = {a % b}");

            // Operadores de incremento/decremento
            Console.WriteLine("\nOperadores de incremento/decremento:");
            int contador = 10;
            Console.WriteLine($"Valor inicial: {contador}");
            Console.WriteLine($"Pré-incremento (++contador): {++contador}");
            Console.WriteLine($"Pós-incremento (contador++): {contador++}");
            Console.WriteLine($"Valor após pós-incremento: {contador}");
            Console.WriteLine($"Pré-decremento (--contador): {--contador}");

            // Operadores de atribuição compostos
            Console.WriteLine("\nOperadores de atribuição compostos:");
            int x = 20;
            Console.WriteLine($"Valor inicial de x: {x}");
            x += 5; Console.WriteLine($"x += 5: {x}");
            x -= 3; Console.WriteLine($"x -= 3: {x}");
            x *= 2; Console.WriteLine($"x *= 2: {x}");
            x /= 4; Console.WriteLine($"x /= 4: {x}");
            x %= 3; Console.WriteLine($"x %= 3: {x}");

            Console.WriteLine();
        }

        /// <summary>
        /// Demonstra operadores relacionais e lógicos
        /// </summary>
        static void DemonstrarOperadoresRelacionais()
        {
            Console.WriteLine("⚖️  2. OPERADORES RELACIONAIS E LÓGICOS");
            Console.WriteLine(new string('-', 40));

            int idade = 25;
            bool temCarteira = true;
            bool temCarro = false;

            Console.WriteLine($"Dados: idade = {idade}, temCarteira = {temCarteira}, temCarro = {temCarro}\n");

            // Operadores relacionais
            Console.WriteLine("Operadores relacionais:");
            Console.WriteLine($"idade > 18: {idade > 18}");
            Console.WriteLine($"idade < 65: {idade < 65}");
            Console.WriteLine($"idade >= 18: {idade >= 18}");
            Console.WriteLine($"idade <= 30: {idade <= 30}");
            Console.WriteLine($"idade == 25: {idade == 25}");
            Console.WriteLine($"idade != 30: {idade != 30}");

            // Operadores lógicos
            Console.WriteLine("\nOperadores lógicos:");
            Console.WriteLine($"temCarteira && idade >= 18: {temCarteira && idade >= 18}");
            Console.WriteLine($"temCarro || temCarteira: {temCarro || temCarteira}");
            Console.WriteLine($"!temCarro: {!temCarro}");

            // Exemplo prático
            bool podeConduzi = temCarteira && idade >= 18;
            bool precisaTransporte = !temCarro;

            Console.WriteLine($"\nAnálise prática:");
            Console.WriteLine($"Pode conduzir veículo: {podeConduzi}");
            Console.WriteLine($"Precisa de transporte: {precisaTransporte}");

            Console.WriteLine();
        }

        /// <summary>
        /// Demonstra estruturas condicionais (if/else, switch)
        /// </summary>
        static void DemonstrarEstruturasCondicionais()
        {
            Console.WriteLine("🌿 3. ESTRUTURAS CONDICIONAIS");
            Console.WriteLine(new string('-', 40));

            // IF/ELSE simples
            Console.WriteLine("Estrutura if/else:");
            int temperatura = 28;
            Console.WriteLine($"Temperatura atual: {temperatura}°C");

            if (temperatura < 15)
            {
                Console.WriteLine("Está frio! Vista um casaco.");
            }
            else if (temperatura >= 15 && temperatura <= 25)
            {
                Console.WriteLine("Temperatura agradável!");
            }
            else
            {
                Console.WriteLine("Está quente! Use roupas leves.");
            }

            // SWITCH tradicional
            Console.WriteLine("\nEstrutura switch tradicional:");
            int diaDaSemana = 3; // Quarta-feira
            Console.WriteLine($"Dia da semana (número): {diaDaSemana}");

            switch (diaDaSemana)
            {
                case 1:
                    Console.WriteLine("Segunda-feira - Início da semana!");
                    break;
                case 2:
                    Console.WriteLine("Terça-feira - Vamos em frente!");
                    break;
                case 3:
                    Console.WriteLine("Quarta-feira - Meio da semana!");
                    break;
                case 4:
                    Console.WriteLine("Quinta-feira - Quase lá!");
                    break;
                case 5:
                    Console.WriteLine("Sexta-feira - SEXTOU!");
                    break;
                case 6:
                case 7:
                    Console.WriteLine("Final de semana - Descanso!");
                    break;
                default:
                    Console.WriteLine("Dia inválido!");
                    break;
            }

            // SWITCH expression (C# 8+)
            Console.WriteLine("\nSwitch expression (moderno):");
            string categoria = temperatura switch
            {
                < 0 => "Congelante",
                >= 0 and < 15 => "Frio",
                >= 15 and < 25 => "Agradável",
                >= 25 and < 35 => "Quente",
                >= 35 => "Muito quente",
            };
            Console.WriteLine($"Categoria da temperatura: {categoria}");

            // Operador ternário
            Console.WriteLine("\nOperador ternário:");
            int pontuacao = 85;
            string resultado = pontuacao >= 70 ? "Aprovado" : "Reprovado";
            Console.WriteLine($"Pontuação: {pontuacao} - Resultado: {resultado}");

            Console.WriteLine();
        }

        /// <summary>
        /// Demonstra estruturas de repetição (loops)
        /// </summary>
        static void DemonstrarEstruturasRepeticao()
        {
            Console.WriteLine("🔄 4. ESTRUTURAS DE REPETIÇÃO");
            Console.WriteLine(new string('-', 40));

            // FOR loop
            Console.WriteLine("Loop FOR - Tabuada do 5:");
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"5 × {i} = {5 * i}");
            }

            // WHILE loop
            Console.WriteLine("\nLoop WHILE - Contagem regressiva:");
            int contador = 5;
            while (contador > 0)
            {
                Console.WriteLine($"Contagem: {contador}");
                contador--;
            }
            Console.WriteLine("🚀 Lançamento!");

            // DO-WHILE loop
            Console.WriteLine("\nLoop DO-WHILE - Validação de entrada:");
            int numero;
            int tentativas = 0;
            do
            {
                tentativas++;
                numero = new Random().Next(1, 11); // Simula entrada do usuário
                Console.WriteLine($"Tentativa {tentativas}: número gerado = {numero}");
            }
            while (numero != 7 && tentativas < 5);

            if (numero == 7)
                Console.WriteLine("✅ Número 7 encontrado!");
            else
                Console.WriteLine("❌ Número 7 não encontrado em 5 tentativas.");

            // FOREACH loop
            Console.WriteLine("\nLoop FOREACH - Lista de cores:");
            string[] cores = { "Vermelho", "Verde", "Azul", "Amarelo", "Roxo" };
            foreach (string cor in cores)
            {
                Console.WriteLine($"🎨 {cor}");
            }

            // Break e Continue
            Console.WriteLine("\nControle de fluxo (break/continue):");
            for (int i = 1; i <= 10; i++)
            {
                if (i == 4) continue; // Pula o 4
                if (i == 8) break;    // Para no 8
                Console.WriteLine($"Número: {i}");
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Demonstra operadores especiais do C#
        /// </summary>
        static void DemonstrarOperadoresEspeciais()
        {
            Console.WriteLine("⭐ 5. OPERADORES ESPECIAIS");
            Console.WriteLine(new string('-', 40));

            // Null-coalescing operator (??)
            Console.WriteLine("Operador null-coalescing (??):");
            string? nome = null;
            string nomeExibicao = nome ?? "Nome não informado";
            Console.WriteLine($"Nome: {nomeExibicao}");

            // Null-conditional operator (?.)
            Console.WriteLine("\nOperador null-conditional (?.):");
            string? texto = "Hello World";
            int? comprimento = texto?.Length;
            Console.WriteLine($"Comprimento do texto: {comprimento}");

            texto = null;
            comprimento = texto?.Length;
            Console.WriteLine($"Comprimento do texto nulo: {comprimento ?? -1}");

            // Null-coalescing assignment (??=)
            Console.WriteLine("\nOperador null-coalescing assignment (??=):");
            string? configuracao = null;
            configuracao ??= "Valor padrão";
            Console.WriteLine($"Configuração: {configuracao}");

            // Pattern matching com is
            Console.WriteLine("\nPattern matching com 'is':");
            object valor = 42;
            if (valor is int numeroInteiro)
            {
                Console.WriteLine($"É um número inteiro: {numeroInteiro}");
            }

            // typeof e nameof
            Console.WriteLine("\nOperadores typeof e nameof:");
            Console.WriteLine($"Tipo de 'valor': {valor.GetType().Name}");
            Console.WriteLine($"Nome da variável: {nameof(valor)}");

            Console.WriteLine();
        }
    }
}
