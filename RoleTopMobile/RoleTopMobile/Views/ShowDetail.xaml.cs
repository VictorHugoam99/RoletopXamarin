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
    public partial class ShowDetail : ContentPage
    {
        public ShowDetail()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        void OnClickBack(object sender, EventArgs e)
        {
            Navigation.RemovePage(this);
            App.Current.MainPage = new NavigationPage(new EventsDetail());
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