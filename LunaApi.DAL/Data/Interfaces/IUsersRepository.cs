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
        public Task Add(User user);
        public Task<User> GetByEmail(string email);
    }
}
