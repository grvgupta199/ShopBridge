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
            
        }

       static string GetConnectionString()
        {
            return @"data source=.;Initial Catalog=ShopBridge;integrated security=True;MultipleActiveResultSets=True;";
        }

    }
}
