using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using Myfirst.Models;

namespace Myfirst.Controllers
{
    [RoutePrefix("Customer")]
    public class CustomerController : Controller
    {
        public ApplicationDbContext dbContext = null;
        public CustomerController()
        {
            dbContext = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            if (dbContext != null)
            {
                dbContext.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult Index()
        {


            //Customer c = new Customer();
            //c.Id = 1;
            //c.Name = "Nishitha";
            //c.DateofBirth = DateTime.Today;
            // var c = GetCustomers();
            var c1 = GetCustomers();
            return View(c1);
        }
        [Route("Customer/FindAge/{DOB?}")]
        public ActionResult FindAge(DateTime? DOB)
        {

            DateTime birthDate = Convert.ToDateTime("23/02/2001");
            DateTime TodayDate = DateTime.Today;
            int age = TodayDate.Year - birthDate.Year;
            if (birthDate > TodayDate.AddYears(-age))
            {
                age--;
            }

            return Content($"Age of a person is :{age}");
        }
        [HttpGet]
        [Authorize]
        public ActionResult Details(int id)
        {
            var customer = GetCustomers().FirstOrDefault(customer1 => customer1.Id == id);
            return View(customer);
        }
        [HttpGet]
        public ActionResult Create()
        {
            var ViewModel = new CustomerViewModel
            {
                Customer = new Customer(),
                GetMemberships = dbContext.Memberships.ToList()
            };
            return View("CreateNew1", ViewModel);
        }
        [HttpPost]
        public ActionResult Create(Customer customer)
        {

            if (!ModelState.IsValid)
            {
                var ViewModel = new CustomerViewModel
                {
                    Customer = new Customer(),
                };
                return View("CreateNew1");
            }

            dbContext.customers.Add(customer);
            dbContext.SaveChanges();
            return RedirectToAction("Index", "customer");

        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var customer = dbContext.customers.SingleOrDefault(c => c.Id == id);
            if (customer != null)
            {
                var ViewModel = new CustomerViewModel
                {
                    Customer = customer,
                    GetMemberships = dbContext.Memberships.ToList()
                };
                return View(ViewModel);
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult Edit(Customer customer, int id)
        {
            var customer1 = dbContext.customers.SingleOrDefault(c => c.Id == id);
            if (customer1 != null)
            {
                customer1.Name = customer.Name;

                customer1.DateofBirth = customer.DateofBirth;
                customer1.Address = customer.Address;
                customer1.Gender = customer.Gender;
                customer1.MembershipId = customer.MembershipId;
                dbContext.SaveChanges();
                return RedirectToAction("Index", "Customer");

            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult Delete(int? id)
        {
            var customer = dbContext.customers.SingleOrDefault(c => c.Id == id);

            if (customer != null)
            {
                dbContext.customers.Remove(customer);
                dbContext.SaveChanges();
                return RedirectToAction("Index", "Customer");
            }

            return HttpNotFound();
        }
        [NonAction]
        public IEnumerable<SelectListItem> GenerateMembershiptype()
        {
            var members = dbContext.Genres.AsEnumerable().Select(g => new SelectListItem
            {
                Text = g.GenreName,
                Value = g.Id.ToString()

            });
            return members;
        }
        public List<SelectListItem> GetGender()
        {
            return new List<SelectListItem>
            {
                new SelectListItem{Text="Select"},
               new SelectListItem{Text="Male",Value="Male"},
                new SelectListItem{Text="Female",Value="Female"},
                new SelectListItem{Text="Others",Value="Others"}
            };
        }


        [NonAction]
        public List<Customer> GetCustomers()
        {
            return dbContext.customers.ToList();
        }
    }


}
