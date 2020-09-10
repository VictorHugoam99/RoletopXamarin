using Newtonsoft.Json;
using RoleTopMobile.Models;
using RoleTopMobile.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace RoleTopMobile.ViewModels
{
    public class EventoViewModel : BaseViewModel
    {
        private List<Evento> _eventos;

        public List<Evento> Eventos
        {
            get { return _eventos; }
            set
            {
                _eventos = value;
                OnPropertyChanged();
            }
        }

        public EventoViewModel()
        {
            Eventos = new List<Evento>();

            getEventos();
        }

        private void getEventos()
        {
            try
            {
                HttpClient client = Utils.getClient;

                HttpResponseMessage response = client.GetAsync("Evento").Result;

                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;

                    Eventos = JsonConvert.DeserializeObject<List<Evento>>(json);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("======================================================================");
                Console.WriteLine("======================================================================");
                Console.WriteLine("======================================================================");
                Console.WriteLine(ex.Message);
                Console.WriteLine("======================================================================");
                Console.WriteLine("======================================================================");
            }
        }
    }
}
