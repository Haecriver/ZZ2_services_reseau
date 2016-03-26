using Microsoft.AspNet.Identity.EntityFramework;

namespace SiteWebJediTournament.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public System.Data.Entity.DbSet<SiteWebJediTournament.ServiceReference1.JediWCF> JediWCFs { get; set; }

        public System.Data.Entity.DbSet<SiteWebJediTournament.Models.JediModels> JediModels { get; set; }

        public System.Data.Entity.DbSet<SiteWebJediTournament.Models.CaracteristiqueModels> CaracteristiqueModels { get; set; }

        public System.Data.Entity.DbSet<SiteWebJediTournament.Models.MatchModels> MatchModels { get; set; }

        public System.Data.Entity.DbSet<SiteWebJediTournament.Models.StadeModels> StadeModels { get; set; }

        public System.Data.Entity.DbSet<SiteWebJediTournament.Models.CaracteristiqueCollection> CaracteristiqueCollections { get; set; }

        public System.Data.Entity.DbSet<SiteWebJediTournament.Models.TournoiModels> TournoiModels { get; set; }
    }
}