using b3digitas.Application.DTOs;
using b3digitas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace b3digitas.Application.Interfaces
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDTO>> GetAllAsync();
        Task<IEnumerable<OrderDTO>> GetBetweenDatesAsync(DateTime date1, DateTime date2);
    }
}
