using RoleTopMobile.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace RoleTopMobile.ViewModels
{
    public class EstadosViewModel : BaseViewModel
    {
        private List<EstadosApi> _estados;

        private static HttpClient client;


        public List<EstadosApi> Estados
        {
            get { return _estados; }
            set
            {
                _estados = value;
                OnPropertyChanged();
            }
        }

        public EstadosViewModel()
        {
            Estados = new List<EstadosApi>();

            getEstados();
        }

        private void getEstados()
        {
            try
            {

                HttpClient client = pegarCliente();
             
                HttpResponseMessage response = client.GetAsync("localidades/estados").Result;

                //await Task.Delay(10000);

                if (response.IsSuccessStatusCode)
                {
                    string json = response.Content.ReadAsStringAsync().Result;

                    Estados = JsonConvert.DeserializeObject<List<EstadosApi>>(json);

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

        private HttpClient pegarCliente()
        {

            if (client == null)
            {
                client = new HttpClient();
                client.BaseAddress = new Uri("https://servicodados.ibge.gov.br/api/v1/");
            }

            return client;
        }
    }
}
