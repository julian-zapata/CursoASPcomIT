﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyComercio.Data;
using MyComercio.Helper;
using MyComercio.Models;

namespace MyComercio.Controllers
{
    public class CiudadController : Controller
    {
        private readonly MyComercioContext _context;

        public CiudadController(MyComercioContext context)
        {
            _context = context;
        }

        // GET: Ciudad
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ciudad.ToListAsync());
        }

        // GET: Ciudad/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ciudad = await _context.Ciudad
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ciudad == null)
            {
                return NotFound();
            }

            return View(ciudad);
        }

        // GET: Ciudad/Create
        public IActionResult Create()
        {
            //var myhelper = new MyHelper(_context);
            //objeto para poder acceder a los metodos de esta clasee

            ViewBag.ListaPaises = MyHelper.GetPaisesSelectList();
            ViewBag.ListaCiudades = MyHelper.GetCiudadesSelectList();

            return View();
        }

        // POST: Ciudad/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IdPais,Descripcion")] Ciudad ciudad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ciudad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ciudad);
        }

        // GET: Ciudad/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ciudad = await _context.Ciudad.FindAsync(id);
            if (ciudad == null)
            {
                return NotFound();
            }
            return View(ciudad);
        }

        // POST: Ciudad/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdPais,Descripcion")] Ciudad ciudad)
        {
            if (id != ciudad.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ciudad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CiudadExists(ciudad.Id))
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
            return View(ciudad);
        }

        // GET: Ciudad/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ciudad = await _context.Ciudad
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ciudad == null)
            {
                return NotFound();
            }

            return View(ciudad);
        }

        // POST: Ciudad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ciudad = await _context.Ciudad.FindAsync(id);
            _context.Ciudad.Remove(ciudad);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CiudadExists(int id)
        {
            return _context.Ciudad.Any(e => e.Id == id);
        }

        public JsonResult GetCiudades(int idPais)
        {
            var ciudades = _context.Ciudad.Where(x => x.IdPais == idPais).ToList();

            return Json(ciudades);
        }

    }
}
