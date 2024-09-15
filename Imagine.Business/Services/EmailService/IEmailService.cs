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
    }
}
