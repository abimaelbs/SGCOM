using SGCOM.Data.Mappings;
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
        public DbSet<Caixa> Caixas { get; set; }

        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region Tabela Grupo
            /*Assim           
            modelBuilder.Entity<Grupo>().ToTable("Grupo");
            modelBuilder.Entity<Grupo>().HasKey(x => x.Id);
            modelBuilder.Entity<Grupo>().Property(x => x.Titulo).HasMaxLength(40).IsRequired();
            modelBuilder.Entity<Grupo>().Property(x => x.DataCadastro).IsRequired(); ou */
            modelBuilder.Configurations.Add(new GrupoMap());
            #endregion Fim Tabela Grupo

            modelBuilder.Configurations.Add(new UsuarioMap());
            modelBuilder.Configurations.Add(new CaixaMap());

            base.OnModelCreating(modelBuilder);
        }
    }

    public class SGComDataContextInitializer : DropCreateDatabaseIfModelChanges<SGCOMDataContext>
    {
        protected override void Seed(SGCOMDataContext context)
        {
            context.Grupos.Add(new Grupo { Id = 1, Titulo = "Administrador" });
            context.SaveChanges();

            context.Usuarios.Add(new Usuario
            {
                Id = 1,
                Nome = "Administrador",
                Login = "admin",
                Senha = "admin",               
                GrupoId = 1                
            });
            context.SaveChanges();

            base.Seed(context); 
        }        
    }
}
