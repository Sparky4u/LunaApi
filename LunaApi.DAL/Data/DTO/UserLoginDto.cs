﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunaApi.DAL.Data.DTO
{
    public class UserLoginDto
    {
        public string UserNameOrEmail {  get; set; }
        public string Password { get; set; }
    }
}
