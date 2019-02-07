using System;
using System.Collections.Generic;

namespace LulasPrisonStatus.Domain
{
    public class Lula
    {
        public static Lula Condenado()
        {
            var condenacaoTriplex = new Condenacao(anos: 12, meses: 1);
            condenacaoTriplex.Descricao = "Condenado por Corrupção Passiva e Ocultação de Patrimônio";

            var condenacaoSitioAtibaia = new Condenacao(anos: 12, meses: 11);
            condenacaoSitioAtibaia.Descricao = "Condenado por Corrupção e Lavagem de Dinheiro";

            var condenacoes = new List<Condenacao> { condenacaoTriplex, condenacaoSitioAtibaia };

            var lulaLadraoRoubouMeuS2 = new Lula(condenacoes);
            lulaLadraoRoubouMeuS2.Calcular();

            return lulaLadraoRoubouMeuS2;
        }

        public Lula(List<Condenacao> condenacoes)
            : this(dataPrisao: new DateTime(year: 2018, month: 04, day: 07), condenacoes: condenacoes) { }

        public Lula(DateTime dataPrisao, List<Condenacao> condenacoes)
        {
            if (condenacoes == null)
                throw new ArgumentNullException("condenacoes");

            DataPrisao = dataPrisao;
            Condenacoes = condenacoes;
        }

        public List<Condenacao> Condenacoes { get; set; }

        public DateTime DataPrisao { get; set; }

        public DateTime DataSaida { get; set; }

        public int DiasCumpridos { get; set; }

        public int DiasTotais { get; set; }

        public double PorcentagemCumprida { get; set; }

        public void Calcular()
        {
            DateTime lulaLivre = DataPrisao;
            foreach (var condenacao in Condenacoes)
            {
                lulaLivre = lulaLivre
                    .AddYears(condenacao.Pena.Anos)
                    .AddMonths(condenacao.Pena.Meses)
                    .AddDays(condenacao.Pena.Dias);
            }

            DataSaida = lulaLivre;
            var tempoCumprido = (DateTime.Now - DataPrisao);
            var tempoTotal = (DataSaida - DataPrisao);

            DiasCumpridos = tempoCumprido.Days;
            DiasTotais = tempoTotal.Days;

            var total = tempoTotal.TotalDays;
            var parcial = tempoCumprido.TotalDays;

            PorcentagemCumprida = parcial / (total / 100);
        }
    }
}
