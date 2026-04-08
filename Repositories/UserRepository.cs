using FundTracker.Data;
using FundTracker.Interface;
using FundTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace FundTracker.Repositories
{
    public class UserRepository : IUser
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateUser(User user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            var user = await _context.User.FirstOrDefaultAsync(u => u.Email == email);

            return user;
        }

        public async Task<User?> GetUserById(int id)
        {
            var user = await _context.User.FirstOrDefaultAsync(u => u.UserId == id);

            return user;
        }
    }
}
