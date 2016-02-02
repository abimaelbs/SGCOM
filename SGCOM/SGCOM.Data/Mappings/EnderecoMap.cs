using SGCOM.Models.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SGCOM.Data.Mappings
{
    public class EnderecoMap : EntityTypeConfiguration<Endereco>
    {
        public EnderecoMap()
        {
            ToTable("Endereco");

            HasKey(x => x.Id);

            HasRequired(x => x.Estado);

            HasRequired(x => x.Municipio);
        }
    }
}
