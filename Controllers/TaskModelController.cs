using System;
using System.Collections.Generic;
using System.Linq;
using _49_1.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _49_1.Controllers
{
    public class TaskModelController : Controller
    {
        private ApplicationContext _db;

        public TaskModelController(ApplicationContext db)
        {
            _db = db;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<TaskModel> tasks = _db.TasksModel.ToList();
            return View(tasks);
        }

        //Add new Task
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(TaskModel task)
        {
            if (task != null)
            {
                _db.TasksModel.Add(task);
                _db.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        //Details Task
        public IActionResult Details(int id)
        {
            var task = _db.TasksModel.FirstOrDefault(e => e.Id == id);

            return View(task);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var task = _db.TasksModel.FirstOrDefault(t => t.Id == id);
            _db.TasksModel.Remove(task);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult InProgress(int id)
        {
            _db.TasksModel.FirstOrDefault(t => t.Id == id).Status = "inProgress";
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Done(int id)
        {
            _db.TasksModel.FirstOrDefault(t => t.Id == id).Status = "done";
            _db.TasksModel.FirstOrDefault(t => t.Id == id).DateOfRelease = DateTime.Now;

            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
