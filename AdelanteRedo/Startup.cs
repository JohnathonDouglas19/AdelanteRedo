using AdelanteRedo.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AdelanteRedo.Startup))]
namespace AdelanteRedo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
        }

        // In this method we will create default User roles, Admin, and SuperAdmin user for login   
        private void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


            ////In Startup iam creating first SuperAdmin Role and creating a default Admin User    
            //if (!roleManager.RoleExists("SuperAdmin"))
            //{

            //    //first we create SuperAdmin Role
            //    var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
            //    role.Name = "SuperAdmin";
            //    roleManager.Create(role);

            //    //Here we create a SuperAdmin user who will maintain the website

            //    var user = new ApplicationUser();
            //    user.UserName = "jdgods011";
            //    user.Email = "jdgods011@outlook.com";

            //    string userPWD = "uKo4$2oV2!oi!dko!4d";

            //    var chkUser = UserManager.Create(user, userPWD);

            //    //Add default User to Role SuperAdmin
            //    if (chkUser.Succeeded)
            //    {
            //        var result1 = UserManager.AddToRole(user.Id, "SuperAdmin");

            //    }
            //}

            //copy these if statements in the future for however many roles need to be generated
            //can change what they are
            //creating Creating Administrator role
            //if (!roleManager.RoleExists("Administrator"))
            //{

            //    var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
            //    role.Name = "Administrator";
            //    roleManager.Create(role);


            //    Here we create a Administrator user who will maintain the website

            //    var user = new ApplicationUser();
            //    user.UserName = "administrator@email.com";
            //    user.Email = "administrator@email.com";

            //    string userPWD = "adelante123";

            //    var chkUser = UserManager.Create(user, userPWD);

            //    Add default User to Role Administrator
            //    if (chkUser.Succeeded)
            //    {
            //        var result1 = UserManager.AddToRole(user.Id, "Administrator");

            //    }


            //}


            //creating Creating Student role
            //if (!roleManager.RoleExists("Student"))
            //{

            //    var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
            //    role.Name = "Student";
            //    roleManager.Create(role);

            //    //Here we create a Student user who will maintain the website

            //    var user = new ApplicationUser();
            //    user.UserName = "student@email.com";
            //    user.Email =    "student@email.com";

            //    string userPWD = "adelante123";

            //    var chkUser = UserManager.Create(user, userPWD);

            //    //Add default User to Role Student
            //    if (chkUser.Succeeded)
            //    {
            //        var result1 = UserManager.AddToRole(user.Id, "Student");

            //    }

            //}

            //creating Creating Volunteer role
            //if (!roleManager.RoleExists("Volunteer"))
            //{

            //    var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
            //    role.Name = "Volunteer";
            //    roleManager.Create(role);

            //    //Here we create a Volunteer user who will maintain the website

            //    var user = new ApplicationUser();
            //    user.UserName = "volunteer@email.com";
            //    user.Email =    "volunteer@email.com";

            //    string userPWD = "adelante123";

            //    var chkUser = UserManager.Create(user, userPWD);

            //    //Add default User to Role Volunteer
            //    if (chkUser.Succeeded)
            //    {
            //        var result1 = UserManager.AddToRole(user.Id, "Volunteer");

            //    }
            //}

        }
    }
}
