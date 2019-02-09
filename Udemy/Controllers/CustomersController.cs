using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Udemy.Models;
using Udemy.ViewModel;

namespace Udemy.Controllers
{
    public class CustomersController : Controller
    {
        CustomersVm customers = new CustomersVm()
        {
            
        };
        // GET: Customers
        public ActionResult Index()
        {
            
            return View(customers);
        }
        public ActionResult Details(int id)
        {
            Customer c = customers.lstCustomers.Where(cu => cu.Id == id).FirstOrDefault();
            if (c != null)
                return View(c);
            else
                return HttpNotFound();
        }
    }
}