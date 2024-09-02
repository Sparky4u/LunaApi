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
    public class UsersRepository : IUsersRepository
    {
        private readonly LunaDbContext _context;

        public UsersRepository(LunaDbContext context)
        {
            _context = context;
        }

        public async Task<User> Add(Guid id, string userName, string passwordHash, string email)
        {
            var userEntity = new User(id,userName, passwordHash, email);

            _context.Users.Add(userEntity);
            await _context.SaveChangesAsync();

            return userEntity;
        }

        public async Task<bool> Delete(Guid userId)
        {
            var user = await _context.Users.FindAsync(userId);

            if(user == null) return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<User?> Update(Guid userId, string userName, string passwordHash, string email)
        {
            var user = await _context.Users.FindAsync(userId);

            if(user == null) throw new NullReferenceException("User not found");

            user.UpdateUserName(userName);
            user.UpdateEmail(email);
            user.UpdatePasswordHash(passwordHash);           

            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<List<User>> Get()
        {
            return await _context.Users
                .AsNoTracking()
                .OrderBy(u => u.UserName)
                .ToListAsync();
        }
    }
}
