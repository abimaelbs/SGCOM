﻿using System;

namespace SGCOM.Models.Entities
{
    public class Usuario
    {
        public Usuario()
        {
            this.IsAtivo = false;
            this.DataCadastro = DateTime.Now;
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string SenhaMaster { get; set; }
        public bool IsAtivo { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime UltimoAcesso { get; set; }
        public int GrupoId { get; set; }
        public virtual Grupo Grupo { get; set; }

        public override string ToString()
        {
            return this.Nome;
        }
    }
}