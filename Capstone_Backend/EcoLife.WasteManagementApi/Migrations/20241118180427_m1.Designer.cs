﻿// <auto-generated />
using System;
using EcoLife.WasteManagementApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EcoLife.WasteManagementApi.Migrations
{
    [DbContext(typeof(WasteManagementDbContext))]
    [Migration("20241118180427_m1")]
    partial class m1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EcoLife.WasteManagementApi.Models.WasteManagementEntity", b =>
                {
                    b.Property<int>("WasteManagementId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WasteManagementId"));

                    b.Property<double>("CompostWaste")
                        .HasColumnType("float");

                    b.Property<double>("LandfillWaste")
                        .HasColumnType("float");

                    b.Property<DateOnly>("RecordedDate")
                        .HasColumnType("date");

                    b.Property<double>("RecycledWaste")
                        .HasColumnType("float");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<double>("WasteEmission")
                        .HasColumnType("float");

                    b.HasKey("WasteManagementId");

                    b.ToTable("WasteManagementEntities");
                });
#pragma warning restore 612, 618
        }
    }
}
