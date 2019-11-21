using System;
using System.Collections;
using System.Collections.Generic;
using SimpleBasket.API.Entities;

namespace SimpleBasket.API.Services
{
    public interface ISimpleBasketRepository
    {
        IEnumerable<Product> GetProducts();
        decimal CalculateFreight(decimal orderAmount);
        void SubmitOrder(int userId, DateTime orderDateTime, IEnumerable<OrderItem> orderItems);
    }
}
