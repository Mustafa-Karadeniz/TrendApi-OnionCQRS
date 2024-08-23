﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TrendApi.Persistence.Context;

#nullable disable

namespace TrendApi.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240822063519_Update3")]
    partial class Update3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TrendApi.Domain.Entites.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.ToTable("Brands");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2024, 8, 22, 9, 35, 18, 700, DateTimeKind.Local).AddTicks(9322),
                            IsDeleted = false,
                            Name = "Computers"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2024, 8, 22, 9, 35, 18, 700, DateTimeKind.Local).AddTicks(9395),
                            IsDeleted = false,
                            Name = "Beauty & Shoes"
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2024, 8, 22, 9, 35, 18, 700, DateTimeKind.Local).AddTicks(9429),
                            IsDeleted = true,
                            Name = "Kids, Health & Clothing"
                        });
                });

            modelBuilder.Entity("TrendApi.Domain.Entites.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ParentId")
                        .HasColumnType("int");

                    b.Property<int>("Priorty")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2024, 8, 22, 9, 35, 18, 701, DateTimeKind.Local).AddTicks(2212),
                            IsDeleted = false,
                            Name = "Elektrik",
                            ParentId = 0,
                            Priorty = 1
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2024, 8, 22, 9, 35, 18, 701, DateTimeKind.Local).AddTicks(2216),
                            IsDeleted = false,
                            Name = "Moda",
                            ParentId = 0,
                            Priorty = 2
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2024, 8, 22, 9, 35, 18, 701, DateTimeKind.Local).AddTicks(2279),
                            IsDeleted = false,
                            Name = "Bilgisayar",
                            ParentId = 1,
                            Priorty = 1
                        },
                        new
                        {
                            Id = 4,
                            CreatedDate = new DateTime(2024, 8, 22, 9, 35, 18, 701, DateTimeKind.Local).AddTicks(2282),
                            IsDeleted = false,
                            Name = "Kadın",
                            ParentId = 2,
                            Priorty = 1
                        });
                });

            modelBuilder.Entity("TrendApi.Domain.Entites.Detail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Details");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            CreatedDate = new DateTime(2024, 8, 22, 9, 35, 18, 704, DateTimeKind.Local).AddTicks(3363),
                            Description = "Açılmadan değirmeni aut autem incidunt açılmadan bilgisayarı.\nİpsum quae bahar corporis.\nSokaklarda balıkhaneye sıradanlıktan aut anlamsız.\nOdio bilgisayarı okuma.\nDüşünüyor suscipit amet un telefonu.",
                            IsDeleted = false,
                            Title = "Autem magnam commodi çobanın."
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 3,
                            CreatedDate = new DateTime(2024, 8, 22, 9, 35, 18, 704, DateTimeKind.Local).AddTicks(3632),
                            Description = "Değerli ad sokaklarda fugit uzattı doğru ab numquam cezbelendi ab.\nRatione incidunt camisi voluptatem yaptı.\nQuam voluptatem patlıcan yaptı quia çakıl quia.",
                            IsDeleted = false,
                            Title = "Dağılımı dışarı tv incidunt et.\nDüşünüyor dışarı düşünüyor ab mıknatıslı dolayı sevindi rem gülüyorum umut."
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 4,
                            CreatedDate = new DateTime(2024, 8, 22, 9, 35, 18, 704, DateTimeKind.Local).AddTicks(3890),
                            Description = "Mi yapacakmış sokaklarda çorba in.\nEnim quae filmini esse otobüs sed.\nUllam göze voluptate amet eum.\nMıknatıslı eum quis.",
                            IsDeleted = false,
                            Title = "Açılmadan masaya ea enim explicabo sequi çakıl quia odio.\nCorporis ex dergi odit ab koyun çarpan.\nMolestiae telefonu lakin voluptatem doğru duyulmamış otobüs ea."
                        });
                });

            modelBuilder.Entity("TrendApi.Domain.Entites.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BrandId = 1,
                            CreatedDate = new DateTime(2024, 8, 22, 9, 35, 18, 708, DateTimeKind.Local).AddTicks(4756),
                            Description = "The beautiful range of Apple Naturalé that has an exciting mix of natural ingredients. With the Goodness of 100% Natural Ingredients",
                            Discount = 2.126125070177150m,
                            IsDeleted = false,
                            Price = 195.21m,
                            Title = "Unbranded Wooden Shirt"
                        },
                        new
                        {
                            Id = 2,
                            BrandId = 3,
                            CreatedDate = new DateTime(2024, 8, 22, 9, 35, 18, 708, DateTimeKind.Local).AddTicks(4811),
                            Description = "The Football Is Good For Training And Recreational Purposes",
                            Discount = 5.3361974229110m,
                            IsDeleted = false,
                            Price = 528.70m,
                            Title = "Intelligent Plastic Chips"
                        });
                });

            modelBuilder.Entity("TrendApi.Domain.Entites.ProductCategory", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.HasKey("ProductId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("ProductCategories");
                });

            modelBuilder.Entity("TrendApi.Domain.Entites.Detail", b =>
                {
                    b.HasOne("TrendApi.Domain.Entites.Category", "Category")
                        .WithMany("Details")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("TrendApi.Domain.Entites.Product", b =>
                {
                    b.HasOne("TrendApi.Domain.Entites.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("TrendApi.Domain.Entites.ProductCategory", b =>
                {
                    b.HasOne("TrendApi.Domain.Entites.Category", "Category")
                        .WithMany("ProductCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TrendApi.Domain.Entites.Product", "Product")
                        .WithMany("ProductCategories")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("TrendApi.Domain.Entites.Category", b =>
                {
                    b.Navigation("Details");

                    b.Navigation("ProductCategories");
                });

            modelBuilder.Entity("TrendApi.Domain.Entites.Product", b =>
                {
                    b.Navigation("ProductCategories");
                });
#pragma warning restore 612, 618
        }
    }
}