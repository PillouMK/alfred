using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Text;
using Org.BouncyCastle.Crypto.Generators;
using Microsoft.AspNet.Identity;

namespace Alfred.Models_db
{
    public class User
    {
        [Key]
        public string Uuid { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Role { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public User()
        {
            Role = 0; // Définir le rôle par défaut à 0
            CreatedAt = DateTime.Now; // Définir la date de création à l'instant actuel
            UpdatedAt = DateTime.Now;
        }

        // Méthode pour hasher le mot de passe avant de l'assigner
        public void SetPassword(string password)
        {
            var passwordHasher = new PasswordHasher();
            Password = passwordHasher.HashPassword(password);
        }
    }
}
