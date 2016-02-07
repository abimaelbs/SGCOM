using SGCOM.Models.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SGCOM.Data.Mappings
{
    public class ProdutoMap : EntityTypeConfiguration<Produto>
    {
        public ProdutoMap()
        {
            ToTable("Produto");

            HasKey(x => x.Id);

            Property(x => x.Descricao).HasMaxLength(60).IsRequired();

            Property(x => x.Valor);

            Property(x => x.CodigoBarra).HasMaxLength(20).IsRequired();

            Property(x=>x.Imagem);

            Property(x => x.DataCadastro).IsRequired();

            HasRequired(x => x.Unidade);

            HasRequired(x => x.Categoria);

            HasRequired(x => x.Usuario);

            HasRequired(x => x.Fornecedor);
        }
    }
}
