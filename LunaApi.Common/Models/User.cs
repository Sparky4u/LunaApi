using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
            PasswordHash = passwordHash ?? throw new ArgumentNullException(nameof(passwordHash));
            Email = email ?? throw new ArgumentNullException(nameof(email));
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
        }
        [Key]
        public Guid Id { get; private set; }
        [Required]
        [StringLength(50)]
        public string UserName { get; private set; }
        [Required]
        [EmailAddress]
        public string Email { get; private set; }
        [Required]
        public string PasswordHash { get; private set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; private set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedAt { get; private set; }
        public ICollection<TaskEntity> Tasks { get; private set; } = new List<TaskEntity>();
       
    }
}
