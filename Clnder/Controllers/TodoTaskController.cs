using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Clnder.Models;
using System.Data.Entity;


namespace Clnder.Controllers
{



    public class TodoTaskController : Controller
    {


        private ApplicationDbContext db = new ApplicationDbContext();





        // GET: TodoTask
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
                var existingTask = _context.TodoTasks.Find(task.Id); // Find existing task in DB
                if (existingTask == null) return HttpNotFound(); // Handle case where task doesn't exist

                // Manually update fields
                existingTask.Title = task.Title;
                existingTask.Description = task.Description;
                existingTask.Status = task.Status;
                existingTask.DueDate = task.DueDate;

                _context.SaveChanges(); // Save changes
                return RedirectToAction("Index"); // Redirect back to task list
            }

            return View(task); // If validation fails, return the form with errors
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
                _context.TodoTasks.Remove(task); // Remove the task from the database
                _context.SaveChanges(); // Commit changes to the database
            }
            return RedirectToAction("Index"); // Redirect back to the Index view after deletion
        }
        // GET: TodoTask/Calendar
        public ActionResult Calendar()
        {
            return View();
        }

       
        //public ActionResult GetTasksForCalendar()
        //{
        //    // Fetch tasks from the database and ensure DueDate is included
        //    var query = db.TodoTasks
        //      .Where(task => task.DueDate != null)
        //      .Select(task => new
        //      {
        //          task.Id,
        //          task.Title,
        //          task.Description,
        //          task.Status,
        //          DueDate = task.DueDate
        //      });

        //    var tasks = query.ToList(); // Check this line for issues


        //    // Format the DueDate in-memory to a string if needed
        //    var formattedTasks = tasks.Select(task => new
        //    {
        //        task.Id,
        //        task.Title,
        //        task.Description,
        //        task.Status,
        //        DueDate = task.DueDate.HasValue ? task.DueDate.Value.ToString("yyyy-MM-dd") : null // Format the DueDate as a string
        //    }).ToList();

        //    return Json(formattedTasks, JsonRequestBehavior.AllowGet);
        //}



    }


}

    










