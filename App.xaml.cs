using System.Configuration;
using System.Data;
using System.Windows;
using Alfred.Data;
using Alfred.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Alfred
{

    public static class GlobalVariables
    {
       public static UserModel User = new UserModel();
       public static AlfredContext dbContext = new AlfredContext();
    }

    public partial class App : Application
    {
    }


}
