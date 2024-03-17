﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PokemonAPI.DAL;

#nullable disable

namespace PokemonAPI.DAL.Migrations
{
    [DbContext(typeof(DbContext))]
    [Migration("20240316082837_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("PokemonAPI.DAL.Entities.Ability", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AbilityName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("PokemonId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PokemonId");

                    b.ToTable("Abilities");
                });

            modelBuilder.Entity("PokemonAPI.DAL.Entities.Breeding", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Height")
                        .HasColumnType("integer");

                    b.Property<int>("PokemonId")
                        .HasColumnType("integer");

                    b.Property<int>("Weight")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PokemonId")
                        .IsUnique();

                    b.ToTable("Breedings");
                });

            modelBuilder.Entity("PokemonAPI.DAL.Entities.Move", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("MoveName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("PokemonId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PokemonId");

                    b.ToTable("Moves");
                });

            modelBuilder.Entity("PokemonAPI.DAL.Entities.Pokemon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Name");

                    b.ToTable("Pokemons");
                });

            modelBuilder.Entity("PokemonAPI.DAL.Entities.Stat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("PokemonId")
                        .HasColumnType("integer");

                    b.Property<string>("StatName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<int>("StatValue")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PokemonId");

                    b.ToTable("Stats");
                });

            modelBuilder.Entity("PokemonAPI.DAL.Entities.Type", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("PokemonId")
                        .HasColumnType("integer");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.HasIndex("PokemonId");

                    b.ToTable("Types");
                });

            modelBuilder.Entity("PokemonAPI.DAL.Entities.Ability", b =>
                {
                    b.HasOne("PokemonAPI.DAL.Entities.Pokemon", "Pokemon")
                        .WithMany("Abilities")
                        .HasForeignKey("PokemonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pokemon");
                });

            modelBuilder.Entity("PokemonAPI.DAL.Entities.Breeding", b =>
                {
                    b.HasOne("PokemonAPI.DAL.Entities.Pokemon", "Pokemon")
                        .WithOne("Breeding")
                        .HasForeignKey("PokemonAPI.DAL.Entities.Breeding", "PokemonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pokemon");
                });

            modelBuilder.Entity("PokemonAPI.DAL.Entities.Move", b =>
                {
                    b.HasOne("PokemonAPI.DAL.Entities.Pokemon", "Pokemon")
                        .WithMany("Moves")
                        .HasForeignKey("PokemonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pokemon");
                });

            modelBuilder.Entity("PokemonAPI.DAL.Entities.Stat", b =>
                {
                    b.HasOne("PokemonAPI.DAL.Entities.Pokemon", "Pokemon")
                        .WithMany("Stats")
                        .HasForeignKey("PokemonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pokemon");
                });

            modelBuilder.Entity("PokemonAPI.DAL.Entities.Type", b =>
                {
                    b.HasOne("PokemonAPI.DAL.Entities.Pokemon", "Pokemon")
                        .WithMany("Types")
                        .HasForeignKey("PokemonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pokemon");
                });

            modelBuilder.Entity("PokemonAPI.DAL.Entities.Pokemon", b =>
                {
                    b.Navigation("Abilities");

                    b.Navigation("Breeding")
                        .IsRequired();

                    b.Navigation("Moves");

                    b.Navigation("Stats");

                    b.Navigation("Types");
                });
#pragma warning restore 612, 618
        }
    }
}
