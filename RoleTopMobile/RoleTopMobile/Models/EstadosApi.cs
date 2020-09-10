using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;


namespace RoleTopMobile.Models
{

    //public class EstadosApi
    //{
    //    [JsonProperty("id")]
    //    public int id { get; set; }

    //    [JsonProperty("sigla")]
    //    public string sigla { get; set; }

    //    [JsonProperty("nome")]
    //    public string nome { get; set; }

    //    [JsonProperty("regiao")]
    //    public ICollection<Regiao> regiao { get; set; }
    //}

    public class EstadosApi
    {
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("sigla")]
        public string sigla { get; set; }

        [JsonProperty("nome")]
        public string nome { get; set; }
        
        [JsonProperty("regiao")]
        public Regiao regiao { get; set; }

        public class Regiao
        {
            public int id { get; set; }
            public string sigla { get; set; }
            public string nome { get; set; }
        }
    }

   
}

