using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

internal class Program
{
    public class Pessoa
    {
        public int Index { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Sex { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string DateOfBirth { get; set; }
        public string JobTitle { get; set; }

        public Pessoa(int index, string userId, string firstName, string lastName, string sex, string email, string phone, string dateOfBirth, string jobTitle)
        {
            Index = index;
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            Sex = sex;
            Email = email;
            Phone = phone;
            DateOfBirth = dateOfBirth;
            JobTitle = jobTitle;
        }

        public override string ToString()
        {
            return $"Index: {Index}, UserId: {UserId}, Name: {FirstName} {LastName}, Sex: {Sex}, Email: {Email}, Phone: {Phone}, DateOfBirth: {DateOfBirth}, JobTitle: {JobTitle}";
        }
    }

    public static void Main(string[] args)
    {
        List<Pessoa> pessoas100 = new List<Pessoa>();
        List<Pessoa> pessoas1000 = new List<Pessoa>();
        List<Pessoa> pessoas10000 = new List<Pessoa>();
        List<Pessoa> pessoas100000 = new List<Pessoa>();

        string basePath = "C:\\Users\\Computador\\Desktop\\Trabalho AED\\";

        LerArquivoCSV(basePath + "people-100.csv", pessoas100);
        LerArquivoCSV(basePath + "people-1000.csv", pessoas1000);
        LerArquivoCSV(basePath + "people-10000.csv", pessoas10000);
        LerArquivoCSV(basePath + "people-100000.csv", pessoas100000);

        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Imprimir Lista 100");
            Console.WriteLine("2. Imprimir Lista 1000");
            Console.WriteLine("3. Imprimir Lista 10000");
            Console.WriteLine("4. Imprimir Lista 100000");
            Console.WriteLine("5. Criar Novo Cadastro na Lista 100");
            Console.WriteLine("6. Atualizar Cadastro na Lista 100");
            Console.WriteLine("7. Ler Cadastro na Lista 100");
            Console.WriteLine("8. Remover Cadastro na Lista 100");
            Console.WriteLine("9. Ordenar Lista 100 por Index (Quicksort)");
            Console.WriteLine("10. Ordenar Lista 100 por FirstName (Merge Sort)");
            Console.WriteLine("11. Limpar dados");
            Console.WriteLine("12. Sair");
            Console.Write("Escolha uma opção: ");

            int opcao = int.Parse(Console.ReadLine());

            switch (opcao)
            {
                case 1:
                    ImprimirLista(pessoas100);
                    break;
                case 2:
                    ImprimirLista(pessoas1000);
                    break;
                case 3:
                    ImprimirLista(pessoas10000);
                    break;
                case 4:
                    ImprimirLista(pessoas100000);
                    break;
                case 5:
                    CriarNovoCadastro(pessoas100);
                    break;
                case 6:
                    AtualizarCadastro(pessoas100);
                    break;
                case 7:
                    LerCadastro(pessoas100);
                    break;
                case 8:
                    RemoverPessoaPorUserId(pessoas100);
                    break;
                case 9:
                    Quicksort(pessoas100, 0, pessoas100.Count - 1);
                    Console.WriteLine("Lista 100 ordenada por Index.");
                    break;
                case 10:
                    pessoas100 = MergeSort(pessoas100);
                    Console.WriteLine("Lista 100 ordenada por FirstName.");
                    break;
                case 11:
                    Console.Clear();
                    break;
                case 12:
                    return;
                default:
                    Console.WriteLine("Opção inválida, tente novamente.");
                    break;
            }
        }
    }

    public static void LerArquivoCSV(string filePath, List<Pessoa> pessoas)
    {
        using (var reader = new StreamReader(filePath))
        {
            reader.ReadLine();  // Pula o cabeçalho

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(',');

                int index = int.Parse(values[0]);
                string userId = values[1];
                string firstName = values[2];
                string lastName = values[3];
                string sex = values[4];
                string email = values[5];
                string phone = values[6];
                string dateOfBirth = values[7];
                string jobTitle = values[8];

                Pessoa pessoa = new Pessoa(index, userId, firstName, lastName, sex, email, phone, dateOfBirth, jobTitle);
                pessoas.Add(pessoa);
            }
        }
    }

    public static void CriarNovoCadastro(List<Pessoa> pessoas)
    {
        Console.Write("Digite o UserId: ");
        string userId = Console.ReadLine();
        Console.Write("Digite o Primeiro Nome: ");
        string firstName = Console.ReadLine();
        Console.Write("Digite o Último Nome: ");
        string lastName = Console.ReadLine();
        Console.Write("Digite o Sexo: ");
        string sex = Console.ReadLine();
        Console.Write("Digite o Email: ");
        string email = Console.ReadLine();
        Console.Write("Digite o Telefone: ");
        string phone = Console.ReadLine();
        Console.Write("Digite a Data de Nascimento (aaaa-mm-dd): ");
        string dateOfBirth = Console.ReadLine();
        Console.Write("Digite o Cargo: ");
        string jobTitle = Console.ReadLine();

        int index = pessoas.Count + 1;
        Pessoa novaPessoa = new Pessoa(index, userId, firstName, lastName, sex, email, phone, dateOfBirth, jobTitle);
        pessoas.Add(novaPessoa);

        Console.WriteLine("Novo cadastro criado com sucesso.");
    }

