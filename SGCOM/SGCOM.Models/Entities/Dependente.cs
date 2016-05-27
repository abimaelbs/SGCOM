using SGCOM.Utilities;
using System;

namespace SGCOM.Models.Entities
{
    public class Dependente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }
        public Enums.eSexo Sexo { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataCadastro { get; set; }
        public virtual Pessoa Pessoa { get; set; }
        public Dependente()
        {
            this.DataCadastro = DateTime.Now;
        }
        public override string ToString()
        {
            return this.Nome;
        }
    }
}
