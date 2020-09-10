using System;
using System.Collections.Generic;

namespace Api_RoleTop.Domains
{
    public partial class Estadio
    {
        public int Id { get; set; }
        public int Evento { get; set; }
        public string Nome { get; set; }
        public byte[] Foto { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string Cidade { get; set; }
        public string Uf { get; set; }

        public virtual Evento EventoNavigation { get; set; }
    }
}
