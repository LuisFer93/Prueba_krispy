using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Prueba_donas.Data;
using Prueba_donas.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_donas.Controllers
{
    public class VentasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VentasController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var ventas = await _context.VentasDona.ToListAsync();
            return View(ventas);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(VentaDona ventaDona)
        {
            if (ModelState.IsValid)
            {
                _context.VentasDona.Add(ventaDona);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ventaDona);
        }

        [HttpGet("GetDonas")]
        public async Task<ActionResult<IEnumerable<VentaDona>>> GetVentasDona()
        {
            var ventas = await _context.VentasDona
                                       .Where(v => v.Cantidad > 10)
                                       .ToListAsync();

            if (ventas == null || ventas.Count == 0)
            {
                return NotFound("No se encontraron ventas con cantidad mayor a 10.");
            }

            return Ok(ventas);
        }

        [HttpPost("CreateVenta")]
        public async Task<IActionResult> CreateVenta([FromBody] VentaDona ventaDona)
        {
            if (ModelState.IsValid)
            {
                _context.VentasDona.Add(ventaDona);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return BadRequest(ModelState);
        }
    }
}
