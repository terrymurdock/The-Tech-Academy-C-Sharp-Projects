using CarInsuranceQuoteMVCApp.Models;
using System;
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
        public ActionResult Quote(string firstName, string lastName, string emailAddress, DateTime dateOfBirth, int carYear, 
                                  string carMake, string carModel, bool dUI, int speedingTickets, bool fullCoverage, bool liability,
                                  decimal quoteTotal)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(emailAddress))
            {
                return View("~/Views/Shared/Error.cshtml");
            }
            else
            {
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
                    var driverAge = DateTime.Now.Year - dateOfBirth.Year;
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
                        quoteTotal += (speedingTickets * 10.00m);
                    }
                    if (dUI == true)
                    {
                        quoteTotal *= .25m;
                    }
                    if (fullCoverage == true)
                    {
                        quoteTotal *= .5m;
                    }

                    db.Quotes.Add(quote);
                    db.SaveChanges();
                }
                return View();
            }
        }
    }
}