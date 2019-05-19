using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext()
        {
        }

        public RepositoryContext(DbContextOptions<RepositoryContext> options)
            :base(options)
        {
        }

        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<CatagoryLookup> CatagoryLookup { get; set; }
        public virtual DbSet<Clothing> Clothing { get; set; }
        public virtual DbSet<Downloads> Downloads { get; set; }
        public virtual DbSet<Magnets> Magnets { get; set; }
        public virtual DbSet<RoleLookup> RoleLookup { get; set; }
        public virtual DbSet<SizeLookup> SizeLookup { get; set; }
        public virtual DbSet<SleeveLookup> SleeveLookup { get; set; }
        public virtual DbSet<Users> Users { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.ProdId })
                    .HasName("PRIMARY");

                entity.ToTable("cart");

                entity.Property(e => e.UserId).HasColumnType("int(11)");

                entity.Property(e => e.ProdId)
                    .HasColumnName("ProdID")
                    .HasColumnType("varchar(4)");

                entity.Property(e => e.Qty).HasColumnType("int(11)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Cart)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_cart_user");
            });

            modelBuilder.Entity<CatagoryLookup>(entity =>
            {
                entity.HasKey(e => e.CatId)
                    .HasName("PRIMARY");

                entity.ToTable("catagory_lookup");

                entity.Property(e => e.CatId).HasColumnType("varchar(10)");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnType("varchar(25)");
            });

            modelBuilder.Entity<Clothing>(entity =>
            {
                entity.HasKey(e => e.ProdId)
                    .HasName("PRIMARY");

                entity.ToTable("clothing");

                entity.HasIndex(e => e.Catagory)
                    .HasName("fk_catagoryidx");

                entity.HasIndex(e => e.ProdId)
                    .HasName("index");

                entity.HasIndex(e => e.Size)
                    .HasName("fk_cloth_size_idx");

                entity.HasIndex(e => e.SleeveLength)
                    .HasName("fk_sleevesidx");

                entity.Property(e => e.ProdId).HasColumnType("varchar(4)");

                entity.Property(e => e.BackPicture)
                    .IsRequired()
                    .HasColumnType("varchar(25)");

                entity.Property(e => e.Catagory)
                    .IsRequired()
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.ProdPicture)
                    .IsRequired()
                    .HasColumnType("varchar(25)");

                entity.Property(e => e.ProdPrice).HasColumnType("decimal(6,2)");

                entity.Property(e => e.ProdQty).HasColumnType("int(11)");

                entity.Property(e => e.Size)
                    .IsRequired()
                    .HasColumnType("varchar(6)");

                entity.Property(e => e.SleeveLength)
                    .IsRequired()
                    .HasColumnType("varchar(2)");

                entity.HasOne(d => d.CatagoryNavigation)
                    .WithMany(p => p.Clothing)
                    .HasForeignKey(d => d.Catagory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_cloth_cat");

                entity.HasOne(d => d.SizeNavigation)
                    .WithMany(p => p.Clothing)
                    .HasForeignKey(d => d.Size)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_cloth_size");

                entity.HasOne(d => d.SleeveLengthNavigation)
                    .WithMany(p => p.Clothing)
                    .HasForeignKey(d => d.SleeveLength)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_sleeves");
            });

            modelBuilder.Entity<Downloads>(entity =>
            {
                entity.HasKey(e => new { e.FileNameId, e.Date })
                    .HasName("PRIMARY");

                entity.ToTable("downloads");

                entity.Property(e => e.FileNameId)
                    .HasColumnName("FileNameID")
                    .HasColumnType("varchar(25)");

                entity.Property(e => e.Date).HasColumnType("varchar(45)");

                entity.Property(e => e.Downloads1)
                    .HasColumnName("Downloads")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<Magnets>(entity =>
            {
                entity.HasKey(e => e.ProdId)
                    .HasName("PRIMARY");

                entity.ToTable("magnets");

                entity.HasIndex(e => e.Catagory)
                    .HasName("fk_catagory_idx");

                entity.HasIndex(e => e.ProdId)
                    .HasName("index");

                entity.Property(e => e.ProdId).HasColumnType("varchar(4)");

                entity.Property(e => e.Capital)
                    .IsRequired()
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.Catagory)
                    .IsRequired()
                    .HasColumnType("varchar(10)");

                entity.Property(e => e.ProdName)
                    .IsRequired()
                    .HasColumnType("varchar(15)");

                entity.Property(e => e.ProdPicture)
                    .IsRequired()
                    .HasColumnType("varchar(25)");

                entity.Property(e => e.ProdPrice).HasColumnType("decimal(6,2)");

                entity.Property(e => e.ProdQty).HasColumnType("int(11)");

                entity.Property(e => e.Statehood)
                    .IsRequired()
                    .HasColumnType("varchar(25)");
            });

            modelBuilder.Entity<RoleLookup>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PRIMARY");

                entity.ToTable("role_lookup");

                entity.Property(e => e.RoleId).HasColumnType("varchar(1)");

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasColumnType("varchar(15)");
            });

            modelBuilder.Entity<SizeLookup>(entity =>
            {
                entity.HasKey(e => e.SizeId)
                    .HasName("PRIMARY");

                entity.ToTable("size_lookup");

                entity.Property(e => e.SizeId).HasColumnType("varchar(6)");

                entity.Property(e => e.Size)
                    .IsRequired()
                    .HasColumnType("varchar(15)");
            });

            modelBuilder.Entity<SleeveLookup>(entity =>
            {
                entity.HasKey(e => e.SleeveId)
                    .HasName("PRIMARY");

                entity.ToTable("sleeve_lookup");

                entity.Property(e => e.SleeveId)
                    .HasColumnName("SleeveID")
                    .HasColumnType("varchar(2)");

                entity.Property(e => e.SleeveLength)
                    .IsRequired()
                    .HasColumnName("Sleeve Length")
                    .HasColumnType("varchar(12)");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.Role)
                    .HasName("fk_role_idx");

                entity.HasIndex(e => e.Username)
                    .HasName("Username_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Address).HasColumnType("varchar(45)");

                entity.Property(e => e.City).HasColumnType("varchar(20)");

                entity.Property(e => e.Email).HasColumnType("varchar(45)");

                entity.Property(e => e.Fname).HasColumnType("varchar(25)");

                entity.Property(e => e.Lname).HasColumnType("varchar(25)");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnType("varchar(40)");

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasColumnType("varchar(1)");

                entity.Property(e => e.State).HasColumnType("varchar(2)");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnType("varchar(12)");

                entity.Property(e => e.Zip).HasColumnType("varchar(10)");

                entity.HasOne(d => d.RoleNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.Role)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_role");
            });
        }
    }
}
