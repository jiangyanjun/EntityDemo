using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DbContext;
using EntityBase;

namespace EntityDemo.Controllers
{
    public class ProcudesController : Controller
    {
        private DbContext.DbContext db = new DbContext.DbContext();

        // GET: Procudes
        public ActionResult Index()
        {
            return View(db.ProductBase.ToList());
        }

        // GET: Procudes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Procude procude = db.ProductBase.Find(id);
            if (procude == null)
            {
                return HttpNotFound();
            }
            return View(procude);
        }

        // GET: Procudes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Procudes/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Sex,Age")] Procude procude)
        {
            if (ModelState.IsValid)
            {
                db.ProductBase.Add(procude);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(procude);
        }

        // GET: Procudes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Procude procude = db.ProductBase.Find(id);
            if (procude == null)
            {
                return HttpNotFound();
            }
            return View(procude);
        }

        // POST: Procudes/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Sex,Age")] Procude procude)
        {
            if (ModelState.IsValid)
            {
                db.Entry(procude).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(procude);
        }

        // GET: Procudes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Procude procude = db.ProductBase.Find(id);
            if (procude == null)
            {
                return HttpNotFound();
            }
            return View(procude);
        }

        // POST: Procudes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Procude procude = db.ProductBase.Find(id);
            db.ProductBase.Remove(procude);
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
