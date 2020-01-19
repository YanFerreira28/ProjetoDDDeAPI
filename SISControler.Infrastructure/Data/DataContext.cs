using SISControler.Domain.Entities;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity;
using SISControler.Infrastructure.EntityConfiguration;

namespace SISControler.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext() : base("connection")
        {
            Configuration.LazyLoadingEnabled = false;
            Database.SetInitializer<DataContext>(new CreateDatabaseIfNotExists<DataContext>());
        }

        public DbSet<Produto> Produto { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new ClienteConfig());
            modelBuilder.Configurations.Add(new ProdutoConfiguration());
            modelBuilder.Configurations.Add(new UsuarioConfiguration());

            modelBuilder.Properties<string>().Configure(c => c.HasColumnType("varchar"));
            base.OnModelCreating(modelBuilder);
        }
    }
}
