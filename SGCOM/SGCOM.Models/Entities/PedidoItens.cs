namespace SGCOM.Models.Entities
{
    public class PedidoItens
    {
        public int Id { get; set; }

        public int ProdutoId { get; set; }

        public decimal Quantidade { get; set; }

        public decimal Valor { get; set; }

        public virtual Produto Produto { get; set; }

        public PedidoItens()
        {

        }
    }
}
