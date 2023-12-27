using Microsoft.EntityFrameworkCore;
using UcakRezervasyon.Models;

namespace UcakRezervasyon.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<guzergah> guzergah { get; set; }
        public DbSet<ucak> ucak { get; set; }
        public DbSet<ucus> ucus { get; set; }
        public DbSet<ucakdetay> ucakdetay { get; set; }
        

        
    }

}

