using System;
using System.ComponentModel;
using System.Globalization;

namespace Exercicio_03;

class Program
{
    static List<Dictionary<string, DateTime>> list = new List<Dictionary<string, DateTime>>();
    static async Task Main(string[] args)
    {
        bool exit = false;

        while (!exit)
        {
            Console.Clear();
            Console.WriteLine("==== MENU CADASTRO DE EVENTOS ====");
            Console.WriteLine("[1] - CADASTRAR EVENTO");
            Console.WriteLine("[2] - LISTAR EVENTOS");
            Console.WriteLine("[3] - SAIR DO EVENTO");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("==== MENU CADASTRO EVENTO ====");
                    Console.Write("Nome: ");
                    string nameEvent = Console.ReadLine();

                    Console.Write("Data e hora (dd/MM/yyyy) HH:mm ");
                    DateTime dateEvent = IsValidDate(Console.ReadLine());

                    Console.WriteLine("Evento cadastrado com sucesso!");

                    Dictionary<string, DateTime> dict = new Dictionary<string, DateTime>();
                    dict.Add(nameEvent, dateEvent);
                    list.Add(dict);

                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine("==== MENU DE EVENTOS CADASTRADOS ====");
                    int count = 1;
                    foreach (var item in list)
                    {
                        foreach (var obj in item)
                        {
                            Console.WriteLine($"Evento {count}");
                            count++;
                            Console.WriteLine($"O evento: {obj.Key} acontecerá as {obj.Value}");
                            Console.WriteLine();
                        }
                    }
                    Console.WriteLine("Digite qualquer tecla para voltar ao Menu:");
                    Console.ReadLine();
                    break;
                case "3":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Digite uma opção válida");
                    await Task.Delay(2000);
                    break;
            }
        }

        Console.Clear();
        Console.WriteLine("Obrigado por usar o programa!");
    }

    static DateTime IsValidDate(string inputUser)
    {
        bool sucess = DateTime.TryParseExact(inputUser, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dateConvert);
        bool existDateEvent = list.Any(x => x.Values.First() == dateConvert);
        Console.WriteLine(existDateEvent);
        while (!sucess || existDateEvent || dateConvert < DateTime.Now)                                                                                                                                                                                                                                                                                                        
        {
            Console.Write("A data digitada é inválida, por favor digite outra data: ");
            inputUser = Console.ReadLine();
            sucess = DateTime.TryParseExact(inputUser, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateConvert);
            existDateEvent = list.Exists(x => x.Values.Equals(dateConvert));
        }

        return dateConvert;
    }
}