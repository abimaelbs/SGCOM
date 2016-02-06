using SGCOM.Utilities;
using System;

namespace SGCOM.Models.Entities
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Rg { get; set; }
        public string CpfCnpj { get; set; }
        public Enums.eSexo Sexo { get; set; }
        public Enums.eStatus Status { get; set; }
        public DateTime DataCadastro { get; set; }

        public Cliente()
        {
            this.DataCadastro = DateTime.Now;
        }
    }
}
