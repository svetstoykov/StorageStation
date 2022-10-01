using Microsoft.EntityFrameworkCore;
using StorageStation.Domain.Models;

namespace StorageStation.Infrastructure.Common.DbContext
{
    public partial class StorageStationDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public StorageStationDbContext()
        {
        }

        public StorageStationDbContext(DbContextOptions<StorageStationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Description> Descriptions { get; set; } = null!;
        public virtual DbSet<Household> Households { get; set; } = null!;
        public virtual DbSet<Item> Items { get; set; } = null!;
        public virtual DbSet<Location> Locations { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<ShoppingList> ShoppingLists { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Categories", "product");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Household)
                    .WithMany(p => p.Categories)
                    .HasForeignKey(d => d.HouseholdId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Categories_Households");
            });

            modelBuilder.Entity<Description>(entity =>
            {
                entity.ToTable("Descriptions", "product");

                entity.HasIndex(e => e.Name, "UC_Name")
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Content).HasMaxLength(200);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.HasOne(d => d.Household)
                    .WithMany(p => p.Descriptions)
                    .HasForeignKey(d => d.HouseholdId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Descriptions_Households");
            });

            modelBuilder.Entity<Household>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.ToTable("Items", "shopping_list");

                entity.Property(e => e.Product).HasMaxLength(100);

                entity.HasOne(d => d.ShoppingList)
                    .WithMany(p => p.Items)
                    .HasForeignKey(d => d.ShoppingListId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Items_ShoppingLists");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.Property(e => e.Coordinates).HasMaxLength(300);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Household)
                    .WithMany(p => p.Locations)
                    .HasForeignKey(d => d.HouseholdId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Locations_Households");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(100);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Products_Categories");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.LocationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Products_Locations");

                entity.HasOne(d => d.NameNavigation)
                    .WithMany(p => p.Products)
                    .HasPrincipalKey(p => p.Name)
                    .HasForeignKey(d => d.Name)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Products_Descriptions");
            });

            modelBuilder.Entity<ShoppingList>(entity =>
            {
                entity.Property(e => e.DateCompleted).HasColumnType("datetime");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.HasOne(d => d.CreatedByUser)
                    .WithMany(p => p.ShoppingLists)
                    .HasForeignKey(d => d.CreatedByUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShoppingLists_Users");

                entity.HasOne(d => d.Household)
                    .WithMany(p => p.ShoppingLists)
                    .HasForeignKey(d => d.HouseholdId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ShoppingLists_Households");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.PasswordHash).HasMaxLength(1000);

                entity.Property(e => e.Username).HasMaxLength(50);

                entity.HasOne(d => d.Household)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.HouseholdId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Users_Households");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
