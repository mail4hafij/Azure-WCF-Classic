using System.Data.Common;
using System.Data.Entity;

namespace SRC.MySQL
{
    // we can also create our custom DB initializer, by inheriting one of the initializers 
    public class ContextInitializer : CreateDatabaseIfNotExists<MySQLContext>
    {
        protected override void Seed(MySQLContext context)
        {
            base.Seed(context);
        }
    }

    public class MySQLContext : DbContext
    {
        public MySQLContext(DbConnection con) : base(con, false)
        {
            Configuration.LazyLoadingEnabled = false;
            // Disable initializer
            System.Data.Entity.Database.SetInitializer<MySQLContext>(null);

            // System.Data.Entity.Database.SetInitializer<MySQLContext>(new DropCreateDatabaseIfModelChanges<MySQLContext>());
            // System.Data.Entity.Database.SetInitializer<MySQLContext>(new DropCreateDatabaseAlways<MySQLContext>());
            // System.Data.Entity.Database.SetInitializer<MySQLContext>(new ContextInitializer());
        }

        public DbSet<Data.Model.Car> Cars { get; set; }
    }
}