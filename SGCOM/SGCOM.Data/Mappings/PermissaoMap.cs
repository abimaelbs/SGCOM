using SGCOM.Models.Entities;
using System.Data.Entity.ModelConfiguration;

namespace SGCOM.Data.Mappings
{
    public class PermissaoMap : EntityTypeConfiguration<Permissao>
    {
        public PermissaoMap()
        {
            ToTable("Permissao");

            HasKey(x => x.Id);

            Property(x => x.Visualizar);

            Property(x => x.Inserir);

            Property(x => x.Editar);

            Property(x => x.Excluir);

            Property(x => x.Relatorio);

            Property(x => x.DataCadastro).IsRequired();

            HasRequired(x => x.Grupo);

            HasRequired(x => x.SubMenu);
        }
    }
}
