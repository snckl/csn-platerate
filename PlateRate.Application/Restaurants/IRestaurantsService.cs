﻿using PlateRate.Domain.Entities;

namespace PlateRate.Application.Restaurants;
public interface IRestaurantsService
{
    Task<IEnumerable<Restaurant>> GetAllRestaurants();
    Task<Restaurant?> GetByIdAsync(int id);
}