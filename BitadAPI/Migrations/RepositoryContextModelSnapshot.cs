﻿// <auto-generated />
using System;
using BitadAPI.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BitadAPI.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    partial class RepositoryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("BitadAPI.Models.Agenda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("End")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("SpeakerId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Start")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("SpeakerId");

                    b.ToTable("Agendas");
                });

            modelBuilder.Entity("BitadAPI.Models.QrCode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("ActivationTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.Property<DateTime>("DeactivationTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Points")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("QrCodes");
                });

            modelBuilder.Entity("BitadAPI.Models.QrCodeRedeem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("QrCodeId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("RedeemTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("QrCodeId");

                    b.HasIndex("UserId");

                    b.ToTable("QrCodeRedeems");
                });

            modelBuilder.Entity("BitadAPI.Models.Speaker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Company")
                        .HasColumnType("text");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Picture")
                        .HasColumnType("text");

                    b.Property<string>("Website")
                        .HasColumnType("text");

                    b.Property<string>("WebsiteLink")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Speakers");
                });

            modelBuilder.Entity("BitadAPI.Models.Staff", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Picture")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Staffs");
                });

            modelBuilder.Entity("BitadAPI.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Code")
                        .HasColumnType("text");

                    b.Property<int>("CurrentScore")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("WorkshopId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("WorkshopId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BitadAPI.Models.Workshop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<int>("ParticipantsNumber")
                        .HasColumnType("integer");

                    b.Property<string>("Room")
                        .HasColumnType("text");

                    b.Property<int?>("SpeakerId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("Start")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("SpeakerId");

                    b.ToTable("Workshops");
                });

            modelBuilder.Entity("BitadAPI.Models.Agenda", b =>
                {
                    b.HasOne("BitadAPI.Models.Speaker", "Speaker")
                        .WithMany()
                        .HasForeignKey("SpeakerId");

                    b.Navigation("Speaker");
                });

            modelBuilder.Entity("BitadAPI.Models.QrCodeRedeem", b =>
                {
                    b.HasOne("BitadAPI.Models.QrCode", "QrCode")
                        .WithMany()
                        .HasForeignKey("QrCodeId");

                    b.HasOne("BitadAPI.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("QrCode");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BitadAPI.Models.User", b =>
                {
                    b.HasOne("BitadAPI.Models.Workshop", "Workshop")
                        .WithMany()
                        .HasForeignKey("WorkshopId");

                    b.Navigation("Workshop");
                });

            modelBuilder.Entity("BitadAPI.Models.Workshop", b =>
                {
                    b.HasOne("BitadAPI.Models.Speaker", "Speaker")
                        .WithMany()
                        .HasForeignKey("SpeakerId");

                    b.Navigation("Speaker");
                });
#pragma warning restore 612, 618
        }
    }
}
