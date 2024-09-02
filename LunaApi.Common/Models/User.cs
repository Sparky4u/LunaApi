using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LunaApi.Common.Models
{
    public class User
    {
        public User(Guid id,string userName,string passwordHash,string email)
        {
            Id = id;
            UserName = userName ?? throw new ArgumentNullException(nameof(userName));
            PasswordHash = passwordHash;
            Email = email ?? throw new ArgumentNullException(nameof(email));
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
        [Key]
        public Guid Id { get; private set; }
        public string UserName { get; private set; }
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime UpdatedAt { get; private set; }

        public void UpdateUserName(string userName)
        {
            UserName = userName ?? throw new ArgumentNullException(nameof(userName));
            UpdatedAt = DateTime.Now;
        }

        public void UpdateEmail(string email)
        {
            Email = email ?? throw new ArgumentNullException(nameof(email));
            UpdatedAt = DateTime.Now;
        }

        public void UpdatePasswordHash(string passwordHash)
        {
            PasswordHash = passwordHash ?? throw new ArgumentNullException(nameof(passwordHash));
            UpdatedAt = DateTime.Now;
        }

        public static User Create(Guid id, string userName, string passwordHash, string email)
        {
            return new User(id, userName, passwordHash, email);
        }
    }
}
