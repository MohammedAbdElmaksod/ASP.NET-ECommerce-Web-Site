using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
#nullable disable

namespace E_CommerceWebSite.Models
{
    public partial class ECommerceDBContext : IdentityDbContext<IdentityUser>
    {
        public ECommerceDBContext()
        {
        }

        public ECommerceDBContext(DbContextOptions<ECommerceDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbCategory> TbCategories { get; set; }
        public virtual DbSet<TbImage> TbImages { get; set; }
        public virtual DbSet<TbProduct> TbProducts { get; set; }
        public virtual DbSet<TbOrderInvoice> TbOrderInvoices { get; set; }

      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TbCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.Property(e => e.CategoryName).IsRequired();
               
            });
            modelBuilder.Entity<TbOrderInvoice>(entity =>
            {
                entity.HasKey(e => e.InvoiceId);
                entity.HasIndex(e => e.UserId ,"IX_TbOrderInvoice_UserId");
                entity.HasOne(d => d.User)
                .WithMany(p => p.OrderInvoice)
                .HasForeignKey(d => d.UserId);
                
            });

            modelBuilder.Entity<TbImage>(entity =>
            {
                entity.HasKey(e => e.ImageId);

                entity.HasIndex(e => e.ProductId, "IX_TbImages_ProductId");

                entity.Property(e => e.ImageName).HasMaxLength(50);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.TbImages)
                    .HasForeignKey(d => d.ProductId);
            });

            modelBuilder.Entity<TbProduct>(entity =>
            {
                entity.HasKey(e => e.ProductId);

                entity.Property(e => e.ProductBuyPrice).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ProductName).IsRequired();

                entity.Property(e => e.ProductSalePrice).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.Category)
                 .WithMany(p => p.TbProducts)
                 .HasForeignKey(d => d.CategoryId)
                 .HasConstraintName("FK_TbProducts_TbCategories");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
