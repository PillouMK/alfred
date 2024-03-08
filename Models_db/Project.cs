using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alfred.Models_db
{
    public class Project
    {
        [Key]
        public string Uuid { get; set; }
        public string UserUuid { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Project()
        {

            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            UserUuid = GlobalVariables.User.Uuid;
            Uuid = Guid.NewGuid().ToString();

        }
    }
}
