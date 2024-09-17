using LunaApi.Common.Models;

namespace LunaApi.DAL.Data.Interfaces
{
    public interface IAuthService
    {
        string GenerateJwtToken(User user);
    }
}
