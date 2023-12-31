﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetoBApi.Models;

#nullable disable

namespace ProjetoBApi.Migrations
{
    [DbContext(typeof(FolhaContext))]
    [Migration("20230629225407_TesteMigration")]
    partial class TesteMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.8");

            modelBuilder.Entity("ProjetoBApi.Models.FolhaCalculada", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("Ano")
                        .HasColumnType("INTEGER");

                    b.Property<double?>("Bruto")
                        .HasColumnType("REAL");

                    b.Property<double?>("Fgts")
                        .HasColumnType("REAL");

                    b.Property<string>("Funcionario")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Horas")
                        .HasColumnType("INTEGER");

                    b.Property<double?>("Inss")
                        .HasColumnType("REAL");

                    b.Property<double?>("Irrf")
                        .HasColumnType("REAL");

                    b.Property<double?>("Liquido")
                        .HasColumnType("REAL");

                    b.Property<int?>("Mes")
                        .HasColumnType("INTEGER");

                    b.Property<double?>("Valor")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Folhas");
                });
#pragma warning restore 612, 618
        }
    }
}
