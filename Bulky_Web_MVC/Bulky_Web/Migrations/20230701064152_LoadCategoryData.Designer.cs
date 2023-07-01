﻿// <auto-generated />
using Bulky_Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bulky_Web.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230701064152_LoadCategoryData")]
    partial class LoadCategoryData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Bulky_Web.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Displayorder")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Displayorder = 1,
                            Name = "Horror"
                        },
                        new
                        {
                            Id = 2,
                            Displayorder = 2,
                            Name = "Thriller"
                        },
                        new
                        {
                            Id = 3,
                            Displayorder = 3,
                            Name = "Action"
                        },
                        new
                        {
                            Id = 4,
                            Displayorder = 4,
                            Name = "Crime/Drama"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
