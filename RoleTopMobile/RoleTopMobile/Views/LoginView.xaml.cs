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
    public partial class LoginView : ContentPage
    {
        LoginViewModel loginViewModel = new LoginViewModel();
        public LoginView()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void BtnCadastro_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CadastroView());
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            UsuarioViewModel user = new UsuarioViewModel
            {
                Email_Apelido = TxtEmail.Text,
                Senha = TxtSenha.Text
            };
            if (loginViewModel.Login(user))
            {
                App.Current.MainPage = new NavigationPage(new BuscaView());

            }
            else
            {
                await DisplayAlert("Erro!", "Email/Apelido ou senha incorretos.", "Fechar");

            }
        }
    }
}