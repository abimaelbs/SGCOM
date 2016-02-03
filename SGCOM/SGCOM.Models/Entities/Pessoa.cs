using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGCOM.Models.Entities
{
    public class Pessoa
    {       
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Sexo { get; set; }
        public long Cpf { get; set; }
        public string Rg { get; set; }
        public string TituloEleitor { get; set; }
        public int Estadocivil { get; set; }
        public int TipoPessoa { get; set; }
        public string NomePai { get; set; }
        public string NomeMae { get; set; }
        public string NomeConjuge { get; set; }
        public int QuantidadeFilhos { get; set; }        
        public DateTime DataNascimento { get; set; }        
        public DateTime DataCadastro { get; set; }

        public Pessoa()
        {
            this.DataCadastro = DateTime.Now;
        }
        public override string ToString()
        {
            return this.Nome;
        }
    }
}
