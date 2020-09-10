using System;
using System.Collections.Generic;

namespace Api_RoleTop.Domains
{
    public partial class Evento
    {
        public Evento()
        {
            Estadio = new HashSet<Estadio>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public int? Jogo { get; set; }
        public int? Show { get; set; }

        public virtual Jogo JogoNavigation { get; set; }
        public virtual Show ShowNavigation { get; set; }
        public virtual ICollection<Estadio> Estadio { get; set; }
    }
}
