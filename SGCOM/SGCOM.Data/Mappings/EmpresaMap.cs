using SGCOM.Models.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SGCOM.Data.Mappings
{
    public class EmpresaMap : EntityTypeConfiguration<Empresa>
    {
        public EmpresaMap()
        {
            ToTable("Empresa");

            HasKey(x => x.Id);

            Property(x => x.CpfCnpj).HasMaxLength(20).IsRequired();

            Property(x => x.NomeFantasia).HasMaxLength(60).IsRequired();

            Property(x => x.RazaoSocial).HasMaxLength(60).IsRequired();

            Property(x => x.InscEstadual).HasMaxLength(20).IsRequired();

            Property(x => x.InscMunicipal).HasMaxLength(20).IsRequired();

            Property(x => x.Loja).HasMaxLength(10).IsRequired();

            Property(x => x.Mensagem).HasMaxLength(80).IsRequired();

            Property(x => x.DataCadastro).IsRequired();
        }
    }
}
