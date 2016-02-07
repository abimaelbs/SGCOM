using SGCOM.Models.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SGCOM.Data.Mappings
{
    public class ParametroMap : EntityTypeConfiguration<Parametro>
    {
        public ParametroMap()
        {
            ToTable("Parametro");

            HasKey(x => x.Id);

            Property(x => x.Nome).HasMaxLength(20).IsRequired();

            Property(x => x.Valor).HasMaxLength(10).IsRequired();

            Property(x => x.Descricao).HasMaxLength(80).IsRequired();

            Property(x => x.DataCadastro).IsRequired();
        }
    }
}
