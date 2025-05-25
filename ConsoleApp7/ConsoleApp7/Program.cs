/*
 ============================================================================
 ConsoleApp7 - Interfaces e Padrões de Design
 ============================================================================
 
 NÍVEL: Intermediário
 OBJETIVO: Demonstrar o uso de interfaces, abstração e padrões básicos
 
 TÓPICOS ABORDADOS:
 - Interfaces (IDisposable, IComparable, IEnumerable)
 - Padrão Strategy
 - Padrão Observer (eventos simples)
 - Padrão Factory
 - Dependency Injection básico
 - Polimorfismo com interfaces
 
 EXEMPLO PRÁTICO: Sistema de processamento de dados com diferentes algoritmos
 ============================================================================
*/

using System.Text;

namespace ConsoleApp7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("=== ConsoleApp7 - Interfaces e Padrões ===\n");

            try
            {
                // 1. Interfaces básicas
                DemonstrarInterfaces();

                // 2. Padrão Strategy
                DemonstrarStrategy();

                // 3. Padrão Observer com eventos
                DemonstrarObserver();

                // 4. Padrão Factory
                DemonstrarFactory();

                // 5. Dependency Injection simples
                DemonstrarDependencyInjection();

                // 6. Sistema prático integrando conceitos
                ExecutarSistemaProcessamento();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nErro: {ex.Message}");
            }

            Console.WriteLine("\nPressione qualquer tecla para sair...");
            Console.ReadKey();
        }

        #region 1. Interfaces Básicas
        static void DemonstrarInterfaces()
        {
            Console.WriteLine("=== 1. INTERFACES BÁSICAS ===");

            // IComparable - permite comparação
            var pessoas = new List<Pessoa>
            {
                new Pessoa("Ana", 25),
                new Pessoa("Carlos", 30),
                new Pessoa("Bruno", 20)
            };

            Console.WriteLine("Antes da ordenação:");
            pessoas.ForEach(p => Console.WriteLine($"  {p}"));

            pessoas.Sort(); // Usa IComparable<Pessoa>

            Console.WriteLine("\nDepois da ordenação por idade:");
            pessoas.ForEach(p => Console.WriteLine($"  {p}"));

            // IDisposable - gerenciamento de recursos
            using (var arquivo = new ProcessadorArquivo("dados.txt"))
            {
                arquivo.ProcessarDados();
            } // Dispose() é chamado automaticamente

            Console.WriteLine();
        }
        #endregion

        #region 2. Padrão Strategy
        static void DemonstrarStrategy()
        {
            Console.WriteLine("=== 2. PADRÃO STRATEGY ===");

            var dados = new double[] { 5.5, 3.2, 8.1, 2.7, 9.3, 1.8, 6.4 };
            var calculadora = new CalculadoraEstatistica();

            // Diferentes estratégias de cálculo
            calculadora.DefinirEstrategia(new MediaAritmetica());
            Console.WriteLine($"Média Aritmética: {calculadora.Calcular(dados):F2}");

            calculadora.DefinirEstrategia(new MediaPonderada());
            Console.WriteLine($"Média Ponderada: {calculadora.Calcular(dados):F2}");

            calculadora.DefinirEstrategia(new Mediana());
            Console.WriteLine($"Mediana: {calculadora.Calcular(dados):F2}");

            Console.WriteLine();
        }
        #endregion

        #region 3. Padrão Observer
        static void DemonstrarObserver()
        {
            Console.WriteLine("=== 3. PADRÃO OBSERVER (EVENTOS) ===");

            var sensor = new SensorTemperatura();

            // Assinando eventos (observers)
            sensor.TemperaturaAlterada += temp =>
                Console.WriteLine($"  📊 Monitor: Temperatura atual {temp}°C");

            sensor.TemperaturaAlterada += temp =>
            {
                if (temp > 30)
                    Console.WriteLine($"  🚨 Alerta: Temperatura alta! {temp}°C");
            };

            sensor.TemperaturaAlterada += temp =>
            {
                if (temp < 0)
                    Console.WriteLine($"  ❄️ Alerta: Temperatura congelante! {temp}°C");
            };

            // Simulando mudanças de temperatura
            Console.WriteLine("Simulando mudanças de temperatura:");
            sensor.SimularLeituras();

            Console.WriteLine();
        }
        #endregion

        #region 4. Padrão Factory
        static void DemonstrarFactory()
        {
            Console.WriteLine("=== 4. PADRÃO FACTORY ===");

            var factory = new VeiculoFactory();

            // Criando diferentes tipos de veículos
            var carro = factory.CriarVeiculo("carro");
            var moto = factory.CriarVeiculo("moto");
            var caminhao = factory.CriarVeiculo("caminhao");

            var veiculos = new IVeiculo[] { carro, moto, caminhao };

            Console.WriteLine("Testando veículos criados pela factory:");
            foreach (var veiculo in veiculos)
            {
                Console.WriteLine($"  {veiculo.Tipo}: {veiculo.ObterDetalhes()}");
                veiculo.Acelerar();
            }

            Console.WriteLine();
        }
        #endregion

        #region 5. Dependency Injection
        static void DemonstrarDependencyInjection()
        {
            Console.WriteLine("=== 5. DEPENDENCY INJECTION BÁSICO ===");

            // Injeção de dependência manual
            ILogger logger = new ConsoleLogger();
            IRepositorio repositorio = new RepositorioMemoria();

            var servico = new ServicoUsuario(logger, repositorio);

            Console.WriteLine("Operações com DI:");
            servico.CriarUsuario("João", "joao@email.com");
            servico.CriarUsuario("Maria", "maria@email.com");
            servico.ListarUsuarios();

            // Mudando implementação sem alterar o código do serviço
            Console.WriteLine("\nMudando logger para arquivo:");
            var servicoComArquivo = new ServicoUsuario(new ArquivoLogger(), repositorio);
            servicoComArquivo.CriarUsuario("Pedro", "pedro@email.com");

            Console.WriteLine();
        }
        #endregion

        #region 6. Sistema Prático
        static void ExecutarSistemaProcessamento()
        {
            Console.WriteLine("=== 6. SISTEMA INTEGRADO - PROCESSADOR DE DADOS ===");

            var processador = new ProcessadorDados();

            // Configurando diferentes componentes via interfaces
            processador.DefinirValidador(new ValidadorNumerico());
            processador.DefinirTransformador(new TransformadorParaQuadrado());
            processador.DefinirExportador(new ExportadorConsole());

            // Dados de teste
            var dados = new[] { "1", "2", "3", "abc", "4", "5", "xyz" };

            Console.WriteLine("Processamento com validador numérico:");
            processador.ProcessarDados(dados);

            // Mudando comportamento
            Console.WriteLine("\nMudando para validador de comprimento:");
            processador.DefinirValidador(new ValidadorComprimento(3));
            processador.DefinirTransformador(new TransformadorParaMaiuscula());
            processador.ProcessarDados(new[] { "abc", "a", "hello", "C#", "world" });

            Console.WriteLine("\n=== FIM DOS EXEMPLOS ===");
        }
        #endregion
    }

    #region Interfaces e Classes de Apoio

    // Interface IComparable
    public class Pessoa : IComparable<Pessoa>
    {
        public string Nome { get; set; }
        public int Idade { get; set; }

        public Pessoa(string nome, int idade)
        {
            Nome = nome;
            Idade = idade;
        }

        public int CompareTo(Pessoa? other)
        {
            if (other == null) return 1;
            return Idade.CompareTo(other.Idade);
        }

        public override string ToString() => $"{Nome} ({Idade} anos)";
    }

    // Interface IDisposable
    public class ProcessadorArquivo : IDisposable
    {
        private readonly string _nomeArquivo;
        private bool _disposed = false;

        public ProcessadorArquivo(string nomeArquivo)
        {
            _nomeArquivo = nomeArquivo;
            Console.WriteLine($"  Arquivo '{_nomeArquivo}' aberto para processamento");
        }

        public void ProcessarDados()
        {
            Console.WriteLine($"  Processando dados do arquivo '{_nomeArquivo}'...");
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                Console.WriteLine($"  Arquivo '{_nomeArquivo}' fechado e recursos liberados");
                _disposed = true;
            }
        }
    }

    // Padrão Strategy - Interface e implementações
    public interface IEstrategiaCalculo
    {
        double Calcular(double[] dados);
    }

    public class MediaAritmetica : IEstrategiaCalculo
    {
        public double Calcular(double[] dados) => dados.Average();
    }

    public class MediaPonderada : IEstrategiaCalculo
    {
        public double Calcular(double[] dados)
        {
            double soma = 0;
            double pesos = 0;
            for (int i = 0; i < dados.Length; i++)
            {
                soma += dados[i] * (i + 1);
                pesos += (i + 1);
            }
            return soma / pesos;
        }
    }

    public class Mediana : IEstrategiaCalculo
    {
        public double Calcular(double[] dados)
        {
            var ordenados = dados.OrderBy(x => x).ToArray();
            int meio = ordenados.Length / 2;

            if (ordenados.Length % 2 == 0)
                return (ordenados[meio - 1] + ordenados[meio]) / 2;
            else
                return ordenados[meio];
        }
    }

    public class CalculadoraEstatistica
    {
        private IEstrategiaCalculo? _estrategia;

        public void DefinirEstrategia(IEstrategiaCalculo estrategia)
        {
            _estrategia = estrategia;
        }

        public double Calcular(double[] dados)
        {
            if (_estrategia == null)
                throw new InvalidOperationException("Estratégia não definida");

            return _estrategia.Calcular(dados);
        }
    }

    // Padrão Observer com eventos
    public class SensorTemperatura
    {
        public event Action<double>? TemperaturaAlterada;

        private double _temperatura;
        public double Temperatura
        {
            get => _temperatura;
            private set
            {
                _temperatura = value;
                TemperaturaAlterada?.Invoke(value);
            }
        }

        public void SimularLeituras()
        {
            var random = new Random();
            var temperaturas = new[] { -5.0, 15.0, 25.0, 35.0, 40.0, 20.0 };

            foreach (var temp in temperaturas)
            {
                Temperatura = temp;
                Thread.Sleep(500); // Simula delay entre leituras
            }
        }
    }

    // Padrão Factory
    public interface IVeiculo
    {
        string Tipo { get; }
        string ObterDetalhes();
        void Acelerar();
    }

    public class Carro : IVeiculo
    {
        public string Tipo => "Carro";
        public string ObterDetalhes() => "4 rodas, motor a combustão";
        public void Acelerar() => Console.WriteLine("    Vrummm! Carro acelerando...");
    }

    public class Moto : IVeiculo
    {
        public string Tipo => "Moto";
        public string ObterDetalhes() => "2 rodas, ágil e econômica";
        public void Acelerar() => Console.WriteLine("    Rrrrrr! Moto acelerando...");
    }

    public class Caminhao : IVeiculo
    {
        public string Tipo => "Caminhão";
        public string ObterDetalhes() => "6+ rodas, carga pesada";
        public void Acelerar() => Console.WriteLine("    Vroooom! Caminhão acelerando devagar...");
    }

    public class VeiculoFactory
    {
        public IVeiculo CriarVeiculo(string tipo)
        {
            return tipo.ToLower() switch
            {
                "carro" => new Carro(),
                "moto" => new Moto(),
                "caminhao" => new Caminhao(),
                _ => throw new ArgumentException($"Tipo de veículo '{tipo}' não suportado")
            };
        }
    }

    // Dependency Injection
    public interface ILogger
    {
        void Log(string mensagem);
    }

    public interface IRepositorio
    {
        void Salvar(string item);
        List<string> ObterTodos();
    }

    public class ConsoleLogger : ILogger
    {
        public void Log(string mensagem)
        {
            Console.WriteLine($"  [LOG] {DateTime.Now:HH:mm:ss} - {mensagem}");
        }
    }

    public class ArquivoLogger : ILogger
    {
        public void Log(string mensagem)
        {
            Console.WriteLine($"  [ARQUIVO] Gravando no arquivo: {mensagem}");
        }
    }

    public class RepositorioMemoria : IRepositorio
    {
        private readonly List<string> _dados = new();

        public void Salvar(string item)
        {
            _dados.Add(item);
        }

        public List<string> ObterTodos() => new(_dados);
    }

    public class ServicoUsuario
    {
        private readonly ILogger _logger;
        private readonly IRepositorio _repositorio;

        public ServicoUsuario(ILogger logger, IRepositorio repositorio)
        {
            _logger = logger;
            _repositorio = repositorio;
        }

        public void CriarUsuario(string nome, string email)
        {
            var usuario = $"{nome} ({email})";
            _repositorio.Salvar(usuario);
            _logger.Log($"Usuário criado: {usuario}");
        }

        public void ListarUsuarios()
        {
            var usuarios = _repositorio.ObterTodos();
            _logger.Log($"Total de usuários: {usuarios.Count}");

            Console.WriteLine("  Usuários cadastrados:");
            usuarios.ForEach(u => Console.WriteLine($"    - {u}"));
        }
    }

    // Sistema integrado de processamento
    public interface IValidador
    {
        bool EhValido(string item);
    }

    public interface ITransformador
    {
        object Transformar(string item);
    }

    public interface IExportador
    {
        void Exportar(IEnumerable<object> dados);
    }

    public class ValidadorNumerico : IValidador
    {
        public bool EhValido(string item) => double.TryParse(item, out _);
    }

    public class ValidadorComprimento : IValidador
    {
        private readonly int _comprimentoMinimo;

        public ValidadorComprimento(int comprimentoMinimo)
        {
            _comprimentoMinimo = comprimentoMinimo;
        }

        public bool EhValido(string item) => item.Length >= _comprimentoMinimo;
    }

    public class TransformadorParaQuadrado : ITransformador
    {
        public object Transformar(string item)
        {
            var numero = double.Parse(item);
            return numero * numero;
        }
    }

    public class TransformadorParaMaiuscula : ITransformador
    {
        public object Transformar(string item) => item.ToUpper();
    }

    public class ExportadorConsole : IExportador
    {
        public void Exportar(IEnumerable<object> dados)
        {
            Console.WriteLine("  Resultados processados:");
            foreach (var item in dados)
            {
                Console.WriteLine($"    → {item}");
            }
        }
    }

    public class ProcessadorDados
    {
        private IValidador? _validador;
        private ITransformador? _transformador;
        private IExportador? _exportador;

        public void DefinirValidador(IValidador validador) => _validador = validador;
        public void DefinirTransformador(ITransformador transformador) => _transformador = transformador;
        public void DefinirExportador(IExportador exportador) => _exportador = exportador;

        public void ProcessarDados(string[] dadosEntrada)
        {
            if (_validador == null || _transformador == null || _exportador == null)
                throw new InvalidOperationException("Todos os componentes devem ser configurados");

            var dadosValidos = dadosEntrada.Where(_validador.EhValido);
            var dadosTransformados = dadosValidos.Select(_transformador.Transformar);

            _exportador.Exportar(dadosTransformados);
        }
    }

    #endregion
}
