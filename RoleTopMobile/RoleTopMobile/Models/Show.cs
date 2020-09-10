using System;
using System.Collections.Generic;
using System.Text;

namespace RoleTopMobile.Models
{
    public partial class Show
    {
        public Show()
        {
            Evento = new HashSet<Evento>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
        public int NumeroPessoas { get; set; }

        public virtual ICollection<Evento> Evento { get; set; }
    }
}
