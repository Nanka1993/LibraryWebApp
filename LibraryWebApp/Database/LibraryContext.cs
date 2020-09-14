using Microsoft.EntityFrameworkCore;
using LibraryWebApp.Models.Domain;

namespace LibraryWebApp.Database
{
    public sealed class LibraryContext : DbContext
    {
        public LibraryContext()
        {
            Database.EnsureCreated();
        }

        public LibraryContext(DbContextOptions options) : base(options) { }

        public DbSet<Magazine> Magazines { get; set; }
        public DbSet<Dissertation> Dissertations { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<SynopsisOfThesis> SynopsisOfThesises { get; set; }
        public DbSet<Article> Articles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Magazine>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Dissertation>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Book>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<SynopsisOfThesis>()
                .HasKey(x => x.Id);


            modelBuilder.Entity<Article>()
                .HasKey(x => x.Id);

            //modelBuilder.Entity<Article>()
            //    .Property(x => x.Id)
            //    .ValueGeneratedOnAdd()
            //    .UseIdentityColumn();
        }
    }
}