using SGCOM.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGCOM.Data.Mappings
{
    public class PessoaMap : EntityTypeConfiguration<Pessoa>
    {
        public PessoaMap()
        {
            HasKey(x => x.Id);

            Property(x => x.Nome).HasMaxLength(60).IsRequired();
        }
    }
}
