/*
 * ===========================================
 * FUNDAMENTOS C# - MÓDULO 4: MÉTODOS E FUNÇÕES
 * ===========================================
 * 
 * Este programa demonstra:
 * - Criação e uso de métodos
 * - Parâmetros e tipos de retorno
 * - Sobrecarga de métodos
 * - Parâmetros opcionais e nomeados
 * - Parâmetros ref, out e in
 * - Recursão
 * 
 * Objetivo: Modularizar código usando métodos
 * Nível: Intermediário
 */

using System;
using System.Collections.Generic;

namespace MetodosEFuncoes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "C# Fundamentals - Módulo 4: Métodos e Funções";
            Console.WriteLine("=".PadLeft(50, '='));
            Console.WriteLine(" MÉTODOS E FUNÇÕES ");
            Console.WriteLine("=".PadLeft(50, '='));
            Console.WriteLine();

            // 1. MÉTODOS BÁSICOS
            DemonstrarMetodosBasicos();

            // 2. PARÂMETROS E RETORNOS
            DemonstrarParametrosRetornos();

            // 3. SOBRECARGA DE MÉTODOS
            DemonstrarSobrecarga();

            // 4. PARÂMETROS ESPECIAIS
            DemonstrarParametrosEspeciais();

            // 5. RECURSÃO
            DemonstrarRecursao();

            // 6. EXEMPLO PRÁTICO
            ExemploPraticoCalculadora();

            Console.WriteLine("\n" + "=".PadLeft(50, '='));
            Console.WriteLine("✅ Módulo 4 concluído! Próximo: ConsoleApp5");
            Console.WriteLine("=".PadLeft(50, '='));
            Console.WriteLine("\nPressione qualquer tecla para sair...");
            Console.ReadKey();
        }

        /// <summary>
        /// Demonstra métodos básicos void e com retorno
        /// </summary>
        static void DemonstrarMetodosBasicos()
        {
            Console.WriteLine("🔧 1. MÉTODOS BÁSICOS");
            Console.WriteLine(new string('-', 40));

            // Chamando método void (sem retorno)
            ExibirMensagemBoasVindas();

            // Chamando método com retorno
            string dataAtual = ObterDataFormatada();
            Console.WriteLine($"Data atual: {dataAtual}");

            // Método que retorna um valor calculado
            double area = CalcularAreaRetangulo(5.0, 3.0);
            Console.WriteLine($"Área do retângulo (5x3): {area:F2} m²");

            Console.WriteLine();
        }

        /// <summary>
        /// Demonstra diferentes tipos de parâmetros e retornos
        /// </summary>
        static void DemonstrarParametrosRetornos()
        {
            Console.WriteLine("📝 2. PARÂMETROS E RETORNOS");
            Console.WriteLine(new string('-', 40));

            // Método com múltiplos parâmetros
            string saudacao = CriarSaudacao("João", "Silva", 25);
            Console.WriteLine(saudacao);

            // Método com parâmetros opcionais
            string saudacaoSimples = CriarSaudacao("Maria");
            Console.WriteLine(saudacaoSimples);

            // Método com parâmetros nomeados
            var resultado = CalcularPotencia(expoente: 3, baseNum: 2);
            Console.WriteLine($"2³ = {resultado}");

            // Método que retorna múltiplos valores (tupla)
            var (min, max, media) = AnalisarNumeros(new[] { 10, 5, 8, 15, 3, 12 });
            Console.WriteLine($"Análise: Mín={min}, Máx={max}, Média={media:F2}");

            Console.WriteLine();
        }

        /// <summary>
        /// Demonstra sobrecarga de métodos
        /// </summary>
        static void DemonstrarSobrecarga()
        {
            Console.WriteLine("🔀 3. SOBRECARGA DE MÉTODOS");
            Console.WriteLine(new string('-', 40));

            // Diferentes versões do método Somar
            Console.WriteLine($"Soma de 2 números: {Somar(5, 3)}");
            Console.WriteLine($"Soma de 3 números: {Somar(5, 3, 2)}");
            Console.WriteLine($"Soma de decimais: {Somar(2.5, 3.7)}");
            Console.WriteLine($"Soma de array: {Somar(new[] { 1, 2, 3, 4, 5 })}");

            // Diferentes versões do método Imprimir
            Imprimir("Texto simples");
            Imprimir("Texto em caixa", true);
            Imprimir(42);
            Imprimir(new[] { "Item 1", "Item 2", "Item 3" });

            Console.WriteLine();
        }

        /// <summary>
        /// Demonstra parâmetros ref, out e in
        /// </summary>
        static void DemonstrarParametrosEspeciais()
        {
            Console.WriteLine("🎛️  4. PARÂMETROS ESPECIAIS (ref, out, in)");
            Console.WriteLine(new string('-', 40));

            // Parâmetro ref - passa por referência (deve ser inicializado)
            Console.WriteLine("Parâmetro ref:");
            int numero = 10;
            Console.WriteLine($"Antes: {numero}");
            MultiplicarPorDois(ref numero);
            Console.WriteLine($"Depois: {numero}");

            // Parâmetro out - retorna valor (não precisa ser inicializado)
            Console.WriteLine("\nParâmetro out:");
            if (TentarConverterParaNumero("123", out int numeroConvertido))
            {
                Console.WriteLine($"Conversão bem-sucedida: {numeroConvertido}");
            }

            if (!TentarConverterParaNumero("abc", out int numeroInvalido))
            {
                Console.WriteLine("Conversão falhou para 'abc'");
            }

            // Múltiplos valores out
            DividirComResto(17, 5, out int quociente, out int resto);
            Console.WriteLine($"17 ÷ 5 = {quociente} com resto {resto}");

            // Parâmetro in - somente leitura (performance)
            Console.WriteLine("\nParâmetro in:");
            var pontoGrande = new PontoGrande { X = 1000000, Y = 2000000, Z = 3000000 };
            double distancia = CalcularDistanciaOrigem(in pontoGrande);
            Console.WriteLine($"Distância da origem: {distancia:F2}");

            Console.WriteLine();
        }

        /// <summary>
        /// Demonstra métodos recursivos
        /// </summary>
        static void DemonstrarRecursao()
        {
            Console.WriteLine("🔄 5. RECURSÃO");
            Console.WriteLine(new string('-', 40));

            // Factorial
            Console.WriteLine("Cálculo de fatorial:");
            for (int i = 1; i <= 6; i++)
            {
                long fat = Fatorial(i);
                Console.WriteLine($"{i}! = {fat}");
            }

            // Fibonacci
            Console.WriteLine("\nSequência de Fibonacci:");
            Console.Write("Primeiros 10 números: ");
            for (int i = 0; i < 10; i++)
            {
                Console.Write($"{Fibonacci(i)} ");
            }
            Console.WriteLine();

            // Contagem regressiva
            Console.WriteLine("\nContagem regressiva recursiva:");
            ContagemRegressiva(5);

            Console.WriteLine();
        }

        /// <summary>
        /// Exemplo prático: Calculadora com múltiplas operações
        /// </summary>
        static void ExemploPraticoCalculadora()
        {
            Console.WriteLine("🧮 6. EXEMPLO PRÁTICO: CALCULADORA AVANÇADA");
            Console.WriteLine(new string('-', 40));

            // Operações básicas
            Console.WriteLine("Operações básicas:");
            Console.WriteLine($"15 + 7 = {OperacaoMatematica(15, 7, '+'):F2}");
            Console.WriteLine($"15 - 7 = {OperacaoMatematica(15, 7, '-'):F2}");
            Console.WriteLine($"15 × 7 = {OperacaoMatematica(15, 7, '*'):F2}");
            Console.WriteLine($"15 ÷ 7 = {OperacaoMatematica(15, 7, '/'):F2}");

            // Operações com arrays
            Console.WriteLine("\nEstatísticas de conjunto:");
            double[] valores = { 10.5, 8.2, 15.7, 12.3, 9.8, 14.1, 11.6 };
            var stats = CalcularEstatisticas(valores);

            Console.WriteLine($"Valores: [{string.Join(", ", valores)}]");
            Console.WriteLine($"Soma: {stats.soma:F2}");
            Console.WriteLine($"Média: {stats.media:F2}");
            Console.WriteLine($"Maior: {stats.maior:F2}");
            Console.WriteLine($"Menor: {stats.menor:F2}");
            Console.WriteLine($"Desvio padrão: {stats.desvioPadrao:F2}");

            // Conversor de unidades
            Console.WriteLine("\nConversor de unidades:");
            double celsius = 25;
            double fahrenheit = ConverterTemperatura(celsius, "C", "F");
            double kelvin = ConverterTemperatura(celsius, "C", "K");

            Console.WriteLine($"{celsius}°C = {fahrenheit:F1}°F = {kelvin:F1}K");

            // Validador de dados
            Console.WriteLine("\nValidação de dados:");
            string[] emails = { "usuario@email.com", "invalido.email", "teste@domain.co.uk" };
            foreach (string email in emails)
            {
                bool valido = ValidarEmail(email);
                Console.WriteLine($"{email}: {(valido ? "✅ Válido" : "❌ Inválido")}");
            }

            Console.WriteLine();
        }

        #region Métodos de Apoio

        // Métodos básicos
        static void ExibirMensagemBoasVindas()
        {
            Console.WriteLine("🎉 Bem-vindo ao módulo de Métodos e Funções!");
        }

        static string ObterDataFormatada()
        {
            return DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        static double CalcularAreaRetangulo(double largura, double altura)
        {
            return largura * altura;
        }

        // Métodos com parâmetros
        static string CriarSaudacao(string nome, string sobrenome = "", int idade = 0)
        {
            if (string.IsNullOrEmpty(sobrenome) && idade == 0)
                return $"Olá, {nome}!";
            else if (idade == 0)
                return $"Olá, {nome} {sobrenome}!";
            else
                return $"Olá, {nome} {sobrenome}, {idade} anos!";
        }

        static double CalcularPotencia(double baseNum, int expoente)
        {
            return Math.Pow(baseNum, expoente);
        }

        static (int min, int max, double media) AnalisarNumeros(int[] numeros)
        {
            if (numeros.Length == 0) return (0, 0, 0);

            int min = numeros[0];
            int max = numeros[0];
            int soma = 0;

            foreach (int num in numeros)
            {
                if (num < min) min = num;
                if (num > max) max = num;
                soma += num;
            }

            double media = (double)soma / numeros.Length;
            return (min, max, media);
        }

        // Sobrecarga de métodos
        static int Somar(int a, int b) => a + b;
        static int Somar(int a, int b, int c) => a + b + c;
        static double Somar(double a, double b) => a + b;
        static int Somar(int[] numeros)
        {
            int soma = 0;
            foreach (int num in numeros) soma += num;
            return soma;
        }

        static void Imprimir(string texto) => Console.WriteLine($"  → {texto}");
        static void Imprimir(string texto, bool emCaixa)
        {
            if (emCaixa)
            {
                Console.WriteLine($"┌{new string('─', texto.Length + 2)}┐");
                Console.WriteLine($"│ {texto} │");
                Console.WriteLine($"└{new string('─', texto.Length + 2)}┘");
            }
            else
            {
                Imprimir(texto);
            }
        }
        static void Imprimir(int numero) => Console.WriteLine($"  → Número: {numero}");
        static void Imprimir(string[] items)
        {
            Console.WriteLine("  → Lista:");
            foreach (string item in items)
                Console.WriteLine($"    • {item}");
        }

        // Parâmetros especiais
        static void MultiplicarPorDois(ref int numero)
        {
            numero *= 2;
        }

        static bool TentarConverterParaNumero(string texto, out int numero)
        {
            return int.TryParse(texto, out numero);
        }

        static void DividirComResto(int dividendo, int divisor, out int quociente, out int resto)
        {
            quociente = dividendo / divisor;
            resto = dividendo % divisor;
        }

        struct PontoGrande
        {
            public long X, Y, Z;
        }

        static double CalcularDistanciaOrigem(in PontoGrande ponto)
        {
            return Math.Sqrt(ponto.X * ponto.X + ponto.Y * ponto.Y + ponto.Z * ponto.Z);
        }

        // Métodos recursivos
        static long Fatorial(int n)
        {
            if (n <= 1) return 1;
            return n * Fatorial(n - 1);
        }

        static int Fibonacci(int n)
        {
            if (n <= 1) return n;
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }

        static void ContagemRegressiva(int numero)
        {
            if (numero <= 0)
            {
                Console.WriteLine("🚀 Lançamento!");
                return;
            }

            Console.WriteLine($"  {numero}...");
            ContagemRegressiva(numero - 1);
        }

        // Exemplo prático - Calculadora
        static double OperacaoMatematica(double a, double b, char operador)
        {
            return operador switch
            {
                '+' => a + b,
                '-' => a - b,
                '*' => a * b,
                '/' => b != 0 ? a / b : double.NaN,
                _ => double.NaN
            };
        }

        static (double soma, double media, double maior, double menor, double desvioPadrao) CalcularEstatisticas(double[] valores)
        {
            if (valores.Length == 0) return (0, 0, 0, 0, 0);

            double soma = 0;
            double maior = valores[0];
            double menor = valores[0];

            foreach (double valor in valores)
            {
                soma += valor;
                if (valor > maior) maior = valor;
                if (valor < menor) menor = valor;
            }

            double media = soma / valores.Length;

            // Cálculo do desvio padrão
            double somaQuadrados = 0;
            foreach (double valor in valores)
            {
                double diferenca = valor - media;
                somaQuadrados += diferenca * diferenca;
            }
            double desvioPadrao = Math.Sqrt(somaQuadrados / valores.Length);

            return (soma, media, maior, menor, desvioPadrao);
        }

        static double ConverterTemperatura(double valor, string origem, string destino)
        {
            // Primeiro converte para Celsius se necessário
            double celsius = origem.ToUpper() switch
            {
                "F" => (valor - 32) * 5 / 9,
                "K" => valor - 273.15,
                "C" => valor,
                _ => valor
            };

            // Depois converte de Celsius para o destino
            return destino.ToUpper() switch
            {
                "F" => celsius * 9 / 5 + 32,
                "K" => celsius + 273.15,
                "C" => celsius,
                _ => celsius
            };
        }

        static bool ValidarEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;

            // Validação básica de email
            int arrobaIndex = email.IndexOf('@');
            if (arrobaIndex <= 0 || arrobaIndex == email.Length - 1) return false;

            int pontoIndex = email.LastIndexOf('.');
            if (pontoIndex <= arrobaIndex || pontoIndex == email.Length - 1) return false;

            return true;
        }

        #endregion
    }
}
