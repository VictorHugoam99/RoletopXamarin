using Newtonsoft.Json;
using RoleTopMobile.Models;
using RoleTopMobile.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RoleTopMobile.ViewModels
{
    public class JogoViewModel : BaseViewModel
    {
        private List<Jogo> _jogos;

        public List<Jogo> Jogos
        {
            get { return _jogos; }
            set
            {
                _jogos = value;
                OnPropertyChanged();
            }
        }

        public JogoViewModel()
        {
            Jogos = new List<Jogo>();

            getJogos();
        }

        private void getJogos()
        {
            try
          {
                HttpClient client = Utils.getClient;

                HttpResponseMessage response = client.GetAsync("Jogo").Result;

                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;

                    Jogos = JsonConvert.DeserializeObject<List<Jogo>>(json);
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
