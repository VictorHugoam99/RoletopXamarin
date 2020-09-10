using RoleTopMobile.Models;
using RoleTopMobile.ViewModels;
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
    public partial class BuscaView : ContentPage
    {
        EstadosViewModel vm = new EstadosViewModel();

        List<string> est = new List<string>();

        public BuscaView()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            foreach (var item in vm.Estados)
            {
                est.Add(item.nome);                 
            }

            est.Sort();

            pck.ItemsSource = est;
        }


        private async void BtnBuscar_Clicked(object sender, EventArgs e)
        {
            Picker pck = sender as Picker;

            if (pck != null)
            {
                App.Current.MainPage = new NavigationPage(new EstadioEvents());
            }
            else
            {
                await DisplayAlert("Erro!", "Preencha um estado", "Fechar");

            }
        }

        private void pck_SelectedIndexChanged(object sender, EventArgs e)
        {

            var itemSelecionado = pck.Items[pck.SelectedIndex];        
            App.Current.MainPage = new NavigationPage(new EstadioEvents());

        }
    }
}