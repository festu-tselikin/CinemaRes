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

    public class TicketsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Tickets
        public ActionResult Index()
        {
            var tbTicket = db.tbTicket.Include(t => t.Client).Include(t => t.Sector);
            return View(tbTicket.ToList());
        }

        // GET: Tickets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.tbTicket.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // GET: Tickets/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            ViewBag.ClientId = new SelectList(db.tbClients, "ClientId", "Family");
            ViewBag.SectorId = new SelectList(db.tbSector, "SectorId", "SectorName");
            return View();
        }

        // POST: Tickets/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Create([Bind(Include = "TicketId,ClientId,SectorId,NColumn,NSpot,Price")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.tbTicket.Add(ticket);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientId = new SelectList(db.tbClients, "ClientId", "Family", ticket.ClientId);
            ViewBag.SectorId = new SelectList(db.tbSector, "SectorId", "SectorName", ticket.SectorId);
            return View(ticket);
        }

        // GET: Tickets/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.tbTicket.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientId = new SelectList(db.tbClients, "ClientId", "Family", ticket.ClientId);
            ViewBag.SectorId = new SelectList(db.tbSector, "SectorId", "SectorName", ticket.SectorId);
            return View(ticket);
        }

        // POST: Tickets/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Edit([Bind(Include = "TicketId,ClientId,SectorId,NColumn,NSpot,Price")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ticket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientId = new SelectList(db.tbClients, "ClientId", "Family", ticket.ClientId);
            ViewBag.SectorId = new SelectList(db.tbSector, "SectorId", "SectorName", ticket.SectorId);
            return View(ticket);
        }

        // GET: Tickets/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.tbTicket.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Ticket ticket = db.tbTicket.Find(id);
            db.tbTicket.Remove(ticket);
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
