using ShopBridge.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public ShopBridgeContext():base("Name=ShopBridgeContext")
        {

        }

    }
}
