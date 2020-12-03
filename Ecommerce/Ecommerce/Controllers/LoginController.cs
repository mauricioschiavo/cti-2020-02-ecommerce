using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace Ecommerce.Controllers
{
    public class LoginController : Controller
    {
        private IWebHostEnvironment Environment;
        public LoginController(IWebHostEnvironment _environment)
        {
            Environment = _environment;
        }

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
                    HttpContext.Session.SetInt32("userId", customerDatabase.Id);
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
        public IActionResult Create(Customer customer, IFormFile postedFile)
        {
            if (postedFile != null && postedFile.Length > 0) //arquivo não está vazio
            {
                string wwwPath = this.Environment.WebRootPath;
                string contentPath = this.Environment.ContentRootPath;

                string path = Path.Combine(this.Environment.WebRootPath, "Uploads");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                string fileName = Path.GetFileName(postedFile.FileName);
                using (FileStream stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                    customer.Picture = fileName;
                }
            }
            DAL.AppContext appContext = new DAL.AppContext();
            customer.Salt = Guid.NewGuid().ToString();
            customer.Hash = Util.Cryptography.CreateMD5(customer.Hash + customer.Salt);
            appContext.Customers.Add(customer);
            appContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
