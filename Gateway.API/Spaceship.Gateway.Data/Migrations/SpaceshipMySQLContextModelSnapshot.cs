﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Spaceship.Gateway.Data.Repositories;

#nullable disable

namespace Spaceship.Gateway.Data.Migrations
{
    [DbContext(typeof(SpaceshipMySQLContext))]
    partial class SpaceshipMySQLContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Spaceship.Gateway.Domain.Entities.Spaceships", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("Deleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("Idle")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("MissionEnd")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Spaceships");
                });

            modelBuilder.Entity("Spaceship.Gateway.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("Deleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Spaceship.Gateway.Domain.Entities.Spaceships", b =>
                {
                    b.HasOne("Spaceship.Gateway.Domain.Entities.User", "User")
                        .WithMany("Spaceships")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("Spaceship.Gateway.Domain.ValueObjects.Material", "BaseRankUpMaterial", b1 =>
                        {
                            b1.Property<Guid>("SpaceshipsId")
                                .HasColumnType("char(36)");

                            b1.Property<int>("Crystal")
                                .HasColumnType("int");

                            b1.Property<int>("Currency")
                                .HasColumnType("int");

                            b1.Property<int>("Metal")
                                .HasColumnType("int");

                            b1.HasKey("SpaceshipsId");

                            b1.ToTable("Spaceships");

                            b1.WithOwner()
                                .HasForeignKey("SpaceshipsId");
                        });

                    b.OwnsOne("Spaceship.Gateway.Domain.ValueObjects.Status", "Status", b1 =>
                        {
                            b1.Property<Guid>("SpaceshipsId")
                                .HasColumnType("char(36)");

                            b1.Property<int>("CurrentHP")
                                .HasColumnType("int");

                            b1.Property<int>("Damage")
                                .HasColumnType("int");

                            b1.Property<int>("Rank")
                                .HasColumnType("int");

                            b1.Property<int>("RepairCost")
                                .HasColumnType("int");

                            b1.Property<int>("Tier")
                                .HasColumnType("int");

                            b1.Property<int>("TotalHP")
                                .HasColumnType("int");

                            b1.HasKey("SpaceshipsId");

                            b1.ToTable("Spaceships");

                            b1.WithOwner()
                                .HasForeignKey("SpaceshipsId");
                        });

                    b.Navigation("BaseRankUpMaterial")
                        .IsRequired();

                    b.Navigation("Status")
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Spaceship.Gateway.Domain.Entities.User", b =>
                {
                    b.OwnsOne("Spaceship.Gateway.Domain.ValueObjects.Material", "Material", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("char(36)");

                            b1.Property<int>("Crystal")
                                .HasColumnType("int");

                            b1.Property<int>("Currency")
                                .HasColumnType("int");

                            b1.Property<int>("Metal")
                                .HasColumnType("int");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("Spaceship.Gateway.Domain.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<string>("Neigbourhood")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<string>("Number")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<string>("PostalCode")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("Spaceship.Gateway.Domain.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Address")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("Spaceship.Gateway.Domain.ValueObjects.Login", "Login", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("Password")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<string>("Username")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("Spaceship.Gateway.Domain.ValueObjects.Name", "Name", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("char(36)");

                            b1.Property<string>("FirstName")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.Property<string>("LastName")
                                .IsRequired()
                                .HasColumnType("longtext");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("Email")
                        .IsRequired();

                    b.Navigation("Login")
                        .IsRequired();

                    b.Navigation("Material")
                        .IsRequired();

                    b.Navigation("Name")
                        .IsRequired();
                });

            modelBuilder.Entity("Spaceship.Gateway.Domain.Entities.User", b =>
                {
                    b.Navigation("Spaceships");
                });
#pragma warning restore 612, 618
        }
    }
}