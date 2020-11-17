using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

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
                ViewBag.Error = "Usuário ou senha incorretos!";
                return View(customer);
            }
            else
            {
                string hash = customer.Hash + customerDatabase.Salt;
                hash = Util.Cryptography.CreateMD5(hash);
                if (customerDatabase.Hash == hash)
                {
                    HttpContext.Session.SetString("user", customerDatabase.Name);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Error = "Usuário ou senha incorretos!";
                    return View(customer);
                }
            }
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            DAL.AppContext appContext = new DAL.AppContext();
            customer.Salt = Guid.NewGuid().ToString();
            customer.Hash = Util.Cryptography.CreateMD5(customer.Hash + customer.Salt);
            appContext.Customers.Add(customer);
            appContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
