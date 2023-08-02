using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using TravelAgencyProject.Dal;
using TravelAgencyProject.Models;

namespace TravelAgencyProject.Controllers
{
    public class FlightsController : Controller
    {

        public ActionResult ViewPage()
        {

            Flights flight = new Flights();
            flight.From = Request.Form["From"];
            flight.To = Request.Form["To"];
            flight.Price = Convert.ToDouble(Request.Form["Price"]);
            flight.DepartDate = Convert.ToDateTime(Request.Form["DepartDate"]);
            flight.ReturnDate= Convert.ToDateTime(Request.Form["ReturnDate"]);
            var TwoWayFlight = Request.Form["radio"];
            var passenger= int.Parse(Request.Form["Traveller"]); 
            ViewBag.pasnum = passenger;


            IQueryable<Flights> filghtlist = null;

            if (TwoWayFlight == "TwoWay")
            {
                filghtlist = db.Flights.Where(x => x.From == flight.From && x.To == flight.To && x.DepartDate.Equals(flight.DepartDate)
                           && x.ReturnDate.Equals(flight.ReturnDate) && flight.Price >= x.Price && x.FlightType == "TwoWay" && x.Seats >= passenger && flight.DepartDate > DateTime.Now);
            }
            else
            {
                filghtlist = db.Flights.Where(x => x.From == flight.From && x.To == flight.To && x.DepartDate.Equals(flight.DepartDate)
                && flight.Price >= x.Price && x.FlightType == "OneWay" && x.Seats >= passenger && flight.DepartDate > DateTime.Now);


            }

            if (!filghtlist.Any())
            {
                ViewBag.Message = "No flights found";
                return View("SearchFlights");
            }

            if(TwoWayFlight == "TwoWay")
                return View("ShowFlightsTwoWay",filghtlist);
            else
                return View("ShowFlightsOneWay", filghtlist);

        }

        public ActionResult Booking(int? id,int? passnum)
        {
            var flight = new FlightsDAL();
            var myflight = flight.Flights.Find(id);
            var sum = (int?)((myflight.Price) * passnum);
            return RedirectToAction("Create", "Payments", new { flightid = id ,num=passnum,total=sum});
        }


        public ActionResult SearchFlights()
        {
            return View("SearchFlights");
        }

        private FlightsDAL db = new FlightsDAL();

        public ActionResult Index()
        {
            return View(db.Flights.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flights flights = db.Flights.Find(id);
            if (flights == null)
            {
                return HttpNotFound();
            }
            return View(flights);
        }

    
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,From,To,DepartDate,ReturnDate,Price,Seats,DepartTime,ReturnTime,FlightType")] Flights flights)
        {


            if (ModelState.IsValid)
            {
                db.Flights.Add(flights);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(flights);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flights flights = db.Flights.Find(id);
            if (flights == null)
            {
                return HttpNotFound();
            }
            return View(flights);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,From,To,DepartDate,ReturnDate,Price,SeatsRow,DepartTime,ReturnTime")] Flights flights)
        {
            if (ModelState.IsValid)
            {
                db.Entry(flights).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(flights);
        }

        // GET: Flights/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Flights flights = db.Flights.Find(id);
            if (flights == null)
            {
                return HttpNotFound();
            }
            return View(flights);
        }

        // POST: Flights/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Flights flights = db.Flights.Find(id);
            db.Flights.Remove(flights);
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
