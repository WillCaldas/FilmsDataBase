﻿using System.ComponentModel.DataAnnotations;

namespace FDB.UsersAPI.Data.Request
{
    public class LoginRequest
    {
        [Required]
        public string UserName { get; set; }
        
        [Required]
        public string Password { get; set; }
    }
}
