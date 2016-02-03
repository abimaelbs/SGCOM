using System;

namespace SGCOM.Models.Entities
{
    public class Permissao
    {        
        public int Id { get; set; }
        public int GrupoId { get; set; }
        public int SubMenuId { get; set; }
        public bool Visualizar { get; set; }         
        public bool Inserir { get; set; }
        public bool Editar { get; set; }
        public bool Excluir { get; set; }
        public bool Relatorio { get; set; }
        public virtual Grupo Grupo { get; set; }
        public virtual SubMenu SubMenu { get; set; }
        public DateTime DataCadastro { get; set; }

        public Permissao()
        {
            this.DataCadastro = DateTime.Now;
        }
    }
}
