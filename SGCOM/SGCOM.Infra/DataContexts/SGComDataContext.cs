using SGCOM.Domain;
using SGCOM.Infra.Mappings;
using System.Data.Entity;

namespace SGCOM.Infra.DataContexts
{
    public class SGComDataContext : DbContext
    {
        public SGComDataContext() : base("SQComConnectionString")
        {
            Database.SetInitializer<SGComDataContext>(new SGComDataContextInitializer());
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Grupo> Grupos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new GrupoMap());

            base.OnModelCreating(modelBuilder);
        }
    }

    public class SGComDataContextInitializer : DropCreateDatabaseIfModelChanges<SGComDataContext>
    {
        protected override void Seed(SGComDataContext context)
        {
            context.Grupos.Add(new Grupo { Id = 1, Titulo = "Administrador" });
            context.SaveChanges();

            base.Seed(context); 
        }
    }
}
