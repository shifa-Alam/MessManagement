using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MessManagement.Web;

namespace MessManagement.Web.Data
{
    public class MessManagementWebContext : DbContext
    {
        public MessManagementWebContext (DbContextOptions<MessManagementWebContext> options)
            : base(options)
        {
        }

        public DbSet<MessManagement.Web.Member> Member { get; set; } = default!;
    }
}
