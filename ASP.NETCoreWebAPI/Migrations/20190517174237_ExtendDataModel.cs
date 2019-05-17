using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ASP.NETCoreWebAPI.Migrations
{
    public partial class ExtendDataModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 255, nullable: false),
                    Description = table.Column<string>(maxLength: 2000, nullable: false),
                    Level = table.Column<int>(nullable: false),
                    FullPrice = table.Column<float>(nullable: false),
                    AuthorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Courses_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CourseCovers",
                columns: table => new
                {
                    CourseCoverId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CoverOfCourseId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseCovers", x => x.CourseCoverId);
                    table.ForeignKey(
                        name: "FK_CourseCovers_Courses_CoverOfCourseId",
                        column: x => x.CoverOfCourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseTags",
                columns: table => new
                {
                    CourseId = table.Column<int>(nullable: false),
                    TagId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseTags", x => new { x.CourseId, x.TagId });
                    table.ForeignKey(
                        name: "FK_CourseTags_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Mosh Hamedani" },
                    { 2, "Anthony Alicea" },
                    { 3, "Eric Wise" },
                    { 4, "Tom Owsiak" },
                    { 5, "John Smith" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "C#" },
                    { 2, "Angular" },
                    { 3, "JavaScript" },
                    { 4, "NodeJs" },
                    { 5, "OOP" },
                    { 6, "Linq" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "AuthorId", "Description", "FullPrice", "Level", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Description for C# Basics", 49f, 1, "C# Basics" },
                    { 2, 1, "Description for C# Intermediate", 49f, 2, "C# Intermediate" },
                    { 3, 1, "Description for C# Advanced", 69f, 3, "C# Advanced" },
                    { 4, 2, "Description for Javascript", 149f, 2, "Javascript: Understanding the Weird Parts" },
                    { 5, 2, "Description for AngularJS", 99f, 2, "Learn and Understand AngularJS" },
                    { 6, 2, "Description for NodeJS", 149f, 2, "Learn and Understand NodeJS" },
                    { 7, 3, "Description for Programming for Beginners", 45f, 1, "Programming for Complete Beginners" },
                    { 8, 4, "Description 16 Hour Course", 150f, 1, "A 16 Hour C# Course with Visual Studio 2013" },
                    { 9, 4, "Description Learn Javascript", 20f, 1, "Learn JavaScript Through Visual Studio 2013" }
                });

            migrationBuilder.InsertData(
                table: "CourseTags",
                columns: new[] { "CourseId", "TagId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 2, 5 },
                    { 3, 1 },
                    { 4, 3 },
                    { 5, 2 },
                    { 6, 4 },
                    { 7, 1 },
                    { 8, 1 },
                    { 9, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseCovers_CoverOfCourseId",
                table: "CourseCovers",
                column: "CoverOfCourseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_AuthorId",
                table: "Courses",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseTags_TagId",
                table: "CourseTags",
                column: "TagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseCovers");

            migrationBuilder.DropTable(
                name: "CourseTags");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
