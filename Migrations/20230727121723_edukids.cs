using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

namespace ProyectoFinal_23AM.Migrations
{
    public partial class edukids : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "grados",
                columns: table => new
                {
                    PkGrado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Grado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grados", x => x.PkGrado);
                });

            migrationBuilder.CreateTable(
                name: "materias",
                columns: table => new
                {
                    PkMateria = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Materia = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_materias", x => x.PkMateria);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    PkRol = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.PkRol);
                });

            migrationBuilder.CreateTable(
                name: "alumnos",
                columns: table => new
                {
                    PkMatricula = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    FkGrado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_alumnos", x => x.PkMatricula);
                    table.ForeignKey(
                        name: "FK_alumnos_grados_FkGrado",
                        column: x => x.FkGrado,
                        principalTable: "grados",
                        principalColumn: "PkGrado",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    PkUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    FkRol = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.PkUsuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_Roles_FkRol",
                        column: x => x.FkRol,
                        principalTable: "Roles",
                        principalColumn: "PkRol",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "calificaciones",
                columns: table => new
                {
                    PkCalificaciones = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Calificación = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    FkMateria = table.Column<int>(type: "int", nullable: false),
                    FkGrado = table.Column<int>(type: "int", nullable: false),
                    FkMatricula = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_calificaciones", x => x.PkCalificaciones);
                    table.ForeignKey(
                        name: "FK_calificaciones_alumnos_FkMatricula",
                        column: x => x.FkMatricula,
                        principalTable: "alumnos",
                        principalColumn: "PkMatricula",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_calificaciones_grados_FkGrado",
                        column: x => x.FkGrado,
                        principalTable: "grados",
                        principalColumn: "PkGrado",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_calificaciones_materias_FkMateria",
                        column: x => x.FkMateria,
                        principalTable: "materias",
                        principalColumn: "PkMateria",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "observaciones",
                columns: table => new
                {
                    PkObervaciones = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Observación = table.Column<string>(type: "text", nullable: false),
                    FkMatricula = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_observaciones", x => x.PkObervaciones);
                    table.ForeignKey(
                        name: "FK_observaciones_alumnos_FkMatricula",
                        column: x => x.FkMatricula,
                        principalTable: "alumnos",
                        principalColumn: "PkMatricula",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_alumnos_FkGrado",
                table: "alumnos",
                column: "FkGrado");

            migrationBuilder.CreateIndex(
                name: "IX_calificaciones_FkGrado",
                table: "calificaciones",
                column: "FkGrado");

            migrationBuilder.CreateIndex(
                name: "IX_calificaciones_FkMateria",
                table: "calificaciones",
                column: "FkMateria");

            migrationBuilder.CreateIndex(
                name: "IX_calificaciones_FkMatricula",
                table: "calificaciones",
                column: "FkMatricula");

            migrationBuilder.CreateIndex(
                name: "IX_observaciones_FkMatricula",
                table: "observaciones",
                column: "FkMatricula");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_FkRol",
                table: "Usuarios",
                column: "FkRol");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "calificaciones");

            migrationBuilder.DropTable(
                name: "observaciones");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "materias");

            migrationBuilder.DropTable(
                name: "alumnos");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "grados");
        }
    }
}
