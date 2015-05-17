using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cinema.Models;

namespace Cinema.Controllers
{
    [Authorize(Roles = "admin")]
    public class ECRBsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ECRBs
        public ActionResult Index()
        {
            return View(db.tbECRB.ToList());
        }

        // GET: ECRBs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ECRB eCRB = db.tbECRB.Find(id);
            if (eCRB == null)
            {
                return HttpNotFound();
            }
            return View(eCRB);
        }

        // GET: ECRBs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ECRBs/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ECRBId,ECRBName")] ECRB eCRB)
        {
            if (ModelState.IsValid)
            {
                db.tbECRB.Add(eCRB);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eCRB);
        }

        // GET: ECRBs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ECRB eCRB = db.tbECRB.Find(id);
            if (eCRB == null)
            {
                return HttpNotFound();
            }
            return View(eCRB);
        }

        // POST: ECRBs/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ECRBId,ECRBName")] ECRB eCRB)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eCRB).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eCRB);
        }

        // GET: ECRBs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ECRB eCRB = db.tbECRB.Find(id);
            if (eCRB == null)
            {
                return HttpNotFound();
            }
            return View(eCRB);
        }

        // POST: ECRBs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ECRB eCRB = db.tbECRB.Find(id);
            db.tbECRB.Remove(eCRB);
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
