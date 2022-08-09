using CoreApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CoreApp.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            List<Customer> list = CustomerContext.Customers;
            return View(list);
        }
    }
}
