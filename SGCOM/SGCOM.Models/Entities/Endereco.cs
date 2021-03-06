﻿using System;

namespace SGCOM.Models.Entities
{
    public class Endereco
    {       
        public int Id { get; set; }
        public int PessoaId { get; set; }
        public string Bairro { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public int EstadoId { get; set; }
        public int MunicipioId { get; set; }
        public string UF { get; set; }
        public virtual Pessoa Pessoa { get; set; }
        public virtual Estado Estado { get; set; }
        public virtual Municipio Municipio { get; set; }
        public DateTime DataCadstro { get; set; }

        public Endereco()
        {
            this.DataCadstro = DateTime.Now;
        }
        public override string ToString()
        {
            return this.Logradouro + '|' + this.Bairro;
        }
    }
}
