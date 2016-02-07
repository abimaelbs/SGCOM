using SGCOM.Models.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SGCOM.Data.Mappings
{
    public class CategoriaMap : EntityTypeConfiguration<Categoria>
    {
        public CategoriaMap()
        {
            ToTable("Categoria");

            HasKey(x => x.Id);

            Property(x => x.Nome).HasMaxLength(20).IsRequired();

            Property(x => x.Imagem);

            Property(x => x.DataCadastro).IsRequired();
        }
    }
}
