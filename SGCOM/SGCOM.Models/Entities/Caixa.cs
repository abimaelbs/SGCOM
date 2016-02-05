using System;

namespace SGCOM.Models.Entities
{
    public class Caixa
    {       
        public int Id { get; set; }
        public int NumeroCaixa { get; set; }
        public decimal ValorAbertura { get; set; }
        public Nullable<decimal> ValorFechamento { get; set; }
        public Nullable<decimal> ValorSangria { get; set; }
        public DateTime DataAbertura { get; set; }
        public Nullable<DateTime> DataFechamento { get; set; }        
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }

        public Caixa()
        {
            this.DataAbertura = DateTime.Now;
        }
    }
}