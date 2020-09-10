using RoleTopMobile.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RoleTopMobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new Splash();
            MainPage = new NavigationPage(new JogoDetail());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
