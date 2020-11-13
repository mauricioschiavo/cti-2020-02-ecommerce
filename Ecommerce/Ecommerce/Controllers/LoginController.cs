using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new Customer());
        }

        [HttpPost]
        public IActionResult Index(Customer customer)
        {
            return View(customer);
        }
    }
}
