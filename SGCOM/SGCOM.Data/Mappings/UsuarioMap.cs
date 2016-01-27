﻿using SGCOM.Models;
using System.Data.Entity.ModelConfiguration;

namespace SGCOM.Data.Mappings
{
    public class UsuarioMap : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMap()
        {
            ToTable("Usuario");

            HasKey(x => x.Id);

            Property(x => x.Nome).HasMaxLength(60).IsRequired();

            Property(x => x.Login).HasMaxLength(20).IsRequired();

            Property(x => x.Senha).HasMaxLength(40).IsRequired();

            Property(X => X.SenhaMaster).HasMaxLength(40);

            Property(x=>x.IsAtivo).IsRequired();

            Property(x => x.DataCadastro).IsRequired();

            HasRequired(x => x.Grupo);            
        }
    }
}
