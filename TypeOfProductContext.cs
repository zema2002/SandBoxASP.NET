using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Restaurant
{
    public partial class TypeOfProductContext : DbContext
    {
        public TypeOfProductContext()
        {
        }

        public TypeOfProductContext(DbContextOptions<TypeOfProductContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<PriceCategory> PriceCategories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Restaurant> Restaurants { get; set; }
        public virtual DbSet<RestaurantInCity> RestaurantInCities { get; set; }
        public virtual DbSet<RestaurantName> RestaurantNames { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-BSJ7QNH\\SQL;Database=TypeOfProduct;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("City");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.NameLatin).HasMaxLength(255);

                entity.Property(e => e.NameRus)
                    .HasMaxLength(255)
                    .HasColumnName("NameRUS");

                entity.Property(e => e.PeopleCounty).HasMaxLength(255);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.City)
                    .HasForeignKey<City>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__City__Id__182C9B23");
            });

            modelBuilder.Entity<PriceCategory>(entity =>
            {
                entity.ToTable("PriceCategory");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AverageCheck).HasMaxLength(255);

                entity.Property(e => e.NameLatin).HasMaxLength(255);

                entity.Property(e => e.NameRus)
                    .HasMaxLength(255)
                    .HasColumnName("NameRUS");

                entity.Property(e => e.PriceCategory1)
                    .HasMaxLength(255)
                    .HasColumnName("PriceCategory");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.PriceCategory)
                    .HasForeignKey<PriceCategory>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PriceCategor__Id__1B0907CE");

                entity.HasOne(d => d.Restaurant)
                    .WithMany(p => p.PriceCategories)
                    .HasForeignKey(d => d.RestaurantId)
                    .HasConstraintName("fk_RestaurantInPriceCategory");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.ProductId).ValueGeneratedNever();

                entity.Property(e => e.NameLatin).HasMaxLength(255);

                entity.Property(e => e.NameRus)
                    .HasMaxLength(255)
                    .HasColumnName("NameRUS");
            });

            modelBuilder.Entity<Restaurant>(entity =>
            {
                entity.ToTable("Restaurant");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.NameLatin).HasMaxLength(255);

                entity.Property(e => e.NameRus)
                    .HasMaxLength(255)
                    .HasColumnName("NameRUS");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Restaurants)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("fk_ProductInRestaurant");

                entity.HasOne(d => d.RestaurantNameNavigation)
                    .WithMany(p => p.Restaurants)
                    .HasForeignKey(d => d.RestaurantName)
                    .HasConstraintName("fk_RestaurantNameInRestaurant");
            });

            modelBuilder.Entity<RestaurantInCity>(entity =>
            {
                entity.ToTable("RestaurantInCity");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.NameLatin).HasMaxLength(255);

                entity.Property(e => e.NameRus)
                    .HasMaxLength(255)
                    .HasColumnName("NameRUS");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.RestaurantInCities)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("fk_CityInRestaurantInCity");

                entity.HasOne(d => d.RestaurantName)
                    .WithMany(p => p.RestaurantInCities)
                    .HasForeignKey(d => d.RestaurantNameId)
                    .HasConstraintName("fk_RestaurantInCity");
            });

            modelBuilder.Entity<RestaurantName>(entity =>
            {
                entity.ToTable("RestaurantName");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.NameLatin).HasMaxLength(255);

                entity.Property(e => e.NameRus)
                    .HasMaxLength(255)
                    .HasColumnName("NameRUS");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
