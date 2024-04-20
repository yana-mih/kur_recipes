using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Recipe.Models
{
    public partial class RecipeContext : DbContext
    {
        public RecipeContext()
        {
        }

        public RecipeContext(DbContextOptions<RecipeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Image> Images { get; set; } = null!;
        public virtual DbSet<Kitchen> Kitchens { get; set; } = null!;
        public virtual DbSet<MainProduct> MainProducts { get; set; } = null!;
        public virtual DbSet<MainProductRecipe> MainProductRecipes { get; set; } = null!;
        public virtual DbSet<Person> People { get; set; } = null!;
        public virtual DbSet<Recipe> Recipes { get; set; } = null!;
        public virtual DbSet<TypeOfCooking> TypeOfCookings { get; set; } = null!;
        public virtual DbSet<TypeOfDish> TypeOfDishes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost\\MSSQLSERVER01;Database=Recipe;Trusted_Connection=True;TrustServerCertificate=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("category");

                entity.Property(e => e.CategoryId).HasColumnName("categoryID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.ToTable("Image");

                entity.Property(e => e.ImageId).HasColumnName("imageID");

                entity.Property(e => e.Image1).HasColumnName("image");
            });

            modelBuilder.Entity<Kitchen>(entity =>
            {
                entity.ToTable("kitchen");

                entity.Property(e => e.KitchenId).HasColumnName("kitchenID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<MainProduct>(entity =>
            {
                entity.ToTable("Main_product");

                entity.Property(e => e.MainProductId).HasColumnName("Main_productID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<MainProductRecipe>(entity =>
            {
                entity.ToTable("Main_productRecipe");

                entity.Property(e => e.MainProductRecipeId).HasColumnName("Main_productRecipeId");

                entity.Property(e => e.MainProductId).HasColumnName("Main_productID");

                entity.HasOne(d => d.MainProduct)
                    .WithMany(p => p.MainProductRecipes)
                    .HasForeignKey(d => d.MainProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Main_productRecipe_Main_product");

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.MainProductRecipes)
                    .HasForeignKey(d => d.RecipeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Main_productRecipe_Recipe");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.ToTable("Person");

                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.Property(e => e.Birthday).HasColumnType("date");

                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Login).HasMaxLength(50);

                entity.Property(e => e.Password)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Recipe>(entity =>
            {
                entity.ToTable("Recipe");

                entity.Property(e => e.RecipeId).HasColumnName("RecipeID");

                entity.Property(e => e.CategoryId).HasColumnName("categoryID");

                entity.Property(e => e.ImageId).HasColumnName("imageID");

                entity.Property(e => e.Ingredients).HasColumnName("ingredients");

                entity.Property(e => e.Kbzy)
                    .HasMaxLength(20)
                    .HasColumnName("KBZY")
                    .IsFixedLength();

                entity.Property(e => e.KitchenId).HasColumnName("kitchenID");

                entity.Property(e => e.NameRecipe).HasMaxLength(50);

                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.Property(e => e.Time)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.TypeOfCookingId).HasColumnName("type_of_cookingID");

                entity.Property(e => e.TypeOfDishId).HasColumnName("type_of_dishID");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Recipes)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Recipe_category");

                entity.HasOne(d => d.Image)
                    .WithMany(p => p.Recipes)
                    .HasForeignKey(d => d.ImageId)
                    .HasConstraintName("FK_Recipe_Image");

                entity.HasOne(d => d.Kitchen)
                    .WithMany(p => p.Recipes)
                    .HasForeignKey(d => d.KitchenId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Recipe_kitchen");

                entity.HasOne(d => d.Person)
                    .WithMany(p => p.Recipes)
                    .HasForeignKey(d => d.PersonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Recipe_Person");

                entity.HasOne(d => d.TypeOfCooking)
                    .WithMany(p => p.Recipes)
                    .HasForeignKey(d => d.TypeOfCookingId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Recipe_type_of_cooking");

                entity.HasOne(d => d.TypeOfDish)
                    .WithMany(p => p.Recipes)
                    .HasForeignKey(d => d.TypeOfDishId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Recipe_type_of_dish");
            });

            modelBuilder.Entity<TypeOfCooking>(entity =>
            {
                entity.ToTable("type_of_cooking");

                entity.Property(e => e.TypeOfCookingId).HasColumnName("type_of_cookingID");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<TypeOfDish>(entity =>
            {
                entity.HasKey(e => e.TypeOfDish1);

                entity.ToTable("type_of_dish");

                entity.Property(e => e.TypeOfDish1).HasColumnName("type_of_dish");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
