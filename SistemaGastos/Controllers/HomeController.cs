using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaGastos.Models;

namespace SistemaGastos.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var gastos = await _context.Gastos
                .Include(g => g.Categoria)
                .ToListAsync();

            var totalIngresos = gastos
                .Where(g => g.Tipo == "Ingreso")
                .Sum(g => g.Monto);

            var totalGastos = gastos
                .Where(g => g.Tipo == "Gasto")
                .Sum(g => g.Monto);

            var balance = totalIngresos - totalGastos;

            var porCategoria = gastos
                .Where(g => g.Tipo == "Gasto")
                .GroupBy(g => g.Categoria!.Nombre)
                .Select(g => new
                {
                    Categoria = g.Key,
                    Total = g.Sum(x => x.Monto)
                })
                .OrderByDescending(g => g.Total)
                .ToList();

            ViewBag.TotalIngresos = totalIngresos;
            ViewBag.TotalGastos = totalGastos;
            ViewBag.Balance = balance;
            ViewBag.PorCategoria = porCategoria;
            ViewBag.UltimosGastos = gastos
                .OrderByDescending(g => g.Fecha)
                .Take(5)
                .ToList();

            return View();
        }
    }
}
