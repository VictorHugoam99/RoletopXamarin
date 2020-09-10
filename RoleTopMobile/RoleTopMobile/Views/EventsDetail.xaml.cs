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
    public partial class EventsDetail : ContentPage
    {
        //private Estadio estadio;





        public EventsDetail()
        {
            InitializeComponent();

            NavigationPage.SetHasNavigationBar(this, false);

        }

        public EventsDetail(Estadio estadio)
        {
            //this.estadio = estadio;

            InitializeComponent();

            EstadioViewModel vm = new EstadioViewModel(estadio.id);

            this.BindingContext = vm;

            NavigationPage.SetHasNavigationBar(this, false);
        }

        void OnClick(object sender, EventArgs e)
        {
            Navigation.PushAsync(new JogoDetail());
        }

        void OnClickBack(object sender, EventArgs e)
        {
            Navigation.PopAsync();
            App.Current.MainPage = new NavigationPage(new EstadioEvents());
        }

        void OnClickExplore(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new BuscaView());
        }

        void OnClickMaps(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new EstadioEvents());
        }

        void OnClickArrow(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new MenuView());
        }
    }
}