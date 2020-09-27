using ShopBridge.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopBridge.Data
{
   public class ShopBridgeContext:DbContext
    {
        static ShopBridgeContext()
        {

            Database.SetInitializer<ShopBridgeContext>(null);
        }

        public ShopBridgeContext():base(GetConnectionString())
        {
            //this.Database.sq
        }

       static string GetConnectionString()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory.ToLower();
            string index = @"shopbridge\";
            string mdfFilePath = "";
            if (path.IndexOf(index) != -1)
                mdfFilePath = Path.Combine(path.Substring(0,path.IndexOf(index) + index.Length), "ShopBridge.Data","Database", "ShopBridge.mdf");
            return $@"data source =(LocalDB)\MSSQLLocalDB;attachdbfilename={mdfFilePath};integrated security = True; MultipleActiveResultSets=True;";
        }

    }
}
