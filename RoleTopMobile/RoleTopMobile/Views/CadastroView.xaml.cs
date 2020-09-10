using RoleTopMobile.Models;
using RoleTopMobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RoleTopMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CadastroView : ContentPage
    {
        CadastroViewModel cadastroViewModel = new CadastroViewModel();
        public CadastroView()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
      
        private async void BtnCadastro_Clicked(object sender, EventArgs e)
        {
            if (verifyInputs())
            {
                Usuarios user = new Usuarios
                {
                    Nome = TxtNome.Text,
                    Email = TxtEmail.Text,
                    Senha = TxtSenha.Text,
                    Apelido = TxtApelido.Text
                };

                 cadastroViewModel.Cadastrar(user);

                await DisplayAlert("Sucesso!", "Cadastro efetuado com sucesso", "Fazer login");
                Navigation.RemovePage(this);
                App.Current.MainPage = new NavigationPage(new LoginView());

                //if (ValidEmail())
                //{
                //    
                //}
                //else
                //{
                //    await DisplayAlert("Erro!", "Email inválido", "Fechar");
                //}

            }
            else
            {
                await DisplayAlert("Erro!", "Preencha todos os campos", "Fechar");
            }

        }

        void BtnBack_Clicked(object sender, EventArgs e)
        {
            Navigation.RemovePage(this);
            App.Current.MainPage = new NavigationPage(new LoginView());
        }

        private bool verifyInputs()
        {
            if (!string.IsNullOrEmpty(TxtNome.Text) && TxtNome.Text.Trim().Length >= 3 &&
                !string.IsNullOrEmpty(TxtEmail.Text) && TxtEmail.Text.Trim().Length >= 3 &&
                !string.IsNullOrEmpty(TxtSenha.Text) && TxtSenha.Text.Trim().Length >= 3 &&
                !string.IsNullOrEmpty(TxtConfSenha.Text) && TxtConfSenha.Text.Trim().Length >= 3 &&
                !string.IsNullOrEmpty(TxtApelido.Text) && TxtApelido.Text.Trim().Length >= 3
                )
            {
                return true;
            }

            return false;

        }

        //private bool ValidEmail()
        //{
        //    string pattern = "/^[a - zA - Z0 - 9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$/";
               

        //    if (TxtEmail.Text.StartsWith("A/Z-a/z") && TxtEmail.Text.Contains("@") && TxtEmail.Text.EndsWith(".com") || !Regex.IsMatch(TxtEmail.Text, pattern))
        //    {
        //        return true;
        //    }
        //    return Convert.ToBoolean(EmailBackgroundColor);
        //}

        //private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    BtnCadastro.IsEnabled = verifyInputs() && ValidEmail();
        //}

        //public Color emailBackgroundColor = Color.Red;

        //public Color EmailBackgroundColor
        //{
        //    get
        //    {
        //        return emailBackgroundColor;
        //    }

        //    set
        //    {
        //        emailBackgroundColor = value;
        //    }
        //}

    }
}