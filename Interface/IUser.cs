using FundTracker.Models;

namespace FundTracker.Interface
{
    public interface IUser
    {
        Task CreateUser(User user);

        Task<User?> GetUserById(int id);

        Task<User?> GetUserByEmail(string email);
    }
}
