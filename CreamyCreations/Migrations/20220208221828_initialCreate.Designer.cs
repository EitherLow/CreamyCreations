﻿// <auto-generated />
using System;
using CreamyCreations.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CreamyCreations.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220208221828_initialCreate")]
    partial class initialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("ProductVersion", "5.0.14");

            modelBuilder.Entity("CreamyCreations.Models.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("addressID");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT")
                        .HasColumnName("city");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT")
                        .HasColumnName("postalCode");

                    b.Property<string>("Province")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT")
                        .HasColumnName("province");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT")
                        .HasColumnName("street");

                    b.HasKey("AddressId");

                    b.ToTable("Address");

                    b.HasData(
                        new
                        {
                            AddressId = 1,
                            City = "Vancouver",
                            PostalCode = "V4B 9X2",
                            Province = "BC",
                            Street = "2 South Mega Street"
                        },
                        new
                        {
                            AddressId = 2,
                            City = "Burnaby",
                            PostalCode = "V8Y 3W2",
                            Province = "BC",
                            Street = "12 Main Street"
                        },
                        new
                        {
                            AddressId = 3,
                            City = "Surrey",
                            PostalCode = "S1L 9H7",
                            Province = "BC",
                            Street = "1 Shopping Street"
                        });
                });

            modelBuilder.Entity("CreamyCreations.Models.Cover", b =>
                {
                    b.Property<int>("CoverId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("coverID");

                    b.Property<string>("Flavor")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT")
                        .HasColumnName("flavor");

                    b.Property<decimal>("Price")
                        .HasColumnType("money")
                        .HasColumnName("price");

                    b.HasKey("CoverId");

                    b.HasIndex(new[] { "Flavor" }, "UQ__Cover__1DA1A8C1AAB7B0D6")
                        .IsUnique();

                    b.ToTable("Cover");

                    b.HasData(
                        new
                        {
                            CoverId = 1,
                            Flavor = "Butter with vanilla",
                            Price = 44.35m
                        },
                        new
                        {
                            CoverId = 2,
                            Flavor = "Plain butter",
                            Price = 10.35m
                        },
                        new
                        {
                            CoverId = 3,
                            Flavor = "Butter with dark chocolate",
                            Price = 34.35m
                        });
                });

            modelBuilder.Entity("CreamyCreations.Models.Decoration", b =>
                {
                    b.Property<int>("DecorationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("decorationID");

                    b.Property<string>("Decoration1")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT")
                        .HasColumnName("decoration");

                    b.Property<decimal>("Price")
                        .HasColumnType("money")
                        .HasColumnName("price");

                    b.HasKey("DecorationId");

                    b.HasIndex(new[] { "Decoration1" }, "UQ__Decorati__129665722C1950E6")
                        .IsUnique();

                    b.ToTable("Decoration");

                    b.HasData(
                        new
                        {
                            DecorationId = 1,
                            Decoration1 = "Chocolate hearts",
                            Price = 34.35m
                        },
                        new
                        {
                            DecorationId = 2,
                            Decoration1 = "Butter roses",
                            Price = 22.15m
                        },
                        new
                        {
                            DecorationId = 3,
                            Decoration1 = "Angles",
                            Price = 12.15m
                        });
                });

            modelBuilder.Entity("CreamyCreations.Models.Filling", b =>
                {
                    b.Property<int>("FillingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("fillingID");

                    b.Property<string>("Flavor")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT")
                        .HasColumnName("flavor");

                    b.Property<decimal>("Price")
                        .HasColumnType("money")
                        .HasColumnName("price");

                    b.HasKey("FillingId");

                    b.HasIndex(new[] { "Flavor" }, "UQ__Filling__1DA1A8C1F474B9D9")
                        .IsUnique();

                    b.ToTable("Filling");

                    b.HasData(
                        new
                        {
                            FillingId = 1,
                            Flavor = "Butter with almond",
                            Price = 60.35m
                        },
                        new
                        {
                            FillingId = 2,
                            Flavor = "Butter with dark chocolate",
                            Price = 30.35m
                        },
                        new
                        {
                            FillingId = 3,
                            Flavor = "Butter with strawberries",
                            Price = 24.35m
                        });
                });

            modelBuilder.Entity("CreamyCreations.Models.Label", b =>
                {
                    b.Property<int>("LabelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("labelID");

                    b.Property<string>("LabelName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT")
                        .HasColumnName("labelName");

                    b.Property<decimal>("Price")
                        .HasColumnType("money")
                        .HasColumnName("price");

                    b.HasKey("LabelId");

                    b.HasIndex(new[] { "LabelName" }, "UQ__Label__FB497B2DA698282A")
                        .IsUnique();

                    b.ToTable("Label");

                    b.HasData(
                        new
                        {
                            LabelId = 1,
                            LabelName = "Dark chocolate  label of last name",
                            Price = 10.25m
                        },
                        new
                        {
                            LabelId = 2,
                            LabelName = "White almond label of last name at the top",
                            Price = 20.25m
                        },
                        new
                        {
                            LabelId = 3,
                            LabelName = "Red strawberry label of last name in the middle",
                            Price = 30.25m
                        });
                });

            modelBuilder.Entity("CreamyCreations.Models.Level", b =>
                {
                    b.Property<int>("LevelNumber")
                        .HasColumnType("INTEGER")
                        .HasColumnName("levelNumber");

                    b.Property<decimal>("Price")
                        .HasColumnType("money")
                        .HasColumnName("price");

                    b.HasKey("LevelNumber")
                        .HasName("PK__Level__8AB0A30A55D0C97C");

                    b.ToTable("Level");

                    b.HasData(
                        new
                        {
                            LevelNumber = 1,
                            Price = 10.5m
                        },
                        new
                        {
                            LevelNumber = 2,
                            Price = 12.5m
                        },
                        new
                        {
                            LevelNumber = 3,
                            Price = 14.25m
                        });
                });

            modelBuilder.Entity("CreamyCreations.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("orderID");

                    b.Property<int>("AddressId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("addressID");

                    b.Property<DateTime>("DeliveryDate")
                        .HasColumnType("date")
                        .HasColumnName("deliveryDate");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("userID");

                    b.Property<int>("WeddingCakeId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("weddingCakeID");

                    b.HasKey("OrderId");

                    b.HasIndex("AddressId");

                    b.HasIndex("UserId");

                    b.HasIndex("WeddingCakeId");

                    b.ToTable("Order");

                    b.HasData(
                        new
                        {
                            OrderId = 1,
                            AddressId = 1,
                            DeliveryDate = new DateTime(2022, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 1,
                            WeddingCakeId = 1
                        },
                        new
                        {
                            OrderId = 2,
                            AddressId = 2,
                            DeliveryDate = new DateTime(2021, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 1,
                            WeddingCakeId = 2
                        },
                        new
                        {
                            OrderId = 3,
                            AddressId = 3,
                            DeliveryDate = new DateTime(2022, 4, 24, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            UserId = 1,
                            WeddingCakeId = 3
                        });
                });

            modelBuilder.Entity("CreamyCreations.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("userID");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("TEXT")
                        .HasColumnName("email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT")
                        .HasColumnName("firstName");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("TEXT")
                        .HasColumnName("lastName");

                    b.HasKey("UserId");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Email = "john.doe@doe.com",
                            FirstName = "John",
                            LastName = "Doe"
                        });
                });

            modelBuilder.Entity("CreamyCreations.Models.WeddingCake", b =>
                {
                    b.Property<int>("WeddingCakeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("weddingCakeID");

                    b.Property<int>("CoverId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("coverID");

                    b.Property<int>("FillingId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("fillingID");

                    b.Property<int>("LabelId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("labelID");

                    b.Property<int>("LevelNumber")
                        .HasColumnType("INTEGER")
                        .HasColumnName("levelNumber");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("money")
                        .HasColumnName("totalPrice");

                    b.HasKey("WeddingCakeId");

                    b.HasIndex("CoverId");

                    b.HasIndex("FillingId");

                    b.HasIndex("LabelId");

                    b.HasIndex("LevelNumber");

                    b.ToTable("WeddingCake");

                    b.HasData(
                        new
                        {
                            WeddingCakeId = 1,
                            CoverId = 1,
                            FillingId = 1,
                            LabelId = 1,
                            LevelNumber = 1,
                            TotalPrice = 320.23m
                        },
                        new
                        {
                            WeddingCakeId = 2,
                            CoverId = 2,
                            FillingId = 2,
                            LabelId = 2,
                            LevelNumber = 2,
                            TotalPrice = 211.83m
                        },
                        new
                        {
                            WeddingCakeId = 3,
                            CoverId = 3,
                            FillingId = 3,
                            LabelId = 3,
                            LevelNumber = 3,
                            TotalPrice = 101.99m
                        });
                });

            modelBuilder.Entity("CreamyCreations.Models.WeddingCakeDecoration", b =>
                {
                    b.Property<int>("WeddingCakeId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("weddingCakeID");

                    b.Property<int>("DecorationId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("decorationID");

                    b.HasKey("WeddingCakeId", "DecorationId")
                        .HasName("PK__WeddingC__E226A6EB5A68EDCE");

                    b.HasIndex("DecorationId");

                    b.ToTable("WeddingCakeDecoration");

                    b.HasData(
                        new
                        {
                            WeddingCakeId = 1,
                            DecorationId = 1
                        },
                        new
                        {
                            WeddingCakeId = 1,
                            DecorationId = 2
                        },
                        new
                        {
                            WeddingCakeId = 1,
                            DecorationId = 3
                        },
                        new
                        {
                            WeddingCakeId = 2,
                            DecorationId = 3
                        },
                        new
                        {
                            WeddingCakeId = 3,
                            DecorationId = 1
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("CreamyCreations.Models.Order", b =>
                {
                    b.HasOne("CreamyCreations.Models.Address", "Address")
                        .WithMany("Orders")
                        .HasForeignKey("AddressId")
                        .HasConstraintName("FK__Order__addressID__3B75D760")
                        .IsRequired();

                    b.HasOne("CreamyCreations.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__Order__userID__3D5E1FD2")
                        .IsRequired();

                    b.HasOne("CreamyCreations.Models.WeddingCake", "WeddingCake")
                        .WithMany("Orders")
                        .HasForeignKey("WeddingCakeId")
                        .HasConstraintName("FK__Order__weddingCa__3C69FB99")
                        .IsRequired();

                    b.Navigation("Address");

                    b.Navigation("User");

                    b.Navigation("WeddingCake");
                });

            modelBuilder.Entity("CreamyCreations.Models.WeddingCake", b =>
                {
                    b.HasOne("CreamyCreations.Models.Cover", "Cover")
                        .WithMany("WeddingCakes")
                        .HasForeignKey("CoverId")
                        .HasConstraintName("FK__WeddingCa__cover__31EC6D26")
                        .IsRequired();

                    b.HasOne("CreamyCreations.Models.Filling", "Filling")
                        .WithMany("WeddingCakes")
                        .HasForeignKey("FillingId")
                        .HasConstraintName("FK__WeddingCa__filli__32E0915F")
                        .IsRequired();

                    b.HasOne("CreamyCreations.Models.Label", "Label")
                        .WithMany("WeddingCakes")
                        .HasForeignKey("LabelId")
                        .HasConstraintName("FK__WeddingCa__label__33D4B598")
                        .IsRequired();

                    b.HasOne("CreamyCreations.Models.Level", "LevelNumberNavigation")
                        .WithMany("WeddingCakes")
                        .HasForeignKey("LevelNumber")
                        .HasConstraintName("FK__WeddingCa__level__34C8D9D1")
                        .IsRequired();

                    b.Navigation("Cover");

                    b.Navigation("Filling");

                    b.Navigation("Label");

                    b.Navigation("LevelNumberNavigation");
                });

            modelBuilder.Entity("CreamyCreations.Models.WeddingCakeDecoration", b =>
                {
                    b.HasOne("CreamyCreations.Models.Decoration", "Decoration")
                        .WithMany("WeddingCakeDecorations")
                        .HasForeignKey("DecorationId")
                        .HasConstraintName("FK__WeddingCa__decor__412EB0B6")
                        .IsRequired();

                    b.HasOne("CreamyCreations.Models.WeddingCake", "WeddingCake")
                        .WithMany("WeddingCakeDecorations")
                        .HasForeignKey("WeddingCakeId")
                        .HasConstraintName("FK__WeddingCa__weddi__403A8C7D")
                        .IsRequired();

                    b.Navigation("Decoration");

                    b.Navigation("WeddingCake");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CreamyCreations.Models.Address", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("CreamyCreations.Models.Cover", b =>
                {
                    b.Navigation("WeddingCakes");
                });

            modelBuilder.Entity("CreamyCreations.Models.Decoration", b =>
                {
                    b.Navigation("WeddingCakeDecorations");
                });

            modelBuilder.Entity("CreamyCreations.Models.Filling", b =>
                {
                    b.Navigation("WeddingCakes");
                });

            modelBuilder.Entity("CreamyCreations.Models.Label", b =>
                {
                    b.Navigation("WeddingCakes");
                });

            modelBuilder.Entity("CreamyCreations.Models.Level", b =>
                {
                    b.Navigation("WeddingCakes");
                });

            modelBuilder.Entity("CreamyCreations.Models.User", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("CreamyCreations.Models.WeddingCake", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("WeddingCakeDecorations");
                });
#pragma warning restore 612, 618
        }
    }
}