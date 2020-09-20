using ShopBridge.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopBridge.Service
{
    public interface IItemService
    {
        string AddItem(Item item);

        IEnumerable<Item> GetAllItems();

        Item GetItemDetails(int id);

        string DeleteItem(int id);
    }
}
