/*
 * ===========================================
 * FUNDAMENTOS C# - MÓDULO 5: PROGRAMAÇÃO ORIENTADA A OBJETOS BÁSICA
 * ===========================================
 * 
 * Este programa demonstra:
 * - Classes e objetos
 * - Propriedades e campos
 * - Construtores
 * - Encapsulamento
 * - Métodos de instância e estáticos
 * - Enum e struct
 * 
 * Objetivo: Introdução aos conceitos de POO
 * Nível: Intermediário
 */

using System;
using System.Collections.Generic;

namespace POOBasica
{
    #region Enums e Structs

    /// <summary>
    /// Enum para representar status de uma conta
    /// </summary>
    public enum StatusConta
    {
        Ativa,
        Inativa,
        Bloqueada,
        Pendente
    }

    /// <summary>
    /// Struct para representar coordenadas
    /// </summary>
    public struct Coordenada
    {
        public double X { get; set; }
        public double Y { get; set; }

        public Coordenada(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double DistanciaDaOrigem()
        {
            return Math.Sqrt(X * X + Y * Y);
        }

        public override string ToString()
        {
            return $"({X:F1}, {Y:F1})";
        }
    }

    #endregion

    #region Classes Principais

    /// <summary>
    /// Classe que representa uma pessoa (conceitos básicos de POO)
    /// </summary>
    public class Pessoa
    {
        // Campos privados (encapsulamento)
        private string _nome;
        private int _idade;
        private static int _contadorPessoas = 0;

        // Propriedades públicas
        public string Nome
        {
            get => _nome;
            set => _nome = string.IsNullOrWhiteSpace(value) ? "Sem nome" : value.Trim();
        }

        public int Idade
        {
            get => _idade;
            set => _idade = value < 0 ? 0 : (value > 150 ? 150 : value);
        }

        // Propriedade automática
        public string Email { get; set; }

        // Propriedade somente leitura
        public DateTime DataCriacao { get; }

        // Propriedade estática
        public static int TotalPessoas => _contadorPessoas;

        // Construtor padrão
        public Pessoa()
        {
            _nome = "Pessoa";
            _idade = 0;
            Email = string.Empty;
            DataCriacao = DateTime.Now;
            _contadorPessoas++;
        }

        // Construtor com parâmetros
        public Pessoa(string nome, int idade, string email = "") : this()
        {
            Nome = nome;
            Idade = idade;
            Email = email;
        }

        // Métodos de instância
        public void ExibirInformacoes()
        {
            Console.WriteLine($"Nome: {Nome}");
            Console.WriteLine($"Idade: {Idade} anos");
            Console.WriteLine($"Email: {(string.IsNullOrEmpty(Email) ? "Não informado" : Email)}");
            Console.WriteLine($"Criado em: {DataCriacao:dd/MM/yyyy HH:mm}");
        }

        public bool EhMaiorDeIdade()
        {
            return Idade >= 18;
        }

        public void FazerAniversario()
        {
            if (Idade < 150)
            {
                Idade++;
                Console.WriteLine($"🎉 Parabéns {Nome}! Agora você tem {Idade} anos!");
            }
        }

        // Método estático
        public static void ExibirEstatisticas()
        {
            Console.WriteLine($"Total de pessoas criadas: {_contadorPessoas}");
        }

        // Sobrescrita do ToString
        public override string ToString()
        {
            return $"{Nome} ({Idade} anos)";
        }
    }

    /// <summary>
    /// Classe que representa uma conta bancária (exemplo prático de POO)
    /// </summary>
    public class ContaBancaria
    {
        // Campos privados
        private double _saldo;
        private readonly string _numeroConta;
        private static int _proximoNumero = 1000;

        // Propriedades
        public string NumeroConta => _numeroConta;
        public string Titular { get; set; }
        public StatusConta Status { get; set; }
        public double Saldo => _saldo; // Somente leitura externa

        // Propriedade calculada
        public string SaldoFormatado => $"R$ {_saldo:F2}";

        // Lista de transações (composição)
        private List<Transacao> _transacoes;
        public IReadOnlyList<Transacao> Transacoes => _transacoes.AsReadOnly();

