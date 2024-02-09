using Alfred.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Alfred.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text.Json.Nodes;
using Newtonsoft.Json.Linq;
namespace Alfred.Controller
{
    public class UserManager
    {
        private AlfredContext dbContext;

        public UserManager()
        {
            dbContext = new AlfredContext();
        }
        public string GetUserByEmail(string email)
        {
            var userData = dbContext.Users
                .Where(user => user.Email.Contains(email))
                .ToList();

            bool userExists = userData.Any();
            var jsonObject = new JObject();
            jsonObject["exist"] = userExists;
            if (userExists)
            {
                var UserJjson = JsonConvert.SerializeObject(userData);
                jsonObject["userData"] = JArray.Parse(UserJjson);
            }

            return jsonObject.ToString();
        }
        public async Task<string> RegisterUser(string username, string email, string password)
        {
            string StringUser = GetUserByEmail(email);
            JObject jsonUser = JObject.Parse(StringUser);
            bool is_exist = (bool)jsonUser["exist"];
            var jsonReturn = new JObject();

            if (is_exist)
            {
                jsonReturn["success"] = false;
                jsonReturn["msg"] = "Vous êtes déjas inscrit connectez-vous !";
                return jsonReturn.ToString();
            }
            else
            {
                try
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

                    string User = GetUserByEmail(email);
                    jsonReturn["success"] = true;
                    jsonReturn["result"] = User;
                    return jsonReturn.ToString();

                }
                catch (DbUpdateException ex)
                {
                    jsonReturn["success"] = false;
                    jsonReturn["msg"] = ex.InnerException?.Message;
                    return jsonReturn.ToString();
                }
                catch (Exception ex)
                {
                    jsonReturn["success"] = false;
                    jsonReturn["msg"] = ex.Message;
                    return jsonReturn.ToString();
                }
            }



        }
    }
}
