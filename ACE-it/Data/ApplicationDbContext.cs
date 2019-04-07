using System.Timers;
using ACE_it.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ACE_it.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<User> AppUsers { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Instruction> Instructions { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RecipeInstruction>()
                .HasKey(ri => new { ri.RecipeId, ri.InstructionId});
            modelBuilder.Entity<RecipeInstruction>()
                .HasOne(ri => ri.Recipe)
                .WithMany(r => r.RecipeInstructions)
                .HasForeignKey(ri => ri.RecipeId);
            modelBuilder.Entity<RecipeInstruction>()
                .HasOne(ri => ri.Instruction)
                .WithMany(ri => ri.RecipeInstructions)
                .HasForeignKey(ri => ri.InstructionId);

            modelBuilder.Entity<InstructionTool>()
                .HasKey(it => new { it.InstructionId, it.ToolId});
            modelBuilder.Entity<InstructionTool>()
                .HasOne(it => it.Instruction)
                .WithMany(i => i.InstructionTools)
                .HasForeignKey(it => it.InstructionId);
            modelBuilder.Entity<InstructionTool>()
                .HasOne(it => it.Tool)
                .WithMany(i => i.InstructionTools)
                .HasForeignKey(it => it.ToolId);

            modelBuilder.Entity<RecipeIngredient>()
                .HasKey(ri => new { ri.RecipeId, ri.IngredientId});
            modelBuilder.Entity<RecipeIngredient>()
                .HasOne(ri => ri.Recipe)
                .WithMany(r => r.RecipeIngredients)
                .HasForeignKey(ri => ri.RecipeId);
            modelBuilder.Entity<RecipeIngredient>()
                .HasOne(ri => ri.Ingredient)
                .WithMany(ri => ri.RecipeIngredients)
                .HasForeignKey(ri => ri.IngredientId);

            modelBuilder.Entity<UserFavouriteIngredient>()
                .HasKey(ri => new { ri.UserId, ri.IngredientId});
            modelBuilder.Entity<UserFavouriteIngredient>()
                .HasOne(ri => ri.User)
                .WithMany(r => r.UserFavouriteIngredients)
                .HasForeignKey(ri => ri.UserId);
            modelBuilder.Entity<UserFavouriteIngredient>()
                .HasOne(ri => ri.Ingredient)
                .WithMany(ri => ri.UserFavouriteIngredients)
                .HasForeignKey(ri => ri.IngredientId);

            modelBuilder.Entity<UserUnwantedIngredient>()
                .HasKey(ri => new { ri.UserId, ri.IngredientId});
            modelBuilder.Entity<UserUnwantedIngredient>()
                .HasOne(ri => ri.User)
                .WithMany(r => r.UserUnwantedIngredients)
                .HasForeignKey(ri => ri.UserId);
            modelBuilder.Entity<UserUnwantedIngredient>()
                .HasOne(ri => ri.Ingredient)
                .WithMany(ri => ri.UserUnwantedIngredients)
                .HasForeignKey(ri => ri.IngredientId);

            modelBuilder.Entity<UserCompletedRecipe>()
                .HasKey(ri => new { ri.UserId, ri.RecipeId});
            modelBuilder.Entity<UserCompletedRecipe>()
                .HasOne(ri => ri.User)
                .WithMany(r => r.UserCompletedRecipes)
                .HasForeignKey(ri => ri.UserId);
            modelBuilder.Entity<UserCompletedRecipe>()
                .HasOne(ri => ri.Recipe)
                .WithMany(ri => ri.UserCompletedRecipes)
                .HasForeignKey(ri => ri.RecipeId);

            modelBuilder.Entity<UserFavouriteRecipe>()
                .HasKey(ri => new { ri.UserId, ri.RecipeId});
            modelBuilder.Entity<UserFavouriteRecipe>()
                .HasOne(ri => ri.User)
                .WithMany(r => r.UserFavouriteRecipes)
                .HasForeignKey(ri => ri.UserId);
            modelBuilder.Entity<UserFavouriteRecipe>()
                .HasOne(ri => ri.Recipe)
                .WithMany(ri => ri.UserFavouriteRecipes)
                .HasForeignKey(ri => ri.RecipeId);

            modelBuilder.Entity<UserWillPrepareRecipe>()
                .HasKey(ri => new { ri.UserId, ri.RecipeId});
            modelBuilder.Entity<UserWillPrepareRecipe>()
                .HasOne(ri => ri.User)
                .WithMany(r => r.UserWillPrepareRecipes)
                .HasForeignKey(ri => ri.UserId);
            modelBuilder.Entity<UserWillPrepareRecipe>()
                .HasOne(ri => ri.Recipe)
                .WithMany(ri => ri.UserWillPrepareRecipes)
                .HasForeignKey(ri => ri.RecipeId);
        }
    }
}
