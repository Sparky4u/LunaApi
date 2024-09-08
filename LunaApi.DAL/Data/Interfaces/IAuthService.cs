using LunaApi.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunaApi.DAL.Data.Interfaces
{
    public interface IAuthService
    {
        string GenerateJwtToken(User user);
    }
}
