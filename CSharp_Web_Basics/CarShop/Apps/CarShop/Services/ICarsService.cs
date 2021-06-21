using CarShop.ViewModels.Cars;
using System.Collections.Generic;

namespace CarShop.Services
{
    public interface ICarsService
    {
        void Add(string userId, string model, int year, string imagePath, string plateNumber);

        ICollection<CarViewModel> AllByUser(string userId);

        ICollection<CarViewModel> All();

        bool IsUserMechanic(string userId);
    }
}
