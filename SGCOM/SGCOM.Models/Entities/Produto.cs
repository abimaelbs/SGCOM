using System;

namespace SGCOM.Models.Entities
{
    public class Produto
    {
        public int Id { get; set; }

        public string Descricao { get; set; }

        public decimal Valor { get; set; }

        public int UnidadeId { get; set; }

        public int CategoriaId { get; set; }

        public int UsuarioId { get; set; }

        public int FornecedorId { get; set; }

        public string CodigoBarra { get; set; }

        public byte Imagem { get; set; }

        public DateTime DataCadastro { get; set; }

        public virtual Fornecedor Fornecedor { get; set; }

        public virtual Usuario Usuario { get; set; }

        public virtual Categoria Categoria { get; set; }

        public virtual Unidade Unidade { get; set; }

        public Produto()
        {
            this.DataCadastro = DateTime.Now;
        }

        public override string ToString()
        {
            return this.Descricao;
        }
    }
}
