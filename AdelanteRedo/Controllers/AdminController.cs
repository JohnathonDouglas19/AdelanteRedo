using AdelanteRedo.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AdelanteRedo.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        //AdelanteDbContext appContext = new AdelanteDbContext();

        //private readonly RoleManager<IdentityRole> _roleManager;
        //private readonly UserManager<ApplicationUser> _userManager;


        //public AdminController()
        //{

        //}

        //public AdminController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        //{
        //    _roleManager = roleManager;
        //    _userManager = userManager;
        //}
        //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(appContext));
        //var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(appContext));

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        //[Authorize]
        //public ActionResult UserManagement()
        //{
        //    var users = _userManager.Users;
        //    var roles = new List<string>();
        //    foreach (var user in users)
        //    {
        //        string str = "";
        //        foreach (var role in _userManager.GetRoles(user.Id))
        //        {
        //            str = (str == "") ? role.ToString() : str + " - " + role.ToString();
        //        }
        //        roles.Add(str);
        //    }
        //    var model = new ListUserViewModel()
        //    {
        //        users = users.ToList(),
        //        roles = roles.ToList()
        //    };
        //    return View(model);
        //}
    }
}
