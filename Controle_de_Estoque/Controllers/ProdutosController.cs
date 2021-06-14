using Controle_de_Estoque.Data;
using Controle_de_Estoque.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
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

            return View(await _context.Produtos.Include(a => a.Categoria).ToListAsync());


        }

        public ActionResult Create()
        {
            ViewBag.Categorias = _context.Categorias;
            var model = new ProdutoViewModel();
            // Sequencial Nº Caixa Arquivo
            var maiorNumero = _context.Produtos.Max(c => c.Caixa);
            var idCaixa = 22000;
            var nCaixa = 0;

            if (maiorNumero == 0)
            {
                idCaixa++;
                nCaixa = idCaixa;
            }
            else
            {
                var diferenca = maiorNumero - idCaixa;
                diferenca++;
                nCaixa = idCaixa + diferenca;
            }

            model.Caixa = nCaixa;
            ViewBag.nCaixa = nCaixa;
            // ==========================

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
                produto.IdCategoria = model.IdCategoria;
                produto.Caixa = model.Caixa;

                var dbProd = _context.Produtos;
                dbProd.Add(produto);
                _context.SaveChanges();
                return RedirectToAction("index");
            }
            ViewBag.Categorias = _context.Categorias;
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
            Categoria categoria = _context.Categorias.Find(produto.IdCategoria);

            if (produto == null)
            {
                return NotFound("Produto não encontrado");
            }

            produto.QtdeProduto = 0;

            //ViewBag.Categorias = _context.Categorias;
            return View(produto);
        }

        //POST/Edit/Produto:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(include: "IdProduto,NomeProduto,QtdeProduto,DescricaoProduto,IdCategoria,motivoEntrada")] Produto model)
        {
            //var entrada = new Entrada();

            if (model.IdProduto != 0)
            {
                var produto = _context.Produtos.Find(model.IdProduto);

                var entrada = new Entrada();

                if (produto == null)
                {
                    return BadRequest("Requisição Invalida, ID do Produto não encontrado");
                }

                if (model.QtdeProduto > 0)
                {
                    var prodBD = produto.QtdeProduto;
                    var prodAdd = model.QtdeProduto;

                    //Entrada Model ================
                    var dataIn = DateTime.Now;
                    entrada.dataEntrada = dataIn;
                    entrada.motivoEntrada = model.motivoEntrada;
                    entrada.usuarioId = 1;
                    entrada.IdProduto = model.IdProduto;
                    //================================

                    produto.QtdeProduto = prodBD + prodAdd;
                }

                //produto.NomeProduto = model.NomeProduto;
                //produto.DescricaoProduto = produto.DescricaoProduto;
                //produto.IdCategoria = model.IdCategoria;
                var EntradaIn = _context.Entradas;
                EntradaIn.Add(entrada);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Categorias = _context.Categorias;
            return View(model);
        }

        // GET: Produto/Saida/5
        [HttpGet("Produtos/Saida/{id}")]
        public IActionResult Saida(int? id)
        {
            if (id == null)
            {
                return BadRequest("Requisição Invalida, ID não encontrado");
            }

            Produto produto = _context.Produtos.Find(id);
            Categoria categoria = _context.Categorias.Find(produto.IdCategoria);

            if (produto == null)
            {
                return NotFound("Produto não encontrado");
            }

            produto.QtdeProduto = 0;

            //ViewBag.Categorias = _context.Categorias;
            return View(produto);
        }

        //POST: Produto/saida/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Saida([Bind(include: "IdProduto,NomeProduto,QtdeProduto,DescricaoProduto,IdCategoria")] Produto model)
        {
            if (model.IdProduto != 0)
            {
                var produto = _context.Produtos.Find(model.IdProduto);

                if (produto == null)
                {
                    return BadRequest("Requisição Invalida, ID do Produto não encontrado");
                }

                if (model.QtdeProduto > 0)
                {
                    var prodBD = produto.QtdeProduto;
                    var prodAdd = model.QtdeProduto;

                    produto.QtdeProduto = prodBD - prodAdd;
                }
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Categorias = _context.Categorias;
            return View(model);
        }


        // GET: Produtos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var produto = await _context.Produtos.FirstOrDefaultAsync(m => m.IdProduto == id);

            var item = _context.Produtos
                        .Include(i => i.Categoria)
                        .FirstOrDefault(x => x.IdProduto == id);

            var motivo = (from a in _context.Entradas
                          orderby a.dataEntrada descending
                          where a.IdProduto == id
                          select new { a.motivoEntrada, a.dataEntrada });

            Dictionary<DateTime, string> lista = new Dictionary<DateTime, string>();
            
            foreach(var m in motivo)
            {
                lista.Add(m.dataEntrada, m.motivoEntrada);
            }

            //lista.Add("item1", "value1");
            //lista.Add("item2", "value2");

            ViewBag.motivos = lista;



            //var motivo = (from a in _context.Entradas
            //              orderby a.dataEntrada descending
            //              select new {a.motivoEntrada, a.dataEntrada });

            //ViewBag.motivos = motivo.ToString();


            if (item == null)
            {
                return NotFound();
            }

           //produto = await _context.Categorias.Include(m => m.IdCategoria == id));

            return View(item);
        }

        //Get: Produto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest("Requisição Invalida, ID do Produto não encontrado");
            }

            Produto produto = _context.Produtos.Find(id);

            if (produto == null)
            {
                return NotFound("Produto não encontrado");
            }
            //ViewBag.Categoria = _context.Categorias.Find(produto.Categoria.IdCategoria).NomeCategoria;
            return View(produto);
        }

        //POST: Produtos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            Produto produto = _context.Produtos.Find(id);
            _context.Produtos.Remove(produto);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
