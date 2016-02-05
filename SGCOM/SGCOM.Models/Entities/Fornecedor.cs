using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGCOM.Models.Entities
{
    public class Fornecedor
    {
        public int Id { get; set; }
        public string RazaoSocial { get; set; }
        public DateTime DataCadastro { get; set; }

        public Fornecedor()
        {
            this.DataCadastro = DateTime.Now;
        }

        public override string ToString()
        {
            return this.RazaoSocial;
        }
    }
}
