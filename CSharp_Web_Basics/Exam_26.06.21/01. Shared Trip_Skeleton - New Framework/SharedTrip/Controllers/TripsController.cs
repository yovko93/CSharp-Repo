using MyWebServer.Controllers;
using MyWebServer.Http;
using SharedTrip.Data;
using SharedTrip.Models;
using SharedTrip.Services;
using SharedTrip.ViewModels.Trips;
using System;
using System.Globalization;
using System.Linq;

namespace SharedTrip.Controllers
{
    public class TripsController : Controller
    {
        private readonly IValidator validator;
        private readonly ApplicationDbContext data;

        public TripsController(
            IValidator validator,
            ApplicationDbContext data)
        {
            this.validator = validator;
            this.data = data;
        }

        [Authorize]
        public HttpResponse All()
        {
            var trips = this.data.Trips
               .Select(x => new TripViewModel
               {
                   Id = x.Id,
                   DepartureTime = x.DepartureTime,
                   EndPoint = x.EndPoint,
                   StartPoint = x.StartPoint,
                   Seats = x.Seats,
                   UsedSeats = x.UserTrips.Count(),
               })
               .ToList();

            return this.View(trips);
        }

        [Authorize]
        public HttpResponse Details(string tripId)
        {
            var trip = this.data.Trips.Where(x => x.Id == tripId)
               .Select(x => new TripDetailsViewModel
               {
                   Id = x.Id,
                   DepartureTime = x.DepartureTime,
                   Description = x.Description,
                   EndPoint = x.EndPoint,
                   ImagePath = x.ImagePath,
                   Seats = x.Seats,
                   StartPoint = x.StartPoint,
                   UsedSeats = x.UserTrips.Count(),
               })
               .FirstOrDefault();

            return this.View(trip);
        }

        [Authorize]
        public HttpResponse AddUserToTrip(string tripId)
        {
            if (!this.HasAvailableSeats(tripId))
            {
                return this.Error("No seats available.");
            }

            var userId = this.User.Id;
            var userInTrip = this.data.UserTrips
                .Any(x => x.UserId == userId && x.TripId == tripId);

            if (userInTrip)
            {
                return this.Redirect("/Trips/Details?tripId=" + tripId);
            }

            var userTrip = new UserTrip
            {
                TripId = tripId,
                UserId = userId,
            };

            this.data.UserTrips.Add(userTrip);
            this.data.SaveChanges();

            return this.Redirect("/Trips/All");
        }

        [Authorize]
        public HttpResponse Add() => this.View();

        [HttpPost]
        [Authorize]
        public HttpResponse Add(AddTripFormModel model)
        {
            var modelErrors = this.validator.ValidateTrip(model);

            if (modelErrors.Any())
            {
                return this.Redirect("/Trips/Add");
            }

            var trip = new Trip
            {
                DepartureTime = DateTime.ParseExact(model.DepartureTime, "dd.MM.yyyy HH:mm",
                CultureInfo.InvariantCulture),
                Description = model.Description,
                EndPoint = model.EndPoint,
                ImagePath = model.ImagePath,
                Seats = model.Seats,
                StartPoint = model.StartPoint,
            };

            this.data.Trips.Add(trip);
            this.data.SaveChanges();

            return this.Redirect("/Trips/All");
        }

        public bool HasAvailableSeats(string tripId)
        {
            var trip = this.data.Trips.Where(x => x.Id == tripId)
                .Select(x => new { x.Seats, TakenSeats = x.UserTrips.Count() })
                .FirstOrDefault();

            var availableSeats = trip.Seats - trip.TakenSeats;
            return availableSeats > 0;
        }
    }
}
