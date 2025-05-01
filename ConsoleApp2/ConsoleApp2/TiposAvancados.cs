using System.Dynamic;

namespace ConsoleApp2
{
    // Classe base para demonstrar herança e modificadores de acesso
    public class Animal(string nome)
    {
        public string Nome { get; set; } = nome;
        protected string? especie;
        internal bool domestico;
        protected internal string? habitat;
        private protected string codigoGenetico = "ACTG";

        public virtual void EmitirSom()
        {
            Console.WriteLine("Som genérico de animal");
        }
    }

    // Classe derivada para demonstrar herança e acesso aos modificadores
    public class Cachorro : Animal
    {
        public Cachorro(string nome) : base(nome)
        {
            especie = "Canis lupus familiaris"; // Acesso a membro protected
            habitat = "Terrestre"; // Acesso a membro protected internal
            domestico = true; // Acesso a membro internal
            // Pode acessar codigoGenetico por ser uma classe derivada no mesmo assembly
            var codigo = codigoGenetico;
        }

        public override void EmitirSom()
        {
            Console.WriteLine("Au au!");
        }
    }

    public class DemonstracaoTiposAvancados
    {
        public static void ExecutarDemonstracao()
        {
            Console.WriteLine("\n=== Demonstração de Tipos Avançados em C# ===\n");

            // Object (tipo base de todos os outros tipos)
            Console.WriteLine("=== Object ===");
            object obj1 = 100;
            object obj2 = "Texto";
            object obj3 = new DateTime(2025, 4, 29);
            Console.WriteLine($"Object pode armazenar qualquer tipo:");
            Console.WriteLine($"obj1 (int): {obj1}, Tipo: {obj1.GetType()}");
            Console.WriteLine($"obj2 (string): {obj2}, Tipo: {obj2.GetType()}");
            Console.WriteLine($"obj3 (DateTime): {obj3}, Tipo: {obj3.GetType()}\n");

            // Dynamic
            Console.WriteLine("=== Dynamic ===");
            dynamic dynamicVar = 100;
            Console.WriteLine($"Dynamic inicialmente é int: {dynamicVar}");
            dynamicVar = "Agora é uma string";
            Console.WriteLine($"Agora dynamic é string: {dynamicVar}");

            // ExpandoObject (objeto dinâmico expansível)
            dynamic pessoa = new ExpandoObject();
            pessoa.Nome = "João";
            pessoa.Idade = 30;
            Console.WriteLine($"ExpandoObject: Nome = {pessoa.Nome}, Idade = {pessoa.Idade}\n");

            // Nullable Types
            Console.WriteLine("=== Nullable Types ===");
            int? numeroNullavel = null;
            double? valorNullavel = 10.5;
            Console.WriteLine($"Número nullable: {numeroNullavel ?? -1}"); // Usando o operador de coalescência nula
            Console.WriteLine($"Valor nullable: {valorNullavel}\n");

            // Demonstração de Modificadores de Acesso
            Console.WriteLine("=== Demonstração de Modificadores de Acesso ===");
            var animal = new Animal("Generic Animal");
            var cachorro = new Cachorro("Rex");

            // Acessando membros públicos
            Console.WriteLine($"Nome do Animal (public): {animal.Nome}");
            animal.EmitirSom();
            cachorro.EmitirSom();

            // Demonstração de conversão entre tipos
            Console.WriteLine("\n=== Conversão entre Tipos ===");
            string numeroString = "123";
            int numeroConvertido = Convert.ToInt32(numeroString);
            Console.WriteLine($"String para Int: {numeroString} -> {numeroConvertido}");

            // Demonstração de tipos anônimos
            Console.WriteLine("\n=== Tipos Anônimos ===");
            var anonimo = new { Nome = "Maria", Idade = 25 };
            Console.WriteLine($"Tipo Anônimo: {anonimo.Nome}, {anonimo.Idade} anos");
        }
    }
}
