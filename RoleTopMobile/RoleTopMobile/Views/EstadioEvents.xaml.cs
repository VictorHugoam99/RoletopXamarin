using RoleTopMobile.Models;
using RoleTopMobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Xaml;

namespace RoleTopMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EstadioEvents : ContentPage
    {
        EstadioViewModel vm = new EstadioViewModel();
        public EstadioEvents()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            this.BindingContext = vm;
         
        }

        void OnClick(object sender, EventArgs e)
        {
            Navigation.PopAsync();
            App.Current.MainPage = new NavigationPage(new EventsDetail());

            //var obj = listviewEstadio.SelectedItem;


            //Console.WriteLine(obj);

            //foreach (var item in vm.Estadios)
            //{
            //    if (item.id == obj)
            //    {
            //        var estadioFuncionando = item;
            //        Console.WriteLine("==========================");
            //        Console.WriteLine("==========================");

            //        Console.WriteLine("==========================");

            //        Console.WriteLine("==========================");
            //        Console.WriteLine("==========================");
            //        Console.WriteLine("==========================");





            //        Console.WriteLine(estadioFuncionando);

            //       Console.WriteLine("==========================");
            //        Console.WriteLine("==========================");

            //        Console.WriteLine("==========================");

            //        Console.WriteLine("==========================");
            //        Console.WriteLine("==========================");
            //        Console.WriteLine("==========================");


            //    }
            //}
            //var estadio = vm.Estadios.FirstOrDefault(es => es.id == obj);


            //Console.WriteLine(estadio);


            //Navigation.PushAsync(new EventsDetail(estadio));
        }

        void OnClickBack(object sender, EventArgs e)
        {
            Navigation.RemovePage(this);
            App.Current.MainPage = new NavigationPage(new BuscaView());
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