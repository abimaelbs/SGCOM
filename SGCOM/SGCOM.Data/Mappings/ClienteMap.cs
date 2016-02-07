using SGCOM.Models.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SGCOM.Data.Mappings
{
    public class ClienteMap : EntityTypeConfiguration<Cliente>
    {
        public ClienteMap()
        {
            ToTable("Cliente");

            HasKey(x => x.Id);

            Property(x => x.Nome).HasMaxLength(80).IsRequired();

            Property(x => x.Rg).HasMaxLength(20);

            Property(x => x.CpfCnpj).HasMaxLength(20).IsRequired();            

            Property(x => x.DataCadastro).IsRequired();
        }
    }
}
