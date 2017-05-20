using System;

namespace SGCOM.Models.Entities
{
    public class Produto2
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public decimal Preco { get; set; }

        public int CategoriaId { get; set; }

        public virtual Categoria Categoria { get; set; }

        public DateTime DataCadastro { get; set; }

        public Produto2()
        {
            this.DataCadastro = DateTime.Now;
        }

        public override string ToString()
        {
            return this.Nome;
        }
    }
}
