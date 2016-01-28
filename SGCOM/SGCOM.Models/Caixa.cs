using System;

namespace SGCOM.Models
{
    public class Caixa
    {
        public Caixa()
        {
            this.DataAbertura = DateTime.Now;
        }

        public int Id { get; set; }
        public int NumeroCaixa { get; set; }
        public decimal ValorAbertura { get; set; }
        public decimal ValorFechamento { get; set; }
        public decimal ValorSangria { get; set; }
        public DateTime DataAbertura { get; set; }
        public DateTime DataFechamento { get; set; }        
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}