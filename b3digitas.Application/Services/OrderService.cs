using AutoMapper;
using b3digitas.Application.DTOs;
using b3digitas.Application.Interfaces;
using b3digitas.Domain.Entities;
using b3digitas.Domain.Interfaces;

namespace b3digitas.Application.Services
{
    public class OrderService : IOrderService
    {
        private IOrderRepository _order;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository order, IMapper mapper) 
        {
            _order = order;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderDTO>> GetBetweenDatesAsync(DateTime date1, DateTime date2)
        {
            var orderEntity = await _order.GetBetweenDatesAsync(date1, date2);

            return _mapper.Map<IEnumerable<OrderDTO>>(orderEntity);
        }

        public async Task<IEnumerable<OrderDTO>> GetAllAsync()
        {
            var ordersEntity = await _order.GetAllAsync();

            return _mapper.Map<IEnumerable<OrderDTO>>(ordersEntity);
        }
    }
}
