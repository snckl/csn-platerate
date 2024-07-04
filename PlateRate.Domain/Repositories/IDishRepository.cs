using PlateRate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlateRate.Domain.Repositories;
public interface IDishRepository
{
    Task<int> CreateAsync(Dish entity);
    Task DeleteAsync(IEnumerable<Dish> dishes);
}
