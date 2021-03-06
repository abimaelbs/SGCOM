﻿using System;
//using System.ComponentModel.DataAnnotations;

namespace SGCOM.Models.Entities
{
    public class Grupo
    {       
        public int Id { get; set; }
        //[StringLength(60)]
        public string Titulo { get; set; }
        public DateTime DataCadastro { get; set; }

        public Grupo()
        {
            this.DataCadastro = DateTime.Now;
        }
        public override string ToString()
        {
            return this.Titulo;
        }
    }
}
