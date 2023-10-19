using System;
using System.Collections.Generic;

namespace Exam.DeliveriesManager
{
    public class AirlinesManager : IAirlinesManager
    {
        public void AddAirline(Airline airline)
        {
            throw new NotImplementedException();
        }

        public void AddFlight(Airline airline, Flight flight)
        {
            throw new NotImplementedException();
        }

        public bool Contains(Airline airline)
        {
            throw new NotImplementedException();
        }

        public bool Contains(Flight flight)
        {
            throw new NotImplementedException();
        }

        public void DeleteAirline(Airline airline)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Airline> GetAirlinesOrderedByRatingThenByCountOfFlightsThenByName()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Airline> GetAirlinesWithFlightsFromOriginToDestination(string origin, string destination)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Flight> GetAllFlights()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Flight> GetCompletedFlights()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Flight> GetFlightsOrderedByCompletionThenByNumber()
        {
            throw new NotImplementedException();
        }

        public Flight PerformFlight(Airline airline, Flight flight)
        {
            throw new NotImplementedException();
        }
    }
}
