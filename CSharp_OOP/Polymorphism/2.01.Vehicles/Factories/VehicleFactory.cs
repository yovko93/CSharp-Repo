﻿using System;

using _2._01.Vehicles.Common;
using _2._01.Vehicles.Models;

namespace _2._01.Vehicles.Factories
{
    public class VehicleFactory
    {
        public VehicleFactory()
        {
        }

       public Vehicle CreateVehicle(string vehicleType, double fuelQuantity, double fuelConsumption)
        {
            Vehicle vehicle;

            if (vehicleType == "Car")
            {
                vehicle = new Car(fuelQuantity, fuelConsumption);
            }
            else if (vehicleType == "Truck")
            {
                vehicle = new Truck(fuelQuantity, fuelConsumption);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidVehicleType);
            }

            return vehicle;
        }

        
    }
}
