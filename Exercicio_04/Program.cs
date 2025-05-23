using System;
using Exercicio_04.Models;

namespace Exercicio_04;

class Program
{
    static void Main(string[] args)
    {
        string inputUser;
        Aluno aluno = new Aluno();

        Console.WriteLine("Nome do aluno: ");
        string name = Console.ReadLine();
        aluno.Nome = name;

        Console.Write("Nota 1: ");
        inputUser = Console.ReadLine();
        decimal nota1 = IsValidDecimal(inputUser);
        aluno.Nota1 = nota1;

        Console.Write("Nota 2: ");
        inputUser = Console.ReadLine();
        decimal nota2 = IsValidDecimal(inputUser);
        aluno.Nota2 = nota2;

        Console.Write("Nota 3: ");
        inputUser = Console.ReadLine();
        decimal nota3 = IsValidDecimal(inputUser);
        aluno.Nota3 = nota3;

        Console.WriteLine($"Média: {aluno.CalcularMedia().ToString("F2")}");
        string result = aluno.EstaProvado() ? "Aprovado" : "Reprovado";
        Console.WriteLine($"Situação: {result}");

    }

    static decimal IsValidDecimal(string inputUser)
    {
        bool sucess = decimal.TryParse(inputUser, out decimal number);
        while (!sucess || number < 0 || number > 10)
        {
            Console.WriteLine("Dados inválidos!!!");
            Console.Write("Por favor digite uma nova nota: ");
            inputUser = Console.ReadLine();
            sucess = decimal.TryParse(inputUser, out number);
        }

        return number;
    }
}