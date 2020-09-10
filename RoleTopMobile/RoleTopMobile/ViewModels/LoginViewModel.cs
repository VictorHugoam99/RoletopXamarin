using Newtonsoft.Json;
using RoleTopMobile.Models;
using RoleTopMobile.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace RoleTopMobile.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public bool Login(UsuarioViewModel user)
        {
            try
            {
                HttpClient client = Utils.getClient;
            
                string objectSerialized = JsonConvert.SerializeObject(user);

                StringContent content = new StringContent(objectSerialized, Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PostAsync("Login", content).Result;

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    string json = response.Content.ReadAsStringAsync().Result;

                    Token token = JsonConvert.DeserializeObject<Token>(json);
                    MessagingCenter.Send<string>("", "SucessoLogin");
                    return true;
                }
                else if (response.StatusCode == HttpStatusCode.NoContent)
                {
                    MessagingCenter.Send<String>("Usuário não encontrado", "ErroLogin");
                    return false;
                }
                else
                {
                    MessagingCenter.Send<String>($"Erro no servidor: StatusCode = {response.StatusCode.ToString()}", "ErroLogin");
                    return false;
                }
            }
            catch (Exception)
            {
                MessagingCenter.Send<String>("Erro", "ErroLogin");
                return false;
            }
        }

        private class Token
        {
            public string token { get; set; }
        }
    }
}
