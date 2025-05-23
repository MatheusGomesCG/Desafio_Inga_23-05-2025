using System;
using System.Text.RegularExpressions;

namespace Exercicio_01;

class Program
{
    static void Main(string[] args)
    {
        string inputUser;

        Console.Write("Nome: ");
        inputUser = Console.ReadLine();
        string name = IsValidName(inputUser);

        Console.Write("CPF: ");
        inputUser = Console.ReadLine();
        string cpf = IsValidCPF(inputUser);

        Console.Write("Idade: ");
        inputUser = Console.ReadLine();
        string age = IsValidAge(inputUser);

        Console.Clear();
        Console.WriteLine("Cadastro aprovado!");
        Console.WriteLine($"Nome: {name}");
        Console.WriteLine($"CPF: {cpf}");
        Console.WriteLine($"Idade: {age}");


    }

    static string IsValidName(string inputUser)
    {
        while (inputUser.Length < 5)
        {
            Console.Write("Digite um nome maior que 05 caracteres: ");
            inputUser = Console.ReadLine();
        }

        return inputUser;
    }

    static string IsValidCPF(string inputUser)
    {
        Regex regex = new Regex(@"^(\d{3})\.?(\d{3})\.?(\d{3})-?(\d{2})$");
        while (inputUser.Length < 11)
        {
            Console.Write("Digite um CPF válido: ");
            inputUser = Console.ReadLine();
        }
        string cpf = inputUser;
        string cpfFormatado = regex.Replace(cpf, "$1.$2.$3-$4");

        return cpfFormatado;
    }

    static string IsValidAge(string inputUser)
    {
        bool sucess = int.TryParse(inputUser, out int age);
        while (!sucess || age < 18)
        {
            Console.Write("Digite uma idade superior a 18: ");
            inputUser = Console.ReadLine();
            sucess = int.TryParse(inputUser, out age);
        }
        return $"{age} anos";
    }
    
}