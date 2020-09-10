using Newtonsoft.Json;
using RoleTopMobile.Models;
using RoleTopMobile.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace RoleTopMobile.ViewModels
{
    public class ShowViewModel : BaseViewModel
    {
        private List<Show> _shows;

        public List<Show> Shows
        {
            get { return _shows; }
            set
            {
                _shows = value;
                OnPropertyChanged();
            }
        }

        public ShowViewModel()
        {
            Shows = new List<Show>();

            getShows();
        }

        private void getShows()
        {
            try
            {
                HttpClient client = Utils.getClient;

                HttpResponseMessage response = client.GetAsync("Show").Result;

                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;

                    Shows = JsonConvert.DeserializeObject<List<Show>>(json);
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
