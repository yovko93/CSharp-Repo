﻿using CarShop.Data;
using System.Linq;

namespace CarShop.Services
{
    public class UserService : IUserService
    {
        private readonly CarShopDbContext data;

        public UserService(CarShopDbContext data)
        {
            this.data = data;
        }

        public bool IsMechanic(string userId)
            => this.data.Users
            .Any(u => u.IsMechanic && u.Id == userId);

        public bool OwnsCar(string userId, string carId)
            => this.data.Cars
            .Any(c => c.Id == carId && c.OwnerId == userId);
    }
}
