using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;
using System.Text;

namespace Alfred.Models
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
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                Password = builder.ToString();
            }
        }
    }
}
