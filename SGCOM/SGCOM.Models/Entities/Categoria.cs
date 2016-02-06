using System;

namespace SGCOM.Models.Entities
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public byte Imagem { get; set; }
        public DateTime DataCadastro { get; set; }

        public Categoria()
        {
            this.DataCadastro = DateTime.Now;
        }
        public override string ToString()
        {
            return this.Nome;
        }
    }
}
