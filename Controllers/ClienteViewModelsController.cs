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
    public class ClienteViewModelsController : Controller
    {
        private readonly Context _context;

        public ClienteViewModelsController(Context context)
        {
            _context = context;
        }

        // GET: ClienteViewModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.ClienteViewModels.ToListAsync());
        }

        // GET: ClienteViewModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteViewModel = await _context.ClienteViewModels
                .FirstOrDefaultAsync(m => m.id == id);
            if (clienteViewModel == null)
            {
                return NotFound();
            }

            return View(clienteViewModel);
        }

        // GET: ClienteViewModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClienteViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nome,sexo,endereco,numero,bairro,cep,telefone")] ClienteViewModel clienteViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clienteViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clienteViewModel);
        }

        // GET: ClienteViewModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteViewModel = await _context.ClienteViewModels.FindAsync(id);
            if (clienteViewModel == null)
            {
                return NotFound();
            }
            return View(clienteViewModel);
        }

        // POST: ClienteViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nome,sexo,endereco,numero,bairro,cep,telefone")] ClienteViewModel clienteViewModel)
        {
            if (id != clienteViewModel.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clienteViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteViewModelExists(clienteViewModel.id))
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
            return View(clienteViewModel);
        }

        // GET: ClienteViewModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteViewModel = await _context.ClienteViewModels
                .FirstOrDefaultAsync(m => m.id == id);
            if (clienteViewModel == null)
            {
                return NotFound();
            }

            return View(clienteViewModel);
        }

        // POST: ClienteViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clienteViewModel = await _context.ClienteViewModels.FindAsync(id);
            _context.ClienteViewModels.Remove(clienteViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteViewModelExists(int id)
        {
            return _context.ClienteViewModels.Any(e => e.id == id);
        }
    }
}
