using CarShop.ViewModels.Issues;
using System.Collections.Generic;

namespace CarShop.Services
{
    public interface IIssuesService
    {
        CarIssuesViewModel GetAllIssues(string carId);

        void Add(string carId, string description);

        void Delete(string carId, string issueId);

        void Fix(string issueId, string carId);
    }
}
