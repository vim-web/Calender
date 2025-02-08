using Clnder.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Clnder.Controllers
{
    public class TaskController : Controller
    {
        private readonly TodoDbContext _context = new TodoDbContext();

        public ActionResult Index()
        {
            var tasks = _context.TodoTasks.ToList();
            return View(tasks);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TodoTask task)
        {
            if (ModelState.IsValid)
            {
                _context.TodoTasks.Add(task);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(task);
        }

        public ActionResult Edit(int id)
        {
            var task = _context.TodoTasks.Find(id);
            if (task == null) return HttpNotFound();
            return View(task);
        }

        [HttpPost]
        public ActionResult Edit(TodoTask task)
        {
            if (ModelState.IsValid)
            {
                _context.Entry(task).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(task);
        }

        public ActionResult Delete(int id)
        {
            var task = _context.TodoTasks.Find(id);
            if (task == null) return HttpNotFound();
            return View(task);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var task = _context.TodoTasks.Find(id);
            if (task != null)
            {
                _context.TodoTasks.Remove(task);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}