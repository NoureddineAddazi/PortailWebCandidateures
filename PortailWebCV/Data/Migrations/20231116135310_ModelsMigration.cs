using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortailWebCV.Data.Migrations
{
    /// <inheritdoc />
    public partial class ModelsMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Candidatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prénom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Téléphone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NiveauEtude = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnnéesExpérience = table.Column<int>(type: "int", nullable: false),
                    DernierEmployeur = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FichierUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidatures", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Candidatures");
        }
    }
}
