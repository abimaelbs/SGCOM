using System;

namespace SGCOM.Models.Entities
{
    public class Unidade
    {
        public int Id { get; set; }
        public string Valor { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; }

        public Unidade()
        {
            this.DataCadastro = DateTime.Now;
        }
        public override string ToString()
        {
            return this.Valor + "-" + this.Descricao;
        }
    }
}
