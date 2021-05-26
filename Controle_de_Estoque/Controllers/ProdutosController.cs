using Controle_de_Estoque.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    }
}
