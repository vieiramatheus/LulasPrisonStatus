using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace xApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BtnLulaLivre.Clicked += BtnLulaLivre_Clicked;
        }

        private void BtnLulaLivre_Clicked(object sender, EventArgs e)
        {
            var lula = LulasPrisonStatus.Domain.Lula.Condenado();
            
            LblStatus.Text = $"Lula cumpriu {lula.PorcentagemCumprida}% da sua pena";

            ProgressoPena.ProgressTo(lula.PorcentagemCumprida / 100, 250, Easing.Linear);            
        }
    }
}
