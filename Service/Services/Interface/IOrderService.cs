using Domain.Entity;
using Service.Services.Interface.Generic;
using Service.ViewModels.Order;

namespace Service.Services.Interface;

public interface IOrderService : ICrudService<Order, OrderCreateVM, OrderEditVM, OrderVM>
{
    Task CreateOrderAsync(OrderCreateVM dto);


}