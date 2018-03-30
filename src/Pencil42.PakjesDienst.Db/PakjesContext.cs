using Microsoft.EntityFrameworkCore;

namespace Pencil42.PakjesDienst.Db
{
    public class PakjesContext : DbContext
    {
        public DbSet<Pakje> Pakjes { get; set; }

        public PakjesContext() : base()
        {

        }

        public PakjesContext(DbContextOptions<PakjesContext> contextOptions) : base(contextOptions)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer();
        }
    }

}