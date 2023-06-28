﻿// <auto-generated />
using System;
using DataAccess.Concrete.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccess.Migrations
{
    [DbContext(typeof(CarRentalContext))]
    partial class CarRentalContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Core.Entities.Concrete.OperationClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.ToTable("OperationClaims");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "admin"
                        });
                });

            modelBuilder.Entity("Core.Entities.Concrete.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsBlocked")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "admin@example.com",
                            FirstName = "John",
                            IsBlocked = false,
                            LastName = "Doe",
                            PasswordHash = new byte[] { 25, 78, 12, 92, 111, 47, 220, 165, 88, 193, 137, 155, 106, 86, 184, 96, 229, 59, 65, 45, 136, 21, 33, 31, 201, 28, 45, 161, 102, 190, 63, 226, 118, 235, 61, 204, 166, 132, 91, 17, 74, 128, 161, 200, 57, 131, 214, 187, 25, 6, 45, 7, 94, 201, 113, 22, 27, 221, 109, 204, 248, 51, 173, 142 },
                            PasswordSalt = new byte[] { 135, 81, 181, 173, 15, 182, 157, 117, 198, 58, 203, 141, 46, 25, 114, 105, 105, 57, 189, 210, 36, 224, 140, 242, 133, 214, 125, 70, 33, 75, 131, 136, 213, 146, 255, 188, 25, 246, 68, 60, 251, 42, 176, 165, 32, 122, 1, 245, 207, 192, 98, 154, 243, 247, 90, 130, 139, 49, 220, 148, 20, 187, 65, 25, 107, 37, 178, 247, 229, 186, 133, 213, 242, 206, 40, 158, 242, 243, 213, 181, 102, 79, 2, 147, 47, 242, 183, 138, 146, 113, 93, 70, 26, 22, 157, 122, 37, 126, 136, 251, 21, 248, 112, 135, 136, 24, 183, 19, 145, 230, 35, 248, 182, 47, 45, 201, 76, 209, 251, 241, 171, 69, 254, 128, 239, 61, 167, 47 }
                        });
                });

            modelBuilder.Entity("Core.Entities.Concrete.UserOperationClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("OperationClaimId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OperationClaimId");

                    b.HasIndex("UserId");

                    b.ToTable("UserOperationClaims");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            OperationClaimId = 1,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("Entities.Concrete.Brand", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Brands");

                    b.HasData(
                        new
                        {
                            Id = (short)1,
                            Name = "TOGG"
                        });
                });

            modelBuilder.Entity("Entities.Concrete.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<short>("BrandId")
                        .HasColumnType("smallint");

                    b.Property<short>("ColorId")
                        .HasColumnType("smallint");

                    b.Property<decimal>("DailyPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<short>("ModelYear")
                        .HasColumnType("smallint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("ColorId");

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BrandId = (short)1,
                            ColorId = (short)1,
                            DailyPrice = 250m,
                            Description = "TOGG SUV model kırmızı",
                            ModelYear = (short)2022,
                            Name = "SUV"
                        },
                        new
                        {
                            Id = 2,
                            BrandId = (short)1,
                            ColorId = (short)2,
                            DailyPrice = 250m,
                            Description = "TOGG SUV model mavi",
                            ModelYear = (short)2022,
                            Name = "SUV"
                        },
                        new
                        {
                            Id = 3,
                            BrandId = (short)1,
                            ColorId = (short)3,
                            DailyPrice = 200m,
                            Description = "TOGG Sedan gri",
                            ModelYear = (short)2022,
                            Name = "Sedan"
                        });
                });

            modelBuilder.Entity("Entities.Concrete.CarImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UploadDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.ToTable("CarImages");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CarId = 1,
                            FileName = "9c51a451-ac2b-4840-81cb-e9447bf97441.jpg",
                            UploadDate = new DateTime(2023, 6, 28, 17, 2, 29, 232, DateTimeKind.Local).AddTicks(8903)
                        },
                        new
                        {
                            Id = 2,
                            CarId = 1,
                            FileName = "62343bd3-b600-4911-ba92-a3e92460c91b.jpg",
                            UploadDate = new DateTime(2023, 6, 28, 17, 2, 29, 232, DateTimeKind.Local).AddTicks(8916)
                        },
                        new
                        {
                            Id = 3,
                            CarId = 1,
                            FileName = "e855898a-5e19-4e9e-82fa-421a884b353a.jpg",
                            UploadDate = new DateTime(2023, 6, 28, 17, 2, 29, 232, DateTimeKind.Local).AddTicks(8917)
                        },
                        new
                        {
                            Id = 4,
                            CarId = 1,
                            FileName = "f16ec7fb-bcfa-49b6-accc-87e92b6d3cc3.jpg",
                            UploadDate = new DateTime(2023, 6, 28, 17, 2, 29, 232, DateTimeKind.Local).AddTicks(8918)
                        },
                        new
                        {
                            Id = 5,
                            CarId = 2,
                            FileName = "3fa88654-2976-4cff-948c-e3e20c730c91.jpg",
                            UploadDate = new DateTime(2023, 6, 28, 17, 2, 29, 232, DateTimeKind.Local).AddTicks(8918)
                        },
                        new
                        {
                            Id = 6,
                            CarId = 2,
                            FileName = "7a6f413f-0d74-4584-89a2-ff7898a8623d.jpg",
                            UploadDate = new DateTime(2023, 6, 28, 17, 2, 29, 232, DateTimeKind.Local).AddTicks(8919)
                        },
                        new
                        {
                            Id = 7,
                            CarId = 2,
                            FileName = "2135828c-09f7-4c6a-a5df-3a137c9a138a.jpg",
                            UploadDate = new DateTime(2023, 6, 28, 17, 2, 29, 232, DateTimeKind.Local).AddTicks(8920)
                        },
                        new
                        {
                            Id = 8,
                            CarId = 2,
                            FileName = "ee9d8d7e-d89b-4d70-b012-4aa241fca70a.jpg",
                            UploadDate = new DateTime(2023, 6, 28, 17, 2, 29, 232, DateTimeKind.Local).AddTicks(8920)
                        },
                        new
                        {
                            Id = 9,
                            CarId = 3,
                            FileName = "33959098-8427-4200-bd6e-823c2890ff10.jpg",
                            UploadDate = new DateTime(2023, 6, 28, 17, 2, 29, 232, DateTimeKind.Local).AddTicks(8921)
                        },
                        new
                        {
                            Id = 10,
                            CarId = 3,
                            FileName = "c300ab97-d45f-439c-90b8-fd09a9426cc4.jpg",
                            UploadDate = new DateTime(2023, 6, 28, 17, 2, 29, 232, DateTimeKind.Local).AddTicks(8922)
                        },
                        new
                        {
                            Id = 11,
                            CarId = 3,
                            FileName = "2cca89e4-a7a4-44fe-b8ac-f50872a1395b.jpg",
                            UploadDate = new DateTime(2023, 6, 28, 17, 2, 29, 232, DateTimeKind.Local).AddTicks(8922)
                        },
                        new
                        {
                            Id = 12,
                            CarId = 3,
                            FileName = "af969d12-5a14-488d-8509-796efb2bd0b3.jpg",
                            UploadDate = new DateTime(2023, 6, 28, 17, 2, 29, 232, DateTimeKind.Local).AddTicks(8923)
                        });
                });

            modelBuilder.Entity("Entities.Concrete.Color", b =>
                {
                    b.Property<short>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<short>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Colors");

                    b.HasData(
                        new
                        {
                            Id = (short)1,
                            Name = "Kırmızı"
                        },
                        new
                        {
                            Id = (short)2,
                            Name = "Mavi"
                        },
                        new
                        {
                            Id = (short)3,
                            Name = "Gri"
                        });
                });

            modelBuilder.Entity("Entities.Concrete.Customer", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            CompanyName = "AGCA"
                        });
                });

            modelBuilder.Entity("Entities.Concrete.Rental", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RentDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Rentals");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CarId = 2,
                            CustomerId = 1,
                            RentDate = new DateTime(2023, 7, 3, 17, 2, 29, 233, DateTimeKind.Local).AddTicks(4856)
                        });
                });

            modelBuilder.Entity("Core.Entities.Concrete.UserOperationClaim", b =>
                {
                    b.HasOne("Core.Entities.Concrete.OperationClaim", "OperationClaim")
                        .WithMany("UserOperationClaims")
                        .HasForeignKey("OperationClaimId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Concrete.User", "User")
                        .WithMany("UserOperationClaims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OperationClaim");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Entities.Concrete.Car", b =>
                {
                    b.HasOne("Entities.Concrete.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Concrete.Color", "Color")
                        .WithMany()
                        .HasForeignKey("ColorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("Color");
                });

            modelBuilder.Entity("Entities.Concrete.CarImage", b =>
                {
                    b.HasOne("Entities.Concrete.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");
                });

            modelBuilder.Entity("Entities.Concrete.Customer", b =>
                {
                    b.HasOne("Core.Entities.Concrete.User", "User")
                        .WithOne()
                        .HasForeignKey("Entities.Concrete.Customer", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Entities.Concrete.Rental", b =>
                {
                    b.HasOne("Entities.Concrete.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entities.Concrete.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Core.Entities.Concrete.OperationClaim", b =>
                {
                    b.Navigation("UserOperationClaims");
                });

            modelBuilder.Entity("Core.Entities.Concrete.User", b =>
                {
                    b.Navigation("UserOperationClaims");
                });
#pragma warning restore 612, 618
        }
    }
}
