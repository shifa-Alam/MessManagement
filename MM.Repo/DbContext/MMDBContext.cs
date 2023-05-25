
using Microsoft.EntityFrameworkCore;
using MM.Core.Entities;



namespace MM.Repo
{
    public class MMDBContext : DbContext
    {
        public MMDBContext(DbContextOptions options) : base(options) { }

        //entities
        public DbSet<Member>? Members { get; set; }
        public DbSet<Meal>? Meals { get; set; }
        public DbSet<Bazar>? Bazars { get; set; }
        public DbSet<Fund>? Funds { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>().HasKey(e => e.Id);
            modelBuilder.Entity<Meal>().HasKey(e => e.Id);
            modelBuilder.Entity<Bazar>().HasKey(e => e.Id);
            modelBuilder.Entity<Fund>().HasKey(e => e.Id);
        }


    }
}
