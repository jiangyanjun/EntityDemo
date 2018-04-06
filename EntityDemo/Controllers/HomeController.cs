using DbContext;
using EntityBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EntityDemo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View(ProcudeDAL.ToLost());
        }
        public ActionResult Add()
        {
            return View();
        }
        public ActionResult Details()
        {
            return View(ProcudeDAL.ToLost());
        }
        public ActionResult Delete()
        {
            return View(ProcudeDAL.ToLost());
        }
        public ActionResult Edit()
        {
            return View(ProcudeDAL.ToLost());
        }
        public ActionResult AddSave(Procude p)
        {
            if (ModelState.IsValid)
                ProcudeDAL.Add(p);
            return RedirectToAction("Index");
        }
    }
}