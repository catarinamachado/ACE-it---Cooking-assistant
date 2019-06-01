using Microsoft.EntityFrameworkCore.Migrations;

namespace ACE_it.Migrations
{
    public partial class UpdateDBComments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_UserCompletedRecipes_UserCompletedRecipeId",
                table: "Comment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comment",
                table: "Comment");

            migrationBuilder.RenameTable(
                name: "Comment",
                newName: "Comments");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_UserCompletedRecipeId",
                table: "Comments",
                newName: "IX_Comments_UserCompletedRecipeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1f61ed16-06ea-4e36-a392-01b47e4742e0", "AQAAAAEAACcQAAAAEHllyBtsUkjEvpWa5kU3GKSWlisxkiJC6T5kXBSLlY9E+PVp0yZPq/yvB26gIX39+g==" });

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_UserCompletedRecipes_UserCompletedRecipeId",
                table: "Comments",
                column: "UserCompletedRecipeId",
                principalTable: "UserCompletedRecipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_UserCompletedRecipes_UserCompletedRecipeId",
                table: "Comments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "Comment");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_UserCompletedRecipeId",
                table: "Comment",
                newName: "IX_Comment_UserCompletedRecipeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comment",
                table: "Comment",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "89c732b6-5055-47e4-a9dd-5ac3d1a63801", "AQAAAAEAACcQAAAAEBAKXGEkNR0dRVN2NMZjf3jy6SRrOTuXjjZvtxucXweZ45vu+pbkhnF1t55nV8Spkg==" });

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_UserCompletedRecipes_UserCompletedRecipeId",
                table: "Comment",
                column: "UserCompletedRecipeId",
                principalTable: "UserCompletedRecipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
