using AutoMapper;
using PlateRate.Application.Restaurants.Dtos;
using PlateRate.Domain.Entities;

namespace PlateRate.Application.Dishes.Dtos;
public class DishesProfile : Profile
{
    public DishesProfile()
    {
        CreateMap<Dish, DishDto>().ReverseMap();
    }
}
