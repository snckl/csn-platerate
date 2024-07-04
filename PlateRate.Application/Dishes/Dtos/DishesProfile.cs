using AutoMapper;
using PlateRate.Application.Dishes.Commands.CreateDish;
using PlateRate.Application.Restaurants.Dtos;
using PlateRate.Domain.Entities;

namespace PlateRate.Application.Dishes.Dtos;
public class DishesProfile : Profile
{
    public DishesProfile()
    {
        CreateMap<CreateDishCommand, Dish>().ReverseMap();
        CreateMap<Dish, DishDto>().ReverseMap();

    }
}
