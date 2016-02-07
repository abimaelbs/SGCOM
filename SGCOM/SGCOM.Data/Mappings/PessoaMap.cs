using SGCOM.Models.Entities;
using System.Data.Entity.ModelConfiguration;

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
