using CarInsuranceQuoteMVCApp.Models;
using CarInsuranceQuoteMVCApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarInsuranceQuoteMVCApp.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            using (CarInsuranceQuotesEntities db = new CarInsuranceQuotesEntities())
            {
                var quotes = (from c in db.Quotes
                               where c.Removed == null
                               select c).ToList();

                var quoteVms = new List<QuoteVm>();
                foreach (var quote in quotes)
                {
                    var quoteVm = new QuoteVm();
                    quoteVm.QuoteID = quote.QuoteID;
                    quoteVm.FirstName = quote.FirstName;
                    quoteVm.LastName = quote.LastName;
                    quoteVm.EmailAddress = quote.EmailAddress;
                    quoteVm.QuoteTotal = quote.QuoteTotal;
                    quoteVms.Add(quoteVm);
                }
                return View(quoteVms);
            }
        }
        public ActionResult Unsubscribe(int id)
        {
            using (CarInsuranceQuotesEntities db = new CarInsuranceQuotesEntities())
            {
                var quote = db.Quotes.Find(id);
                quote.Removed = DateTime.Now;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}