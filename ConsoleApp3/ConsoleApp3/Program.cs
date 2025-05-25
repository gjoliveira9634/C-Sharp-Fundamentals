/*
 * ===========================================
 * FUNDAMENTOS C# - MÓDULO 3: ARRAYS E COLEÇÕES
 * ===========================================
 * 
 * Este programa demonstra:
 * - Arrays unidimensionais e multidimensionais
 * - Coleções genéricas (List<T>, Dictionary<K,V>)
 * - Operações com coleções
 * - Introdução ao LINQ básico
 * 
 * Objetivo: Trabalhar com estruturas de dados
 * Nível: Intermediário
 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace ArraysEColecoes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "C# Fundamentals - Módulo 3: Arrays e Coleções";
            Console.WriteLine("=".PadLeft(50, '='));
            Console.WriteLine(" ARRAYS E COLEÇÕES ");
            Console.WriteLine("=".PadLeft(50, '='));
            Console.WriteLine();

            // 1. ARRAYS
            DemonstrarArrays();

            // 2. LISTAS GENÉRICAS
            DemonstrarListas();

            // 3. DICIONÁRIOS
            DemonstrarDicionarios();

            // 4. LINQ BÁSICO
            DemonstrarLinqBasico();

            // 5. EXEMPLO PRÁTICO
            ExemploPraticoNotasAlunos();

            Console.WriteLine("\n" + "=".PadLeft(50, '='));
            Console.WriteLine("✅ Módulo 3 concluído! Próximo: ConsoleApp4");
            Console.WriteLine("=".PadLeft(50, '='));
            Console.WriteLine("\nPressione qualquer tecla para sair...");
            Console.ReadKey();
        }

        /// <summary>
        /// Demonstra o uso de arrays unidimensionais e multidimensionais
        /// </summary>
        static void DemonstrarArrays()
        {
            Console.WriteLine("📊 1. ARRAYS");
            Console.WriteLine(new string('-', 40));

            // Array unidimensional - declaração e inicialização
            Console.WriteLine("Arrays unidimensionais:");

            // Diferentes formas de criar arrays
            int[] numeros1 = new int[5];                    // Array vazio de 5 elementos
            int[] numeros2 = { 1, 2, 3, 4, 5 };           // Inicialização direta
            int[] numeros3 = new int[] { 10, 20, 30 };     // Inicialização explícita

            // Preenchendo array
            for (int i = 0; i < numeros1.Length; i++)
            {
                numeros1[i] = (i + 1) * 10;
            }

            Console.WriteLine($"numeros1: [{string.Join(", ", numeros1)}]");
            Console.WriteLine($"numeros2: [{string.Join(", ", numeros2)}]");
            Console.WriteLine($"numeros3: [{string.Join(", ", numeros3)}]");

            // Propriedades importantes dos arrays
            Console.WriteLine($"\nPropriedades do array numeros2:");
            Console.WriteLine($"Comprimento: {numeros2.Length}");
            Console.WriteLine($"Primeiro elemento: {numeros2[0]}");
            Console.WriteLine($"Último elemento: {numeros2[numeros2.Length - 1]}");

            // Array de strings
            Console.WriteLine("\nArray de strings:");
            string[] frutas = { "Maçã", "Banana", "Laranja", "Uva", "Pêra" };
            Console.WriteLine("Frutas disponíveis:");
            for (int i = 0; i < frutas.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {frutas[i]}");
            }

            // Array multidimensional
            Console.WriteLine("\nArray multidimensional (matriz 3x3):");
            int[,] matriz = {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            };

            for (int linha = 0; linha < matriz.GetLength(0); linha++)
            {
                for (int coluna = 0; coluna < matriz.GetLength(1); coluna++)
                {
                    Console.Write($"{matriz[linha, coluna],3}");
                }
                Console.WriteLine();
            }

            // Array jagged (array de arrays)
            Console.WriteLine("\nArray jagged:");
            int[][] arrayJagged = new int[3][];
            arrayJagged[0] = new int[] { 1, 2 };
            arrayJagged[1] = new int[] { 3, 4, 5, 6 };
            arrayJagged[2] = new int[] { 7, 8, 9 };

            for (int i = 0; i < arrayJagged.Length; i++)
            {
                Console.WriteLine($"Linha {i}: [{string.Join(", ", arrayJagged[i])}]");
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Demonstra o uso de List<T> e suas operações
        /// </summary>
        static void DemonstrarListas()
        {
            Console.WriteLine("📋 2. LISTAS GENÉRICAS (List<T>)");
            Console.WriteLine(new string('-', 40));

            // Criando uma lista
            List<string> cidades = new List<string>();

            // Adicionando elementos
            cidades.Add("São Paulo");
            cidades.Add("Rio de Janeiro");
            cidades.Add("Belo Horizonte");
            cidades.AddRange(new[] { "Salvador", "Brasília", "Fortaleza" });

            Console.WriteLine("Lista de cidades:");
            for (int i = 0; i < cidades.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {cidades[i]}");
            }

            // Operações com listas
            Console.WriteLine($"\nTotal de cidades: {cidades.Count}");
            Console.WriteLine($"Primeira cidade: {cidades[0]}");
            Console.WriteLine($"Última cidade: {cidades[cidades.Count - 1]}");

            // Busca e verificação
            string cidadeProcurada = "Rio de Janeiro";
            bool encontrou = cidades.Contains(cidadeProcurada);
            int indice = cidades.IndexOf(cidadeProcurada);
            Console.WriteLine($"\nBusca por '{cidadeProcurada}':");
            Console.WriteLine($"Encontrada: {encontrou}");
            Console.WriteLine($"Índice: {indice}");

            // Inserção e remoção
            cidades.Insert(2, "Curitiba");
            Console.WriteLine($"\nApós inserir 'Curitiba' na posição 2:");
            Console.WriteLine($"[{string.Join(", ", cidades)}]");

            cidades.Remove("Salvador");
            Console.WriteLine($"\nApós remover 'Salvador':");
            Console.WriteLine($"[{string.Join(", ", cidades)}]");

            // Ordenação
            cidades.Sort();
            Console.WriteLine($"\nLista ordenada alfabeticamente:");
            Console.WriteLine($"[{string.Join(", ", cidades)}]");

            // Lista de números para demonstrar operações matemáticas
            Console.WriteLine("\nLista de números:");
            List<int> numeros = new List<int> { 15, 3, 9, 1, 12, 7, 20, 5 };
            Console.WriteLine($"Original: [{string.Join(", ", numeros)}]");

            numeros.Sort();
            Console.WriteLine($"Ordenada: [{string.Join(", ", numeros)}]");

            // Usando foreach
            Console.WriteLine("\nUsando foreach para exibir números pares:");
            foreach (int numero in numeros)
            {
                if (numero % 2 == 0)
                {
                    Console.WriteLine($"  {numero} é par");
                }
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Demonstra o uso de Dictionary<K,V>
        /// </summary>
        static void DemonstrarDicionarios()
        {
            Console.WriteLine("🗂️  3. DICIONÁRIOS (Dictionary<K,V>)");
            Console.WriteLine(new string('-', 40));

            // Criando um dicionário
            Dictionary<string, int> idades = new Dictionary<string, int>();

            // Adicionando elementos
            idades.Add("João", 25);
            idades.Add("Maria", 30);
            idades.Add("Pedro", 28);
            idades["Ana"] = 22; // Forma alternativa de adicionar

            Console.WriteLine("Dicionário de idades:");
            foreach (var pessoa in idades)
            {
                Console.WriteLine($"{pessoa.Key}: {pessoa.Value} anos");
            }

            // Verificações
            string nomeBusca = "Maria";
            if (idades.ContainsKey(nomeBusca))
            {
                Console.WriteLine($"\n{nomeBusca} tem {idades[nomeBusca]} anos");
            }

            // Tentativa segura de obter valor
            if (idades.TryGetValue("Carlos", out int idadeCarlos))
            {
                Console.WriteLine($"Carlos tem {idadeCarlos} anos");
            }
            else
            {
                Console.WriteLine("Carlos não encontrado no dicionário");
            }

            // Dicionário mais complexo - estoque de produtos
            Console.WriteLine("\nDicionário de estoque:");
            Dictionary<string, (double preco, int quantidade)> estoque = new()
            {
                ["Notebook"] = (2500.99, 15),
                ["Mouse"] = (45.90, 120),
                ["Teclado"] = (89.50, 75),
                ["Monitor"] = (899.99, 8)
            };

            foreach (var produto in estoque)
            {
                var (preco, qtd) = produto.Value;
                Console.WriteLine($"{produto.Key}: R$ {preco:F2} - Qtd: {qtd}");
            }

            // Operações com dicionário
            Console.WriteLine($"\nTotal de produtos diferentes: {estoque.Count}");
            Console.WriteLine("Produtos em estoque:");
            foreach (string produto in estoque.Keys)
            {
                Console.WriteLine($"  - {produto}");
            }

            Console.WriteLine();
        }

        /// <summary>
        /// Demonstra operações básicas do LINQ
        /// </summary>
        static void DemonstrarLinqBasico()
        {
            Console.WriteLine("🔍 4. LINQ BÁSICO");
            Console.WriteLine(new string('-', 40));

            List<int> numeros = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 15, 20, 25, 30 };
            Console.WriteLine($"Lista original: [{string.Join(", ", numeros)}]");

            // Where - filtrar elementos
            var numerosPares = numeros.Where(n => n % 2 == 0);
            Console.WriteLine($"Números pares: [{string.Join(", ", numerosPares)}]");

            var maioresQue10 = numeros.Where(n => n > 10);
            Console.WriteLine($"Maiores que 10: [{string.Join(", ", maioresQue10)}]");

            // Select - transformar elementos
            var quadrados = numeros.Take(5).Select(n => n * n);
            Console.WriteLine($"Quadrados dos 5 primeiros: [{string.Join(", ", quadrados)}]");

            // Operações de agregação
            Console.WriteLine("\nOperações de agregação:");
            Console.WriteLine($"Soma: {numeros.Sum()}");
            Console.WriteLine($"Média: {numeros.Average():F2}");
            Console.WriteLine($"Maior: {numeros.Max()}");
            Console.WriteLine($"Menor: {numeros.Min()}");
            Console.WriteLine($"Quantidade: {numeros.Count()}");

            // First, Last, Single
            Console.WriteLine("\nBuscas específicas:");
            Console.WriteLine($"Primeiro: {numeros.First()}");
            Console.WriteLine($"Último: {numeros.Last()}");
            Console.WriteLine($"Primeiro maior que 5: {numeros.First(n => n > 5)}");

            // Any e All
            Console.WriteLine($"Existe algum número par? {numeros.Any(n => n % 2 == 0)}");
            Console.WriteLine($"Todos são positivos? {numeros.All(n => n > 0)}");

            // Ordenação com LINQ
            var ordenadoDesc = numeros.OrderByDescending(n => n).Take(5);
            Console.WriteLine($"Top 5 maiores: [{string.Join(", ", ordenadoDesc)}]");

            // LINQ com strings
            Console.WriteLine("\nLINQ com strings:");
            List<string> nomes = new List<string> { "Ana", "Bruno", "Carlos", "Diana", "Eduardo", "Fernanda" };

            var nomesComA = nomes.Where(nome => nome.Contains('a', StringComparison.OrdinalIgnoreCase));
            Console.WriteLine($"Nomes com 'a': [{string.Join(", ", nomesComA)}]");

            var nomesPorTamanho = nomes.OrderBy(nome => nome.Length).ThenBy(nome => nome);
            Console.WriteLine($"Ordenados por tamanho: [{string.Join(", ", nomesPorTamanho)}]");

            Console.WriteLine();
        }

        /// <summary>
        /// Exemplo prático: Sistema de notas de alunos
        /// </summary>
        static void ExemploPraticoNotasAlunos()
        {
            Console.WriteLine("🎓 5. EXEMPLO PRÁTICO: SISTEMA DE NOTAS");
            Console.WriteLine(new string('-', 40));

            // Dicionário para armazenar alunos e suas notas
            Dictionary<string, List<double>> notasAlunos = new Dictionary<string, List<double>>
            {
                ["João Silva"] = new List<double> { 8.5, 7.2, 9.1, 6.8 },
                ["Maria Santos"] = new List<double> { 9.0, 8.7, 9.5, 8.9 },
                ["Pedro Costa"] = new List<double> { 6.5, 7.0, 6.2, 7.8 },
                ["Ana Oliveira"] = new List<double> { 9.2, 9.8, 9.0, 9.5 },
                ["Carlos Lima"] = new List<double> { 5.5, 6.0, 5.8, 6.5 }
            };

            Console.WriteLine("RELATÓRIO DE NOTAS DOS ALUNOS");
            Console.WriteLine(new string('=', 50));

            // Calcular média individual e status
            var relatorioAlunos = new List<(string nome, double media, string status)>();

            foreach (var aluno in notasAlunos)
            {
                string nome = aluno.Key;
                List<double> notas = aluno.Value;
                double media = notas.Average();
                string status = media >= 7.0 ? "APROVADO" : "REPROVADO";

                relatorioAlunos.Add((nome, media, status));

                Console.WriteLine($"\n{nome}:");
                Console.WriteLine($"  Notas: [{string.Join(", ", notas.Select(n => n.ToString("F1")))}]");
                Console.WriteLine($"  Média: {media:F2}");
                Console.WriteLine($"  Status: {status}");
            }

            // Estatísticas gerais
            Console.WriteLine("\n" + new string('=', 50));
            Console.WriteLine("ESTATÍSTICAS GERAIS:");

            double mediaGeral = relatorioAlunos.Average(r => r.media);
            var aprovados = relatorioAlunos.Where(r => r.status == "APROVADO").ToList();
            var reprovados = relatorioAlunos.Where(r => r.status == "REPROVADO").ToList();

            Console.WriteLine($"Média geral da turma: {mediaGeral:F2}");
            Console.WriteLine($"Alunos aprovados: {aprovados.Count}");
            Console.WriteLine($"Alunos reprovados: {reprovados.Count}");

            if (aprovados.Any())
            {
                var melhorAluno = aprovados.OrderByDescending(a => a.media).First();
                Console.WriteLine($"Melhor desempenho: {melhorAluno.nome} ({melhorAluno.media:F2})");
            }

            // Lista de aprovados ordenada por média
            if (aprovados.Any())
            {
                Console.WriteLine("\nALUNOS APROVADOS (por ordem de média):");
                foreach (var aluno in aprovados.OrderByDescending(a => a.media))
                {
                    Console.WriteLine($"  • {aluno.nome}: {aluno.media:F2}");
                }
            }

            Console.WriteLine();
        }
    }
}
