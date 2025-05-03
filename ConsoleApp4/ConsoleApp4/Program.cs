class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Demonstração de Coleções e Listas em C# ===\n");

        // Criando e manipulando uma List<T>
        Console.WriteLine("1. Trabalhando com List<string>:");
        List<string> frutas = new List<string>();

        // Adicionando elementos
        frutas.Add("Maçã");
        frutas.Add("Banana");
        frutas.Add("Laranja");
        frutas.AddRange(new[] { "Uva", "Pera", "Manga" });

        Console.WriteLine("Lista de frutas:");
        ImprimirLista(frutas);

        // Removendo elementos
        frutas.Remove("Pera");
        Console.WriteLine("\nApós remover 'Pera':");
        ImprimirLista(frutas);

        // Verificando existência
        Console.WriteLine($"\nContém 'Maçã'? {frutas.Contains("Maçã")}");

        // Ordenando a lista
        frutas.Sort();
        Console.WriteLine("\nLista ordenada:");
        ImprimirLista(frutas);

        // Trabalhando com List<int>
        Console.WriteLine("\n2. Trabalhando com List<int>:");
        List<int> numeros = new List<int> { 5, 8, 2, 10, 3, 1, 7, 4, 6, 9 };

        Console.WriteLine("Números originais:");
        ImprimirLista(numeros);

        // Usando LINQ
        var numerosPares = numeros.Where(n => n % 2 == 0).ToList();
        Console.WriteLine("\nNúmeros pares:");
        ImprimirLista(numerosPares);

        // Encontrando valores
        Console.WriteLine($"\nPrimeiro número maior que 7: {numeros.First(n => n > 7)}");
        Console.WriteLine($"Soma de todos os números: {numeros.Sum()}");
        Console.WriteLine($"Média dos números: {numeros.Average():F2}");
        Console.WriteLine($"Maior número: {numeros.Max()}");
        Console.WriteLine($"Menor número: {numeros.Min()}");

        // Dictionary exemplo
        Console.WriteLine("\n3. Trabalhando com Dictionary<TKey, TValue>:");
        Dictionary<string, int> idades = new Dictionary<string, int>
        {
            {"João", 25},
            {"Maria", 30},
            {"Pedro", 22}
        };

        foreach (var pessoa in idades)
        {
            Console.WriteLine($"{pessoa.Key} tem {pessoa.Value} anos");
        }

        // HashSet exemplo
        Console.WriteLine("\n4. Trabalhando com HashSet<T>:");
        HashSet<int> conjunto1 = new HashSet<int> { 1, 2, 3, 4, 5 };
        HashSet<int> conjunto2 = new HashSet<int> { 4, 5, 6, 7, 8 };

        conjunto1.UnionWith(conjunto2);
        Console.WriteLine("União dos conjuntos:");
        ImprimirLista(conjunto1.ToList());
    }

    static void ImprimirLista<T>(List<T> lista)
    {
        foreach (var item in lista)
        {
            Console.Write($"{item}, ");
        }
        Console.WriteLine();
    }
}
