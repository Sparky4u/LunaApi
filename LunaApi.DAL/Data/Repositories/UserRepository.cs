using LunaApi.Common.Models;
using LunaApi.DAL.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunaApi.DAL.Data.Repositories
{
    public class UserRepository : IUsersRepository
    {
        private readonly LunaDbContext _context;

        public UserRepository(LunaDbContext context)
        {
            _context = context;
        }

        public async Task Add(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentNullException(nameof(email));
            }

            return await _context.Users.
                FirstOrDefaultAsync(u => u.Email == email);
        }

    }
}
