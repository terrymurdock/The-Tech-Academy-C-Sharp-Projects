using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarInsuranceQuoteMVCApp.ViewModels
{
    public class QuoteVm
    {
        public int QuoteID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public Nullable<int> CarYear { get; set; }
        public string CarMake { get; set; }
        public string CarModel { get; set; }
        public Nullable<bool> DUI { get; set; }
        public Nullable<int> SpeedingTickets { get; set; }
        public Nullable<bool> FullCoverage { get; set; }
        public Nullable<bool> Liability { get; set; }
        public Nullable<decimal> QuoteTotal { get; set; }
    }
}