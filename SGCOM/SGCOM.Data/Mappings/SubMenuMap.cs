using SGCOM.Models.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SGCOM.Data.Mappings
{
    public class SubMenuMap : EntityTypeConfiguration<SubMenu>
    {
        public SubMenuMap()
        {
            ToTable("SubMenu");

            HasKey(x => x.Id);

            Property(x => x.Titulo).HasMaxLength(20).IsRequired();

            Property(x => x.Link).HasMaxLength(80);

            Property(x => x.Ordem);

            HasRequired(x => x.Menu);
        }
    }
}
