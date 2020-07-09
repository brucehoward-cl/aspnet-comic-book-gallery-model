using ComicBookGalleryModel.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ComicBookGalleryModel
{
    public class Context : DbContext
    {

        public Context() 
        {
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Context>());
            //Database.SetInitializer(new CreateDatabaseIfNotExists<Context>());
            //Database.SetInitializer(new DropCreateDatabaseAlways<Context>());
            Database.SetInitializer(new DatabaseInitializer());
        }

        public DbSet<ComicBook> ComicBooks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //modelBuilder.Conventions.Remove<DecimalPropertyConvention>();
            //modelBuilder.Conventions.Add(new DecimalPropertyConvention(5, 2));

            modelBuilder.Entity<ComicBook>()
                .Property(cb => cb.AverageRating)
                .HasPrecision(5, 2);
        }

    }
}
