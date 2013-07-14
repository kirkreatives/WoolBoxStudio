using System.Data.Entity;

namespace WoolBoxStudio.Models
{
    public class WoolBoxStudioContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<WoolBoxStudio.Models.WoolBoxStudioContext>());

        public WoolBoxStudioContext() : base("name=WoolBoxStudioContext")
        {
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<About> Abouts { get; set; }

        public DbSet<CraftShow> CraftShows { get; set; }

        public DbSet<HomeCarousel> HomeCarousels { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Portfolio> Portfolios { get; set; }
    }
}
