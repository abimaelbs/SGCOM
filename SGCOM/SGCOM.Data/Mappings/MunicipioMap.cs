using SGCOM.Models.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SGCOM.Data.Mappings
{
    public class MunicipioMap : EntityTypeConfiguration<Municipio>
    {
        public MunicipioMap()
        {
            ToTable("Municipio");

            HasKey(x => x.Id);

            Property(x => x.Nome).HasMaxLength(60).IsRequired();

            //HasRequired(x => x.EstadoId);
        }
    }
}
