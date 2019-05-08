using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using routine_explorer.Data;
using routine_explorer.Models;

namespace routine_explorer.Controllers
{
    public class RoutineFileUploaderStatusesController : Controller
    {
        private readonly DatabaseContext _context;

        public RoutineFileUploaderStatusesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: RoutineFileUploaderStatuses
        public async Task<IActionResult> Index()
        {
            return View(await _context.RoutineFileUploaderStatus.ToListAsync());
        }

        // GET: RoutineFileUploaderStatuses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var routineFileUploaderStatus = await _context.RoutineFileUploaderStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (routineFileUploaderStatus == null)
            {
                return NotFound();
            }

            return View(routineFileUploaderStatus);
        }

        // GET: RoutineFileUploaderStatuses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RoutineFileUploaderStatuses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NameOfFilesUploaded,statusOfPublish,TimeOfUpload")] RoutineFileUploaderStatus routineFileUploaderStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(routineFileUploaderStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(routineFileUploaderStatus);
        }

        // GET: RoutineFileUploaderStatuses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var routineFileUploaderStatus = await _context.RoutineFileUploaderStatus.FindAsync(id);
            if (routineFileUploaderStatus == null)
            {
                return NotFound();
            }
            return View(routineFileUploaderStatus);
        }

        // POST: RoutineFileUploaderStatuses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NameOfFilesUploaded,statusOfPublish,TimeOfUpload")] RoutineFileUploaderStatus routineFileUploaderStatus)
        {
            if (id != routineFileUploaderStatus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(routineFileUploaderStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoutineFileUploaderStatusExists(routineFileUploaderStatus.Id))
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
            return View(routineFileUploaderStatus);
        }

        // GET: RoutineFileUploaderStatuses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var routineFileUploaderStatus = await _context.RoutineFileUploaderStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (routineFileUploaderStatus == null)
            {
                return NotFound();
            }

            return View(routineFileUploaderStatus);
        }

        // POST: RoutineFileUploaderStatuses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var routineFileUploaderStatus = await _context.RoutineFileUploaderStatus.FindAsync(id);
            _context.RoutineFileUploaderStatus.Remove(routineFileUploaderStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoutineFileUploaderStatusExists(int id)
        {
            return _context.RoutineFileUploaderStatus.Any(e => e.Id == id);
        }
    }
}
