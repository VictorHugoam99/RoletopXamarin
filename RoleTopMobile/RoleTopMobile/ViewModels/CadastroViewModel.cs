using Newtonsoft.Json;
using RoleTopMobile.Models;
using RoleTopMobile.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;

namespace RoleTopMobile.ViewModels
{
    public class CadastroViewModel : BaseViewModel
    {
        public void Cadastrar(Usuarios usuario)
        {
            try
            {
                HttpClient client = Utils.getClient;

                string objectSerialized = JsonConvert.SerializeObject(usuario);

                StringContent content = new StringContent(objectSerialized, Encoding.UTF8, "application/json");

                HttpResponseMessage response = client.PostAsync("Usuario", content).Result;

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    MessagingCenter.Send<string>("", "SucessoLogin");
                }
                else if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    MessagingCenter.Send<String>("Usuário não pode ser cadastrado", "ErroLogin");
                }
                else
                {
                    MessagingCenter.Send<String>($"Erro no servidor: StatusCode = {response.StatusCode.ToString()}", "ErroLogin");
                }
            }
            catch (Exception)
            {
                MessagingCenter.Send<String>("Erro", "ErroLogin");
            }
        }
    }
}

