using Microsoft.EntityFrameworkCore.Migrations;

namespace LibraryWebApp.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CountryName = table.Column<string>(nullable: true),
                    IsOriginal = table.Column<bool>(nullable: false),
                    CityName = table.Column<string>(nullable: true),
                    Year = table.Column<int>(nullable: false),
                    PageAmount = table.Column<int>(nullable: false),
                    Authors = table.Column<string>(nullable: true),
                    Udk = table.Column<string>(nullable: true),
                    Editors = table.Column<string>(nullable: true),
                    Bbk = table.Column<string>(nullable: true),
                    Isbn = table.Column<string>(nullable: true),
                    PublishingOfficeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dissertations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CountryName = table.Column<string>(nullable: true),
                    IsOriginal = table.Column<bool>(nullable: false),
                    CityName = table.Column<string>(nullable: true),
                    Year = table.Column<int>(nullable: false),
                    PageAmount = table.Column<int>(nullable: false),
                    Authors = table.Column<string>(nullable: true),
                    Udk = table.Column<string>(nullable: true),
                    Institution = table.Column<string>(nullable: true),
                    AcademicAdviser = table.Column<string>(nullable: true),
                    ScientificSpecialtiy = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dissertations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Magazines",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CountryName = table.Column<string>(nullable: true),
                    IsOriginal = table.Column<bool>(nullable: false),
                    CityName = table.Column<string>(nullable: true),
                    Year = table.Column<int>(nullable: false),
                    PageAmount = table.Column<int>(nullable: false),
                    Number = table.Column<int>(nullable: false),
                    Issn = table.Column<string>(nullable: true),
                    RubricatorName = table.Column<string>(nullable: true),
                    IsIncludedInWebOfScience = table.Column<bool>(nullable: false),
                    IsIncludedVak = table.Column<bool>(nullable: false),
                    InclusionInformationInRints = table.Column<string>(nullable: true),
                    InclusionInformationInScopus = table.Column<string>(nullable: true),
                    PublishingOfficeName = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Magazines", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SynopsisOfThesises",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CountryName = table.Column<string>(nullable: true),
                    IsOriginal = table.Column<bool>(nullable: false),
                    CityName = table.Column<string>(nullable: true),
                    Year = table.Column<int>(nullable: false),
                    PageAmount = table.Column<int>(nullable: false),
                    Authors = table.Column<string>(nullable: true),
                    Udk = table.Column<string>(nullable: true),
                    DissertationId = table.Column<int>(nullable: true),
                    Institution = table.Column<string>(nullable: true),
                    AcademicAdviser = table.Column<string>(nullable: true),
                    ScientificSpeciality = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SynopsisOfThesises", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SynopsisOfThesises_Dissertations_DissertationId",
                        column: x => x.DissertationId,
                        principalTable: "Dissertations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    MagazineId = table.Column<int>(nullable: true),
                    Authors = table.Column<string>(nullable: true),
                    PageFrom = table.Column<int>(nullable: false),
                    PageTo = table.Column<int>(nullable: false),
                    Udk = table.Column<string>(nullable: true),
                    IsOriginal = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Articles_Magazines_MagazineId",
                        column: x => x.MagazineId,
                        principalTable: "Magazines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articles_MagazineId",
                table: "Articles",
                column: "MagazineId");

            migrationBuilder.CreateIndex(
                name: "IX_SynopsisOfThesises_DissertationId",
                table: "SynopsisOfThesises",
                column: "DissertationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "SynopsisOfThesises");

            migrationBuilder.DropTable(
                name: "Magazines");

            migrationBuilder.DropTable(
                name: "Dissertations");
        }
    }
}
