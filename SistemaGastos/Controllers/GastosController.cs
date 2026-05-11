using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaGastos.Models;

namespace SistemaGastos.Controllers
{
    public class GastosController : Controller
    {
        private readonly AppDbContext _context;

        public GastosController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var gastos = await _context.Gastos
                .Include(g => g.Categoria)
                .OrderByDescending(g => g.Fecha)
                .ToListAsync();
            return View(gastos);
        }

        public async Task<IActionResult> Crear()
        {
            ViewBag.Categorias = await _context.Categorias
                .OrderBy(c => c.Nombre == "Otros")
                .ThenBy(c => c.Nombre)
                .ToListAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Crear(Gasto gasto)
        {
            if (ModelState.IsValid)
            {
                _context.Gastos.Add(gasto);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Categorias = await _context.Categorias
                .OrderBy(c => c.Nombre == "Otros")
                .ThenBy(c => c.Nombre)
                .ToListAsync();
            return View(gasto);
        }

        public async Task<IActionResult> Editar(int id)
        {
            var gasto = await _context.Gastos.FindAsync(id);
            if (gasto == null) return NotFound();

            ViewBag.Categorias = await _context.Categorias
                .OrderBy(c => c.Nombre == "Otros")
                .ThenBy(c => c.Nombre)
                .ToListAsync();
            return View(gasto);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(int id, Gasto gasto)
        {
            if (ModelState.IsValid)
            {
                _context.Gastos.Update(gasto);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.Categorias = await _context.Categorias
                .OrderBy(c => c.Nombre == "Otros")
                .ThenBy(c => c.Nombre)
                .ToListAsync();
            return View(gasto);
        }

        public async Task<IActionResult> Eliminar(int id)
        {
            var gasto = await _context.Gastos.FindAsync(id);
            if (gasto == null) return NotFound();

            _context.Gastos.Remove(gasto);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}