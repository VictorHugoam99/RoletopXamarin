using System;
using System.Collections.Generic;

namespace Api_RoleTop.Domains
{
    public partial class Selecao
    {
        public Selecao()
        {
            JogoSelecaoCasaNavigation = new HashSet<Jogo>();
            JogoSelecaoVisitanteNavigation = new HashSet<Jogo>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public byte[] Foto { get; set; }

        public virtual ICollection<Jogo> JogoSelecaoCasaNavigation { get; set; }
        public virtual ICollection<Jogo> JogoSelecaoVisitanteNavigation { get; set; }
    }
}
