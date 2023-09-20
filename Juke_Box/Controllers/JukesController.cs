using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Juke_Box.Models;
using System.Collections;

namespace Juke_Box.Controllers
{
    public class JukesController : Controller
    {
        private readonly SongDbContext _context;

        public JukesController(SongDbContext context)
        {
            _context = context;
        }

        // GET: Jukes
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var jukesList = await _context.jukes.ToListAsync();
            ViewBag.NumberOfSongs = jukesList.Count;
            return PartialView("Index", jukesList);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(Juke juke)
        {
            if (ModelState.IsValid)
            {
                _context.Add(juke);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
