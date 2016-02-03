using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGCOM.Models.Entities
{
    public class Municipio
    {       
        public int Id { get; set; }
        public string Nome { get; set; }
        public int EstadoId { get; set; }
        //public virtual Estado Estado { get; set; }

        public Municipio()
        {

        }
        public override string ToString()
        {
            return this.Nome;
        }
    }
}
