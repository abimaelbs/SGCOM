using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGCOM.Models.Entities
{
    public class Acesso
    {
        public Acesso()
        {
            this.DataCadastro = DateTime.Now;
        }

        public int Id { get; set; }
        public string Tela { get; set; }
        public string Link { get; set; }
        public DateTime DataCadastro { get; set; }

        public virtual Grupo Grupo { get; set; }
    }
}