        // Construtor
        public ContaBancaria(string titular, double saldoInicial = 0)
        {
            _numeroConta = (_proximoNumero++).ToString();
            Titular = titular ?? throw new ArgumentNullException(nameof(titular));
            _saldo = saldoInicial >= 0 ? saldoInicial : 0;
            Status = StatusConta.Ativa;
            _transacoes = new List<Transacao>();

            if (saldoInicial > 0)
            {
                _transacoes.Add(new Transacao("Depósito inicial", saldoInicial, TipoTransacao.Deposito));
            }
        }

        // Métodos públicos
        public bool Depositar(double valor, string descricao = "Depósito")
        {
            if (valor <= 0 || Status != StatusConta.Ativa)
                return false;

            _saldo += valor;
            _transacoes.Add(new Transacao(descricao, valor, TipoTransacao.Deposito));
            return true;
        }

        public bool Sacar(double valor, string descricao = "Saque")
        {
            if (valor <= 0 || valor > _saldo || Status != StatusConta.Ativa)
                return false;

            _saldo -= valor;
            _transacoes.Add(new Transacao(descricao, valor, TipoTransacao.Saque));
            return true;
        }

        public bool Transferir(double valor, ContaBancaria contaDestino, string descricao = "Transferência")
        {
            if (contaDestino == null || valor <= 0 || valor > _saldo || Status != StatusConta.Ativa)
                return false;

            if (contaDestino.Status != StatusConta.Ativa)
                return false;

            // Debita da conta origem
            _saldo -= valor;
            _transacoes.Add(new Transacao($"{descricao} para {contaDestino.NumeroConta}", valor, TipoTransacao.Transferencia));

            // Credita na conta destino
            contaDestino._saldo += valor;
            contaDestino._transacoes.Add(new Transacao($"{descricao} de {NumeroConta}", valor, TipoTransacao.Deposito));

            return true;
        }

        public void BloquearConta()
        {
            Status = StatusConta.Bloqueada;
            Console.WriteLine($"Conta {NumeroConta} foi bloqueada.");
        }

        public void ExibirExtrato()
        {
            Console.WriteLine($"\n=== EXTRATO DA CONTA {NumeroConta} ===");
            Console.WriteLine($"Titular: {Titular}");
            Console.WriteLine($"Status: {Status}");
            Console.WriteLine($"Saldo atual: {SaldoFormatado}");
            Console.WriteLine("\nÚltimas transações:");

            if (_transacoes.Count == 0)
            {
                Console.WriteLine("  Nenhuma transação realizada.");
            }
            else
            {
                foreach (var transacao in _transacoes.TakeLast(10))
                {
                    Console.WriteLine($"  {transacao}");
                }
            }
            Console.WriteLine(new string('=', 40));
        }
    }

    /// <summary>
    /// Classe para representar uma transação bancária
    /// </summary>
    public class Transacao
    {
        public string Descricao { get; }
        public double Valor { get; }
        public TipoTransacao Tipo { get; }
        public DateTime DataHora { get; }

        public Transacao(string descricao, double valor, TipoTransacao tipo)
        {
            Descricao = descricao ?? "Transação";
            Valor = Math.Abs(valor);
            Tipo = tipo;
            DataHora = DateTime.Now;
        }

        public override string ToString()
        {
            string sinal = Tipo == TipoTransacao.Saque || Tipo == TipoTransacao.Transferencia ? "-" : "+";
            return $"{DataHora:dd/MM HH:mm} | {Descricao} | {sinal}R$ {Valor:F2}";
        }
    }

    public enum TipoTransacao
    {
        Deposito,
        Saque,
        Transferencia
    }

    #endregion

    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "C# Fundamentals - Módulo 5: POO Básica";
            Console.WriteLine("=".PadLeft(55, '='));
            Console.WriteLine(" PROGRAMAÇÃO ORIENTADA A OBJETOS BÁSICA ");
            Console.WriteLine("=".PadLeft(55, '='));
            Console.WriteLine();

