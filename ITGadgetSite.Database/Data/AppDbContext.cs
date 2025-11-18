using ITGadgetSite.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace ITGadgetSite.Database.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<ITGadget> Gadgets { get; set; }
    }
}
