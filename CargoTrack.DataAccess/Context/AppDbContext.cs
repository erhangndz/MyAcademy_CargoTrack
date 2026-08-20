using CargoTrack.Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace CargoTrack.DataAccess.Context
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<ContactInfo> ContactInfos { get; set; }


    }
}
