using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ACE_it.Migrations
{
    public partial class UpdateRateRecipes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserCompletedRecipeId = table.Column<int>(nullable: false),
                    Text = table.Column<string>(maxLength: 120, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_UserCompletedRecipes_UserCompletedRecipeId",
                        column: x => x.UserCompletedRecipeId,
                        principalTable: "UserCompletedRecipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b0a8bd6d-5cfd-430e-accb-54ab2f1b781d", "AQAAAAEAACcQAAAAEDvA/vxz/jxdfqOQafEHOr577j3EA1p9+Ti9XYjSJFuvM0vpPCXX2c77lB1/6Qm7Mg==" });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_UserCompletedRecipeId",
                table: "Comment",
                column: "UserCompletedRecipeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9c560e31-5fd0-4333-8047-c98b277a68a6", "AQAAAAEAACcQAAAAEH+8EgUtEoYnKwi77+hrlqO8uko7JhWA6G8SpfA4s//8k6IriPqyQoApfaLxGgW1vw==" });
        }
    }
}
