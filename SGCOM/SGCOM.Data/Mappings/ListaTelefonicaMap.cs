using SGCOM.Models.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SGCOM.Data.Mappings
{
    public class ListaTelefonicaMap : EntityTypeConfiguration<ListaTelefonica>
    {
        public ListaTelefonicaMap()
        {
            ToTable("ListaTelefonica");

            HasKey(x => x.Id);

            Property(x => x.Nome).HasMaxLength(60).IsRequired();

            Property(x => x.Telefone).HasMaxLength(12).IsRequired();

            Property(x => x.Cor).HasMaxLength(10).IsOptional();

            Property(x => x.Data).IsRequired();
        }
    }
}
