﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using POS.DAL;

namespace POS.DAL.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20191225085708_Add required fields")]
    partial class Addrequiredfields
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("POS.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasMaxLength(100);

                    b.Property<string>("No")
                        .HasMaxLength(50);

                    b.Property<string>("State")
                        .HasMaxLength(100);

                    b.Property<string>("Street")
                        .HasMaxLength(100);

                    b.Property<string>("ZipCode")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("POS.Models.Communication", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comment")
                        .HasMaxLength(250);

                    b.Property<int>("Medium");

                    b.Property<string>("Value")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Communications");
                });

            modelBuilder.Entity("POS.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<string>("Barcode");

                    b.Property<int>("CategoryId");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<decimal>("Price");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("POS.Models.ItemCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Description")
                        .HasMaxLength(1000);

                    b.Property<int?>("Level");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<int>("ParentCategoryId");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("POS.Models.PurchaseOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code");

                    b.Property<DateTime>("Date");

                    b.Property<decimal>("TotalPrice");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.ToTable("PurchaseOrders");
                });

            modelBuilder.Entity("POS.Models.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active");

                    b.Property<bool>("BlackList");

                    b.Property<string>("Code")
                        .HasMaxLength(100);

                    b.Property<string>("Comment")
                        .HasMaxLength(500);

                    b.Property<string>("ContactNo")
                        .HasMaxLength(10);

                    b.Property<string>("Description")
                        .HasMaxLength(1000);

                    b.Property<string>("Email")
                        .HasMaxLength(250);

                    b.Property<string>("Name")
                        .HasMaxLength(250);

                    b.Property<string>("Telephone")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("POS.Models.Item", b =>
                {
                    b.HasOne("POS.Models.ItemCategory", "ItemCateogry")
                        .WithMany("Items")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
