using SmartBank.Email.Api.Models;
using System.Threading.Tasks;

namespace SmartBank.Email.Api.Application.Services
{
    public interface IEmailSender
    {
        void SendEmail(Message message);
        Task SendEmailAsync(Message message);
        Task<bool> SendEmail(MessageSendGrid message);
        Task<bool> SendEmail(SenderEmailInputModel model);
    }
}
