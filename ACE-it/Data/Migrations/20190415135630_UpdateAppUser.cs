using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ACE_it.Migrations
{
    public partial class UpdateAppUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCompletedRecipes",
                table: "UserCompletedRecipes");

            migrationBuilder.DropColumn(
                name: "Reaction",
                table: "UserCompletedRecipes");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "UserCompletedRecipes",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AlterColumn<int>(
                name: "NumberOfCoupons",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Difficulty",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfVisits",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCompletedRecipes",
                table: "UserCompletedRecipes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "UserReactedToRecipes",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RecipeId = table.Column<int>(nullable: false),
                    Reaction = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserReactedToRecipes", x => new { x.UserId, x.RecipeId });
                    table.ForeignKey(
                        name: "FK_UserReactedToRecipes_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserReactedToRecipes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "BirthDate", "ConcurrencyStamp", "Difficulty", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "NumberOfCoupons", "NumberOfVisits", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "cac07695-acf1-448b-b896-c14112e6f732", 0, "user@aceit.com", true, false, null, "user@aceit.com", "user@aceit.com", 0, 0, "AQAAAAEAACcQAAAAEDMHs4MOYZRFQVdRV/W8g2RrnLAN01+RVwqgRT8ySfi3gg7ymsRx/hVXcRbRWVMahA==", null, false, "", false, "user@aceit.com" });

            migrationBuilder.InsertData(
                table: "UserCompletedRecipes",
                columns: new[] { "Id", "Difficulties", "Duration", "RecipeId", "UserId" },
                values: new object[,]
                {
                    { 1, "none", 1000, 1, "1" },
                    { 2, "none", 1000, 1, "1" },
                    { 3, "cooking point", 500, 2, "1" }
                });

            migrationBuilder.InsertData(
                table: "UserReactedToRecipes",
                columns: new[] { "UserId", "RecipeId", "Reaction" },
                values: new object[,]
                {
                    { "1", 1, 0 },
                    { "1", 2, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserCompletedRecipes_UserId",
                table: "UserCompletedRecipes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserReactedToRecipes_RecipeId",
                table: "UserReactedToRecipes",
                column: "RecipeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserReactedToRecipes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCompletedRecipes",
                table: "UserCompletedRecipes");

            migrationBuilder.DropIndex(
                name: "IX_UserCompletedRecipes_UserId",
                table: "UserCompletedRecipes");

            migrationBuilder.DeleteData(
                table: "UserCompletedRecipes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserCompletedRecipes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "UserCompletedRecipes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserCompletedRecipes");

            migrationBuilder.DropColumn(
                name: "NumberOfVisits",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "Reaction",
                table: "UserCompletedRecipes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "NumberOfCoupons",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "Difficulty",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCompletedRecipes",
                table: "UserCompletedRecipes",
                columns: new[] { "UserId", "RecipeId" });
        }
    }
}
