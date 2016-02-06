using System;

namespace SGCOM.Models.Entities
{
    public class Empresa
    {
        public int Id { get; set; }
        public string CpfCnpj { get; set; }
        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }
        public string InscMunicipal { get; set; }
        public string InscEstadual { get; set; }
        public string Loja { get; set; }
        public string Mensagem { get; set; }
        public DateTime DataCadastro { get; set; }

        public Empresa()
        {
            this.DataCadastro = DateTime.Now;
        }
        public override string ToString()
        {
            return this.NomeFantasia;
        }
    }
}
