using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ACE_it.Migrations
{
    public partial class AddDurationToSessionRecipe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "StartTime",
                table: "SessionRecipe",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2bf22052-29f2-445e-bb0b-0d491f54c9d4", "AQAAAAEAACcQAAAAEBaDsx47eUp4gr+KOXQ/eNuWJZyNLTDJW2XMsLtJOwoKhhwNeG/kiz6dMPXswvmkJA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "SessionRecipe");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "1f61ed16-06ea-4e36-a392-01b47e4742e0", "AQAAAAEAACcQAAAAEHllyBtsUkjEvpWa5kU3GKSWlisxkiJC6T5kXBSLlY9E+PVp0yZPq/yvB26gIX39+g==" });
        }
    }
}
