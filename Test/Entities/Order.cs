using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Entities.Enums;
using System.Globalization;

namespace Test.Entities
{
    internal class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public Client Client { get; set; }

        public List<OrderItem> Items { get; set; } = new List<OrderItem>();

        public Order() 
        {
        }

        public Order(DateTime moment, OrderStatus status, Client client)
        {
            Moment = moment;
            Status = status;
            Client = client;
        }

        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }
        public void RemoveItem(OrderItem item)
        {
            Items.Remove(item);
        }
        public double Total()
        {
            double total = 0;
            foreach (OrderItem item in Items)
            {
                total += item.subTotal();
            }
            return total;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("ORDER SUMMARY:");
            sb.AppendLine($"Order moment: {Moment}");
            sb.AppendLine($"Order status: {Status} ");
            sb.AppendLine($"Client: {Client}");
            sb.AppendLine("Order items:");
            foreach (OrderItem item in Items)
            {
                sb.AppendLine($"{item.Product.Name}, Quantity: {item.Quantity}, Subtotal: {item.subTotal().ToString("F2", CultureInfo.InvariantCulture)} ");
            }
            sb.AppendLine($"Total price: {Total().ToString("F2", CultureInfo.InvariantCulture)}");
            return sb.ToString();
        }
    }
}
