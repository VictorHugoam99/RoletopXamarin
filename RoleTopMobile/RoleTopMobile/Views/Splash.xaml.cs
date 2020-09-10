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
    public partial class Splash : ContentPage
    {
        public Splash()
        {
            InitializeComponent();

            Navigation();
        }

        private async void Navigation()
        {
            await Task.Delay(2500);
            App.Current.MainPage = new NavigationPage(new LoginView());
        }
    }
}