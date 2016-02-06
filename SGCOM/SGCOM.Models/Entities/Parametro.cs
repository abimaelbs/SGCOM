using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGCOM.Models.Entities
{
    public class Parametro
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Valor { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; }

        public Parametro()
        {
            this.DataCadastro = DateTime.Now;
        }
        public override string ToString()
        {
            return this.Nome;
        }
    }
}
