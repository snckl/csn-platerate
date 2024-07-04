using MediatR;
using PlateRate.Application.Restaurants.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlateRate.Application.Dishes.Queries.GetAllDishes;
public class GetAllDishesQuery(int id) : IRequest<IEnumerable<DishDto>>
{
    public int RestaurantId { get; set; } = id;
}
