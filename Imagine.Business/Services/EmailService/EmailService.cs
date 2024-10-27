using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Imagine.Business.Services.OrderItemService;
using Imagine.DataAccess.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Imagine.Business.Services.EmailService
{
    public class EmailService : IEmailService
    {
        private readonly IOrderItemService _orderItemService;
        private readonly string email;
        private readonly string password;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public EmailService(IConfiguration configuration, IOrderItemService orderItemService, IHttpContextAccessor httpContextAccessor)
        {
            email = configuration["EmailSettings:Email"];
            password = configuration["EmailSettings:Password"];
            _orderItemService = orderItemService;
            _httpContextAccessor = httpContextAccessor;
        }


        public async Task SendOrderEmailAsync(string email, string subject, Order order, int id)
        {
            using (var client = new SmtpClient("smtp.gmail.com", 587))
            {
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(this.email, password);

                using (var mailMessage = new MailMessage())
                {
                    mailMessage.From = new MailAddress(this.email);
                    mailMessage.Subject = subject;
                    mailMessage.Body = CreateOrderCompletedMessage(order, email, id);
                    mailMessage.IsBodyHtml = true;
                    mailMessage.To.Add(email);


                    try
                    {
                        await client.SendMailAsync(mailMessage);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred while sending the email: {ex.Message}");
                        throw;
                    }
                }
            }
        }

        public async Task SendOrderCancelledEmailAsync(string email, string subject, Order order, int id)
        {
            using (var client = new SmtpClient("smtp.gmail.com", 587))
            {
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(this.email, password);

                using (var mailMessage = new MailMessage())
                {
                    mailMessage.From = new MailAddress(this.email);
                    mailMessage.Subject = subject;
                    mailMessage.Body = OrderCancelledMessage(order, email, id);
                    mailMessage.IsBodyHtml = true;
                    mailMessage.To.Add(email);

                    try
                    {
                        await client.SendMailAsync(mailMessage);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred while sending the email: {ex.Message}");
                        throw;
                    }
                }
            }
        }

        public async Task SendOrderUpdatedEmailAsync(string email, string subject, Order order, OrderItem? orderItem, int id)
        {
            using (var client = new SmtpClient("smtp.gmail.com", 587))
            {
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(this.email, password);

                using (var mailMessage = new MailMessage())
                {
                    mailMessage.From = new MailAddress(this.email);
                    mailMessage.Subject = subject;
                    mailMessage.Body = OrderUpdatedMessage(order,orderItem, email, id);
                    mailMessage.IsBodyHtml = true;
                    mailMessage.To.Add(email);

                    try
                    {
                        await client.SendMailAsync(mailMessage);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred while sending the email: {ex.Message}");
                        throw;
                    }
                }
            }
        }

        public async Task SendClientConnectedChatEmailAsync(string email, string subject, string roomId)
        {
            using (var client = new SmtpClient("smtp.gmail.com", 587))
            {
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(this.email, password);
                using (var mailMessage = new MailMessage())
                {
                    mailMessage.From = new MailAddress(this.email);
                    mailMessage.Subject = subject;
                    mailMessage.Body = ClientJoinedLiveChat(roomId);
                    mailMessage.IsBodyHtml = true;
                    mailMessage.To.Add(email);
                    try
                    {
                        await client.SendMailAsync(mailMessage);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred while sending the email: {ex.Message}");
                        throw;
                    }
                }
            }
        }

        public async Task SendEmailAsync(string email, string subject, string confirmUrl)
        {
            using (var client = new SmtpClient("smtp.gmail.com", 587))
            {
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(this.email, password);

                using (var mailMessage = new MailMessage())
                {
                    mailMessage.From = new MailAddress(this.email);
                    mailMessage.Subject = subject;
                    mailMessage.Body = CreateHtmlMessage(email, confirmUrl);
                    mailMessage.IsBodyHtml = true;
                    mailMessage.To.Add(email);


                    try
                    {
                        await client.SendMailAsync(mailMessage);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"An error occurred while sending the email: {ex.Message}");
                        throw;
                    }
                }
            }
        }


        public string ClientJoinedLiveChat(string roomId)
        {
            return $@"
                <html>
                <body>
                    <h2>An User entered live chat.</h2>
                    <p>Room Id = ""{roomId}"",</p>
                    <p>Enter the chat as soon as possible!</p>
                    <p>Imagine Administration Team</p>
                </body>
                </html>";
        }


        public string CreateHtmlMessage(string email, string confirmUrl)
        {
            return $@"
                <html>
                <body>
                    <h2>Thank You for Registering!</h2>
                    <p>Dear {email},</p>
                    <p>Thank you for registering with us. Please confirm your email address by clicking the link below:</p>
                    <a href = ""{confirmUrl}"">Confirm your email</a>
                    <p>If you did not create an account, no further action is required.</p>
                    <p>Best regards,<br/>The Imagine Team</p>
                </body>
                </html>";
        }

        public string CreateOrderCompletedMessage(Order order, string email, int id)
        {
            var request = _httpContextAccessor.HttpContext.Request;
            var baseUrl = $"{request.Scheme}://{request.Host}";
            var orderDetailsUrl = $"{baseUrl}/Order/OrderDetails/{id}";
            return $@"
    <html>
    <body style='font-family: Arial, sans-serif; background-color: #f4f4f9; padding: 20px;'>
        <div style='max-width: 600px; margin: 0 auto; background-color: #fff; border-radius: 10px; padding: 20px; box-shadow: 0 4px 8px rgba(0,0,0,0.1);'>
            <h2 style='color: #4CAF50; text-align: center;'>Thank you for your order!</h2>
            <p style='font-size: 16px;'>Your order has been received and is now being processed. You can track your order by clicking the link below:</p>
            <a href='{orderDetailsUrl}' 
               style='display: inline-block; padding: 10px 15px; background-color: #4CAF50; color: white; text-decoration: none; border-radius: 5px; font-size: 16px; text-align: center;'>
                Check Your Order
            </a>
            <div style='margin-top: 20px;'>
                <p style='font-size: 16px;'><strong>Tracking Number:</strong> {order.TrackingNumber}</p>
                <p style='font-size: 16px;'><strong>Total Amount:</strong> ₺{order.TotalAmount}</p>
            </div>
            <hr style='border: none; border-top: 1px solid #ddd;' />
            <p style='font-size: 14px; color: #555; text-align: center;'>If you have any questions, feel free to contact our support team.</p>
        </div>
    </body> 
    </html>";

        }

        public string OrderCancelledMessage(Order order, string email, int id)
        {
            var request = _httpContextAccessor.HttpContext.Request;
            var baseUrl = $"{request.Scheme}://{request.Host}";
            var orderDetailsUrl = $"{baseUrl}/Order/OrderDetails/{id}";

            return $@"
    <html>
    <body style='font-family: Arial, sans-serif; background-color: #f4f4f9; padding: 20px;'>
        <div style='max-width: 600px; margin: 0 auto; background-color: #fff; border-radius: 10px; padding: 20px; box-shadow: 0 4px 8px rgba(0,0,0,0.1);'>
            <h2 style='color: #4CAF50; text-align: center;'>Your Refund Has Been Processed</h2>
            <p style='font-size: 16px;'>
                We have processed a refund of <strong>{order.TotalAmount}₺</strong> to your account.
            </p>
            <p style='font-size: 16px;'>Your bank will reflect this amount within 8 business days.</p>
            <h3 style='color: #4CAF50;'>Order Details</h3>
            <a href='{orderDetailsUrl}' 
               style='display: inline-block; padding: 10px 15px; background-color: #4CAF50; color: white; text-decoration: none; border-radius: 5px; font-size: 16px; text-align: center;'>
                Check Your Cancelled Order
            </a>
            <p style='font-size: 16px;'><strong>Tracking Number:</strong> {order.TrackingNumber}</p>
            <p style='font-size: 16px;'><strong>Refunded Amount:</strong> {order.TotalAmount}₺</p>
            <p style='font-size: 14px; color: #555; text-align: center;'>If you have any questions, feel free to contact us.</p>
        </div>
    </body>
    </html>";

        }

        public string OrderUpdatedMessage(Order order,OrderItem? orderItem, string email, int id)
        {
            var request = _httpContextAccessor.HttpContext.Request;
            var baseUrl = $"{request.Scheme}://{request.Host}";
            var orderDetailsUrl = $"{baseUrl}/Order/OrderDetails/{id}";

            return $@"
    <html>
    <body style='font-family: Arial, sans-serif; background-color: #f4f4f9; padding: 20px;'>
        <div style='max-width: 600px; margin: 0 auto; background-color: #fff; border-radius: 10px; padding: 20px; box-shadow: 0 4px 8px rgba(0,0,0,0.1);'>
            <h2 style='color: #4CAF50; text-align: center;'>Your Order Has Been Updated</h2>
            <p style='font-size: 16px;'>
                Your order is currently <strong>{order.OrderStatus}</strong>.
            </p>
            <h3 style='color: #4CAF50;'>Order Details</h3>
 <p style='font-size: 16px;'><strong>Product Name:</strong> {orderItem.Product.Name}</p>
            <a href='{orderDetailsUrl}' 
               style='display: inline-block; padding: 10px 15px; background-color: #4CAF50; color: white; text-decoration: none; border-radius: 5px; font-size: 16px; text-align: center;'>
                Check Your Order Status Here
            </a>
            <p style='font-size: 16px;'><strong>Order Id:</strong> {order.Id}</p>
            <p style='font-size: 16px;'><strong>Tracking Number:</strong> {order.TrackingNumber}</p>
            <p style='font-size: 14px; color: #555; text-align: center;'>If you have any questions, feel free to contact us.</p>
        </div>
    </body>
    </html>";

        }
    }
}
