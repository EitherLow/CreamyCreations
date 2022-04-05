using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using CreamyCreations.Models;
using CreamyCreations.ViewModels;

namespace CreamyCreations.Data
{


    public partial class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Cover> Covers { get; set; }
        public virtual DbSet<Decoration> Decorations { get; set; }
        public virtual DbSet<Filling> Fillings { get; set; }
        public virtual DbSet<Label> Labels { get; set; }
        public virtual DbSet<Level> Levels { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<WeddingCake> WeddingCakes { get; set; }
        public virtual DbSet<WeddingCakeDecoration> WeddingCakeDecorations { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Address");

                entity.Property(e => e.AddressId).HasColumnName("addressID");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("city");

                entity.Property(e => e.PostalCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("postalCode");

                entity.Property(e => e.Province)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("province");

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("street");
            });

            modelBuilder.Entity<Cover>(entity =>
            {
                entity.ToTable("Cover");

                entity.HasIndex(e => e.Flavor, "UQ__Cover__1DA1A8C1AAB7B0D6")
                    .IsUnique();

                entity.Property(e => e.CoverId).HasColumnName("coverID");

                entity.Property(e => e.Flavor)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("flavor");

                entity.Property(e => e.Price)
                    .HasColumnType("money")
                    .HasColumnName("price");
            });

            modelBuilder.Entity<Decoration>(entity =>
            {
                entity.ToTable("Decoration");

                entity.HasIndex(e => e.Decoration1, "UQ__Decorati__129665722C1950E6")
                    .IsUnique();

                entity.Property(e => e.DecorationId).HasColumnName("decorationID");

                entity.Property(e => e.Decoration1)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("decoration");

                entity.Property(e => e.Price)
                    .HasColumnType("money")
                    .HasColumnName("price");
            });

            modelBuilder.Entity<Filling>(entity =>
            {
                entity.ToTable("Filling");

                entity.HasIndex(e => e.Flavor, "UQ__Filling__1DA1A8C1F474B9D9")
                    .IsUnique();

                entity.Property(e => e.FillingId).HasColumnName("fillingID");

                entity.Property(e => e.Flavor)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("flavor");

                entity.Property(e => e.Price)
                    .HasColumnType("money")
                    .HasColumnName("price");
            });

            modelBuilder.Entity<Label>(entity =>
            {
                entity.ToTable("Label");

                entity.HasIndex(e => e.LabelName, "UQ__Label__FB497B2DA698282A")
                    .IsUnique();

                entity.Property(e => e.LabelId).HasColumnName("labelID");

                entity.Property(e => e.LabelName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("labelName");

                entity.Property(e => e.Price)
                    .HasColumnType("money")
                    .HasColumnName("price");
            });

            modelBuilder.Entity<Level>(entity =>
            {
                entity.HasKey(e => e.LevelNumber)
                    .HasName("PK__Level__8AB0A30A55D0C97C");

                entity.ToTable("Level");

                entity.Property(e => e.LevelNumber)
                    .ValueGeneratedNever()
                    .HasColumnName("levelNumber");

                entity.Property(e => e.Price)
                    .HasColumnType("money")
                    .HasColumnName("price");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.OrderId).HasColumnName("orderID");

                entity.Property(e => e.AddressId).HasColumnName("addressID");

                entity.Property(e => e.DeliveryDate)
                    .HasColumnType("date")
                    .HasColumnName("deliveryDate");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.Property(e => e.WeddingCakeId).HasColumnName("weddingCakeID");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Order__addressID__3B75D760");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Order__userID__3D5E1FD2");

                entity.HasOne(d => d.WeddingCake)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.WeddingCakeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Order__weddingCa__3C69FB99");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(256)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("firstName");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("lastName");
            });

            modelBuilder.Entity<WeddingCake>(entity =>
            {
                entity.ToTable("WeddingCake");

                entity.Property(e => e.WeddingCakeId).HasColumnName("weddingCakeID");

                entity.Property(e => e.CoverId).HasColumnName("coverID");

                entity.Property(e => e.FillingId).HasColumnName("fillingID");

                entity.Property(e => e.LabelId).HasColumnName("labelID");

                entity.Property(e => e.LevelNumber).HasColumnName("levelNumber");

                entity.Property(e => e.TotalPrice)
                    .HasColumnType("money")
                    .HasColumnName("totalPrice");

                //entity.HasOne(d => d.Cover)
                //    .WithMany(p => p.WeddingCakes)
                //    .HasForeignKey(d => d.CoverId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK__WeddingCa__cover__31EC6D26");

                //entity.HasOne(d => d.Filling)
                //    .WithMany(p => p.WeddingCakes)
                //    .HasForeignKey(d => d.FillingId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK__WeddingCa__filli__32E0915F");

                //entity.HasOne(d => d.Label)
                //    .WithMany(p => p.WeddingCakes)
                //    .HasForeignKey(d => d.LabelId)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK__WeddingCa__label__33D4B598");

                //entity.HasOne(d => d.LevelNumberNavigation)
                //    .WithMany(p => p.WeddingCakes)
                //    .HasForeignKey(d => d.LevelNumber)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK__WeddingCa__level__34C8D9D1");
            });

