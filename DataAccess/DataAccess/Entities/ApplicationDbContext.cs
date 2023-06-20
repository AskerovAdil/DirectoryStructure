using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<CatalogItem> CatalogItems { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}
        

        protected override void OnModelCreating(ModelBuilder builder) => base.OnModelCreating(builder);
        
    }
}
