using System;
//using System.ComponentModel.DataAnnotations;

namespace SGCOM.Domain
{
    public class Grupo
    {
        public Grupo()
        {
            this.DataCadastro = DateTime.Now;
        }   
                
        public int Id { get; set; }

        //[StringLength(60)]
        public string Titulo { get; set; }

        public DateTime DataCadastro { get; set; }

        public override string ToString()
        {
            return this.Titulo;
        }
    }
}
