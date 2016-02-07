using System;

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