    public static void AtualizarCadastro(List<Pessoa> pessoas)
    {
        Console.Write("Digite o UserId do cadastro a ser atualizado: ");
        string userId = Console.ReadLine();

        Pessoa pessoa = pessoas.FirstOrDefault(p => p.UserId == userId);
        if (pessoa != null)
        {
            Console.Write("Digite o Primeiro Nome: ");
            pessoa.FirstName = Console.ReadLine();
            Console.Write("Digite o Último Nome: ");
            pessoa.LastName = Console.ReadLine();
            Console.Write("Digite o Sexo: ");
            pessoa.Sex = Console.ReadLine();
            Console.Write("Digite o Email: ");
            pessoa.Email = Console.ReadLine();
            Console.Write("Digite o Telefone: ");
            pessoa.Phone = Console.ReadLine();
            Console.Write("Digite a Data de Nascimento (aaaa-mm-dd): ");
            pessoa.DateOfBirth = Console.ReadLine();
            Console.Write("Digite o Cargo: ");
            pessoa.JobTitle = Console.ReadLine();

            Console.WriteLine($"Cadastro com UserId {userId} atualizado com sucesso.");
        }
        else
        {
            Console.WriteLine($"Não foi encontrada uma pessoa com o UserId {userId} para atualização.");
        }
    }

    public static void LerCadastro(List<Pessoa> pessoas)
    {
        Console.Write("Digite o UserId do cadastro a ser lido: ");
        string userId = Console.ReadLine();

        Pessoa pessoa = pessoas.FirstOrDefault(p => p.UserId == userId);
        if (pessoa != null)
        {
            Console.WriteLine(pessoa);
        }
        else
        {
            Console.WriteLine($"Não foi encontrada uma pessoa com o UserId {userId} na lista.");
        }
    }

    public static void RemoverPessoaPorUserId(List<Pessoa> pessoas)
    {
        Console.Write("Digite o UserId do cadastro a ser removido: ");
        string userId = Console.ReadLine();

        Pessoa pessoa = pessoas.FirstOrDefault(p => p.UserId == userId);
        if (pessoa != null)
        {
            pessoas.Remove(pessoa);
            Console.WriteLine($"Pessoa com UserId {userId} removida com sucesso.");
        }
        else
        {
            Console.WriteLine($"Não foi encontrada uma pessoa com o UserId {userId} na lista.");
        }
    }

    public static void Quicksort(List<Pessoa> pessoas, int left, int right)
    {
        if (left < right)
        {
            int pivotIndex = Partition(pessoas, left, right);
            Quicksort(pessoas, left, pivotIndex - 1);
            Quicksort(pessoas, pivotIndex + 1, right);
        }
    }

    private static int Partition(List<Pessoa> pessoas, int left, int right)
    {
        int pivotValue = pessoas[right].Index;
        int i = left - 1;

        for (int j = left; j < right; j++)
        {
            if (pessoas[j].Index <= pivotValue)
            {
                i++;
                Swap(pessoas, i, j);
            }
        }

        Swap(pessoas, i + 1, right);
        return i + 1;
    }

    private static void Swap(List<Pessoa> pessoas, int i, int j)
    {
        Pessoa temp = pessoas[i];
        pessoas[i] = pessoas[j];
        pessoas[j] = temp;
    }

    public static List<Pessoa> MergeSort(List<Pessoa> pessoas)
    {
        if (pessoas.Count <= 1)
            return pessoas;

        int mid = pessoas.Count / 2;
        List<Pessoa> left = MergeSort(pessoas.GetRange(0, mid));
        List<Pessoa> right = MergeSort(pessoas.GetRange(mid, pessoas.Count - mid));

        return Merge(left, right);
    }

    private static List<Pessoa> Merge(List<Pessoa> left, List<Pessoa> right)
    {
        List<Pessoa> result = new List<Pessoa>();
        int leftPointer = 0, rightPointer = 0;

        while (leftPointer < left.Count && rightPointer < right.Count)
        {
            if (string.Compare(left[leftPointer].FirstName, right[rightPointer].FirstName) < 0)
            {
                result.Add(left[leftPointer]);
                leftPointer++;
            }
            else
            {
                result.Add(right[rightPointer]);
                rightPointer++;
            }
        }

        while (leftPointer < left.Count)
        {
            result.Add(left[leftPointer]);
            leftPointer++;
        }

        while (rightPointer < right.Count)
        {
            result.Add(right[rightPointer]);
            rightPointer++;
        }

        return result;
    }

    public static void ImprimirLista(List<Pessoa> pessoas)
    {
        foreach (var pessoa in pessoas)
        {
            Console.WriteLine(pessoa);
        }
    }
}