            modelBuilder.Entity<WeddingCakeDecoration>(entity =>
            {
                entity.HasKey(e => new { e.WeddingCakeId, e.DecorationId })
                    .HasName("PK__WeddingC__E226A6EB5A68EDCE");

                entity.ToTable("WeddingCakeDecoration");

                entity.Property(e => e.WeddingCakeId).HasColumnName("weddingCakeID");

                entity.Property(e => e.DecorationId).HasColumnName("decorationID");

                entity.HasOne(d => d.Decoration)
                    .WithMany(p => p.WeddingCakeDecorations)
                    .HasForeignKey(d => d.DecorationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__WeddingCa__decor__412EB0B6");

                entity.HasOne(d => d.WeddingCake)
                    .WithMany(p => p.WeddingCakeDecorations)
                    .HasForeignKey(d => d.WeddingCakeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__WeddingCa__weddi__403A8C7D");
            });

            OnModelCreatingPartial(modelBuilder);


            // Level
            modelBuilder.Entity<Level>().HasData(
                new Level { LevelNumber = 1, Price = 10.5m },
                new Level { LevelNumber = 2, Price = 12.5m },
                new Level { LevelNumber = 3, Price = 14.25m });

            // Label
            modelBuilder.Entity<Label>().HasData(
                new Label { LabelId = 1, LabelName = "Dark chocolate  label of last name", Price = 10.25m },
                new Label { LabelId = 2, LabelName = "White almond label of last name at the top", Price = 20.25m },
                new Label { LabelId = 3, LabelName = "Red strawberry label of last name in the middle", Price = 30.25m });

            // Filling
            modelBuilder.Entity<Filling>().HasData(
                new Filling { FillingId = 1, Price = 60.35m, Flavor = "Butter with almond" },
                new Filling { FillingId = 2, Price = 30.35m, Flavor = "Butter with dark chocolate" },
                new Filling { FillingId = 3, Price = 24.35m, Flavor = "Butter with strawberries" });

            // Cover
            modelBuilder.Entity<Cover>().HasData(
                new Cover { CoverId = 1, Price = 44.35m, Flavor = "Butter with vanilla" },
                new Cover { CoverId = 2, Price = 10.35m, Flavor = "Plain butter" },
                new Cover { CoverId = 3, Price = 34.35m, Flavor = "Butter with dark chocolate" });

            // Decoration
            modelBuilder.Entity<Decoration>().HasData(
                new Decoration { DecorationId = 1, Price = 34.35m, Decoration1 = "Chocolate hearts" },
                new Decoration { DecorationId = 2, Price = 22.15m, Decoration1 = "Butter roses" },
                new Decoration { DecorationId = 3, Price = 12.15m, Decoration1 = "Angles" });

            // User
            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@doe.com" });

            // Address
            modelBuilder.Entity<Address>().HasData(
                new Address { AddressId = 1, City = "Vancouver", PostalCode = "V4B 9X2", Street = "2 South Mega Street", Province = "BC" },
                new Address { AddressId = 2, City = "Burnaby", PostalCode = "V8Y 3W2", Street = "12 Main Street", Province = "BC" },
                new Address { AddressId = 3, City = "Surrey", PostalCode = "S1L 9H7", Street = "1 Shopping Street", Province = "BC" });

            // Wedding Cake
            modelBuilder.Entity<WeddingCake>().HasData(
                new WeddingCake { WeddingCakeId = 1, CoverId = 1, FillingId = 1, LabelId = 1, LevelNumber = 1, TotalPrice = 320.23m },
                new WeddingCake { WeddingCakeId = 2, CoverId = 2, FillingId = 2, LabelId = 2, LevelNumber = 2, TotalPrice = 211.83m },
                new WeddingCake { WeddingCakeId = 3, CoverId = 3, FillingId = 3, LabelId = 3, LevelNumber = 3, TotalPrice = 101.99m });

            // Order
            modelBuilder.Entity<Order>().HasData(
                new Order { OrderId = 1, AddressId = 1, WeddingCakeId = 1, UserId = 1, DeliveryDate = new DateTime(2022,12,01) },
                new Order { OrderId = 2, AddressId = 2, WeddingCakeId = 2, UserId = 1, DeliveryDate = new DateTime(2021,11,30) },
                new Order { OrderId = 3, AddressId = 3, WeddingCakeId = 3, UserId = 1, DeliveryDate = new DateTime(2022,04,24) });

            // Wedding Cake Decoration
            modelBuilder.Entity<WeddingCakeDecoration>().HasData(
                new WeddingCakeDecoration { WeddingCakeId = 1, DecorationId = 1 },
                new WeddingCakeDecoration { WeddingCakeId = 1, DecorationId = 2 },
                new WeddingCakeDecoration { WeddingCakeId = 1, DecorationId = 3 },
                new WeddingCakeDecoration { WeddingCakeId = 2, DecorationId = 3 },
                new WeddingCakeDecoration { WeddingCakeId = 3, DecorationId = 1 });


        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<CreamyCreations.ViewModels.AdminOrdersVM> AdminOrdersVM { get; set; }

        public DbSet<CreamyCreations.ViewModels.UserProfileVM> UserProfileVM { get; set; }

        public DbSet<CreamyCreations.ViewModels.CreateWeddingCakeVM> WeddingCakeVM { get; set; }


        public DbSet<CreamyCreations.ViewModels.OrdersVm> OrdersVm { get; set; }
        public DbSet<CreamyCreations.ViewModels.CustomerWeddingCakeVM> CustomerWeddingCakeVM { get; set; }

        public DbSet<CreamyCreations.ViewModels.WeddingCakeVM> WeddingCakeVM_1 { get; set; }

    }
}
