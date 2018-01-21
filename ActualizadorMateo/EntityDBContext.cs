namespace ActualizadorMateo
{
    //using BusinessObject.Entities;
    using Helpers;
    using Oracle.ManagedDataAccess.Client;
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Threading.Tasks;

    public class EntityDBContext : DbContext
    {
        public EntityDBContext(string connectionString)
           : base(new OracleConnection(connectionString), true)
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }


        public EntityDBContext()
            : base(new OracleConnection(TalmaConnectionString.TLM_TRADU), true)
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        #region Declare DbSet

        //public DbSet<UserEntity> UserEntities { get; set; }
        //public DbSet<PhysicalLocaitionsEntity> PhysicalLocaitionsEntities { get; set; }
        //public DbSet<ULDvEntity> ULDvEntities { get; set; }
        //public DbSet<AirlineEntity> AirlineEntities { get; set; }
        #endregion

        #region Override methods
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            // Crea la base de datos cada vez que se ejecuta la aplicación si existen cambios                   
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DbContext>());
            //Database.SetInitializer(new CreateDatabaseIfNotExists<DbContext>());

            // Remove unused conventions
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync()
        {
            return base.SaveChangesAsync();
        }
        #endregion

    }
}
