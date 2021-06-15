using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Classificados.Models;

namespace Classificados.Controllers
{
    public class ClassificadosController : Controller
    {
        private readonly Context _context;

        public ClassificadosController(Context context)
        {
            _context = context;
        }

        // GET: Classificados
        public async Task<IActionResult> Index()
        {
            var context = _context.Classificados.Include(c => c.Categoria);
            return View(await context.ToListAsync());
        }

        // GET: Classificados/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classificado = await _context.Classificados
                .Include(c => c.Categoria)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (classificado == null)
            {
                return NotFound();
            }

            return View(classificado);
        }

        // GET: Classificados/Create
        public IActionResult Create()
        {
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Nome");
            return View();
        }

        // POST: Classificados/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Titulo,Descricao,Valor,CategoriaId")] Classificado classificado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(classificado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Nome", classificado.CategoriaId);
            return View(classificado);
        }

        // GET: Classificados/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classificado = await _context.Classificados.FindAsync(id);
            if (classificado == null)
            {
                return NotFound();
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Nome", classificado.CategoriaId);
            return View(classificado);
        }

        // POST: Classificados/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Titulo,Descricao,Valor,CategoriaId")] Classificado classificado)
        {
            if (id != classificado.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(classificado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassificadoExists(classificado.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "Id", "Nome", classificado.CategoriaId);
            return View(classificado);
        }

        // GET: Classificados/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classificado = await _context.Classificados
                .Include(c => c.Categoria)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (classificado == null)
            {
                return NotFound();
            }

            return View(classificado);
        }

        // POST: Classificados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var classificado = await _context.Classificados.FindAsync(id);
            _context.Classificados.Remove(classificado);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClassificadoExists(int id)
        {
            return _context.Classificados.Any(e => e.Id == id);
        }
    }
}
