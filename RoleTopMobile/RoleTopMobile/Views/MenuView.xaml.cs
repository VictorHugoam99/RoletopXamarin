using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RoleTopMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuView : ContentPage
    {
        public MenuView()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

        }

        void OnClickBack(object sender, EventArgs e)
        {
            Navigation.RemovePage(this);
            App.Current.MainPage = new NavigationPage(new EstadioEvents());
        }

        private void BtnInicio_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new EstadioEvents());
        }

        private void BtnBusca_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new BuscaView());
        }

        private void BtnConfig_Clicked(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new ConfiguracaoView());
        }


    }
}