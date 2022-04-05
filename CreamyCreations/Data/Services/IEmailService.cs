using CreamyCreations.Models;
using SendGrid;
using System.Threading.Tasks;
namespace CreamyCreations.Data.Services
{
    public interface IEmailService
    {
        Task<Response> SendSingleEmail(ComposeEmailModel payload);
    }

}
