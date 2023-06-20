using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataAccess.Entities
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<CatalogItem> CatalogItems { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CatalogItem>()
                .HasOne(n => n.ParentCatalog)
                .WithMany(n => n.SubCatalogs)
                .HasForeignKey(n => n.ParentId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
