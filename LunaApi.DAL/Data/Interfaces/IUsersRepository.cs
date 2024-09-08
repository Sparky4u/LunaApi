﻿using LunaApi.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunaApi.DAL.Data.Interfaces
{
    public interface IUsersRepository
    {
        public Task<User> Register(string userName, string passwordHash, string email);
        public Task<User?> Login(string userNameOrEmail, string password);
    }
}
