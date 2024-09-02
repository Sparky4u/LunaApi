using LunaApi.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunaApi.DAL.Data.Interfaces
{
    public interface IUsersRepository
    {
        public Task<User> Add(Guid id, string userName, string passwordHash, string email);
        public Task<User?> Update(Guid id, string userName, string passwordHash, string email);
        public Task<bool> Delete(Guid userId);
        public Task<List<User>> Get();
    }
}
