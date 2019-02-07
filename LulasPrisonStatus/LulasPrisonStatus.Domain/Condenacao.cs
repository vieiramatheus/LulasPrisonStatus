using System;
using System.Collections.Generic;
using System.Text;

namespace LulasPrisonStatus.Domain
{
    public class Condenacao
    {
        public Condenacao(int anos = 0, int meses = 0 , int dias = 0)
        {
            Pena = new Tempo { Anos = anos, Meses = meses, Dias = dias };
        }

        public Tempo Pena { get; set; }

        public string Descricao { get; set; }

        public string Sentenca { get; set; }
    }
}
