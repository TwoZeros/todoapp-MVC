using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using todoapp.Data;
using todoapp.Models;

namespace todoapp.Controllers
{
    public class TaskController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TaskController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TaskTodoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tasks.ToListAsync());
        }

        // GET: TaskTodoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskTodo = await _context.Tasks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taskTodo == null)
            {
                return NotFound();
            }

            return View(taskTodo);
        }

        // GET: TaskTodoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TaskTodoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,Name,Completed,Description")] TaskTodo taskTodo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taskTodo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(taskTodo);
        }

        // GET: TaskTodoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskTodo = await _context.Tasks.FindAsync(id);
            if (taskTodo == null)
            {
                return NotFound();
            }
            return View(taskTodo);
        }

        // POST: TaskTodoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,Name,Completed,Description")] TaskTodo taskTodo)
        {
            if (id != taskTodo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taskTodo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskTodoExists(taskTodo.Id))
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
            return View(taskTodo);
        }

        // GET: TaskTodoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskTodo = await _context.Tasks
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taskTodo == null)
            {
                return NotFound();
            }

            return View(taskTodo);
        }

        // POST: TaskTodoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var taskTodo = await _context.Tasks.FindAsync(id);
            _context.Tasks.Remove(taskTodo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaskTodoExists(int id)
        {
            return _context.Tasks.Any(e => e.Id == id);
        }
    }
}
