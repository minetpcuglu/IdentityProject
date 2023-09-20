﻿// <auto-generated />
using System;
using DataAccessLayer.Concrete.EntiityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20230920070607_CitAdded")]
    partial class CitAdded
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EntitiesLayer.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool?>("Aktif")
                        .HasColumnType("bit");

                    b.Property<bool?>("Durum")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("EklenmeZamani")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("GuncellenmeZamani")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("SilinmeZamani")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("City");
                });

            modelBuilder.Entity("EntitiesLayer.District", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool?>("Aktif")
                        .HasColumnType("bit");

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<bool?>("Durum")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("EklenmeZamani")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("GuncellenmeZamani")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("SilinmeZamani")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("District");
                });

            modelBuilder.Entity("EntitiesLayer.Factory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool?>("Aktif")
                        .HasColumnType("bit");

                    b.Property<bool?>("Durum")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("EklenmeZamani")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("GuncellenmeZamani")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("SilinmeZamani")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Factory");
                });

            modelBuilder.Entity("EntitiesLayer.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool?>("Aktif")
                        .HasColumnType("bit");

                    b.Property<bool?>("Durum")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("EklenmeZamani")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("GuncellenmeZamani")
                        .HasColumnType("datetime2");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("SilinmeZamani")
                        .HasColumnType("datetime2");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("EntitiesLayer.WasteCode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool?>("Aktif")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Durum")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("EklenmeZamani")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("GuncellenmeZamani")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("SilinmeZamani")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("WasteCode");
                });

            modelBuilder.Entity("EntitiesLayer.WasteForm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AddressLine")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<bool?>("Aktif")
                        .HasColumnType("bit");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("DistrictId")
                        .HasColumnType("int");

                    b.Property<bool?>("Durum")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("EklenmeZamani")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("GuncellenmeZamani")
                        .HasColumnType("datetime2");

                    b.Property<string>("MonthlyAmount")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("SendEmail")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool?>("SendMailIsSuccess")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("SilinmeZamani")
                        .HasColumnType("datetime2");

                    b.Property<byte?>("StockingMethodEnum")
                        .HasColumnType("tinyint");

                    b.Property<int>("WasteCodeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DistrictId");

                    b.HasIndex("WasteCodeId");

                    b.ToTable("WasteForm");
                });

            modelBuilder.Entity("EntitiesLayer.WasteFormImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool?>("Aktif")
                        .HasColumnType("bit");

                    b.Property<string>("Base64")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("Durum")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("EklenmeZamani")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("GuncellenmeZamani")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("SilinmeZamani")
                        .HasColumnType("datetime2");

                    b.Property<int>("WasteFormId")
                        .HasColumnType("int");

                    b.Property<byte?>("WasteFormStatusEnum")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.HasIndex("WasteFormId");

                    b.ToTable("WasteFormImage");
                });

            modelBuilder.Entity("EntitiesLayer.District", b =>
                {
                    b.HasOne("EntitiesLayer.City", "City")
                        .WithMany("District")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("EntitiesLayer.WasteForm", b =>
                {
                    b.HasOne("EntitiesLayer.District", "District")
                        .WithMany("WasteForm")
                        .HasForeignKey("DistrictId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntitiesLayer.WasteCode", "WasteCode")
                        .WithMany("WasteForm")
                        .HasForeignKey("WasteCodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("District");

                    b.Navigation("WasteCode");
                });

            modelBuilder.Entity("EntitiesLayer.WasteFormImage", b =>
                {
                    b.HasOne("EntitiesLayer.WasteForm", "WasteForm")
                        .WithMany("WasteFormImage")
                        .HasForeignKey("WasteFormId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("WasteForm");
                });

            modelBuilder.Entity("EntitiesLayer.City", b =>
                {
                    b.Navigation("District");
                });

            modelBuilder.Entity("EntitiesLayer.District", b =>
                {
                    b.Navigation("WasteForm");
                });

            modelBuilder.Entity("EntitiesLayer.WasteCode", b =>
                {
                    b.Navigation("WasteForm");
                });

            modelBuilder.Entity("EntitiesLayer.WasteForm", b =>
                {
                    b.Navigation("WasteFormImage");
                });
#pragma warning restore 612, 618
        }
    }
}