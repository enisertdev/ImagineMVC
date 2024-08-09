using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;

namespace Imagine.DataAccess.Entities
{
    public enum OrderStatus
    {
        Pending,
        Processing,
        Shipped,
        Delivered,
        Cancelled
    }

    public enum PaymentMethod
    {
        PayPal,
        CreditCard,
        Swift
    }
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime OrderTime { get; set; }
        public string OrderStatus { get; set; }
        public decimal TotalAmount { get; set; }
        public string PaymentMethod { get; set; }
        public string OrderAddress { get; set; }
        public string TrackingNumber { get; set; }
        public DateTime LastUpdated { get; set; }
        public User? User { get; set; }

    }
}
