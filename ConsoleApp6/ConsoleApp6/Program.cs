/*
 * ===========================================
 * FUNDAMENTOS C# - MÓDULO 6: POO AVANÇADA - HERANÇA E POLIMORFISMO
 * ===========================================
 * 
 * Este programa demonstra:
 * - Herança de classes
 * - Polimorfismo (virtual, override, abstract)
 * - Classes abstratas
 * - Modificadores de acesso
 * - Sealed classes
 * - Base e this
 * 
 * Objetivo: Dominar conceitos avançados de POO
 * Nível: Avançado
 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace POOAvancada
{
    #region Classes Base

    /// <summary>
    /// Classe abstrata base para representar formas geométricas
    /// </summary>
    public abstract class Forma
    {
        // Propriedades comuns
        public string Nome { get; protected set; }
        public string Cor { get; set; }
        public DateTime DataCriacao { get; }

        // Contador estático
        protected static int _contadorFormas = 0;
        public static int TotalFormas => _contadorFormas;

        // Construtor protegido (só pode ser chamado por classes filhas)
        protected Forma(string nome, string cor = "Branco")
        {
            Nome = nome ?? "Forma";
            Cor = cor ?? "Branco";
            DataCriacao = DateTime.Now;
            _contadorFormas++;
        }

        // Métodos abstratos (devem ser implementados nas classes filhas)
        public abstract double CalcularArea();
        public abstract double CalcularPerimetro();

        // Método virtual (pode ser sobrescrito)
        public virtual void ExibirInformacoes()
        {
            Console.WriteLine($"Forma: {Nome}");
            Console.WriteLine($"Cor: {Cor}");
            Console.WriteLine($"Área: {CalcularArea():F2}");
            Console.WriteLine($"Perímetro: {CalcularPerimetro():F2}");
        }

        // Método concreto (comum a todas as formas)
        public void AlterarCor(string novaCor)
        {
            string corAnterior = Cor;
            Cor = novaCor ?? "Branco";
            Console.WriteLine($"{Nome}: cor alterada de {corAnterior} para {Cor}");
        }

        // Override do ToString
        public override string ToString()
        {
            return $"{Nome} ({Cor}) - Área: {CalcularArea():F2}";
        }
    }

    /// <summary>
    /// Classe abstrata para formas com lados
    /// </summary>
    public abstract class Poligono : Forma
    {
        public int NumeroLados { get; protected set; }

        protected Poligono(string nome, int numeroLados, string cor = "Branco")
            : base(nome, cor)
        {
            NumeroLados = numeroLados > 0 ? numeroLados : 3;
        }

        public override void ExibirInformacoes()
        {
            base.ExibirInformacoes(); // Chama o método da classe pai
            Console.WriteLine($"Número de lados: {NumeroLados}");
        }
    }

    #endregion

    #region Classes Concretas

    /// <summary>
    /// Círculo - herda diretamente de Forma
    /// </summary>
    public class Circulo : Forma
    {
        public double Raio { get; set; }

        public Circulo(double raio, string cor = "Branco")
            : base("Círculo", cor)
        {
            Raio = raio > 0 ? raio : 1;
        }

        public override double CalcularArea()
        {
            return Math.PI * Raio * Raio;
        }

        public override double CalcularPerimetro()
        {
            return 2 * Math.PI * Raio;
        }

        // Método específico do círculo
        public double CalcularDiametro()
        {
            return 2 * Raio;
        }

        public override void ExibirInformacoes()
        {
            base.ExibirInformacoes();
            Console.WriteLine($"Raio: {Raio:F2}");
            Console.WriteLine($"Diâmetro: {CalcularDiametro():F2}");
        }
    }

    /// <summary>
    /// Retângulo - herda de Polígono
    /// </summary>
    public class Retangulo : Poligono
    {
        public double Largura { get; set; }
        public double Altura { get; set; }

        public Retangulo(double largura, double altura, string cor = "Branco")
            : base("Retângulo", 4, cor)
        {
            Largura = largura > 0 ? largura : 1;
            Altura = altura > 0 ? altura : 1;
        }

        public override double CalcularArea()
        {
            return Largura * Altura;
        }

        public override double CalcularPerimetro()
        {
            return 2 * (Largura + Altura);
        }

        // Método específico
        public bool EhQuadrado()
        {
            return Math.Abs(Largura - Altura) < 0.001;
        }

        public override void ExibirInformacoes()
        {
            base.ExibirInformacoes();
            Console.WriteLine($"Dimensões: {Largura:F2} × {Altura:F2}");
            Console.WriteLine($"É quadrado: {(EhQuadrado() ? "Sim" : "Não")}");
        }
    }

    /// <summary>
    /// Quadrado - herda de Retângulo (demonstra herança em cadeia)
    /// </summary>
    public sealed class Quadrado : Retangulo
    {
        public double Lado
        {
            get => Largura;
            set
            {
                if (value > 0)
                {
                    Largura = value;
                    Altura = value;
                }
            }
        }

        public Quadrado(double lado, string cor = "Branco")
            : base(lado, lado, cor)
        {
            Nome = "Quadrado"; // Redefine o nome
        }

        // Override específico para quadrado
        public override void ExibirInformacoes()
        {
            Console.WriteLine($"Forma: {Nome}");
            Console.WriteLine($"Cor: {Cor}");
            Console.WriteLine($"Área: {CalcularArea():F2}");
            Console.WriteLine($"Perímetro: {CalcularPerimetro():F2}");
            Console.WriteLine($"Número de lados: {NumeroLados}");
            Console.WriteLine($"Lado: {Lado:F2}");
        }
    }

    /// <summary>
    /// Triângulo - herda de Polígono
    /// </summary>
    public class Triangulo : Poligono
    {
        public double LadoA { get; set; }
        public double LadoB { get; set; }
        public double LadoC { get; set; }

        public Triangulo(double ladoA, double ladoB, double ladoC, string cor = "Branco")
            : base("Triângulo", 3, cor)
        {
            // Validação dos lados do triângulo
            if (EhTrianguloValido(ladoA, ladoB, ladoC))
            {
                LadoA = ladoA;
                LadoB = ladoB;
                LadoC = ladoC;
            }
            else
            {
                // Define um triângulo equilátero padrão
                LadoA = LadoB = LadoC = 1;
                Console.WriteLine("Lados inválidos! Criando triângulo equilátero padrão.");
            }
        }

        private bool EhTrianguloValido(double a, double b, double c)
        {
            return a > 0 && b > 0 && c > 0 &&
                   a + b > c && a + c > b && b + c > a;
        }

        public override double CalcularArea()
        {
            // Fórmula de Heron
            double s = CalcularPerimetro() / 2;
            return Math.Sqrt(s * (s - LadoA) * (s - LadoB) * (s - LadoC));
        }

        public override double CalcularPerimetro()
        {
            return LadoA + LadoB + LadoC;
        }

        public string TipoTriangulo()
        {
            if (Math.Abs(LadoA - LadoB) < 0.001 && Math.Abs(LadoB - LadoC) < 0.001)
                return "Equilátero";
            else if (Math.Abs(LadoA - LadoB) < 0.001 || Math.Abs(LadoB - LadoC) < 0.001 || Math.Abs(LadoA - LadoC) < 0.001)
                return "Isósceles";
            else
                return "Escaleno";
        }

        public override void ExibirInformacoes()
        {
            base.ExibirInformacoes();
            Console.WriteLine($"Lados: {LadoA:F2}, {LadoB:F2}, {LadoC:F2}");
            Console.WriteLine($"Tipo: {TipoTriangulo()}");
        }
    }

    #endregion

    #region Sistema de Funcionários (Exemplo Prático)

    /// <summary>
    /// Classe base abstrata para funcionários
    /// </summary>
    public abstract class Funcionario
    {
        private static int _proximoId = 1;

        public int Id { get; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime DataAdmissao { get; }
        protected double SalarioBase { get; set; }

        protected Funcionario(string nome, string email, double salarioBase)
        {
            Id = _proximoId++;
            Nome = nome ?? throw new ArgumentNullException(nameof(nome));
            Email = email ?? "";
            DataAdmissao = DateTime.Now;
            SalarioBase = salarioBase > 0 ? salarioBase : 1000;
        }

        // Método abstrato - cada tipo de funcionário calcula diferente
        public abstract double CalcularSalario();

        // Método virtual - pode ser sobrescrito
        public virtual string ObterDetalhes()
        {
            return $"ID: {Id} | {Nome} | {Email} | Admissão: {DataAdmissao:dd/MM/yyyy}";
        }

        // Método concreto comum
        public int CalcularTempoServico()
        {
            return (DateTime.Now - DataAdmissao).Days;
        }

        public override string ToString()
        {
            return $"{Nome} (ID: {Id}) - Salário: {CalcularSalario():C}";
        }
    }

    /// <summary>
    /// Funcionário CLT
    /// </summary>
    public class FuncionarioCLT : Funcionario
    {
        public double Bonus { get; set; }
        public double Desconto { get; set; }

        public FuncionarioCLT(string nome, string email, double salarioBase, double bonus = 0, double desconto = 0)
            : base(nome, email, salarioBase)
        {
            Bonus = bonus >= 0 ? bonus : 0;
            Desconto = desconto >= 0 ? desconto : 0;
        }

        public override double CalcularSalario()
        {
            return SalarioBase + Bonus - Desconto;
        }

        public override string ObterDetalhes()
        {
            return $"{base.ObterDetalhes()} | CLT | Salário Base: {SalarioBase:C}";
        }
    }

    /// <summary>
    /// Funcionário terceirizado
    /// </summary>
    public class FuncionarioTerceirizado : Funcionario
    {
        public double ValorHora { get; set; }
        public int HorasTrabalhadas { get; set; }
        public double TaxaAdministrativa { get; set; }

        public FuncionarioTerceirizado(string nome, string email, double valorHora, double taxaAdministrativa = 0.1)
            : base(nome, email, 0) // Salário base 0 para terceirizados
        {
            ValorHora = valorHora > 0 ? valorHora : 10;
            TaxaAdministrativa = taxaAdministrativa >= 0 ? taxaAdministrativa : 0.1;
            HorasTrabalhadas = 0;
        }

        public override double CalcularSalario()
        {
            double salarioBruto = ValorHora * HorasTrabalhadas;
            double taxa = salarioBruto * TaxaAdministrativa;
            return salarioBruto - taxa;
        }

        public void RegistrarHoras(int horas)
        {
            if (horas > 0)
                HorasTrabalhadas += horas;
        }

        public override string ObterDetalhes()
        {
            return $"{base.ObterDetalhes()} | Terceirizado | R$ {ValorHora:F2}/h | {HorasTrabalhadas}h";
        }
    }

    /// <summary>
    /// Gerente - herda de FuncionarioCLT com responsabilidades extras
    /// </summary>
    public class Gerente : FuncionarioCLT
    {
        public string Departamento { get; set; }
        public List<Funcionario> Subordinados { get; }
        private const double BONUS_LIDERANCA = 1000;

        public Gerente(string nome, string email, double salarioBase, string departamento)
            : base(nome, email, salarioBase)
        {
            Departamento = departamento ?? "Geral";
            Subordinados = new List<Funcionario>();
        }

        public override double CalcularSalario()
        {
            // Salário base + bônus + bônus por subordinado
            double salarioBase = base.CalcularSalario();
            double bonusLideranca = BONUS_LIDERANCA + (Subordinados.Count * 200);
            return salarioBase + bonusLideranca;
        }

        public void AdicionarSubordinado(Funcionario funcionario)
        {
            if (funcionario != null && !Subordinados.Contains(funcionario))
            {
                Subordinados.Add(funcionario);
                Console.WriteLine($"{funcionario.Nome} adicionado como subordinado de {Nome}");
            }
        }

        public void RemoverSubordinado(Funcionario funcionario)
        {
            if (Subordinados.Remove(funcionario))
            {
                Console.WriteLine($"{funcionario.Nome} removido dos subordinados de {Nome}");
            }
        }

        public override string ObterDetalhes()
        {
            return $"{base.ObterDetalhes()} | Gerente | Depto: {Departamento} | Subordinados: {Subordinados.Count}";
        }
    }

    #endregion

    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "C# Fundamentals - Módulo 6: POO Avançada";
            Console.WriteLine("=".PadLeft(60, '='));
            Console.WriteLine(" POO AVANÇADA - HERANÇA E POLIMORFISMO ");
            Console.WriteLine("=".PadLeft(60, '='));
            Console.WriteLine();

            // 1. HERANÇA E CLASSES ABSTRATAS
            DemonstrarHerancaAbstracao();

            // 2. POLIMORFISMO
            DemonstrarPolimorfismo();

            // 3. OVERRIDE E VIRTUAL
            DemonstrarOverrideVirtual();

            // 4. SEALED CLASSES
            DemonstrarSealedClass();

            // 5. EXEMPLO PRÁTICO - SISTEMA DE FUNCIONÁRIOS
            ExemploPraticoFuncionarios();

            Console.WriteLine("\n" + "=".PadLeft(60, '='));
            Console.WriteLine("✅ Módulo 6 concluído! Próximo: ConsoleApp7");
            Console.WriteLine("=".PadLeft(60, '='));
            Console.WriteLine("\nPressione qualquer tecla para sair...");
            Console.ReadKey();
        }

        static void DemonstrarHerancaAbstracao()
        {
            Console.WriteLine("🏗️  1. HERANÇA E CLASSES ABSTRATAS");
            Console.WriteLine(new string('-', 50));

            // Não é possível instanciar uma classe abstrata
            // Forma forma = new Forma(); // ERRO de compilação

            // Criando objetos das classes concretas
            Circulo circulo = new Circulo(5, "Azul");
            Retangulo retangulo = new Retangulo(4, 6, "Verde");
            Quadrado quadrado = new Quadrado(3, "Vermelho");
            Triangulo triangulo = new Triangulo(3, 4, 5, "Amarelo");

            List<Forma> formas = new List<Forma> { circulo, retangulo, quadrado, triangulo };

            Console.WriteLine($"Total de formas criadas: {Forma.TotalFormas}");
            Console.WriteLine("\nFormas criadas:");

            foreach (Forma forma in formas)
            {
                Console.WriteLine($"  - {forma}");
            }

            Console.WriteLine();
        }

        static void DemonstrarPolimorfismo()
        {
            Console.WriteLine("🎭 2. POLIMORFISMO");
            Console.WriteLine(new string('-', 50));

            // Array de formas (polimorfismo)
            Forma[] formas = {
                new Circulo(3, "Azul"),
                new Retangulo(2, 4, "Verde"),
                new Quadrado(5, "Vermelho"),
                new Triangulo(3, 4, 5, "Amarelo")
            };

            Console.WriteLine("Demonstrando polimorfismo:");
            Console.WriteLine("Todas são tratadas como 'Forma', mas cada uma executa seu próprio método:\n");

            foreach (Forma forma in formas)
            {
                // Polimorfismo: cada forma executa sua própria implementação
                Console.WriteLine($"=== {forma.Nome} ===");
                forma.ExibirInformacoes();
                Console.WriteLine();
            }

            // Calculando área total usando polimorfismo
            double areaTotal = formas.Sum(f => f.CalcularArea());
            Console.WriteLine($"Área total de todas as formas: {areaTotal:F2}");

            Console.WriteLine();
        }

        static void DemonstrarOverrideVirtual()
        {
            Console.WriteLine("🔄 3. OVERRIDE E VIRTUAL");
            Console.WriteLine(new string('-', 50));

            Console.WriteLine("Demonstrando métodos virtual e override:");

            // Método virtual sendo sobrescrito
            Forma forma1 = new Circulo(2, "Azul");
            Forma forma2 = new Quadrado(3, "Verde");

            Console.WriteLine("\nMétodo ExibirInformacoes() sobrescrito:");
            Console.WriteLine("--- Círculo ---");
            forma1.ExibirInformacoes(); // Executa a versão do Círculo

            Console.WriteLine("\n--- Quadrado ---");
            forma2.ExibirInformacoes(); // Executa a versão do Quadrado

            // Testando método específico da classe filha
            if (forma1 is Circulo circulo)
            {
                Console.WriteLine($"\nMétodo específico do círculo - Diâmetro: {circulo.CalcularDiametro():F2}");
            }

            Console.WriteLine();
        }

        static void DemonstrarSealedClass()
        {
            Console.WriteLine("🔒 4. SEALED CLASS");
            Console.WriteLine(new string('-', 50));

            Console.WriteLine("Quadrado é uma classe 'sealed' - não pode ser herdada:");

            Quadrado quadrado = new Quadrado(4, "Roxo");
            Console.WriteLine($"Quadrado criado: {quadrado}");

            // Tentativa de herdar de Quadrado resultaria em erro:
            // class SuperQuadrado : Quadrado { } // ERRO!

            Console.WriteLine("✅ Classes sealed impedem herança indesejada");
            Console.WriteLine("✅ Útil para classes que não devem ser estendidas");

            Console.WriteLine();
        }

        static void ExemploPraticoFuncionarios()
        {
            Console.WriteLine("👥 5. EXEMPLO PRÁTICO: SISTEMA DE FUNCIONÁRIOS");
            Console.WriteLine(new string('-', 50));

            try
            {
                // Criando funcionários de diferentes tipos
                var funcionarios = new List<Funcionario>
                {
                    new FuncionarioCLT("João Silva", "joao@empresa.com", 3000, 500, 200),
                    new FuncionarioCLT("Maria Santos", "maria@empresa.com", 3500, 300, 150),
                    new FuncionarioTerceirizado("Pedro Costa", "pedro@terceirizada.com", 25, 0.15),
                    new Gerente("Ana Oliveira", "ana@empresa.com", 8000, "TI"),
                    new Gerente("Carlos Lima", "carlos@empresa.com", 7500, "Vendas")
                };

                // Registrando horas para o terceirizado
                var terceirizado = funcionarios.OfType<FuncionarioTerceirizado>().First();
                terceirizado.RegistrarHoras(160); // 160 horas no mês

                // Adicionando subordinados aos gerentes
                var gerentes = funcionarios.OfType<Gerente>().ToList();
                var funcionariosCLT = funcionarios.OfType<FuncionarioCLT>().Where(f => !(f is Gerente)).ToList();

                gerentes[0].AdicionarSubordinado(funcionariosCLT[0]); // Ana gerencia João
                gerentes[1].AdicionarSubordinado(funcionariosCLT[1]); // Carlos gerencia Maria
                gerentes[1].AdicionarSubordinado(terceirizado);        // Carlos gerencia Pedro

                Console.WriteLine("=== FOLHA DE PAGAMENTO ===");
                Console.WriteLine();

                double totalFolha = 0;
                foreach (Funcionario funcionario in funcionarios)
                {
                    // Polimorfismo: cada tipo calcula salário diferente
                    double salario = funcionario.CalcularSalario();
                    totalFolha += salario;

                    Console.WriteLine(funcionario.ObterDetalhes());
                    Console.WriteLine($"Salário: {salario:C}");
                    Console.WriteLine($"Tempo de serviço: {funcionario.CalcularTempoServico()} dias");
                    Console.WriteLine();
                }

                Console.WriteLine($"TOTAL DA FOLHA: {totalFolha:C}");

                // Demonstrando casting e verificação de tipo
                Console.WriteLine("\n=== RELATÓRIO GERENCIAL ===");
                foreach (Funcionario funcionario in funcionarios)
                {
                    if (funcionario is Gerente gerente)
                    {
                        Console.WriteLine($"Gerente: {gerente.Nome}");
                        Console.WriteLine($"Departamento: {gerente.Departamento}");
                        Console.WriteLine($"Subordinados: {gerente.Subordinados.Count}");

                        foreach (var subordinado in gerente.Subordinados)
                        {
                            Console.WriteLine($"  → {subordinado.Nome}");
                        }
                        Console.WriteLine();
                    }
                }

                // Estatísticas usando LINQ e polimorfismo
                Console.WriteLine("=== ESTATÍSTICAS ===");
                Console.WriteLine($"Total de funcionários: {funcionarios.Count}");
                Console.WriteLine($"Funcionários CLT: {funcionarios.OfType<FuncionarioCLT>().Count()}");
                Console.WriteLine($"Funcionários terceirizados: {funcionarios.OfType<FuncionarioTerceirizado>().Count()}");
                Console.WriteLine($"Gerentes: {funcionarios.OfType<Gerente>().Count()}");
                Console.WriteLine($"Salário médio: {funcionarios.Average(f => f.CalcularSalario()):C}");
                Console.WriteLine($"Maior salário: {funcionarios.Max(f => f.CalcularSalario()):C}");
                Console.WriteLine($"Menor salário: {funcionarios.Min(f => f.CalcularSalario()):C}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }

            Console.WriteLine();
        }
    }
}
