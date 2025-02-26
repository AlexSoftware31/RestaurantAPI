
namespace WebApi.Services.Interfaces
{
    public interface IEmailServices
    {
        Task SendEmailAsync(string subject, string email, string body);
    }
}
