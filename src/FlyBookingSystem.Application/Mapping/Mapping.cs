using AutoMapper;
using FlyBookingSystem.IServices.Airport.Dtos;
using FlyBookingSystem.IServices.Booking.Dtos;
using FlyBookingSystem.IServices.Categories.Dtos;
using FlyBookingSystem.IServices.Customer.Dtos;
using FlyBookingSystem.IServices.Discount.Dtos;
using FlyBookingSystem.IServices.Flight.Dtos;
using FlyBookingSystem.IServices.FlightSchedule.Dtos;
using FlyBookingSystem.IServices.LoyaltyProgram.Dtos;
using FlyBookingSystem.IServices.Passenger.Dtos;
using FlyBookingSystem.IServices.Payment.Dtos;
using FlyBookingSystem.IServices.Staff.Dtos;
using FlyBookingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlyBookingSystem.Mapping
{
    public class Mapping:Profile
    {
        public Mapping()
        {
            CreateMap<Customer, CustomerDto>().ReverseMap();
            CreateMap<Customer, CreateUpdateCustomerDto>().ReverseMap();

            CreateMap<Booking, BookingDto>().ReverseMap();
            CreateMap<Booking, CreateUpdateBookingDto>().ReverseMap();

            CreateMap<Flight, FlightDto>().ReverseMap();
            CreateMap<Flight, CreateUpdateFlightDto>().ReverseMap();

            CreateMap<FlightSchedule, FlightScheduleDto>().ReverseMap();
            CreateMap<FlightSchedule, CreateUpdateFlightScheduleDto>().ReverseMap();

            CreateMap<Airport, AirportDto>().ReverseMap();
            CreateMap<Airport, CreateUpdateAirportDto>().ReverseMap();

            CreateMap<Passenger, PassengerDto>().ReverseMap();
            CreateMap<Passenger, CreateUpdatePassengerDto>().ReverseMap();

            CreateMap<Payment, PaymentDto>().ReverseMap();
            CreateMap<Payment, CreateUpdatePaymentDto>().ReverseMap();

            CreateMap<LoyaltyProgram, LoyaltyProgramDto>().ReverseMap();
            CreateMap<LoyaltyProgram, CreateUpdateLoyaltyProgramDto>().ReverseMap();

            CreateMap<Discount, DiscountDto>().ReverseMap();
            CreateMap<Discount, CreateUpdateDiscountDto>().ReverseMap();

            CreateMap<Staff, StaffDto>().ReverseMap();
            CreateMap<Staff, CreateUpdateStaffDto>().ReverseMap();

            CreateMap<Categories, CategoriesDto>().ReverseMap();
            CreateMap<Categories, CreateUpdateCategoriesDto>().ReverseMap();


        }
    }
}
