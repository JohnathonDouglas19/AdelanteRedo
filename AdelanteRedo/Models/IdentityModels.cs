using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using AdelanteRedo.Migrations;

namespace AdelanteRedo.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
    

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer<ApplicationDbContext>(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
            //Database.SetInitializer<ApplicationDbContext>(new CreateDatabaseIfNotExists<ApplicationDbContext>());
            //Database.SetInitializer<ApplicationDbContext>(new DropCreateDatabaseIfModelChanges<ApplicationDbContext>());
        }

        static ApplicationDbContext()
        {
            // Seed the database
            Database.SetInitializer<ApplicationDbContext>(new ApplicationCreateDb());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        //TODO: Add Sets for all entities in the Database.
        public DbSet<Student> Student { get; set; }
        public DbSet<Parent> Parent { get; set; }
        public DbSet<StudentParent> StudentParent { get; set; }
        //public DbSet<Admin> Admins { get; set; }
        public DbSet<Donor> Donor { get; set; }
        public DbSet<StudentAttendance> StudentAttendance { get; set; }
        public DbSet<Meeting> Meeting { get; set; }
        public DbSet<Programs> Programs { get; set; }
        public DbSet<StudentProgram> StudentProgram { get; set; }
        public System.Data.Entity.DbSet<AdelanteRedo.Models.Staff> Staff { get; set; }
        public System.Data.Entity.DbSet<AdelanteRedo.Models.Volunteer> Volunteer { get; set; }

        public System.Data.Entity.DbSet<AdelanteRedo.Models.Event> Events { get; set; }

    }
}