using SGCOM.Models.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SGCOM.Data.Mappings
{
    public class MenuMap : EntityTypeConfiguration<Menu>
    {
        public MenuMap()
        {
            ToTable("Menu");

            HasKey(x => x.Id);

            Property(x => x.Titulo).HasMaxLength(20).IsRequired();

            Property(x => x.Ordem);
        }
    }
}
