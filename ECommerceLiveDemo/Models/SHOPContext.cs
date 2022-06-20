using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ECommerceLiveDemo.Models
{
    public partial class SHOPContext : DbContext
    {
        public SHOPContext()
        {
        }

        public SHOPContext(DbContextOptions<SHOPContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<BrandUserMapping> BrandUserMappings { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductVideoMapping> ProductVideoMappings { get; set; }
        public virtual DbSet<VideoCategoryMapping> VideoCategoryMapping { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<UserUserRoleMapping> UserUserRoleMappings { get; set; }
        public virtual DbSet<Video> Videos { get; set; }
        public virtual DbSet<VideoBrandMapping> VideoBrandMapping { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
               //optionsBuilder.UseSqlServer("Server=localhost;Initial Catalog=SHOP;Integrated Security=True;");
                optionsBuilder.UseSqlServer(@"Data Source=78.135.83.247,1433;Initial Catalog=SHOPTest;User ID=sa;Password=tolga123;Integrated Security=False;Trusted_Connection=False");
                optionsBuilder.UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Turkish_CI_AS");

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("Brand");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ContactPhone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SiteUrl)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BrandUserMapping>(entity =>
            {

                entity.ToTable("Brand_User_Mapping");

                entity.HasOne(d => d.Brand)
    .WithMany(p => p.BrandUserMappings)
    .HasForeignKey(d => d.BrandId)
    .HasConstraintName("FK_Brand_User_Mapping_Brand");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.BrandUserMappings)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Brand_User_Mapping_User");
            });

            // modelBuilder.Entity<VideoBrandMapping>(entity =>
            // {
            //
            //     entity.ToTable("Video_Brand_Mapping");
            //
            //     entity.HasOne(d => d.Brand)
            //         .WithMany(p => p.VideoBrandMappings)
            //         .HasForeignKey(d => d.BrandId)
            //         .HasConstraintName("FK_Video_Brand_Mapping_Brand");
            //
            //     entity.HasOne(d => d.Video)
            //         .WithMany(p => p.VideoBrandMappings)
            //         .HasForeignKey(d => d.VideoId)
            //         .HasConstraintName("FK_Video_Brand_Mapping_Video");
            // });
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SystemName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.CreateDate).HasColumnType("date");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDate).HasColumnType("date");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Product_Brand");
            });

           


            modelBuilder.Entity<ProductVideoMapping>(entity =>
            {
                entity.ToTable("Product_Video_Mapping");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductVideoMappings)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_Product_Video_Mapping_Product");

                entity.HasOne(d => d.Video)
                    .WithMany(p => p.ProductVideoMappings)
                    .HasForeignKey(d => d.VideoId)
                    .HasConstraintName("FK_Product_Video_Mapping_Video");
            });
        //    modelBuilder.Entity<VideoCategoryMapping>(entity =>
        //    {
         //       entity.ToTable("Video_Category_Mapping");

         //       entity.HasOne(d => d.Category)
         //           .WithMany(p => p.VideoCategoryMappings)
         //           .HasForeignKey(d => d.CategoryId)
         //           .HasConstraintName("FK_Video_Category_Mapping");

         //       entity.HasOne(d => d.Video)
         //           .WithMany(p => p.VideoCategoryMappings)
         //           .HasForeignKey(d => d.VideoId)
         //           .HasConstraintName("FK_Video_Category_Mapping");
         //   });
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.CreateDate).HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastSignOnDate).HasColumnType("date");

                entity.Property(e => e.MobilePhoneNo)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdateDate).HasColumnType("date");

            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.ToTable("UserRole");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SystemName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserUserRoleMapping>(entity =>
            {
                entity.ToTable("User_UserRole_Mapping");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserUserRoleMappings)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_User_UserRole_Mapping_User");

                entity.HasOne(d => d.UserRole)
                    .WithMany(p => p.UserUserRoleMappings)
                    .HasForeignKey(d => d.UserRoleId)
                    .HasConstraintName("FK_User_UserRole_Mapping_UserRole");
            });

            modelBuilder.Entity<Video>(entity =>
            {
                entity.ToTable("Video");

                entity.Property(e => e.FileName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FileUrl)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
