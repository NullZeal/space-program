﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SpaceProgramApi.Data;

#nullable disable

namespace SpaceProgramApi.Migrations
{
    [DbContext(typeof(SpaceProgramApiContext))]
    partial class SpaceProgramApiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SpaceProgramApi.Models.Officer", b =>
                {
                    b.Property<Guid>("OfficerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Rank")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("SpaceStationId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("OfficerId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.HasIndex("SpaceStationId");

                    b.ToTable("Officer");
                });

            modelBuilder.Entity("SpaceProgramApi.Models.SpaceStation", b =>
                {
                    b.Property<Guid>("SpaceStationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("SpaceStationId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("SpaceStation");
                });

            modelBuilder.Entity("SpaceProgramApi.Models.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId");

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("User");
                });

            modelBuilder.Entity("SpaceProgramApi.Models.Officer", b =>
                {
                    b.HasOne("SpaceProgramApi.Models.SpaceStation", "SpaceStation")
                        .WithMany("OfficerList")
                        .HasForeignKey("SpaceStationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SpaceStation");
                });

            modelBuilder.Entity("SpaceProgramApi.Models.SpaceStation", b =>
                {
                    b.Navigation("OfficerList");
                });
#pragma warning restore 612, 618
        }
    }
}
