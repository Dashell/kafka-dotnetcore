﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Recipe.API.Infrastructure;

namespace Recipe.API.Infrastructure.Migrations
{
    [DbContext(typeof(RecipeContext))]
    partial class RecipeContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Recipe.API.Models.Recipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .HasColumnName("name")
                        .HasColumnType("text");

                    b.HasKey("Id")
                        .HasName("pk_recipes");

                    b.ToTable("recipes");
                });

            modelBuilder.Entity("Recipe.API.Models.RecipeProduct", b =>
                {
                    b.Property<int>("RecipeId")
                        .HasColumnName("recipe_id")
                        .HasColumnType("integer");

                    b.Property<int>("ProductId")
                        .HasColumnName("product_id")
                        .HasColumnType("integer");

                    b.HasKey("RecipeId", "ProductId")
                        .HasName("pk_recipe_product");

                    b.ToTable("recipe_product");
                });

            modelBuilder.Entity("Recipe.API.Models.RecipeProduct", b =>
                {
                    b.HasOne("Recipe.API.Models.Recipe", "Recipe")
                        .WithMany("Products")
                        .HasForeignKey("RecipeId")
                        .HasConstraintName("fk_recipe_product_recipes_recipe_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
