using SGCOM.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
