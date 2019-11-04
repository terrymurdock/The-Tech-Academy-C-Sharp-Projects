using System.ComponentModel.DataAnnotations;

namespace KnockoutProject.ViewModels
{
    public class VisitorsLogbookViewModel
    {
        [Required, Display(Name = "Visitors Logbook: Please enter your name")]
        public string VisitorsLogbook { get; set; }
    }
}