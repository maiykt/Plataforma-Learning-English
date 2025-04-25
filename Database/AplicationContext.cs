using Database.Models;
using Microsoft.EntityFrameworkCore;


namespace Database
{
    public class AplicationContext : DbContext
    {
        public AplicationContext(DbContextOptions<AplicationContext>options): base(options) { }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categoies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            #region tables
            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<Category>().ToTable("Categories");
            #endregion


            #region "primary keys"
            modelBuilder.Entity<Product>().HasKey(product => product.Id); //lambda
            modelBuilder.Entity<Category>().HasKey(c => c.Id);
            #endregion


            #region relationships
            modelBuilder.Entity<Category>()
                .HasMany<Product>(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p=> p.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

            #region "property configuration"
            
            #region product
            modelBuilder.Entity<Product>()
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(150);
            #endregion

            #region Category
            modelBuilder.Entity<Category>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(150);
            #endregion

            #endregion

        }

    }
}
