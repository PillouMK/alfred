using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Alfred.Models
{
    public class UserModel
    {
        public string Uuid { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public int Role { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public static UserModel FromJson(JObject json)
        {
            return new UserModel
            {
                Uuid = (string)json["Uuid"],
                Username = (string)json["Username"],
                Email = (string)json["Email"],
                Role = (int)json["Role"],
                CreatedAt = (DateTime)json["CreatedAt"],
                UpdatedAt = (DateTime)json["UpdatedAt"]
            };
        }
    }

}
