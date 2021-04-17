using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoIntegrador.Database;
using ProvaAncelmo.Models;

namespace ProvaAncelmo.Controllers
{
    public class ProdutoViewModelsController : Controller
    {
        private readonly Context _context;

        public ProdutoViewModelsController(Context context)
        {
            _context = context;
        }

        // GET: ProdutoViewModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProdutoViewModels.ToListAsync());
        }

        // GET: ProdutoViewModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtoViewModel = await _context.ProdutoViewModels
                .FirstOrDefaultAsync(m => m.id == id);
            if (produtoViewModel == null)
            {
                return NotFound();
            }

            return View(produtoViewModel);
        }

        // GET: ProdutoViewModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProdutoViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,codigoProduto,preco,categoria,observacao")] ProdutoViewModel produtoViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produtoViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(produtoViewModel);
        }

        // GET: ProdutoViewModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtoViewModel = await _context.ProdutoViewModels.FindAsync(id);
            if (produtoViewModel == null)
            {
                return NotFound();
            }
            return View(produtoViewModel);
        }

        // POST: ProdutoViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,codigoProduto,preco,categoria,observacao")] ProdutoViewModel produtoViewModel)
        {
            if (id != produtoViewModel.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(produtoViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProdutoViewModelExists(produtoViewModel.id))
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
            return View(produtoViewModel);
        }

        // GET: ProdutoViewModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produtoViewModel = await _context.ProdutoViewModels
                .FirstOrDefaultAsync(m => m.id == id);
            if (produtoViewModel == null)
            {
                return NotFound();
            }

            return View(produtoViewModel);
        }

        // POST: ProdutoViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produtoViewModel = await _context.ProdutoViewModels.FindAsync(id);
            _context.ProdutoViewModels.Remove(produtoViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProdutoViewModelExists(int id)
        {
            return _context.ProdutoViewModels.Any(e => e.id == id);
        }
    }
}
