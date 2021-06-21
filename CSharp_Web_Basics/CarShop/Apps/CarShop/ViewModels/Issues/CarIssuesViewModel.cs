using CarShop.Data.Models;
using System.Collections.Generic;

namespace CarShop.ViewModels.Issues
{
    public class CarIssuesViewModel
    {
        public string Model { get; set; }

        public int Year { get; set; }

        public string CarId { get; set; }

        public ICollection<IssueViewModel> Issues { get; set; }
    }
}
