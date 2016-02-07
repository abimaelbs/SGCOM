using SGCOM.Models.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SGCOM.Data.Mappings
{
    public class PedidoMap : EntityTypeConfiguration<Pedido>
    {
        public PedidoMap()
        {
            ToTable("Pedido");

            HasKey(x => x.Id);

            Property(x => x.UsuarioId).IsOptional();

            Property(x => x.DataCadastro).IsRequired();

            HasRequired(x => x.Empresa);

            HasRequired(x => x.Caixa);

            HasRequired(x => x.Cliente);

            //HasRequired(x => x.Usuario);            
        }
    }
}
