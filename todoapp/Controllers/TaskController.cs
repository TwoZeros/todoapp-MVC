using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using todoapp.Models;
using todoapp.Repository.Interfaces;
using todoDap.Repositories;

namespace todoapp.Controllers
{
    public class TaskController : Controller
    {
       
        IRepository<TaskTodo> db;
        public TaskController()
        {
            db = new TodoRepository();
           
        }

        // GET: TaskTodoes
        public IActionResult Index()
        {
            return View(db.GetAll());
        }

        // GET: TaskTodoes/Details/5
        public IActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskTodo = db.GetById(id);
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
                db.Create(taskTodo);
                return RedirectToAction(nameof(Index));
            }
            return View(taskTodo);
        }

        // GET: TaskTodoes/Edit/5
        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskTodo = db.GetById(id);
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
                    db.Update(taskTodo);
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
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskTodo = db.GetById(id);
            if (taskTodo == null)
            {
                return NotFound();
            }

            return View(taskTodo);
        }

        // POST: TaskTodoes/Delete/5
        [HttpPost, ActionName(nameof(Delete))]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
        
        var taskTodo = db.GetById(id);
            db.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool TaskTodoExists(int id)
        {

            return db.GetById(id) != null;

        }
    }
}
