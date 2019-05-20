using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ACE_it.Migrations
{
    public partial class UpdateUserWillPrepareRecipes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserWillPrepareRecipe_Recipes_RecipeId",
                table: "UserWillPrepareRecipe");

            migrationBuilder.DropForeignKey(
                name: "FK_UserWillPrepareRecipe_AspNetUsers_UserId",
                table: "UserWillPrepareRecipe");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserWillPrepareRecipe",
                table: "UserWillPrepareRecipe");

            migrationBuilder.RenameTable(
                name: "UserWillPrepareRecipe",
                newName: "UserWillPrepareRecipes");

            migrationBuilder.RenameIndex(
                name: "IX_UserWillPrepareRecipe_RecipeId",
                table: "UserWillPrepareRecipes",
                newName: "IX_UserWillPrepareRecipes_RecipeId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserWillPrepareRecipes",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserWillPrepareRecipes",
                table: "UserWillPrepareRecipes",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "cb611e9c-d0eb-4490-aed7-b68d6a3c2ab8", "AQAAAAEAACcQAAAAEF/MhunZmqaMXEgxPTOs3PDG99esPpKJX8paYtHNs1QmSEQ2+R/PcDJIQjgHDbPrAg==" });

            migrationBuilder.CreateIndex(
                name: "IX_UserWillPrepareRecipes_UserId",
                table: "UserWillPrepareRecipes",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserWillPrepareRecipes_Recipes_RecipeId",
                table: "UserWillPrepareRecipes",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserWillPrepareRecipes_AspNetUsers_UserId",
                table: "UserWillPrepareRecipes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserWillPrepareRecipes_Recipes_RecipeId",
                table: "UserWillPrepareRecipes");

            migrationBuilder.DropForeignKey(
                name: "FK_UserWillPrepareRecipes_AspNetUsers_UserId",
                table: "UserWillPrepareRecipes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserWillPrepareRecipes",
                table: "UserWillPrepareRecipes");

            migrationBuilder.DropIndex(
                name: "IX_UserWillPrepareRecipes_UserId",
                table: "UserWillPrepareRecipes");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserWillPrepareRecipes");

            migrationBuilder.RenameTable(
                name: "UserWillPrepareRecipes",
                newName: "UserWillPrepareRecipe");

            migrationBuilder.RenameIndex(
                name: "IX_UserWillPrepareRecipes_RecipeId",
                table: "UserWillPrepareRecipe",
                newName: "IX_UserWillPrepareRecipe_RecipeId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_UserWillPrepareRecipe_Recipes_RecipeId",
                table: "UserWillPrepareRecipe",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserWillPrepareRecipe_AspNetUsers_UserId",
                table: "UserWillPrepareRecipe",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
