using System;
using AutoMapper;
using CarDealer.Models;
using CarDealer.DataTransferObjects.Input;

namespace CarDealer
{
    public class CarDealerProfile : Profile
    {
        public CarDealerProfile()
        {
            this.CreateMap<CustomerInputModel, Customer>()
                .ForMember(x => x.BirthDate, y => y.MapFrom(s => DateTime.Parse(s.BirthDate)));
        }
    }
}
