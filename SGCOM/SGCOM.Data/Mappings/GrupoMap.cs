using SGCOM.Models;
using SGCOM.Models.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SGCOM.Data.Mappings
{
    public class GrupoMap : EntityTypeConfiguration<Grupo>
    {
        // ctor = construtor
        public GrupoMap()
        {
            ToTable("Grupo");

            HasKey(x => x.Id);

            Property(x => x.Titulo).HasMaxLength(40).IsRequired();

            Property(x => x.DataCadastro).IsRequired();
        }
    }
}
