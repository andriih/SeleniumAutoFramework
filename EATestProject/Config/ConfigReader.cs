using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace EAAutoFramework.Base.Config
{
    public class ConfigReader
    {
        public static string InitializeTest()
        {
            return ConfigurationManager.AppSettings["AUT"].ToString();
        }
    }
}
