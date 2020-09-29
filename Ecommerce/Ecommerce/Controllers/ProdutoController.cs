using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Controllers
{
    public class ProdutoController : Controller
    {
        public IActionResult Index()
        {
            Contexto contexto = new Contexto();
            var lsProdutos = contexto.Produtos.ToList();
            return View(lsProdutos);
        }
    }
}