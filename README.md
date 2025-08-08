# 🚀 Fundamentos C# (C# Fundamentals)

[![License](https://img.shields.io/badge/license-MIT-blue.svg)](LICENSE)
![C#](https://img.shields.io/badge/C%23-12.0-purple.svg)
![.NET](https://img.shields.io/badge/.NET-8.0-512BD4)

## 📝 Descrição

Este repositório apresenta uma **jornada completa de aprendizado em C#** através
de 7 projetos console progressivos e interativos. Cada aplicação foi
meticulosamente projetada para ensinar conceitos específicos da linguagem, desde
variáveis básicas até padrões de design avançados.

**🎯 Objetivo Principal:** Proporcionar uma experiência de aprendizado hands-on
onde cada projeto console demonstra conceitos fundamentais do C# através de
exemplos práticos, exercícios interativos e código didático com comentários
explicativos.

## 🎯 Objetivos de Aprendizagem

- **Dominar a sintaxe C#**: Variáveis, tipos de dados e operadores essenciais
- **Controlar o fluxo de execução**: Estruturas condicionais, loops e tomada de
  decisão
- **Organizar código eficientemente**: Métodos, funções e programação modular
- **Aplicar Programação Orientada a Objetos**: Classes, herança, polimorfismo e
  abstração
- **Implementar padrões profissionais**: Interfaces, injeção de dependência e
  design patterns

## 📚 Aplicações Console - Jornada Progressiva

Cada aplicação console é uma estação de aprendizado com exemplos interativos e
exercícios práticos:

### 🌱 **Nível Iniciante - Fundamentos Essenciais**

- **[ConsoleApp1 - Tipos e Variáveis](./ConsoleApp1/)**: Declaração de
  variáveis, tipos primitivos (int, string, bool), entrada/saída de dados com
  `Console.ReadLine()`, conversões de tipo seguras com `TryParse` e formatação
  de strings com interpolação.

- **[ConsoleApp2 - Operadores e Controle](./ConsoleApp2/)**: Operadores
  aritméticos, relacionais e lógicos, estruturas condicionais (`if/else`,
  `switch`), loops (`for`, `while`, `foreach`), operadores especiais (`??`,
  `?.`) e controle de fluxo (`break`, `continue`).

- **[ConsoleApp3 - Arrays e Coleções](./ConsoleApp3/)**: Arrays unidimensionais
  e multidimensionais, coleções genéricas (`List<T>`, `Dictionary<K,V>`),
  operações com coleções, introdução ao LINQ básico e manipulação de dados
  estruturados.

### 🌿 **Nível Intermediário - Programação Estruturada**

- **[ConsoleApp4 - Métodos e Funções](./ConsoleApp4/)**: Criação de métodos,
  parâmetros e tipos de retorno, sobrecarga de métodos, parâmetros opcionais e
  nomeados, modificadores `ref`, `out` e `in`, recursão e modularização de
  código.

- **[ConsoleApp5 - POO Básica](./ConsoleApp5/)**: Classes e objetos,
  propriedades e encapsulamento, construtores, métodos de instância e estáticos,
  enums e structs, modificadores de acesso e conceitos fundamentais de
  orientação a objetos.

### 🌳 **Nível Avançado - POO e Padrões**

- **[ConsoleApp6 - POO Avançada](./ConsoleApp6/)**: Herança de classes,
  polimorfismo (`virtual`, `override`), classes abstratas, modificadores
  `sealed`, palavra-chave `base`, hierarquias de classes e conceitos avançados
  de POO.

- **[ConsoleApp7 - Interfaces e Padrões](./ConsoleApp7/)**: Interfaces
  (`IDisposable`, `IComparable`), padrões de design (Strategy, Observer,
  Factory), injeção de dependência básica, polimorfismo com interfaces e
  arquitetura de software limpa.

## 🛠️ Tecnologias Utilizadas

- **C# 12.0** - Última versão da linguagem
- **.NET 8.0** - Framework de desenvolvimento
- **Visual Studio Code** - Editor recomendado
- **Git** - Controle de versão

## 🚀 Como Usar

### Pré-requisitos

- **Windows 11** (ambiente de desenvolvimento)
- **Prompt de Comando (CMD)** (shell padrão)
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download) instalado
- Editor de código (recomendado: Visual Studio Code ou Visual Studio 2022)

### Verificando a Instalação

Verifique se o .NET está instalado corretamente:

```cmd
dotnet --version
```

Deve retornar a versão 8.0 ou superior.

### Executando os Projetos

1. **Clone o repositório:**

```cmd
git clone https://github.com/gjoliveira9634/C-Sharp-Fundamentals
cd C-Sharp-Fundamentals
```

2. **Navegue até o projeto desejado:**

```cmd
cd ConsoleApp1\ConsoleApp1
```

3. **Execute o projeto:**

```cmd
dotnet run
```

### Ordem Recomendada de Estudo

Para máximo aproveitamento, siga a ordem sequencial dos projetos:

**Trilha Iniciante:** ConsoleApp1 → ConsoleApp2 → ConsoleApp3 (Fundamentos)
**Trilha Intermediária:** ConsoleApp4 → ConsoleApp5 (Programação Estruturada e
POO) **Trilha Avançada:** ConsoleApp6 → ConsoleApp7 (POO Avançada e Padrões)

## 📖 Conceitos Detalhados por Aplicação

| **Aplicação**   | **Conceitos Principais**                                     | **Exemplos Práticos**                                    |
| --------------- | ------------------------------------------------------------ | -------------------------------------------------------- |
| **ConsoleApp1** | Variáveis, tipos primitivos, entrada/saída, conversões       | Sistema de cadastro básico, calculadora simples          |
| **ConsoleApp2** | Operadores, condicionais, loops, controle de fluxo           | Jogo de adivinhação, validação de dados                  |
| **ConsoleApp3** | Arrays, coleções, LINQ básico, manipulação de dados          | Sistema de notas de alunos, gerenciador de listas        |
| **ConsoleApp4** | Métodos, parâmetros, sobrecarga, recursão                    | Calculadora avançada, validador de dados                 |
| **ConsoleApp5** | Classes, objetos, propriedades, construtores, encapsulamento | Sistema bancário, gerenciamento de pessoas               |
| **ConsoleApp6** | Herança, polimorfismo, classes abstratas, hierarquias        | Sistema de formas geométricas, jogo interativo           |
| **ConsoleApp7** | Interfaces, padrões de design, injeção de dependência        | Processador de dados, sistema com diferentes estratégias |

## 📁 Estrutura dos Projetos

Cada projeto segue a estrutura padrão do .NET:

```
ConsoleAppX/
├── ConsoleAppX.sln          # Solução do Visual Studio
└── ConsoleAppX/
    ├── ConsoleAppX.csproj   # Arquivo de projeto
    ├── Program.cs           # Ponto de entrada da aplicação
    └── [Outras pastas]      # Conforme necessário (ex: Interfaces/, Models/)
```

## 🎓 Para Estudantes

Cada projeto inclui:

- ✅ **Comentários didáticos** explicando cada conceito
- ✅ **Exemplos práticos** aplicados a situações reais
- ✅ **Exercícios progressivos** para praticar
- ✅ **Código limpo** seguindo boas práticas

## 🤝 Contribuição

Sinta-se à vontade para contribuir com melhorias, correções ou novos exemplos!

## 📄 Licença

Este projeto está sob a licença MIT. Veja o arquivo [LICENSE](LICENSE) para mais
detalhes.

---

## 🔧 Comandos Úteis (CMD)

Para cada projeto, navegue até a pasta do projeto e execute:

```cmd
rem Compilar o projeto
dotnet build

rem Executar o projeto
dotnet run

rem Limpar arquivos de build
dotnet clean
```
