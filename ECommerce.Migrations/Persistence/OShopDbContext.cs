using ECommerce.Domain.Entities.Category;
using ECommerce.Domain.Entities.Photos;
using ECommerce.Domain.Entities.Product;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Migrations.Persistence
{
    public class OShopDbContext : DbContext
    {
        public OShopDbContext()
        {

        }
        public OShopDbContext(DbContextOptions options) : base(options)
        {

        }

        #region DbSets
        public DbSet<Products> _Products { get; set; }
        public DbSet<Categories> _Categories { get; set; }
        //public DbSet<ProductPhotos> _ProductPhotos { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(OShopDbContext).Assembly);
            base.OnModelCreating(builder);

            builder.Entity<Products>(entity =>
            {
                entity.ToTable(name: "Products");
                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                    .IsRequired()
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ArabicName)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(true)
                .HasColumnName("ProductNameAR")
                .IsFixedLength(true);

                entity.Property(e => e.EnglishName)
                .IsRequired()
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ProductNameEN")
                .IsFixedLength(true);

                entity.Property(e => e.Price)
                .HasPrecision(6, 2)
                .IsRequired()
                .HasColumnName("Price");


                entity.Property(e => e.HasAvailableStock)
                .IsRequired()
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("HasAvailableStock")
                .IsFixedLength(true)
                .HasDefaultValue(0);

                entity.Property(e => e.Image)
                .IsRequired(false)
                .HasColumnName("Image");

                entity.HasOne(d => d.ProductCategory)
               .WithMany()
               .HasForeignKey(e => e.FK_CategoryId)
               .IsRequired(false)
               .HasConstraintName("FK_Product_ProductCategory");

            });

            builder.Entity<Categories>(entity =>
            {
                entity.ToTable(name: "Categories");

                entity.HasKey(e => e.ID);

                entity.Property(e => e.ID)
                  .IsRequired()
                  .IsUnicode(false)
                  .HasMaxLength(10)
                  .HasColumnName("ID")
                  .ValueGeneratedOnAdd();

             
                entity.Property(e => e.Name)
                  .IsRequired()
                  .IsUnicode()
                  .HasColumnName("Name")
                  .HasMaxLength(255);

                entity.Property(e => e.CreatedDate)
               .IsRequired(false)
               .IsUnicode(false)
               .HasColumnName("CreatedDate");
            });

            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseLazyLoadingProxies(false);

            base.OnConfiguring(optionsBuilder);

        }
    }
}