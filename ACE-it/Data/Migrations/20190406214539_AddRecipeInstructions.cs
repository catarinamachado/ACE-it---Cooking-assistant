using Microsoft.EntityFrameworkCore.Migrations;

namespace ACE_it.Data.Migrations
{
    public partial class AddRecipeInstructions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RecipeInstruction",
                columns: table => new
                {
                    RecipeId = table.Column<int>(nullable: false),
                    InstructionId = table.Column<int>(nullable: false),
                    Index = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeInstruction", x => new { x.RecipeId, x.InstructionId });
                    table.ForeignKey(
                        name: "FK_RecipeInstruction_Instructions_InstructionId",
                        column: x => x.InstructionId,
                        principalTable: "Instructions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeInstruction_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RecipeInstruction_InstructionId",
                table: "RecipeInstruction",
                column: "InstructionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecipeInstruction");
        }
    }
}
