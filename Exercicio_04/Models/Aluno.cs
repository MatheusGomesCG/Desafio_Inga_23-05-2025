using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Exercicio_04.Models
{
    public class Aluno
    {
        public string Nome { get; set; }
        public decimal Nota1 { get; set; }
        public decimal Nota2 { get; set; }
        public decimal Nota3 { get; set; }

        public decimal CalcularMedia()
        {
            return (Nota1 + Nota2 + Nota3) / 3;
        }

        public bool EstaProvado()
        {
            if (CalcularMedia() >= 7)
            {
                return true;
            }

            return false;
        }
    }
}