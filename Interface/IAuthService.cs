using FundTracker.Models;

namespace FundTracker.Interface
{
    public interface IAuthService
    {
        Task Register(User user);
        Task<User?> Login(string email, string password);
    }
}
