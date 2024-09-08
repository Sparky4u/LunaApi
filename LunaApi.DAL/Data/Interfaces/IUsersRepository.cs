using LunaApi.Common.Models;

namespace LunaApi.DAL.Data.Interfaces
{
    public interface IUsersRepository
    {
        public Task<User> Register(string userName, string passwordHash, string email);
        public Task<User?> Login(string userNameOrEmail, string password);
    }
}
