using Imagine.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imagine.Business.Services.EmailService
{
    public interface IEmailService
    {
        Task SendEmailAsync(string email, string subject, string confirmUrl);
        Task SendOrderEmailAsync(string email, string subject, Order order, int id);
        Task SendOrderCancelledEmailAsync(string email, string subject, Order order, int id);
        Task SendOrderUpdatedEmailAsync(string email, string subject, Order order, OrderItem? orderItem, int id);
    }
}
