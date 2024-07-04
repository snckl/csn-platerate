using PlateRate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlateRate.Domain.Repositories;
public interface IDishRepository
{
    Task<Dish?> GetByIdAsync(int id);
    Task<int> CreateAsync(Dish entity);
    Task DeleteAsync(Dish dish);
    Task SaveAsync();
}
