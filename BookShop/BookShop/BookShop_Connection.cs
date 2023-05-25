using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace BookShop
{
    public partial class BookShop_Connection : DbContext
    {
        public BookShop_Connection()
            : base("name=BookShop")
        {
        }

        public virtual DbSet<Authors> Authors { get; set; }
        public virtual DbSet<Books> Books { get; set; }
        public virtual DbSet<Countries> Countries { get; set; }
        public virtual DbSet<Sales> Sales { get; set; }
        public virtual DbSet<Shops> Shops { get; set; }
        public virtual DbSet<Themes> Themes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Authors>()
                .HasMany(e => e.Books)
                .WithRequired(e => e.Authors)
                .HasForeignKey(e => e.AuthorId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Books>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Books>()
                .HasMany(e => e.Sales)
                .WithRequired(e => e.Books)
                .HasForeignKey(e => e.BookId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Countries>()
                .HasMany(e => e.Authors)
                .WithRequired(e => e.Countries)
                .HasForeignKey(e => e.CountryId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Countries>()
                .HasMany(e => e.Shops)
                .WithRequired(e => e.Countries)
                .HasForeignKey(e => e.CountryId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Sales>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Shops>()
                .HasMany(e => e.Sales)
                .WithRequired(e => e.Shops)
                .HasForeignKey(e => e.ShopId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Themes>()
                .HasMany(e => e.Books)
                .WithRequired(e => e.Themes)
                .HasForeignKey(e => e.ThemeId)
                .WillCascadeOnDelete(false);
        }
    }
}
