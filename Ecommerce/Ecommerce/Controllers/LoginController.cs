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
            DAL.AppContext appContext = new DAL.AppContext();
            Customer customerDatabase = appContext.Customers
                .Where(x => x.Email == customer.Email).SingleOrDefault();
            if (customerDatabase == null)
            {
                return View(customer);
            }
            else
            {
                string hash = customer.Hash + customerDatabase.Salt;
                hash = Util.Cryptography.CreateMD5(hash);
                if(customerDatabase.Hash == hash)
                {
                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    return View(customer);
                }
            }
        }
    }
}
