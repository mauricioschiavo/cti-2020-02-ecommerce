using DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Ecommerce.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            DAL.AppContext contexto = new DAL.AppContext();
            var lsProdutos = contexto.Produtos.OrderBy(x => x.Name).ToList();
            return View(lsProdutos);
        }
    }
}