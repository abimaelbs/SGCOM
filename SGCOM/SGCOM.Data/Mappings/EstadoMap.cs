using SGCOM.Models.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SGCOM.Data.Mappings
{
    public class EstadoMap : EntityTypeConfiguration<Estado>
    {
        public EstadoMap()
        {
            ToTable("Estado");

            HasKey(x => x.Id);

            Property(x => x.Nome).HasMaxLength(60).IsRequired();
        }
    }
}
