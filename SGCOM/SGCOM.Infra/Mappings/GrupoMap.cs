using SGCOM.Domain;
using System.Data.Entity.ModelConfiguration;

namespace SGCOM.Infra.Mappings
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
