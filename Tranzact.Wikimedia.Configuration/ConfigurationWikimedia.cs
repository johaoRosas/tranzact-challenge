using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Tranzact.Wikimedia.Configuration
{
    public class ConfigurationWikimedia : ConfigurationBase
    {
        public static string GetBaseUrl()
        {

            return GetConfiguration("Wikimedia.BaseUrl");

        }

        public static string GetPath()
        {

            return Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName +  GetConfiguration("Wikimedia.Path");

        }


    }
}
