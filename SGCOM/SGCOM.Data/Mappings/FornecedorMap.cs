using SGCOM.Models.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SGCOM.Data.Mappings
{
    public class FornecedorMap : EntityTypeConfiguration<Fornecedor>
    {
        public FornecedorMap()
        {
            ToTable("Fornecedor");

            HasKey(x => x.Id);

            Property(x => x.RazaoSocial).HasMaxLength(80).IsRequired();

            Property(x => x.DataCadastro).IsRequired();
        }
    }
}
