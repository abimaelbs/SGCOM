﻿using SGCOM.Data.Mappings;
using SGCOM.Models;
using SGCOM.Models.Entities;
using System.Data.Entity;

namespace SGCOM.Data.DataContexts
{
    public class SGCOMDataContext : DbContext
    {
        public SGCOMDataContext() : base("SGCOMConectionString")
        {
            Database.SetInitializer<SGCOMDataContext>(new SGComDataContextInitializer());
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        #region Models DbSet

        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<SubMenu> SubMenus { get; set; }
        public DbSet<Parametro> Parametros { get; set; }
        public DbSet<Permissao> Acessos { get; set; }
        public DbSet<Caixa> Caixas { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Estado> Estados  { get; set; }
        public DbSet<Municipio> Municipios { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        #endregion

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    #region Tabela Grupo
        //    /*Assim           
        //    modelBuilder.Entity<Grupo>().ToTable("Grupo");
        //    modelBuilder.Entity<Grupo>().HasKey(x => x.Id);
        //    modelBuilder.Entity<Grupo>().Property(x => x.Titulo).HasMaxLength(40).IsRequired();
        //    modelBuilder.Entity<Grupo>().Property(x => x.DataCadastro).IsRequired(); ou */
        //    modelBuilder.Configurations.Add(new GrupoMap());
        //    #endregion Fim Tabela Grupo

        //    modelBuilder.Configurations.Add(new UsuarioMap());
        //    modelBuilder.Configurations.Add(new MenuMap());
        //    modelBuilder.Configurations.Add(new SubMenuMap());
        //    modelBuilder.Configurations.Add(new ParametroMap());
        //    modelBuilder.Configurations.Add(new PermissaoMap());
        //    modelBuilder.Configurations.Add(new CaixaMap());
        //    modelBuilder.Configurations.Add(new PessoaMap());
        //    modelBuilder.Configurations.Add(new EstadoMap());
        //    modelBuilder.Configurations.Add(new MunicipioMap());
        //    modelBuilder.Configurations.Add(new EnderecoMap());

        //    base.OnModelCreating(modelBuilder);
        //}
    }

    public class SGComDataContextInitializer : DropCreateDatabaseIfModelChanges<SGCOMDataContext>
    {
        protected override void Seed(SGCOMDataContext context)
        {
            context.Grupos.Add(new Grupo { Id = 0, Titulo = "Administrador" });
            context.Usuarios.Add(new Usuario
            {
                Id = 0,
                Nome = "Administrador",
                Login = "admin",
                Senha = "admin",
                GrupoId = 1
            });
            context.Estados.Add(new Estado { Id = 0, Nome = "Mato Grosso" });           
            context.Municipios.Add(new Municipio { Id = 0, Nome = "Cuiabá", EstadoId = 1 });
            context.SaveChanges();

            base.Seed(context); 
        }        
    }
}
