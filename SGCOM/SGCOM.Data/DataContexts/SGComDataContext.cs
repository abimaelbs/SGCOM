using SGCOM.Models;
using SGCOM.Data.Mappings;
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

        #region Models
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new GrupoMap());
            modelBuilder.Configurations.Add(new UsuarioMap());

            base.OnModelCreating(modelBuilder);
        }
    }

    public class SGComDataContextInitializer : DropCreateDatabaseIfModelChanges<SGCOMDataContext>
    {
        protected override void Seed(SGCOMDataContext context)
        {
            context.Grupos.Add(new Grupo { Id = 1, Titulo = "Administrador" });
            context.SaveChanges();

            //context.Usuarios.Add(new Usuario
            //{
            //    Id = 1,
            //    Nome = "Administrador",
            //    Login = "admin",
            //    Senha = "admin",
            //    IsAtivo = true,
            //    GrupoId = 1
            //});
            //context.SaveChanges();

            base.Seed(context); 
        }        
    }
}
