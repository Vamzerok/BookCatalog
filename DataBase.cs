using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Security.Permissions;
using Newtonsoft.Json.Linq;
using System.CodeDom;
using System.Windows;

namespace WebShop
{
    internal class DataBase
    {
        public void Import(string path)
        {
            JsonConvert.DeserializeObject<Book>(path);
        }
    }
}
