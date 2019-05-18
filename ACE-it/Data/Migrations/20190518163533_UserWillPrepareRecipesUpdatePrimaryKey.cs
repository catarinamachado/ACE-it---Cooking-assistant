using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ACE_it.Migrations
{
    public partial class UserWillPrepareRecipesUpdatePrimaryKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserWillPrepareRecipe",
                table: "UserWillPrepareRecipe");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserWillPrepareRecipe",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserWillPrepareRecipe",
                table: "UserWillPrepareRecipe",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "27fc3db2-9105-49ce-8270-7b8f2ff4bb76", "AQAAAAEAACcQAAAAEAipQfaFuREHdeg3oTTrObsKodzfuT3pzboVfSNeiXeteZFf+ZYFg06cE8FQ6L0/Ng==" });

            migrationBuilder.CreateIndex(
                name: "IX_UserWillPrepareRecipe_UserId",
                table: "UserWillPrepareRecipe",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserWillPrepareRecipe",
                table: "UserWillPrepareRecipe");

            migrationBuilder.DropIndex(
                name: "IX_UserWillPrepareRecipe_UserId",
                table: "UserWillPrepareRecipe");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserWillPrepareRecipe");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserWillPrepareRecipe",
                table: "UserWillPrepareRecipe",
                columns: new[] { "UserId", "RecipeId" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9c560e31-5fd0-4333-8047-c98b277a68a6", "AQAAAAEAACcQAAAAEH+8EgUtEoYnKwi77+hrlqO8uko7JhWA6G8SpfA4s//8k6IriPqyQoApfaLxGgW1vw==" });
        }
    }
}
