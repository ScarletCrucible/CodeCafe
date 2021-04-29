﻿// <auto-generated />
using CodeCafe.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CodeCafe.Migrations
{
    [DbContext(typeof(CafeContext))]
    partial class CafeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CodeCafe.Models.OrderItem", b =>
                {
                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.ToTable("OrderItems");

                    b.HasData(
                        new
                        {
                            ProductId = 1
                        },
                        new
                        {
                            ProductId = 2
                        },
                        new
                        {
                            ProductId = 3
                        },
                        new
                        {
                            ProductId = 4
                        });
                });

            modelBuilder.Entity("CodeCafe.Models.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            Description = "Cappucino",
                            Image = "logo.png",
                            Price = 2.9900000000000002,
                            ProductName = "Cappucino"
                        },
                        new
                        {
                            ProductId = 2,
                            Description = "Mocha Frappe",
                            Image = "logo.png",
                            Price = 2.9900000000000002,
                            ProductName = "Mocha Frappe"
                        },
                        new
                        {
                            ProductId = 3,
                            Description = "Caramel Frappe",
                            Image = "logo.png",
                            Price = 2.9900000000000002,
                            ProductName = "Caramel Frappe"
                        },
                        new
                        {
                            ProductId = 4,
                            Description = "Black Coffee",
                            Image = "logo.png",
                            Price = 1.0,
                            ProductName = "Black Coffee"
                        });
                });

            modelBuilder.Entity("CodeCafe.Models.OrderItem", b =>
                {
                    b.HasOne("CodeCafe.Models.Product", "Product")
                        .WithMany("OrderItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("CodeCafe.Models.Product", b =>
                {
                    b.Navigation("OrderItems");
                });
#pragma warning restore 612, 618
        }
    }
}
