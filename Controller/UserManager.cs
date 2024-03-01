using Alfred.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Alfred.Models_db;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text.Json.Nodes;
using Newtonsoft.Json.Linq;
using Microsoft.AspNet.Identity;
using System.Security.Policy;


namespace Alfred.Controller
{
    public class UserManager
    {
        private AlfredContext dbContext;

        public UserManager()
        {
            dbContext = new AlfredContext();
        }

        public async Task<JObject> GetUserByEmail(string email)
        {
            var userData = await dbContext.Users
                .FirstOrDefaultAsync(user => user.Email == email);

            JObject jsonObject = new JObject();
            if (userData != null)
            {
                jsonObject["exist"] = true;
                jsonObject["result"] = JObject.FromObject(userData);
            }
            else
            {
                jsonObject["exist"] = false;
            }

            return jsonObject;
        }
        public async Task<JObject> RegisterUser(string username, string email, string password)
        {
            JObject jsonResult = await GetUserByEmail(email);

            bool is_exist = (bool)jsonResult["exist"];

            if (is_exist)
            {
                jsonResult["success"] = false;
                jsonResult["msg"] = "Vous êtes déjas inscrit connectez-vous !";
                return jsonResult;
            }
            else
            {
                var userModel = new User
                {
                    Uuid = Guid.NewGuid().ToString(),
                    Username = username,
                    Email = email
                };

                userModel.SetPassword(password);

                dbContext.Add(userModel);
                dbContext.SaveChanges();

                JObject jsonUser = await GetUserByEmail(email);
                jsonUser["success"] = true;

                return jsonUser;
            }



        }
        public async Task<JObject> LoginUser(string email, string password)
        {
            JObject jsonResult = await GetUserByEmail(email);

            bool is_exist = (bool)jsonResult["exist"];

            if (is_exist)
            {
                JObject jsonUser = (JObject)jsonResult["result"];
                string db_password = (string)jsonUser["Password"];

                var passwordHasher = new PasswordHasher();
                bool isVerified = passwordHasher.VerifyHashedPassword(db_password, password) != PasswordVerificationResult.Failed;

                if(isVerified)
                {
                    jsonResult["success"] = true;
                }
                else
                {
                    jsonResult["success"] = false;
                    jsonResult["msg"] = "Mot de passe incorrect";
                }

                return jsonResult;
            }
            else
            {
                jsonResult["success"] = false;
                jsonResult["msg"] = "Vous n'avez pas encore de compte. Inscrivez-vous !";
                return jsonResult;
            }
        }
    }
}
