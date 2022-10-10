using Microsoft.EntityFrameworkCore;
using StorageStation.Domain.Locations;
using StorageStation.Domain.Products;
using StorageStation.Domain.ShoppingLists;
using StorageStation.Domain.Users;

namespace StorageStation.Infrastructure.Common.DbContext;

public partial class StorageStationDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public StorageStationDbContext()
    {
    }

    public StorageStationDbContext(DbContextOptions<StorageStationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; } 
    public virtual DbSet<Household> Households { get; set; } 
    public virtual DbSet<Item> Items { get; set; } 
    public virtual DbSet<Location> Locations { get; set; } 
    public virtual DbSet<Product> Products { get; set; } 
    public virtual DbSet<ShoppingList> ShoppingLists { get; set; } 
    public virtual DbSet<StoredItem> StoredItems { get; set; } 
    public virtual DbSet<User> Users { get; set; } 

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

        modelBuilder.Entity<Household>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.ToTable("Items", "shopping_list");

            entity.HasOne(d => d.Product)
                .WithMany(p => p.Items)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Items_Products");

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
            entity.HasIndex(e => e.Name, "UC_Name")
                .IsUnique();

            entity.Property(e => e.Description).HasMaxLength(200);

            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.Category)
                .WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_Categories");

            entity.HasOne(d => d.Household)
                .WithMany(p => p.Products)
                .HasForeignKey(d => d.HouseholdId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_Households");
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
        });

        modelBuilder.Entity<StoredItem>(entity =>
        {
            entity.ToTable("StoredItems", "location");

            entity.HasOne(d => d.Location)
                .WithMany(p => p.StoredItems)
                .HasForeignKey(d => d.LocationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StoredItems_Locations");

            entity.HasOne(d => d.Product)
                .WithMany(p => p.StoredItems)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_StoredItems_Products");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Email).HasMaxLength(100);

            entity.Property(e => e.FullName).HasMaxLength(50);

            entity.Property(e => e.PasswordHash).HasMaxLength(1000);

            entity.Property(e => e.Username).HasMaxLength(50);

            entity.HasOne(d => d.Household)
                .WithMany(p => p.Users)
                .HasForeignKey(d => d.HouseholdId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Users_Households");
        });

        this.OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}