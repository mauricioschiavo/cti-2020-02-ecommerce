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
            Contexto contexto = new Contexto();
            var lsProdutos = contexto.Produtos.OrderBy(x => x.Name).ToList();
            return View(lsProdutos);
        }
    }
}