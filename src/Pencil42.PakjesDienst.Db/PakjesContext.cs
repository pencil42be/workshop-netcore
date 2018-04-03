using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

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
    }

    

}