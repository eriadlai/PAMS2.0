using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PAMS_2._0.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Almacen",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Almacen", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AlmacenProducto",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idAlmacen = table.Column<int>(type: "int", nullable: false),
                    idProducto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlmacenProducto", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AntecedentesClinicos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idPaciente = table.Column<int>(type: "int", nullable: false),
                    psicologico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    psiquiatrico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Patologico = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AntecedentesClinicos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "AntecedentesFamiliares",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idPaciente = table.Column<int>(type: "int", nullable: false),
                    enfermedadGrave = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    accidentes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    medicamentos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    intervencionQuirurgica = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dispAuxiliar = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AntecedentesFamiliares", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CirculoSocial",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idPaciente = table.Column<int>(type: "int", nullable: false),
                    social = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    laboral = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    vivienda = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CirculoSocial", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Cita",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    hora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    idPaciente = table.Column<int>(type: "int", nullable: false),
                    idUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cita", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Edicion",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idUsuario = table.Column<int>(type: "int", nullable: false),
                    fecha = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Edicion", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "EstadoMental",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idPaciente = table.Column<int>(type: "int", nullable: false),
                    lenguaje = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    emocional = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    realidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    higiene = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoMental", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Familiares",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idPaciente = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    parentesco = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ocupacion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Familiares", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Habitos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idPaciente = table.Column<int>(type: "int", nullable: false),
                    dream = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    alimento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    antPsicologicos = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Habitos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "HistorialSexual",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idPaciente = table.Column<int>(type: "int", nullable: false),
                    abuso = table.Column<bool>(type: "bit", nullable: false),
                    embarazo = table.Column<bool>(type: "bit", nullable: false),
                    edad = table.Column<int>(type: "int", nullable: false),
                    preferenciaSexual = table.Column<int>(type: "int", nullable: false),
                    traumas = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistorialSexual", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    foto = table.Column<byte>(type: "tinyint", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    apellido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    escolaridad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    religion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ocupacion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    actividadExtra = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    servicio = table.Column<int>(type: "int", nullable: false),
                    asunto = table.Column<int>(type: "int", nullable: false),
                    fechaRegistro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Problema",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idPaciente = table.Column<int>(type: "int", nullable: false),
                    evolucion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    causas = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    acciones = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    implicaciones = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Problema", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    unidad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    costoUnitario = table.Column<double>(type: "float", nullable: false),
                    stock = table.Column<int>(type: "int", nullable: false),
                    sku = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ReporteSesion",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idPaciente = table.Column<int>(type: "int", nullable: false),
                    diagnostico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    observaciones = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    objetivoClinico = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReporteSesion", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    foto = table.Column<byte>(type: "tinyint", nullable: false),
                    telefono = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    nacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    apellido = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    rol = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Almacen");

            migrationBuilder.DropTable(
                name: "AlmacenProducto");

            migrationBuilder.DropTable(
                name: "AntecedentesClinicos");

            migrationBuilder.DropTable(
                name: "AntecedentesFamiliares");

            migrationBuilder.DropTable(
                name: "CirculoSocial");

            migrationBuilder.DropTable(
                name: "Cita");

            migrationBuilder.DropTable(
                name: "Edicion");

            migrationBuilder.DropTable(
                name: "EstadoMental");

            migrationBuilder.DropTable(
                name: "Familiares");

            migrationBuilder.DropTable(
                name: "Habitos");

            migrationBuilder.DropTable(
                name: "HistorialSexual");

            migrationBuilder.DropTable(
                name: "Paciente");

            migrationBuilder.DropTable(
                name: "Problema");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "ReporteSesion");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
