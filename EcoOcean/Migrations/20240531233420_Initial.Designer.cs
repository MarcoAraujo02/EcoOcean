﻿// <auto-generated />
using System;
using EcoOcean.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace EcoOcean.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240531233420_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EcoOcean.Models.Administrador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("Email");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("Password");

                    b.HasKey("Id");

                    b.ToTable("Administrador");
                });

            modelBuilder.Entity("EcoOcean.Models.Area", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("Cep");

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("Cidade");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("Descricao");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("Estado");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("Rua");

                    b.HasKey("Id");

                    b.ToTable("Area");
                });

            modelBuilder.Entity("EcoOcean.Models.Coleta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<float>("Quantidade")
                        .HasColumnType("BINARY_FLOAT")
                        .HasColumnName("Quantidade");

                    b.Property<string>("TipoDoLixo")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("Tipo_Do_Lixo");

                    b.HasKey("Id");

                    b.ToTable("Coleta");
                });

            modelBuilder.Entity("EcoOcean.Models.Evento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AdministradorId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("AreaId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<DateTime?>("DataFim")
                        .IsRequired()
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("Data_fim");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("Data_Inicio");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("Status");

                    b.HasKey("Id");

                    b.HasIndex("AdministradorId");

                    b.HasIndex("AreaId");

                    b.ToTable("Evento");
                });

            modelBuilder.Entity("EcoOcean.Models.Voluntario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("Data_Nascimento");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("Email");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("Nome");

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("Sexo");

                    b.HasKey("Id");

                    b.ToTable("Voluntario");
                });

            modelBuilder.Entity("EventoVoluntario", b =>
                {
                    b.Property<int>("EventosId")
                        .HasColumnType("NUMBER(10)");

                    b.Property<int>("VoluntariosId")
                        .HasColumnType("NUMBER(10)");

                    b.HasKey("EventosId", "VoluntariosId");

                    b.HasIndex("VoluntariosId");

                    b.ToTable("EventoVoluntario");
                });

            modelBuilder.Entity("EcoOcean.Models.Evento", b =>
                {
                    b.HasOne("EcoOcean.Models.Administrador", "Administrador")
                        .WithMany("Eventos")
                        .HasForeignKey("AdministradorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EcoOcean.Models.Area", "Area")
                        .WithMany("Eventos")
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Administrador");

                    b.Navigation("Area");
                });

            modelBuilder.Entity("EventoVoluntario", b =>
                {
                    b.HasOne("EcoOcean.Models.Evento", null)
                        .WithMany()
                        .HasForeignKey("EventosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EcoOcean.Models.Voluntario", null)
                        .WithMany()
                        .HasForeignKey("VoluntariosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EcoOcean.Models.Administrador", b =>
                {
                    b.Navigation("Eventos");
                });

            modelBuilder.Entity("EcoOcean.Models.Area", b =>
                {
                    b.Navigation("Eventos");
                });
#pragma warning restore 612, 618
        }
    }
}