            // 1. CLASSES E OBJETOS BÁSICOS
            DemonstrarClassesBasicas();

            // 2. ENCAPSULAMENTO E PROPRIEDADES
            DemonstrarEncapsulamento();

            // 3. CONSTRUTORES
            DemonstrarConstrutores();

            // 4. MÉTODOS ESTÁTICOS
            DemonstrarMetodosEstaticos();

            // 5. ENUMS E STRUCTS
            DemonstrarEnumsStructs();

            // 6. EXEMPLO PRÁTICO
            ExemploPraticoBanco();

            Console.WriteLine("\n" + "=".PadLeft(55, '='));
            Console.WriteLine("✅ Módulo 5 concluído! Próximo: ConsoleApp6");
            Console.WriteLine("=".PadLeft(55, '='));
            Console.WriteLine("\nPressione qualquer tecla para sair...");
            Console.ReadKey();
        }

        static void DemonstrarClassesBasicas()
        {
            Console.WriteLine("👤 1. CLASSES E OBJETOS BÁSICOS");
            Console.WriteLine(new string('-', 40));

            // Criando objetos
            Pessoa pessoa1 = new Pessoa();
            Console.WriteLine("Pessoa criada com construtor padrão:");
            pessoa1.ExibirInformacoes();

            Console.WriteLine("\nAlterando propriedades:");
            pessoa1.Nome = "João Silva";
            pessoa1.Idade = 25;
            pessoa1.Email = "joao@email.com";
            pessoa1.ExibirInformacoes();

            Console.WriteLine($"\nÉ maior de idade? {pessoa1.EhMaiorDeIdade()}");
            Console.WriteLine($"ToString(): {pessoa1}");

            Console.WriteLine();
        }

        static void DemonstrarEncapsulamento()
        {
            Console.WriteLine("🔒 2. ENCAPSULAMENTO E PROPRIEDADES");
            Console.WriteLine(new string('-', 40));

            Pessoa pessoa = new Pessoa();

            // Testando validação nas propriedades
            Console.WriteLine("Testando validação de dados:");

            pessoa.Nome = "   Maria Santos   "; // Será trimmed
            pessoa.Idade = -5; // Será ajustado para 0
            Console.WriteLine($"Nome após trim: '{pessoa.Nome}'");
            Console.WriteLine($"Idade após validação: {pessoa.Idade}");

            pessoa.Idade = 200; // Será ajustado para 150
            Console.WriteLine($"Idade após validação (200): {pessoa.Idade}");

            // Propriedade somente leitura
            Console.WriteLine($"Data de criação (somente leitura): {pessoa.DataCriacao}");

            Console.WriteLine();
        }

        static void DemonstrarConstrutores()
        {
            Console.WriteLine("🏗️  3. CONSTRUTORES");
            Console.WriteLine(new string('-', 40));

            // Construtor padrão
            Pessoa p1 = new Pessoa();
            Console.WriteLine("Construtor padrão:");
            Console.WriteLine($"  {p1}");

            // Construtor com parâmetros
            Pessoa p2 = new Pessoa("Ana Costa", 30, "ana@email.com");
            Console.WriteLine("\nConstrutor com parâmetros:");
            Console.WriteLine($"  {p2}");

            // Construtor com parâmetros opcionais
            Pessoa p3 = new Pessoa("Carlos Lima", 28);
            Console.WriteLine("\nConstrutor com parâmetro opcional:");
            Console.WriteLine($"  {p3}");

            Console.WriteLine();
        }

        static void DemonstrarMetodosEstaticos()
        {
            Console.WriteLine("⚡ 4. MÉTODOS E PROPRIEDADES ESTÁTICAS");
            Console.WriteLine(new string('-', 40));

            Console.WriteLine("Contadores estáticos:");
            Console.WriteLine($"Total inicial: {Pessoa.TotalPessoas}");

            // Criando mais pessoas
            var pessoas = new[]
            {
                new Pessoa("Alice", 22),
                new Pessoa("Bob", 35),
                new Pessoa("Carol", 28)
            };

            Console.WriteLine($"Após criar 3 pessoas: {Pessoa.TotalPessoas}");

            // Método estático
            Pessoa.ExibirEstatisticas();

            Console.WriteLine();
        }

