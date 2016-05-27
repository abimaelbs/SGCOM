using SGCOM.Models.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SGCOM.Data.Mappings
{
    public class GrauParentescoMap : EntityTypeConfiguration<GrauParentesco>
    {
        public GrauParentescoMap()
        {
            ToTable("GrauParentesco");

            HasKey(x => x.Id);

            Property(x => x.DescricaoParentesco).HasMaxLength(40).IsRequired();
        }
    }
}
