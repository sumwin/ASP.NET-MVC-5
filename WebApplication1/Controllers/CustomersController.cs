using System.Linq;
using System.Web.Mvc;
using WebApplication1.Models;
using System.Data.Entity;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm",viewModel);
        }
                
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("CustomerForm" , viewModel);
            }
            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerinDb = _context.Customers.Single(c => c.Id == customer.Id);
                               
                customerinDb.Name = customer.Name;
                customerinDb.Birthdate = customer.Birthdate;
                customerinDb.MembershipTypeId = customer.MembershipTypeId;
                customerinDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            } 
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }
               
        // GET: Customers
        public ViewResult Index()
        {
           //var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            //return View(customers);
            return View();
        }
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c =>c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        //Edit: Customers
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
        };
            return View("CustomerForm", viewModel);
        }
    }
}