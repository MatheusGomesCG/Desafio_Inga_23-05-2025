using System;
using System.Runtime.CompilerServices;

namespace Exercicio_02;

class Program
{
    static async Task Main(string[] args)
    {
        List<Dictionary<string, object>> list = new List<Dictionary<string, object>>();
        int id = 0;

        for (int i = 0; i < 3; i++)
        {
            Console.Clear();
            Console.WriteLine($"Cadastro do {i}º Produto");
            Console.Write("Digite o nome do produto: ");
            string nameProduct = Console.ReadLine();

            Console.Write("Digite o preço do produto: ");
            bool sucess = decimal.TryParse(Console.ReadLine(), out decimal priceProduct);
            while (!sucess || priceProduct <= 0)
            {
                Console.WriteLine("Digite um preço válido!!!!!");
                Console.Write("Digite o preço do produto: ");
                sucess = decimal.TryParse(Console.ReadLine(), out priceProduct);
            }

            Console.Write("Digite a quantidade do produto: ");
            sucess = int.TryParse(Console.ReadLine(), out int quantityProduct);
            while (!sucess || quantityProduct <= 0)
            {
                Console.WriteLine("Quantitade inválida!!!");
                Console.Write("Digite a quantidade do produto: ");
                sucess = int.TryParse(Console.ReadLine(), out quantityProduct);
            }

            Dictionary<string, object> dict = new Dictionary<string, object>();
            id++;
            dict.Add("Id", id);
            dict.Add("Nome", nameProduct);
            dict.Add("Preço", priceProduct);
            dict.Add("Quantidade", quantityProduct);

            list.Add(dict);
        }

        bool exit = false;
        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("==== MENU CONTROLE DE ESTOQUE ====");
            Console.WriteLine("[1] - COMPRAR PRODUTO");
            Console.WriteLine("[2] - REABASTECER ESTOQUE");
            Console.WriteLine("[3] - SAIR");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("==== MENU COMPRA PRODUTO ====");
                    foreach (var item in list)
                    {
                        foreach (var obj in item)
                        {
                            if (obj.Key.Equals("Id"))
                            {
                                Console.WriteLine($"Opção - [{obj.Value}]");
                            }
                            else
                            {
                                Console.WriteLine($"{obj.Key} = {obj.Value}");
                            }
                        }
                    }
                    Console.Write("Escolha uma das opções: ");
                    string inputUser = Console.ReadLine();
                    int valueIdList = IsValidInt(inputUser);
                    if (list.Exists(x => x.Values.Equals(valueIdList)))
                    {
                        var productBuy = list.Find(x => x.Values.Equals(valueIdList));
                        Console.Write("Informe a quantidade que deseja retirar: ");
                        int quantityBuy = IsValidInt(Console.ReadLine());
                        if ((int)productBuy["Quantidade"] <= quantityBuy)
                        {
                            Console.WriteLine("Compra realizada com sucesso!");
                            Console.WriteLine($"{productBuy["Quantidade"]}");
                        }
                        else
                        {
                            Console.WriteLine("Quantidade superior a capacidade de estoque");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Não existe esse produto no nosso estoque!");
                        await Task.Delay(2000);
                    }
                    break;
                case "2":
                    break;
                case "3":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Digite uma opção válida!!!!");
                    await Task.Delay(2000);
                    break;
            }


        }
        
        static int IsValidInt(string inputUser)
        {
            bool sucess = int.TryParse(inputUser, out int validNumber);
            while (!sucess || validNumber <= 0)
            {
                Console.Write("Digite um número válido acima de zero: ");
                inputUser = Console.ReadLine();
                sucess = int.TryParse(inputUser, out validNumber);
            }
            return validNumber;
        }
    }
}