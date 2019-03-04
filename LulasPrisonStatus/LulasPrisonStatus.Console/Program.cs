using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LulasPrisonStatus.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var tokenE = "▒";
            var tokenF = "█";

            var lula = Domain.Lula.Condenado();
            
            string porcentagemS = "";
            for (int i = 0; i < 100; i++)
            {
                if (i <= lula.PorcentagemCumprida)
                    porcentagemS += tokenF;
                else
                    porcentagemS += tokenE;
            }

            Console.WriteLine("Lula foi preso dia: {0:dd/MM/yyyy}", lula.DataPrisao);
            Console.WriteLine("Lula será solto dia: {0:dd/MM/yyyy}", lula.DataSaida);

            Console.WriteLine("Isso corresponde a um total de {0:N0} dias preso", lula.DiasTotais);
            Console.WriteLine("Lula cumpriu o total de {0:N0} dias da sua pena", lula.DiasCumpridos);

            Console.WriteLine("Lula cumpriu {0}% da sua pena", lula.PorcentagemCumprida);
            Console.Write(porcentagemS);
            Console.Read();
        }
    }
}
