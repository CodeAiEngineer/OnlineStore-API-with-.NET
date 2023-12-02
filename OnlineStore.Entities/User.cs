using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineStore.Entities
{
    public enum Role
    {
        Admin,
        Client
    }

    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        [Index(IsUnique = true)]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public bool IsActive { get; set; } = true;

        [Required]
        public Role UserRole { get; set; }
    }



    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class AuthData
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }



}


