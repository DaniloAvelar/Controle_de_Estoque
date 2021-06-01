﻿using Controle_de_Estoque.Data;
using Controle_de_Estoque.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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

        //public ActionResult Index()
        //{
        //    return View();
        //}


        public async Task<IActionResult> Index()
        {
            return View(await _context.Produtos.ToListAsync());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
