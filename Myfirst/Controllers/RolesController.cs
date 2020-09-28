using Microsoft.AspNet.Identity.EntityFramework;
using Myfirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Myfirst.Controllers
{
    [Authorize(Roles = "IT_Admin")]
    public class RolesController : Controller
    {
       
        private ApplicationDbContext dbContext = null;
        public RolesController()
        {
            dbContext = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
        // GET: Roles
        public ActionResult Index()
        {
            var role = dbContext.Roles.ToList();
            return View(role);
        }
        public ActionResult Create()
        {
            var role = dbContext.Roles.ToList();
            return View(role);
        }
        [HttpPost]
        public ActionResult Create(IdentityRole role)
        {
            dbContext.Roles.Add(role);
            dbContext.SaveChanges();
            return RedirectToAction("Index","Roles");
        }
    }
}