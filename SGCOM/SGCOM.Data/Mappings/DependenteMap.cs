using SGCOM.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGCOM.Data.Mappings
{
    public class DependenteMap : EntityTypeConfiguration<Dependente>
    {
        public DependenteMap()
        {
            ToTable("Dependente");

            HasKey(x => x.Id);

            Property(x => x.Nome).IsRequired();

            Property(x => x.DataNascimento).IsRequired();

            Property(x => x.CPF).IsOptional();

            Property(x => x.RG).IsOptional();

            HasRequired(x => x.Pessoa);
        }
    }
}
