using SGCOM.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGCOM.Data.Mappings
{
    public class AcessoMap : EntityTypeConfiguration<Acesso>
    {
        public AcessoMap()
        {
            ToTable("Acesso");

            HasKey(x => x.Id);

            HasRequired(x => x.Grupo);
        }
    }
}
