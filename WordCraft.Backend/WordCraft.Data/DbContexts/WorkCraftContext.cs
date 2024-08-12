using Microsoft.EntityFrameworkCore;
using WordCraft.Core.Models.DataModel.WordCraft;

namespace WordCraft.Data.DbContexts
{
    public class WorkCraftContext : DbContext
    {
        public WorkCraftContext(DbContextOptions<WorkCraftContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
