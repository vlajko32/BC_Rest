﻿// <auto-generated />
using System;
using BasketballClub_Rest.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BasketballClub_Rest.Migrations
{
    [DbContext(typeof(BCContext))]
    [Migration("20220117001835_EnumTest")]
    partial class EnumTest
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BasketballClub_Rest.Domain.Gym", b =>
                {
                    b.Property<int>("GymID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GymName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GymID");

                    b.ToTable("Gyms");
                });

            modelBuilder.Entity("BasketballClub_Rest.Domain.Player", b =>
                {
                    b.Property<int>("PlayerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SelectionID")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PlayerID");

                    b.HasIndex("SelectionID");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("BasketballClub_Rest.Domain.Selection", b =>
                {
                    b.Property<int>("SelectionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SelectionAge")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("SelectionName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SelectionID");

                    b.ToTable("Selections");
                });

            modelBuilder.Entity("BasketballClub_Rest.Domain.Training", b =>
                {
                    b.Property<int>("TrainingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CoachUserID")
                        .HasColumnType("int");

                    b.Property<int?>("GymID")
                        .HasColumnType("int");

                    b.Property<int>("SelectionID")
                        .HasColumnType("int");

                    b.Property<int>("TrainingDuration")
                        .HasColumnType("int");

                    b.Property<DateTime>("TrainingStart")
                        .HasColumnType("datetime2");

                    b.HasKey("TrainingID");

                    b.HasIndex("CoachUserID");

                    b.HasIndex("GymID");

                    b.HasIndex("SelectionID");

                    b.ToTable("Trainings");
                });

            modelBuilder.Entity("BasketballClub_Rest.Domain.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BasketballClub_Rest.Domain.Administrator", b =>
                {
                    b.HasBaseType("BasketballClub_Rest.Domain.User");

                    b.ToTable("Administrators");
                });

            modelBuilder.Entity("BasketballClub_Rest.Domain.Coach", b =>
                {
                    b.HasBaseType("BasketballClub_Rest.Domain.User");

                    b.Property<int?>("SelectionID")
                        .HasColumnType("int");

                    b.Property<int>("YearsOfExperience")
                        .HasColumnType("int");

                    b.HasIndex("SelectionID");

                    b.ToTable("Coaches");
                });

            modelBuilder.Entity("BasketballClub_Rest.Domain.Player", b =>
                {
                    b.HasOne("BasketballClub_Rest.Domain.Selection", "Selection")
                        .WithMany("Players")
                        .HasForeignKey("SelectionID");

                    b.Navigation("Selection");
                });

            modelBuilder.Entity("BasketballClub_Rest.Domain.Training", b =>
                {
                    b.HasOne("BasketballClub_Rest.Domain.Coach", "Coach")
                        .WithMany()
                        .HasForeignKey("CoachUserID");

                    b.HasOne("BasketballClub_Rest.Domain.Gym", "Gym")
                        .WithMany()
                        .HasForeignKey("GymID");

                    b.HasOne("BasketballClub_Rest.Domain.Selection", "Selection")
                        .WithMany("Trainings")
                        .HasForeignKey("SelectionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Coach");

                    b.Navigation("Gym");

                    b.Navigation("Selection");
                });

            modelBuilder.Entity("BasketballClub_Rest.Domain.Administrator", b =>
                {
                    b.HasOne("BasketballClub_Rest.Domain.User", null)
                        .WithOne()
                        .HasForeignKey("BasketballClub_Rest.Domain.Administrator", "UserID")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BasketballClub_Rest.Domain.Coach", b =>
                {
                    b.HasOne("BasketballClub_Rest.Domain.Selection", "Selection")
                        .WithMany("Coaches")
                        .HasForeignKey("SelectionID");

                    b.HasOne("BasketballClub_Rest.Domain.User", null)
                        .WithOne()
                        .HasForeignKey("BasketballClub_Rest.Domain.Coach", "UserID")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();

                    b.Navigation("Selection");
                });

            modelBuilder.Entity("BasketballClub_Rest.Domain.Selection", b =>
                {
                    b.Navigation("Coaches");

                    b.Navigation("Players");

                    b.Navigation("Trainings");
                });
#pragma warning restore 612, 618
        }
    }
}
