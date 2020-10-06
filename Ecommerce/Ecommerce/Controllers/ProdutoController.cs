using DAL;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Ecommerce.Controllers
{
    public class ProdutoController : Controller
    {
        public IActionResult Index()
        {
            Contexto contexto = new Contexto();

            //Produto novoProduto = new Produto();
            //novoProduto.Name = "Novo ";
            //novoProduto.Price = DateTime.Now.Second;
            //contexto.Produtos.Add(novoProduto);
            //contexto.SaveChanges();

            var lsProdutos = contexto.Produtos.OrderBy(x => x.Name).ToList();
            return View(lsProdutos);
        }
    }
}