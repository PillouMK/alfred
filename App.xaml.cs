using System.Configuration;
using System.Data;
using System.Windows;
using Alfred.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Alfred
{

    public static class GlobalVariables
    {
       public static UserModel User = new UserModel();
    }

    public partial class App : Application
    {
    }


}
