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
    public class FilmsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Films
        public ActionResult Index()
        {
            var tbFilm = db.tbFilm.Include(f => f.ECRB).Include(f => f.Genre);
            return View(tbFilm.ToList());
        }

        // GET: Films/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Film film = db.tbFilm.Find(id);
            if (film == null)
            {
                return HttpNotFound();
            }
            return View(film);
        }

        // GET: Films/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            ViewBag.ECRBId = new SelectList(db.tbECRB, "ECRBId", "ECRBName");
            ViewBag.GenreId = new SelectList(db.tbGenre, "GenreId", "GenreName");
            return View();
        }

        // POST: Films/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Create([Bind(Include = "FilmId,FilmName,AllAbout,GenreId,ECRBId")] Film film)
        {
            if (ModelState.IsValid)
            {
                db.tbFilm.Add(film);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ECRBId = new SelectList(db.tbECRB, "ECRBId", "ECRBName", film.ECRBId);
            ViewBag.GenreId = new SelectList(db.tbGenre, "GenreId", "GenreName", film.GenreId);
            return View(film);
        }

        // GET: Films/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Film film = db.tbFilm.Find(id);
            if (film == null)
            {
                return HttpNotFound();
            }
            ViewBag.ECRBId = new SelectList(db.tbECRB, "ECRBId", "ECRBName", film.ECRBId);
            ViewBag.GenreId = new SelectList(db.tbGenre, "GenreId", "GenreName", film.GenreId);
            return View(film);
        }

        // POST: Films/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Edit([Bind(Include = "FilmId,FilmName,AllAbout,GenreId,ECRBId")] Film film)
        {
            if (ModelState.IsValid)
            {
                db.Entry(film).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ECRBId = new SelectList(db.tbECRB, "ECRBId", "ECRBName", film.ECRBId);
            ViewBag.GenreId = new SelectList(db.tbGenre, "GenreId", "GenreName", film.GenreId);
            return View(film);
        }

        // GET: Films/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Film film = db.tbFilm.Find(id);
            if (film == null)
            {
                return HttpNotFound();
            }
            return View(film);
        }

        // POST: Films/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Film film = db.tbFilm.Find(id);
            db.tbFilm.Remove(film);
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
