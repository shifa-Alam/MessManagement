
using Microsoft.EntityFrameworkCore;
using MM.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MM.Repo
{
    public class MMDBContext : DbContext
    {
        public MMDBContext(DbContextOptions options) : base(options) { }

        //entities
        public DbSet<Member>? Members { get; set; }
        public DbSet<Meal>? Meals { get; set; }
        public DbSet<Bazar>? Bazars { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=DESKTOP-EA380EP\SQLEXPRESS;Database=MessManagement;Trusted_Connection=True;");
        //    //optionsBuilder.UseSqlServer(@" Server = 192.168.1.55; Database = MessManagement; Integrated Security=false; User Id = sa; Password = admin123##;");

        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Member>().HasKey(e => e.Id);
            modelBuilder.Entity<Meal>().HasKey(e => e.Id);
            modelBuilder.Entity<Bazar>().HasKey(e => e.Id);
        }


    }
}
