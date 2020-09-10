using RoleTopMobile.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace RoleTopMobile.Models
{
    public partial class Selecao
    {
        public Selecao()
        {
            JogoSelecaoCasaNavigation = new HashSet<Jogo>();
            JogoSelecaoVisitanteNavigation = new HashSet<Jogo>();
        }

        public ImageSource imgSourceSelecao
        {
            get
            {
                try
                {
                    return Utils.getImageSourceFromByteArray(Foto);
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public byte[] Foto { get; set; }

        public virtual ICollection<Jogo> JogoSelecaoCasaNavigation { get; set; }
        public virtual ICollection<Jogo> JogoSelecaoVisitanteNavigation { get; set; }
    }
}
