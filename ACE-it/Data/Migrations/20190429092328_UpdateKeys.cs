using Microsoft.EntityFrameworkCore.Migrations;

namespace ACE_it.Migrations
{
    public partial class UpdateKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFavouriteIngredient_Ingredients_IngredientId",
                table: "UserFavouriteIngredient");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFavouriteIngredient_AspNetUsers_UserId",
                table: "UserFavouriteIngredient");

            migrationBuilder.DropForeignKey(
                name: "FK_UserUnwantedIngredient_Ingredients_IngredientId",
                table: "UserUnwantedIngredient");

            migrationBuilder.DropForeignKey(
                name: "FK_UserUnwantedIngredient_AspNetUsers_UserId",
                table: "UserUnwantedIngredient");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserUnwantedIngredient",
                table: "UserUnwantedIngredient");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFavouriteIngredient",
                table: "UserFavouriteIngredient");

            migrationBuilder.RenameTable(
                name: "UserUnwantedIngredient",
                newName: "UserUnwantedIngredients");

            migrationBuilder.RenameTable(
                name: "UserFavouriteIngredient",
                newName: "UserFavouriteIngredients");

            migrationBuilder.RenameIndex(
                name: "IX_UserUnwantedIngredient_IngredientId",
                table: "UserUnwantedIngredients",
                newName: "IX_UserUnwantedIngredients_IngredientId");

            migrationBuilder.RenameIndex(
                name: "IX_UserFavouriteIngredient_IngredientId",
                table: "UserFavouriteIngredients",
                newName: "IX_UserFavouriteIngredients_IngredientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserUnwantedIngredients",
                table: "UserUnwantedIngredients",
                columns: new[] { "UserId", "IngredientId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFavouriteIngredients",
                table: "UserFavouriteIngredients",
                columns: new[] { "UserId", "IngredientId" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "c0b374bf-2ed2-49ea-8f90-f10163d223ad", "AQAAAAEAACcQAAAAEBFyoRh0vLVbMxscQhNMJZON8PO/dJ5iQjifAbdRRLW0lWOO9HwbtpQlmq0fgZFUcQ==" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavouriteIngredients_Ingredients_IngredientId",
                table: "UserFavouriteIngredients",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavouriteIngredients_AspNetUsers_UserId",
                table: "UserFavouriteIngredients",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserUnwantedIngredients_Ingredients_IngredientId",
                table: "UserUnwantedIngredients",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserUnwantedIngredients_AspNetUsers_UserId",
                table: "UserUnwantedIngredients",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFavouriteIngredients_Ingredients_IngredientId",
                table: "UserFavouriteIngredients");

            migrationBuilder.DropForeignKey(
                name: "FK_UserFavouriteIngredients_AspNetUsers_UserId",
                table: "UserFavouriteIngredients");

            migrationBuilder.DropForeignKey(
                name: "FK_UserUnwantedIngredients_Ingredients_IngredientId",
                table: "UserUnwantedIngredients");

            migrationBuilder.DropForeignKey(
                name: "FK_UserUnwantedIngredients_AspNetUsers_UserId",
                table: "UserUnwantedIngredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserUnwantedIngredients",
                table: "UserUnwantedIngredients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserFavouriteIngredients",
                table: "UserFavouriteIngredients");

            migrationBuilder.RenameTable(
                name: "UserUnwantedIngredients",
                newName: "UserUnwantedIngredient");

            migrationBuilder.RenameTable(
                name: "UserFavouriteIngredients",
                newName: "UserFavouriteIngredient");

            migrationBuilder.RenameIndex(
                name: "IX_UserUnwantedIngredients_IngredientId",
                table: "UserUnwantedIngredient",
                newName: "IX_UserUnwantedIngredient_IngredientId");

            migrationBuilder.RenameIndex(
                name: "IX_UserFavouriteIngredients_IngredientId",
                table: "UserFavouriteIngredient",
                newName: "IX_UserFavouriteIngredient_IngredientId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserUnwantedIngredient",
                table: "UserUnwantedIngredient",
                columns: new[] { "UserId", "IngredientId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserFavouriteIngredient",
                table: "UserFavouriteIngredient",
                columns: new[] { "UserId", "IngredientId" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "cac07695-acf1-448b-b896-c14112e6f732", "AQAAAAEAACcQAAAAEDMHs4MOYZRFQVdRV/W8g2RrnLAN01+RVwqgRT8ySfi3gg7ymsRx/hVXcRbRWVMahA==" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavouriteIngredient_Ingredients_IngredientId",
                table: "UserFavouriteIngredient",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavouriteIngredient_AspNetUsers_UserId",
                table: "UserFavouriteIngredient",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserUnwantedIngredient_Ingredients_IngredientId",
                table: "UserUnwantedIngredient",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserUnwantedIngredient_AspNetUsers_UserId",
                table: "UserUnwantedIngredient",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
