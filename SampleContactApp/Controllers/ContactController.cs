using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SampleContactApp.Models;using System.Diagnostics;

namespace SampleContactApp.Controllers
{
    public class ContactController : Controller
    {
        private MyDatabaseContext db = new MyDatabaseContext();
        
        public ActionResult Index()
        {            
            Trace.WriteLine("GET /Contact/Index");
            return View(db.Contacts.ToList());
        }
        
        // GET: Contact/Create
        public ActionResult Create()
        {
            Trace.WriteLine("GET /Contact/Create");
            return View(new Contact {});
        }

        // POST: Contact/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FirstName,LastName,Email,PhoneNumber,IsActive")] Contact contact)
        {
            Trace.WriteLine("POST /Contact/Create");
            if (ModelState.IsValid)
            {
                db.Contacts.Add(contact);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contact);
        }

        // GET: Contact/Edit/5
        public ActionResult Edit(int? id)
        {
            Trace.WriteLine("GET /Contact/Edit/" + id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: Contact/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,FirstName,LastName,Email,PhoneNumber,IsActive")] Contact contact)
        {
            Trace.WriteLine("POST /Contact/Edit/" + contact.ID);
            if (ModelState.IsValid)
            {
                db.Entry(contact).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contact);
        }

        // GET: Contact/Delete/5
        public ActionResult Delete(int? id)
        {
            Trace.WriteLine("GET /Contact/Delete/" + id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: Contact/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Trace.WriteLine("POST /Contact/Delete/" + id);
            Contact contact = db.Contacts.Find(id);
            db.Contacts.Remove(contact);
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
