
using Microsoft.EntityFrameworkCore;
using MM.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MM.Repo
{
    public  class MMDBContext : DbContext
    {

        public MMDBContext()
        {

        }
        //entities
        public DbSet<Member> Members { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-EA380EP\SQLEXPRESS;Database=MessManagement;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
       
       
    }
}
