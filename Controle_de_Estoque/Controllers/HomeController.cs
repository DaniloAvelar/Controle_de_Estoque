using Controle_de_Estoque.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Controle_de_Estoque.Controllers
{
    public class HomeController : Controller
    {
        private readonly ControleDeEstoqueDbContext _context;
        public HomeController(ControleDeEstoqueDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Produtos.ToListAsync());
        }


        //// GET: Produtos
        //public ActionResult Index()
        //{

        //    var produtos = _context.Produtos.ToList();
        //    return View(produtos);
        //}



        ////GET: Produtos
        //public ActionResult Index()
        //{
        //    var produtos = _context.Produtos.ToList();
        //    return View(produtos);
        //}

        //private readonly ControleDeEstoqueDbContext _context;
        //public HomeController(ControleDeEstoqueDbContext context)
        //{
        //    _context = context;
        //}

        //// ControleDeEstoqueDbContext db;

        //// GET: Produtos
        //public ActionResult Index()
        //{
        //    var produtos = _context.Produtos.ToList();
        //    return View(produtos);
        //}


        ////public async Task<IActionResult> Index()
        ////{
        ////    return View(await _context.Produtos.ToListAsync());
        ////}

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
