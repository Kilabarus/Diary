using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DiaryService.Models;

namespace DiaryService.Controllers
{
    public class TasksController : Controller
    {
        private DiaryConnection db = new DiaryConnection();

        // GET: Tasks
        public ActionResult Index()
        {
            var tasks = db.Tasks.Include(t => t.TaskType).Include(t => t.TaskStatus).Include(t => t.TaskFrequency);
            return View(tasks.ToList());
        }

        // GET: Tasks/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task task = db.Tasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // GET: Tasks/Create
        public ActionResult Create()
        {
            ViewBag.Type_Id = new SelectList(db.TaskTypes, "Id", "Type");
            ViewBag.Status_Id = new SelectList(db.TaskStatus, "Id", "Status");
            ViewBag.Frequency_Id = new SelectList(db.TaskFrequencies, "Id", "Frequency");
            return View();
        }

        // POST: Tasks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,BeginDate,EndDate,Description,Type_Id,Frequency_Id,Status_Id")] Task task)
        {
            if (ModelState.IsValid)
            {
                db.Tasks.Add(task);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Type_Id = new SelectList(db.TaskTypes, "Id", "Type", task.Type_Id);
            ViewBag.Status_Id = new SelectList(db.TaskStatus, "Id", "Status", task.Status_Id);
            ViewBag.Frequency_Id = new SelectList(db.TaskFrequencies, "Id", "Frequency", task.Frequency_Id);
            return View(task);
        }

        // GET: Tasks/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task task = db.Tasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            ViewBag.Type_Id = new SelectList(db.TaskTypes, "Id", "Type", task.Type_Id);
            ViewBag.Status_Id = new SelectList(db.TaskStatus, "Id", "Status", task.Status_Id);
            ViewBag.Frequency_Id = new SelectList(db.TaskFrequencies, "Id", "Frequency", task.Frequency_Id);
            return View(task);
        }

        // POST: Tasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,BeginDate,EndDate,Description,Type_Id,Frequency_Id,Status_Id")] Task task)
        {
            if (ModelState.IsValid)
            {
                db.Entry(task).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Type_Id = new SelectList(db.TaskTypes, "Id", "Type", task.Type_Id);
            ViewBag.Status_Id = new SelectList(db.TaskStatus, "Id", "Status", task.Status_Id);
            ViewBag.Frequency_Id = new SelectList(db.TaskFrequencies, "Id", "Frequency", task.Frequency_Id);
            return View(task);
        }

        // GET: Tasks/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task task = db.Tasks.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Task task = db.Tasks.Find(id);
            db.Tasks.Remove(task);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
