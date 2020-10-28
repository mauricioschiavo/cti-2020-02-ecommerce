using DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Ecommerce.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index(int? categoryId)
        {
            DAL.AppContext contexto = new DAL.AppContext();
            IEnumerable<Product> lsProducts = contexto.Products;
            if (categoryId.HasValue)
            {
                lsProducts = lsProducts.Where(x => x.CategoryId == categoryId.Value);
            }
            lsProducts = lsProducts.OrderBy(x => x.Name).ToList();
            ViewBag.Categories = contexto.Categories.OrderBy(x => x.Name).ToList();
            return View(lsProducts);
        }

        public IActionResult Detail(int id)
        {
            DAL.AppContext context = new DAL.AppContext();
            Product product = context.Products.Find(id);
            return View(product);
        }
    }
}