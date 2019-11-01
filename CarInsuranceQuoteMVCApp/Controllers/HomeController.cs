using CarInsuranceQuoteMVCApp.Models;
using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarInsuranceQuoteMVCApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Quote(string firstName, string lastName, string emailAddress, DateTime? dateOfBirth, int? carYear, 
                                  string carMake, string carModel, int? speedingTickets, bool? dUI = false, 
                                  bool? fullCoverage = false, bool? liability = false, decimal? quoteTotal = 50.00m)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(emailAddress) || 
                dateOfBirth == null || carYear == null || string.IsNullOrEmpty(carMake) || string.IsNullOrEmpty(carModel))
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            else
            {
                DateTime dob = Convert.ToDateTime(dateOfBirth);
                var driverAge = DateTime.Now.Year - dob.Year;

                if (driverAge < 25 || driverAge > 100)
                {
                    quoteTotal += 25.00m;
                }
                if (driverAge < 18)
                {
                    quoteTotal += 100.00m;
                }
                if (carYear < 2000 || carYear > 2015)
                {
                    quoteTotal += 25.00m;
                }
                if (carMake == "Porsche")
                {
                    quoteTotal += 25.00m;
                }
                if (carModel == "911 Carrera")
                {
                    quoteTotal += 25.00m;
                }
                if (speedingTickets > 0)
                {
                    quoteTotal += speedingTickets * 10.00m;
                }
                if (dUI == true)
                {
                    quoteTotal *= 1.25m;
                }
                if (fullCoverage == true)
                {
                    quoteTotal *= 1.5m;
                }

                using (CarInsuranceQuotesEntities db = new CarInsuranceQuotesEntities())
                {
                    var quote = new Quote
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        EmailAddress = emailAddress,
                        DateOfBirth = dateOfBirth,
                        CarYear = carYear,
                        CarMake = carMake,
                        CarModel = carModel,
                        DUI = dUI,
                        SpeedingTickets = speedingTickets,
                        FullCoverage = fullCoverage,
                        Liability = liability,
                        QuoteTotal = quoteTotal
                };
                    TempData["QT"] = quote;
                    db.Quotes.Add(quote);
                    db.SaveChanges();
                }
                return Redirect("/Home/QuoteDetails");
            }
        }
        public ActionResult QuoteDetails()
        {
            Quote qt = TempData["QT"] as Quote;
            return View(qt);
        }
    }
}