        static void DemonstrarEnumsStructs()
        {
            Console.WriteLine("📊 5. ENUMS E STRUCTS");
            Console.WriteLine(new string('-', 40));

            // Demonstrando Enum
            Console.WriteLine("Trabalhando com Enums:");
            StatusConta status = StatusConta.Ativa;
            Console.WriteLine($"Status inicial: {status}");

            status = StatusConta.Bloqueada;
            Console.WriteLine($"Status alterado: {status}");

            // Demonstrando Struct
            Console.WriteLine("\nTrabalhando com Structs:");
            Coordenada ponto1 = new Coordenada(3, 4);
            Coordenada ponto2 = new Coordenada(0, 0);

            Console.WriteLine($"Ponto 1: {ponto1}");
            Console.WriteLine($"Distância da origem: {ponto1.DistanciaDaOrigem():F2}");
            Console.WriteLine($"Ponto 2: {ponto2}");

            // Structs são tipos de valor
            Coordenada ponto3 = ponto1; // Cópia do valor
            ponto3.X = 10;
            Console.WriteLine($"Ponto 1 após modificar ponto 3: {ponto1}"); // Não muda
            Console.WriteLine($"Ponto 3 modificado: {ponto3}");

            Console.WriteLine();
        }

        static void ExemploPraticoBanco()
        {
            Console.WriteLine("🏦 6. EXEMPLO PRÁTICO: SISTEMA BANCÁRIO");
            Console.WriteLine(new string('-', 40));

            try
            {
                // Criando contas
                ContaBancaria conta1 = new ContaBancaria("João Silva", 1000);
                ContaBancaria conta2 = new ContaBancaria("Maria Santos", 500);
                ContaBancaria conta3 = new ContaBancaria("Pedro Costa");

                Console.WriteLine("Contas criadas:");
                Console.WriteLine($"  {conta1.NumeroConta} - {conta1.Titular} - {conta1.SaldoFormatado}");
                Console.WriteLine($"  {conta2.NumeroConta} - {conta2.Titular} - {conta2.SaldoFormatado}");
                Console.WriteLine($"  {conta3.NumeroConta} - {conta3.Titular} - {conta3.SaldoFormatado}");

                // Realizando operações
                Console.WriteLine("\nOperações bancárias:");

                bool sucesso1 = conta1.Depositar(200, "Salário");
                Console.WriteLine($"Depósito na conta {conta1.NumeroConta}: {(sucesso1 ? "✅ Sucesso" : "❌ Falhou")}");

                bool sucesso2 = conta1.Sacar(150, "Compras");
                Console.WriteLine($"Saque da conta {conta1.NumeroConta}: {(sucesso2 ? "✅ Sucesso" : "❌ Falhou")}");

                bool sucesso3 = conta1.Transferir(300, conta2, "Pagamento");
                Console.WriteLine($"Transferência {conta1.NumeroConta} → {conta2.NumeroConta}: {(sucesso3 ? "✅ Sucesso" : "❌ Falhou")}");

                // Tentativa de operação inválida
                bool sucesso4 = conta3.Sacar(100);
                Console.WriteLine($"Saque inválido da conta {conta3.NumeroConta}: {(sucesso4 ? "✅ Sucesso" : "❌ Falhou (saldo insuficiente)")}");

                // Exibindo extratos
                conta1.ExibirExtrato();
                conta2.ExibirExtrato();

                // Testando bloqueio
                Console.WriteLine("\nTestando bloqueio de conta:");
                conta1.BloquearConta();
                bool sucesso5 = conta1.Depositar(100);
                Console.WriteLine($"Depósito em conta bloqueada: {(sucesso5 ? "✅ Sucesso" : "❌ Falhou (conta bloqueada)")}");

                // Demonstrando lista somente leitura
                Console.WriteLine($"\nConta {conta2.NumeroConta} possui {conta2.Transacoes.Count} transações.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }

            Console.WriteLine();
        }
    }
}
