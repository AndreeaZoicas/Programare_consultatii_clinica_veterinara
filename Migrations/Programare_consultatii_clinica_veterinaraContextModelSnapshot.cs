﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Programare_consultatii_clinica_veterinara.Data;

#nullable disable

namespace Programare_consultatii_clinica_veterinara.Migrations
{
    [DbContext(typeof(Programare_consultatii_clinica_veterinaraContext))]
    partial class Programare_consultatii_clinica_veterinaraContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Programare_consultatii_clinica_veterinara.Models.Consultatie", b =>
                {
                    b.Property<int>("ConsultatieID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ConsultatieID"));

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<int>("MedicID")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("Ora")
                        .HasColumnType("time");

                    b.Property<int>("PacientID")
                        .HasColumnType("int");

                    b.HasKey("ConsultatieID");

                    b.HasIndex("MedicID");

                    b.HasIndex("PacientID");

                    b.ToTable("Consultatie");
                });

            modelBuilder.Entity("Programare_consultatii_clinica_veterinara.Models.Medic", b =>
                {
                    b.Property<int>("MedicID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MedicID"));

                    b.Property<int>("ExperientaAni")
                        .HasColumnType("int");

                    b.Property<string>("Nume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Specializare")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MedicID");

                    b.ToTable("Medic");
                });

            modelBuilder.Entity("Programare_consultatii_clinica_veterinara.Models.Pacient", b =>
                {
                    b.Property<int>("PacientID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PacientID"));

                    b.Property<DateTime>("DataNasterii")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProprietarID")
                        .HasColumnType("int");

                    b.Property<string>("Rasa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Specie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PacientID");

                    b.HasIndex("ProprietarID");

                    b.ToTable("Pacient");
                });

            modelBuilder.Entity("Programare_consultatii_clinica_veterinara.Models.Proprietar", b =>
                {
                    b.Property<int>("ProprietarID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProprietarID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProprietarID");

                    b.ToTable("Proprietar");
                });

            modelBuilder.Entity("Programare_consultatii_clinica_veterinara.Models.Recenzie", b =>
                {
                    b.Property<int>("RecenzieID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RecenzieID"));

                    b.Property<string>("Comentariu")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MedicID")
                        .HasColumnType("int");

                    b.Property<int>("PacientID")
                        .HasColumnType("int");

                    b.Property<int>("Scor")
                        .HasColumnType("int");

                    b.HasKey("RecenzieID");

                    b.HasIndex("MedicID");

                    b.HasIndex("PacientID");

                    b.ToTable("Recenzie");
                });

            modelBuilder.Entity("Programare_consultatii_clinica_veterinara.Models.Consultatie", b =>
                {
                    b.HasOne("Programare_consultatii_clinica_veterinara.Models.Medic", "Medic")
                        .WithMany("Consultatii")
                        .HasForeignKey("MedicID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Programare_consultatii_clinica_veterinara.Models.Pacient", "Pacient")
                        .WithMany()
                        .HasForeignKey("PacientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medic");

                    b.Navigation("Pacient");
                });

            modelBuilder.Entity("Programare_consultatii_clinica_veterinara.Models.Pacient", b =>
                {
                    b.HasOne("Programare_consultatii_clinica_veterinara.Models.Proprietar", "Proprietar")
                        .WithMany("Pacienti")
                        .HasForeignKey("ProprietarID");

                    b.Navigation("Proprietar");
                });

            modelBuilder.Entity("Programare_consultatii_clinica_veterinara.Models.Recenzie", b =>
                {
                    b.HasOne("Programare_consultatii_clinica_veterinara.Models.Medic", "Medic")
                        .WithMany()
                        .HasForeignKey("MedicID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Programare_consultatii_clinica_veterinara.Models.Pacient", "Pacient")
                        .WithMany()
                        .HasForeignKey("PacientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Medic");

                    b.Navigation("Pacient");
                });

            modelBuilder.Entity("Programare_consultatii_clinica_veterinara.Models.Medic", b =>
                {
                    b.Navigation("Consultatii");
                });

            modelBuilder.Entity("Programare_consultatii_clinica_veterinara.Models.Proprietar", b =>
                {
                    b.Navigation("Pacienti");
                });
#pragma warning restore 612, 618
        }
    }
}
