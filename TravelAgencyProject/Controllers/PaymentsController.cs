using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.Mvc;
using TravelAgencyProject.Dal;
using TravelAgencyProject.Models;

namespace TravelAgencyProject.Controllers
{
    public class PaymentsController : Controller
    {
        private PaymentsDAL db = new PaymentsDAL();

        // GET: Payments
        public ActionResult Index()
        {
            return View(db.Payments.ToList());
        }

        public ActionResult Success()
        {
            return View("Success");
        }
        public ActionResult SearchFlights()
        {
            return RedirectToAction("SearchFlights","Flights");
        }

        // GET: Payments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment payment = db.Payments.Find(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            return View(payment);
        }

        // GET: Payments/Create
        public ActionResult Create(int total)
        {
            ViewBag.totalprice = total;
            return View();
        }

        // POST: Payments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ReservationId,FirstName,LastName,Email,id,PhoneNumber,TotalPrice,CardNumber")] Payment payment,int flightid,int num, int total)
        {

            var savecredit = Request.Form["radio"];

            if (ModelState.IsValid)
            {
                db.Payments.Add(payment);
                db.SaveChanges();
                if (savecredit == "No")
                {
                    payment.CardNumber = "################";
                    db.SaveChanges();

                }
                var flight = new FlightsDAL();
                //var myflight = flight.Flights.Find(flightid);
                Flights myflight = db.Flights.Find(flightid);
                if (myflight != null)
                {
                    payment.TotalPrice = total;
                    myflight.Seats = (myflight.Seats) - num;
                    //db.Entry(myflight).State = EntityState.Modified;
                    db.SaveChanges();
                }
                ViewBag.flightnumber = flightid;

                return View("Success",payment);
            }

            return View(payment);
        }

        // GET: Payments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment payment = db.Payments.Find(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            return View(payment);
        }

        // POST: Payments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ReservationId,FirstName,LastName,Email,id,PhoneNumber,TotalPrice,CardNumber")] Payment payment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(payment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(payment);
        }

        // GET: Payments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment payment = db.Payments.Find(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            return View(payment);
        }

        // POST: Payments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Payment payment = db.Payments.Find(id);
            db.Payments.Remove(payment);
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
