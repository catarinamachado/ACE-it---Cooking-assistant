using Microsoft.EntityFrameworkCore.Migrations;

namespace ACE_it.Migrations
{
    public partial class UpdateDbContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFavouriteRecipe_Recipes_RecipeId",
                table: "UserFavouriteRecipe");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFavouriteRecipe_AspNetUsers_UserId",
                table: "UserFavouriteRecipe");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFavouriteRecipe",
                table: "UserFavouriteRecipe");

            migrationBuilder.RenameTable(
                name: "UserFavouriteRecipe",
                newName: "UserFavouriteRecipes");

            migrationBuilder.RenameIndex(
                name: "IX_UserFavouriteRecipe_RecipeId",
                table: "UserFavouriteRecipes",
                newName: "IX_UserFavouriteRecipes_RecipeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFavouriteRecipes",
                table: "UserFavouriteRecipes",
                columns: new[] { "UserId", "RecipeId" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9c560e31-5fd0-4333-8047-c98b277a68a6", "AQAAAAEAACcQAAAAEH+8EgUtEoYnKwi77+hrlqO8uko7JhWA6G8SpfA4s//8k6IriPqyQoApfaLxGgW1vw==" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavouriteRecipes_Recipes_RecipeId",
                table: "UserFavouriteRecipes",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavouriteRecipes_AspNetUsers_UserId",
                table: "UserFavouriteRecipes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFavouriteRecipes_Recipes_RecipeId",
                table: "UserFavouriteRecipes");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFavouriteRecipes_AspNetUsers_UserId",
                table: "UserFavouriteRecipes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFavouriteRecipes",
                table: "UserFavouriteRecipes");

            migrationBuilder.RenameTable(
                name: "UserFavouriteRecipes",
                newName: "UserFavouriteRecipe");

            migrationBuilder.RenameIndex(
                name: "IX_UserFavouriteRecipes_RecipeId",
                table: "UserFavouriteRecipe",
                newName: "IX_UserFavouriteRecipe_RecipeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFavouriteRecipe",
                table: "UserFavouriteRecipe",
                columns: new[] { "UserId", "RecipeId" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c0b374bf-2ed2-49ea-8f90-f10163d223ad", "AQAAAAEAACcQAAAAEBFyoRh0vLVbMxscQhNMJZON8PO/dJ5iQjifAbdRRLW0lWOO9HwbtpQlmq0fgZFUcQ==" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavouriteRecipe_Recipes_RecipeId",
                table: "UserFavouriteRecipe",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavouriteRecipe_AspNetUsers_UserId",
                table: "UserFavouriteRecipe",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
