using SGCOM.Models.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SGCOM.Data.Mappings
{
    public class UnidadeMap : EntityTypeConfiguration<Unidade>
    {
        public UnidadeMap()
        {
            ToTable("Unidade");

            HasKey(x => x.Id);

            Property(x => x.Descricao).HasMaxLength(40).IsRequired();

            Property(x => x.Valor).HasMaxLength(3);

            Property(x => x.DataCadastro).IsRequired();
        }
    }
}
