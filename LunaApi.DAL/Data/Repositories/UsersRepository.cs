using LunaApi.Common.Models;
using LunaApi.DAL.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LunaApi.DAL.Data.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly LunaDbContext _context;

        public UsersRepository(LunaDbContext context)
        {
            _context = context;
        }

        public async Task<User?> Login(string userNameOrEmail, string password)
        {      
                var user = await _context.Users.
                FirstOrDefaultAsync(u => u.UserName == userNameOrEmail || u.Email == userNameOrEmail);

            if (user == null)
            {
                throw new UnauthorizedAccessException("Invalid username or email");
            }

            if(!VerifyPassword(password,user.PasswordHash))
            {
                throw new UnauthorizedAccessException("Invalid password");
            }

            return user;
        }

        public async Task<User> Register(string userName, string email, string password)
        {
            if (await _context.Users.AnyAsync(u => u.UserName == userName || u.Email == email))
            {
                throw new InvalidOperationException("Username or Email already exists.");
            }

            string passwordHash = HashPassword(password);

            var userId = Guid.NewGuid();

            var user = new User(userId,userName,passwordHash,email);

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hasehBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hasehBytes).Replace("-", "").ToLower();
            }
        }

        private bool VerifyPassword(string password, string storedHash)
        {
            var hash = HashPassword(password);
            return hash == storedHash;
        }
    }
}
