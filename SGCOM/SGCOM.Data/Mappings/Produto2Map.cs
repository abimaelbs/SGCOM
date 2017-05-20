using System.Data.Entity.ModelConfiguration;
using SGCOM.Models.Entities;

namespace SGCOM.Data.Mappings
{
    public class Produto2Map : EntityTypeConfiguration<Produto2>
    {
        public Produto2Map()
        {
            ToTable("Produto2");

            HasKey(x => x.Id);

            Property(x => x.Nome).HasMaxLength(60).IsRequired();

            Property(x => x.Preco);            

            Property(x => x.DataCadastro).IsRequired();
            
            HasRequired(x => x.Categoria);            
        }
    }
}
