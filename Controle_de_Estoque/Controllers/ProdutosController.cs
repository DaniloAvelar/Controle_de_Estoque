using Controle_de_Estoque.Data;
using Controle_de_Estoque.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Threading.Tasks;

namespace Controle_de_Estoque.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly ControleDeEstoqueDbContext _context;
        public ProdutosController(ControleDeEstoqueDbContext context)
        {
            _context = context;
        }

        // GET: Produtos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Produtos.ToListAsync());
        }

        public ActionResult Create()
        {
            ViewBag.Categorias = _context.Categoria;
            var model = new ProdutoViewModel();
            return View(model);
        }
        // POST CREATE Produto:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProdutoViewModel model)
        {
            if (ModelState.IsValid)
            {
                var produto = new Produto();
                produto.NomeProduto = model.NomeProduto;
                produto.QtdeProduto = model.QtdeProduto;
                produto.DescricaoProduto = model.DescricaoProduto;
                produto.IdCategoria = model.CategoriaId;

                var dbProd = _context.Produtos;
                dbProd.Add(produto);
                _context.SaveChanges();
                return RedirectToAction("index");
            }
            ViewBag.Categories = _context.Categoria;
            return View(model);
        }

        //GET: Produto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest("Requisição Invalida, ID não encontrado");
            }

            Produto produto = _context.Produtos.Find(id);

            if (produto == null)
            {
                return NotFound("Produto não encontrado");
            }

            ViewBag.Categorias = _context.Categoria;
            return View(produto);
        }

        //IdProduto,NomeProduto,QtdeProduto,DescricaoProduto,IdCategoria
        //POST/Edit/Produto:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(include: "IdProduto,NomeProduto,QtdeProduto,DescricaoProduto,IdCategoria")] Produto model)
        {
            if (model.IdProduto != 0)
            {
                var produto = _context.Produtos.Find(model.IdProduto);

                if (produto == null)
                {
                    return BadRequest("Requisição Invalida, ID do Produto não encontrado");
                }

                if(model.QtdeProduto != 0)
                {
                    var prodBD= produto.QtdeProduto;
                    var prodAdd = model.QtdeProduto;

                    produto.QtdeProduto = prodBD + prodAdd;
                }

                //produto.NomeProduto = model.NomeProduto;
                //produto.DescricaoProduto = produto.DescricaoProduto;
                //produto.IdCategoria = model.IdCategoria;

                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Categorias = _context.Categoria;
            return View(model);
        }


    }
}
