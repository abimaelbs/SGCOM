using SGCOM.Models.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SGCOM.Data.Mappings
{
    public class PedidoItensMap : EntityTypeConfiguration<PedidoItens>
    {
        public PedidoItensMap()
        {
            ToTable("PedidoItens");

            HasKey(x => x.Id);

            Property(x => x.Quantidade);

            Property(x => x.Valor);

            HasRequired(x => x.Produto);
        }
    }
}
