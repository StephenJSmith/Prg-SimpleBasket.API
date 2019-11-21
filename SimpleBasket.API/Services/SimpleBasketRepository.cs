using System;
using System.Collections.Generic;
using System.Linq;
using SimpleBasket.API.Entities;

namespace SimpleBasket.API.Services
{
    public class SimpleBasketRepository: ISimpleBasketRepository
    {
        private IEnumerable<Product> _products;

        public SimpleBasketRepository()
        {
            PopulateProductsList();
        }

        private void PopulateProductsList()
        {
            _products = new List<Product>
            {
                new Product {Id = 1, Name = "Football", UnitPrice = 25.00m},
                new Product {Id = 2, Name = "Surfboard", UnitPrice = 179m},
                new Product {Id = 3, Name = "Running shoes", UnitPrice = 95m},
                new Product {Id = 4, Name = "Kayak", UnitPrice = 275m},
                new Product {Id = 5, Name = "Chess board", UnitPrice = 19m}
            };
        }

        public IEnumerable<Product> GetProducts()
        {
            return _products;
        }

        public decimal CalculateFreight(decimal orderAmount)
        {
            if (orderAmount <= 0m)
            {
                return 0m;
            }

            if (orderAmount <= 50m)
            {
                return 10m;
            }

            return 20m;
        }

        public void SubmitOrder(int userId, DateTime orderDateTime, IEnumerable<OrderItem> orderItems)
        {
            var newOrder = new Order
            {
                UserId = userId,
                DateTime = orderDateTime,
            };
            var completeOrderItems = CompleteOrderItemsFromServer(newOrder, orderItems);
            var subtotalAmount = completeOrderItems.Sum(oi => oi.Amount);
            var freightAmount = CalculateFreight(subtotalAmount);

            newOrder.Freight = freightAmount;
            newOrder.OrderItems = completeOrderItems;

            //TODO: Persist to data store
        }

        private IEnumerable<OrderItem> CompleteOrderItemsFromServer(
            Order newOrder,
            IEnumerable<OrderItem> orderItems)
        {
            var products = GetProducts();

            var completeOrderItems = new List<OrderItem>();
            foreach (var orderItem in orderItems)
            {
                var product = products.FirstOrDefault(p => p.Id == orderItem.ProductId);
                if (product == null) { continue; }

                var completeOrderItem = new OrderItem
                {
                    Order = newOrder,
                    ProductId = orderItem.ProductId,
                    Quantity = orderItem.Quantity,
                    Amount = orderItem.Quantity * product.UnitPrice
                };

                completeOrderItems.Add(completeOrderItem);
            }

            return completeOrderItems;
        }
    }
}
