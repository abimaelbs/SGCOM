using System;

namespace SGCOM.Models.Entities
{
    public class Pedido
    {
        public int Id { get; set; }
     
        public int ClienteId { get; set; }

        public int UsuarioId { get; set; }

        public int CaixaId { get; set; }

        public int EmpresaId { get; set; }

        public Utilities.Enums.eTipoAtendimento TipoAtendimento { get; set; }

        public Utilities.Enums.eTipoPagamento TipoPagamento { get; set; }

        public DateTime DataCadastro { get; set; }

        public virtual Caixa Caixa { get; set; }

        public virtual Empresa Empresa { get; set; }

        public virtual Usuario Usuario { get; set; }

        public virtual Cliente Cliente { get; set; }

        public Pedido()
        {
            this.DataCadastro = DateTime.Now;
        }
    }
}
