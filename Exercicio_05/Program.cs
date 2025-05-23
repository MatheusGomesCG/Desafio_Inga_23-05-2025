using System;
using Exercicio_05.Models;

namespace Exercicio_05;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.Write("Nome do produto: ");
        string nameProduct = Console.ReadLine();

        Console.Write("Preço: ");
        double priceProduct = IsValidDouble(Console.ReadLine());

        Console.Write("Desconto (%): ");
        double descountProduct = IsValidDouble(Console.ReadLine());

        Produto p = new Produto(nameProduct, priceProduct, descountProduct);
        Console.WriteLine();
        Console.WriteLine(p.ExibirInformacoes());
    }

    static double IsValidDouble(string inputUser)
    {
        bool sucess = double.TryParse(inputUser, out double number);
        while (!sucess || number < 0)
        {
            Console.Write("Digite um valor válido: ");
            sucess = double.TryParse(Console.ReadLine(), out number);
        }

        return number;
    }
}