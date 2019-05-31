using Microsoft.EntityFrameworkCore.Migrations;

namespace ACE_it.Migrations
{
    public partial class UpdateComments : Migration
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
                values: new object[] { "28a7a130-d1e1-4b81-ba5a-69f01ac652bf", "AQAAAAEAACcQAAAAECUgeXgZao2eO3DNrM8zfbeRGtAWIXaGr3H33RPRZO5hcpSMh16THU6j9IuQe9QZ+A==" });

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
                values: new object[] { "b0a8bd6d-5cfd-430e-accb-54ab2f1b781d", "AQAAAAEAACcQAAAAEDvA/vxz/jxdfqOQafEHOr577j3EA1p9+Ti9XYjSJFuvM0vpPCXX2c77lB1/6Qm7Mg==" });

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
