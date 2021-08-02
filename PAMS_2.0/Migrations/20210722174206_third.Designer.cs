﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PAMS_2._0.Data;

namespace PAMS_2._0.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20210722174206_third")]
    partial class third
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PAMS_2._0.Models.Edicion", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("fecha")
                        .HasColumnType("int");

                    b.Property<int>("idUsuario")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Edicion");
                });

            modelBuilder.Entity("PAMS_2._0.Models.Logistica.Almacen", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Almacen");
                });

            modelBuilder.Entity("PAMS_2._0.Models.Logistica.AlmacenProducto", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("idAlmacen")
                        .HasColumnType("int");

                    b.Property<int>("idProducto")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("AlmacenProducto");
                });

            modelBuilder.Entity("PAMS_2._0.Models.Logistica.Cita", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("fecha")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("hora")
                        .HasColumnType("datetime2");

                    b.Property<int>("idPaciente")
                        .HasColumnType("int");

                    b.Property<int>("idUsuario")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Cita");
                });

            modelBuilder.Entity("PAMS_2._0.Models.Logistica.Producto", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("costoUnitario")
                        .HasColumnType("float");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("sku")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("stock")
                        .HasColumnType("int");

                    b.Property<string>("unidad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Producto");
                });

            modelBuilder.Entity("PAMS_2._0.Models.Paciente", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("actividadExtra")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("asunto")
                        .HasColumnType("int");

                    b.Property<string>("direccion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("escolaridad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("fechaRegistro")
                        .HasColumnType("datetime2");

                    b.Property<byte[]>("foto")
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime>("nacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ocupacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("religion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("servicio")
                        .HasColumnType("int");

                    b.Property<string>("telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Paciente");
                });

            modelBuilder.Entity("PAMS_2._0.Models.Psicologia.AntecedentesClinicos", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Patologico")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("idPaciente")
                        .HasColumnType("int");

                    b.Property<string>("psicologico")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("psiquiatrico")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("AntecedentesClinicos");
                });

            modelBuilder.Entity("PAMS_2._0.Models.Psicologia.AntecedentesFamiliares", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("accidentes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("dispAuxiliar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("enfermedadGrave")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("idPaciente")
                        .HasColumnType("int");

                    b.Property<string>("intervencionQuirurgica")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("medicamentos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("AntecedentesFamiliares");
                });

            modelBuilder.Entity("PAMS_2._0.Models.Psicologia.CirculoSocial", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("idPaciente")
                        .HasColumnType("int");

                    b.Property<string>("laboral")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("social")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("vivienda")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("CirculoSocial");
                });

            modelBuilder.Entity("PAMS_2._0.Models.Psicologia.EstadoMental", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("emocional")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("higiene")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("idPaciente")
                        .HasColumnType("int");

                    b.Property<string>("lenguaje")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("realidad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("EstadoMental");
                });

            modelBuilder.Entity("PAMS_2._0.Models.Psicologia.Familiares", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("apellido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("idPaciente")
                        .HasColumnType("int");

                    b.Property<DateTime>("nacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ocupacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("parentesco")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Familiares");
                });

            modelBuilder.Entity("PAMS_2._0.Models.Psicologia.Habitos", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("alimento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("antPsicologicos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("dream")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("idPaciente")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.ToTable("Habitos");
                });

            modelBuilder.Entity("PAMS_2._0.Models.Psicologia.HistorialSexual", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("abuso")
                        .HasColumnType("bit");

                    b.Property<int>("edad")
                        .HasColumnType("int");

                    b.Property<bool>("embarazo")
                        .HasColumnType("bit");

                    b.Property<int>("idPaciente")
                        .HasColumnType("int");

                    b.Property<int>("preferenciaSexual")
                        .HasColumnType("int");

                    b.Property<bool>("traumas")
                        .HasColumnType("bit");

                    b.HasKey("id");

                    b.ToTable("HistorialSexual");
                });

            modelBuilder.Entity("PAMS_2._0.Models.Psicologia.Problema", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("acciones")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("causas")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("evolucion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("idPaciente")
                        .HasColumnType("int");

                    b.Property<string>("implicaciones")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Problema");
                });

            modelBuilder.Entity("PAMS_2._0.Models.Psicologia.ReporteSesion", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("diagnostico")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("idPaciente")
                        .HasColumnType("int");

                    b.Property<string>("objetivoClinico")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("observaciones")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("ReporteSesion");
                });

            modelBuilder.Entity("PAMS_2._0.Models.Usuario", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("apellido")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("foto")
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime>("nacimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("rol")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("telefono")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Usuario");
                });
#pragma warning restore 612, 618
        }
    }
}
