﻿// <auto-generated />
using AMS.WebUI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace AMS.WebUI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20191201210826_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AMS.WebUI.Models.FacilityCost", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CalculationType");

                    b.Property<int>("CostIncomeType");

                    b.Property<string>("Description");

                    b.Property<decimal>("EmptyUnitShare")
                        .HasColumnType("decimal(3,2)");

                    b.Property<int>("KindOfUsage");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("FacilityCosts");
                });

            modelBuilder.Entity("AMS.WebUI.Models.Unit", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Unit");
                });

            modelBuilder.Entity("AMS.WebUI.Models.UnitFacilityCost", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("FacilityCostId");

                    b.Property<bool>("IsApplicant");

                    b.Property<bool>("OwnerPays");

                    b.Property<int>("Share");

                    b.Property<Guid>("UnitId");

                    b.Property<string>("UsagePeriod");

                    b.HasKey("Id");

                    b.HasIndex("FacilityCostId");

                    b.HasIndex("UnitId");

                    b.ToTable("UnitFacilityCost");
                });

            modelBuilder.Entity("AMS.WebUI.Models.UnitFacilityCost", b =>
                {
                    b.HasOne("AMS.WebUI.Models.FacilityCost", "FacilityCost")
                        .WithMany("UnitFacilityCosts")
                        .HasForeignKey("FacilityCostId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AMS.WebUI.Models.Unit", "Unit")
                        .WithMany("UnitFacilityCosts")
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
