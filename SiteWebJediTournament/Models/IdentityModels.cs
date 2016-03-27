using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SiteWebJediTournament.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string Prenom { get; set; }
        public string Nom { get; set; }
        public string Login { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUser>().ToTable("utilisateur").Property(p => p.Id).HasColumnName("numuser");
            modelBuilder.Entity<ApplicationUser>().ToTable("utilisateur").Property(p => p.Login).HasColumnName("loginuser");
            modelBuilder.Entity<ApplicationUser>().ToTable("utilisateur").Property(p => p.PasswordHash).HasColumnName("passworduser");
            modelBuilder.Entity<ApplicationUser>().ToTable("utilisateur").Property(p => p.Prenom).HasColumnName("prenom");
            modelBuilder.Entity<ApplicationUser>().ToTable("utilisateur").Property(p => p.Nom).HasColumnName("nom");
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
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