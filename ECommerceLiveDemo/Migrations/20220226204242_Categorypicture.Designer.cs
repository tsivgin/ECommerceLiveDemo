﻿// <auto-generated />
using System;
using ECommerceLiveDemo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ECommerceLiveDemo.Migrations
{
    [DbContext(typeof(SHOPContext))]
    [Migration("20220226204242_Categorypicture")]
    partial class Categorypicture
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("Turkish_CI_AS")
                .HasAnnotation("ProductVersion", "7.0.0-preview.1.22076.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ECommerceLiveDemo.Models.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ContactEmail")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("ContactPhone")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("ImageLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsBrand")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("SiteUrl")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Brand", (string)null);
                });

            modelBuilder.Entity("ECommerceLiveDemo.Models.BrandUserMapping", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("BrandId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("UserId");

                    b.ToTable("Brand_User_Mapping", (string)null);
                });

            modelBuilder.Entity("ECommerceLiveDemo.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CategoryPicture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.Property<string>("SystemName")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Category", (string)null);
                });

            modelBuilder.Entity("ECommerceLiveDemo.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("BrandId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("date");

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<double?>("OldPrice")
                        .HasColumnType("float");

                    b.Property<double?>("Price")
                        .HasColumnType("float");

                    b.Property<string>("ProductUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.ToTable("Product", (string)null);
                });

            modelBuilder.Entity("ECommerceLiveDemo.Models.ProductVideoMapping", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<int?>("VideoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("VideoId");

                    b.ToTable("Product_Video_Mapping", (string)null);
                });

            modelBuilder.Entity("ECommerceLiveDemo.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("date");

                    b.Property<DateTime?>("CreateDate")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Gender")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("LastSignOnDate")
                        .HasColumnType("date");

                    b.Property<string>("MobilePhoneNo")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Password")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("ECommerceLiveDemo.Models.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("SystemName")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("UserRole", (string)null);
                });

            modelBuilder.Entity("ECommerceLiveDemo.Models.UserUserRoleMapping", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("UserRoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("UserRoleId");

                    b.ToTable("User_UserRole_Mapping", (string)null);
                });

            modelBuilder.Entity("ECommerceLiveDemo.Models.Video", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileName")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("FileUrl")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("FirstImageLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondImageLink")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Video", (string)null);
                });

            modelBuilder.Entity("ECommerceLiveDemo.Models.VideoCategoryMapping", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int?>("VideoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("VideoId");

                    b.ToTable("VideoCategoryMapping");
                });

            modelBuilder.Entity("ECommerceLiveDemo.Models.BrandUserMapping", b =>
                {
                    b.HasOne("ECommerceLiveDemo.Models.Brand", "Brand")
                        .WithMany("BrandUserMappings")
                        .HasForeignKey("BrandId")
                        .HasConstraintName("FK_Brand_User_Mapping_Brand");

                    b.HasOne("ECommerceLiveDemo.Models.User", "User")
                        .WithMany("BrandUserMappings")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Brand_User_Mapping_User");

                    b.Navigation("Brand");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ECommerceLiveDemo.Models.Product", b =>
                {
                    b.HasOne("ECommerceLiveDemo.Models.Brand", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK_Product_Brand");

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("ECommerceLiveDemo.Models.ProductVideoMapping", b =>
                {
                    b.HasOne("ECommerceLiveDemo.Models.Product", "Product")
                        .WithMany("ProductVideoMappings")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("FK_Product_Video_Mapping_Product");

                    b.HasOne("ECommerceLiveDemo.Models.Video", "Video")
                        .WithMany("ProductVideoMappings")
                        .HasForeignKey("VideoId")
                        .HasConstraintName("FK_Product_Video_Mapping_Video");

                    b.Navigation("Product");

                    b.Navigation("Video");
                });

            modelBuilder.Entity("ECommerceLiveDemo.Models.UserUserRoleMapping", b =>
                {
                    b.HasOne("ECommerceLiveDemo.Models.User", "User")
                        .WithMany("UserUserRoleMappings")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_User_UserRole_Mapping_User");

                    b.HasOne("ECommerceLiveDemo.Models.UserRole", "UserRole")
                        .WithMany("UserUserRoleMappings")
                        .HasForeignKey("UserRoleId")
                        .HasConstraintName("FK_User_UserRole_Mapping_UserRole");

                    b.Navigation("User");

                    b.Navigation("UserRole");
                });

            modelBuilder.Entity("ECommerceLiveDemo.Models.VideoCategoryMapping", b =>
                {
                    b.HasOne("ECommerceLiveDemo.Models.Category", "Category")
                        .WithMany("VideoCategoryMappings")
                        .HasForeignKey("CategoryId");

                    b.HasOne("ECommerceLiveDemo.Models.Video", "Video")
                        .WithMany("VideoCategoryMappings")
                        .HasForeignKey("VideoId");

                    b.Navigation("Category");

                    b.Navigation("Video");
                });

            modelBuilder.Entity("ECommerceLiveDemo.Models.Brand", b =>
                {
                    b.Navigation("BrandUserMappings");

                    b.Navigation("Products");
                });

            modelBuilder.Entity("ECommerceLiveDemo.Models.Category", b =>
                {
                    b.Navigation("VideoCategoryMappings");
                });

            modelBuilder.Entity("ECommerceLiveDemo.Models.Product", b =>
                {
                    b.Navigation("ProductVideoMappings");
                });

            modelBuilder.Entity("ECommerceLiveDemo.Models.User", b =>
                {
                    b.Navigation("BrandUserMappings");

                    b.Navigation("UserUserRoleMappings");
                });

            modelBuilder.Entity("ECommerceLiveDemo.Models.UserRole", b =>
                {
                    b.Navigation("UserUserRoleMappings");
                });

            modelBuilder.Entity("ECommerceLiveDemo.Models.Video", b =>
                {
                    b.Navigation("ProductVideoMappings");

                    b.Navigation("VideoCategoryMappings");
                });
#pragma warning restore 612, 618
        }
    }
}