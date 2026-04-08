using System.Security.Claims;
using FundTracker.Interface;
using FundTracker.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using FundTracker.Repositories;
using Microsoft.AspNetCore.Identity;

namespace FundTracker.Services
{
    public class AuthService : IAuthService
    {

        private readonly IUser _userRepo;
        private readonly PasswordHasher<User> _hasher = new();

        public AuthService(IUser userRepo)
        {
            _userRepo = userRepo;
        }


        public async Task Register(User user)
        {
            user.Password = _hasher.HashPassword(user, user.Password);
            await _userRepo.CreateUser(user);
        }

        public async Task<User?> Login(string email, string password)
        {
            var user = await _userRepo.GetUserByEmail(email);

            if (user == null)
                return null;

            var result = _hasher.VerifyHashedPassword(user, user.Password, password);

            if (result == PasswordVerificationResult.Failed)
                return null;

            return user;
        }
    }
}
