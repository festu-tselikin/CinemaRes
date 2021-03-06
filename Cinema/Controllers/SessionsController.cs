﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cinema.Models;
using PagedList;
using Microsoft.AspNet.Identity;


namespace Cinema.Controllers
{
    public class SessionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Sessions
        public ActionResult Index(string RoomId,int? page)
        {
            //var tbSession = db.tbSession.Include(s => s.Film).Include(s => s.Room);
            //return View(tbSession.ToList());
           // searchString1 = DateTime.Today;
            var RoomList = new List<string>();
            var RoomQry = from d in db.tbRoom
                          orderby d.RoomName
                          select d.RoomName;
            RoomList.AddRange(RoomQry.Distinct());
            //ViewBag.RoomId = new SelectList(db.tbRoom, "RoomId", "RoomName");
            ViewBag.RoomId = new SelectList(RoomList);
            var query = from m in db.tbSession
                        orderby m.DateSession
                        select m;
            if (!String.IsNullOrEmpty(RoomId))
            {
                query = query.Where(s => s.Room.RoomName == RoomId).OrderBy(s=>s.DateSession);
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(query.ToPagedList(pageNumber,pageSize));
        }

        // GET: Sessions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Session session = db.tbSession.Find(id);
            if (session == null)
            {
                return HttpNotFound();
            }
            return View(session);
        }

        // GET: Sessions/Create
        public ActionResult Create()
        {
            ViewBag.FilmId = new SelectList(db.tbFilm, "FilmId", "FilmName");
            ViewBag.RoomId = new SelectList(db.tbRoom, "RoomId", "RoomName");
            return View();
        }

        // POST: Sessions/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SessionID,FilmId,RoomId,DateSession,TimeSession")] Session session)
        {
            if (ModelState.IsValid)
            {
                db.tbSession.Add(session);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FilmId = new SelectList(db.tbFilm, "FilmId", "FilmName", session.FilmId);
            ViewBag.RoomId = new SelectList(db.tbRoom, "RoomId", "RoomName", session.RoomId);
            return View(session);
        }

        // GET: Sessions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Session session = db.tbSession.Find(id);
            if (session == null)
            {
                return HttpNotFound();
            }
            ViewBag.FilmId = new SelectList(db.tbFilm, "FilmId", "FilmName", session.FilmId);
            ViewBag.RoomId = new SelectList(db.tbRoom, "RoomId", "RoomName", session.RoomId);
            return View(session);
        }

        // POST: Sessions/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SessionID,FilmId,RoomId,DateSession,TimeSession")] Session session)
        {
            if (ModelState.IsValid)
            {
                db.Entry(session).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FilmId = new SelectList(db.tbFilm, "FilmId", "FilmName", session.FilmId);
            ViewBag.RoomId = new SelectList(db.tbRoom, "RoomId", "RoomName", session.RoomId);
            return View(session);
        }

        // GET: Sessions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Session session = db.tbSession.Find(id);
            if (session == null)
            {
                return HttpNotFound();
            }
            return View(session);
        }

        // POST: Sessions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Session session = db.tbSession.Find(id);
            db.tbSession.Remove(session);
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
        [Authorize(Roles = "user")]
        public ActionResult Book(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Session session = db.tbSession.Find(id);
            if (session == null)
            {
                return HttpNotFound();
            }
            ViewBag.SectorID = new SelectList(db.tbSector, "SectorId", "SectorName", session.SessionID);
            return View(session);
        }

        [HttpPost]
        public ActionResult Book(FormCollection FC)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            context.tbTicket.Add(new Ticket
            {
                ClientId=User.Identity.GetUserId(),
                Price = 500,
                SectorId=Int32.Parse(FC["SectorID"]),
                NColumn=Int32.Parse(FC["Column"]),
                NSpot=Int32.Parse(FC["Row"]),
                SessionId=Int32.Parse(FC["SessionID"])
            });
            context.SaveChanges();
            return RedirectToAction("Thanks");
        }

        public ActionResult Thanks()
        {
            return View();
        }

    }
}
