using System;

namespace SGCOM.Models.Entities
{
    public class ListaTelefonica
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string Cor { get; set; }
        public DateTime Data { get; set; }

        public ListaTelefonica()
        {
            this.Data = DateTime.Now;
        }
    }
}
