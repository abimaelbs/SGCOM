using SGCOM.Models;
using System.Data.Entity.ModelConfiguration;

namespace SGCOM.Data.Mappings
{
    public class GrupoMap : EntityTypeConfiguration<Grupo>
    {
        public GrupoMap()
        {
            ToTable("Grupo");

            HasKey(x => x.Id);

            Property(x => x.Titulo).HasMaxLength(40).IsRequired();

            Property(x => x.DataCadastro).IsRequired();
        }
    }
}
