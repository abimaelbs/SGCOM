using SGCOM.Models;
using System.Data.Entity.ModelConfiguration;

namespace SGCOM.Data.Mappings
{
    public class CaixaMap : EntityTypeConfiguration<Caixa>
    {
        public CaixaMap()
        {
            ToTable("Caixa");

            HasKey(x => x.Id);

            Property(x => x.NumeroCaixa).IsRequired();

            Property(x => x.UsuarioId).IsRequired();

            Property(x =>x.ValorAbertura).IsRequired();

            Property(x => x.ValorFechamento);

            Property(x => x.ValorSangria);

            Property(x => x.DataAbertura).IsRequired();

            Property(x => x.DataFechamento);

            HasRequired(x => x.Usuario);  
        }
    }
}
