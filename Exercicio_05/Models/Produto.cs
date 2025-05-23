using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercicio_05.Models
{
    public class Produto
    {
        public string Nome { get; set; }
        public double Preco { get; set; }
        public double DescontoPercentual { get; set; }

        public Produto(string nome, double preco, double descontoPercentual)
        {
            Nome = nome;
            Preco = preco;
            DescontoPercentual = descontoPercentual;
        }

        private double PrecoComDesconto()
        {
            return Preco * ((100.00 - DescontoPercentual) / 100.00);
        }

        public string ExibirInformacoes()
        {
            return $"Nome do produto: {Nome}\n" +
                   $"Preço original: {Preco:C}\n" +
                   $"Desconto: {DescontoPercentual}%\n" +
                   $"Preço com desconto: {PrecoComDesconto():C}";
        }
    }
}