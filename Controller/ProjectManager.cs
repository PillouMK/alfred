using Alfred.Data;
using Alfred.Models_db;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Alfred.Models;
using Microsoft.AspNet.Identity;

namespace Alfred.Controller
{
    public class ProjectManager
    {

        public async Task<JObject> GetProjectByName(string name)
        {
            var projetData = await GlobalVariables.dbContext.Projects
                .FirstOrDefaultAsync(projet => projet.Name == name);

            JObject jsonObject = new JObject();
            if (projetData != null)
            {
                jsonObject["exist"] = true;
                jsonObject["result"] = JObject.FromObject(projetData);
            }
            else
            {
                jsonObject["exist"] = false;
            }

            return jsonObject;
        }

        public async Task CreateNewProject(string ProjectName)
        {
            JObject jsonResult = await GetProjectByName(ProjectName);

            bool is_exist = (bool)jsonResult["exist"];

            if (!is_exist)
            {
                var projectModel = new Project
                {
                    Name = ProjectName,
                    Description = "Mon projet Alfred"
                };
                await GlobalVariables.dbContext.AddAsync(projectModel);
                await GlobalVariables.dbContext.SaveChangesAsync();
            }

        }

    }
}
