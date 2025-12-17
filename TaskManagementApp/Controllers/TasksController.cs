using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TaskManagementApp.Data;
using TaskManagementApp.Models;
using TaskStatus = TaskManagementApp.Models.Enums.TaskStatus;

namespace TaskManagementApp.Controllers
{
    public class TasksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TasksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tasks
        public async Task<IActionResult> Index(string searchString, TaskStatus? status)
        {
            var query = _context.Tasks
                .Include(t => t.CreatedByUser)
                .Include(t => t.UpdatedByUser)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                query = query.Where(t =>
                    t.Title.Contains(searchString) ||
                    t.Description.Contains(searchString));
            }

            if (status.HasValue)
            {
                query = query.Where(t => t.Status == status.Value);
            }

            ViewBag.StatusList = Enum.GetValues(typeof(TaskStatus))
                .Cast<TaskStatus>()
                .ToList();

            return View(await query.ToListAsync());
        }


        // GET: Tasks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskItem = await _context.Tasks
                .Include(t => t.CreatedByUser)
                .Include(t => t.UpdatedByUser)
                .FirstOrDefaultAsync(m => m.TaskId == id);
            if (taskItem == null)
            {
                return NotFound();
            }

            return View(taskItem);
        }

        // GET: Tasks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tasks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Description,DueDate,Status,Remarks")] TaskItem taskItem)
        {
            if (ModelState.IsValid)
            {

                taskItem.CreatedOn = DateTime.UtcNow;
                taskItem.UpdatedOn = DateTime.UtcNow;
                taskItem.CreatedBy = 1;   // Admin
                taskItem.UpdatedBy = 1;

                _context.Add(taskItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(taskItem);
        }


        // GET: Tasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskItem = await _context.Tasks.FindAsync(id);
            if (taskItem == null)
            {
                return NotFound();
            }
            return View(taskItem);
        }

        // POST: Tasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TaskId,Title,Description,DueDate,Status,Remarks")] TaskItem taskItem)
        {
            if (id != taskItem.TaskId)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    var existingTask = await _context.Tasks
                        .AsNoTracking()
                        .FirstOrDefaultAsync(t => t.TaskId == id);

                    if (existingTask == null)
                        return NotFound();

                    // Preserve creation audit data
                    taskItem.CreatedOn = existingTask.CreatedOn;
                    taskItem.CreatedBy = existingTask.CreatedBy;

                    // Update audit data
                    taskItem.UpdatedOn = DateTime.UtcNow;
                    taskItem.UpdatedBy = 1;

                    _context.Update(taskItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskItemExists(taskItem.TaskId))
                        return NotFound();
                    else
                        throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(taskItem);
        }


        // GET: Tasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskItem = await _context.Tasks
                .Include(t => t.CreatedByUser)
                .Include(t => t.UpdatedByUser)
                .FirstOrDefaultAsync(m => m.TaskId == id);
            if (taskItem == null)
            {
                return NotFound();
            }

            return View(taskItem);
        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var taskItem = await _context.Tasks.FindAsync(id);
            if (taskItem != null)
            {
                _context.Tasks.Remove(taskItem);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaskItemExists(int id)
        {
            return _context.Tasks.Any(e => e.TaskId == id);
        }
    }
}
