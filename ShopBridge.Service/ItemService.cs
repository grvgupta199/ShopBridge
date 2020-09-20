using ShopBridge.Data;
using ShopBridge.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopBridge.Service
{
    public class ItemService : IItemService
    {

        public string AddItem(Item item)
        {
            List<SqlParameter> p = new List<SqlParameter>()
            {
                new SqlParameter{ParameterName="@name",Value=string.IsNullOrWhiteSpace(item.Name)==true?"":item.Name },
                new SqlParameter{ParameterName="@Description",Value=string.IsNullOrWhiteSpace(item.Description)==true?"":item.Description },
                new SqlParameter{ParameterName="@price",Value=item.Price.HasValue?item.Price:0 },
                new SqlParameter{ParameterName="@imagePath",Value=string.IsNullOrWhiteSpace(item.ImagePath)==true?"":item.ImagePath }
            };
            var sqlHelper = SqlHelper.ExcuteProcedure("usp_AddItem @name,@Description,@price,@imagePath", p.ToArray());
            var res = sqlHelper.ResultSetFor<string>().ToList();
            return res.FirstOrDefault();

        }

        public string DeleteItem(int id)
        {
            var sqlHelper = SqlHelper.ExcuteProcedure("usp_DeleteItem @id", new SqlParameter("@id", id));
            var res = sqlHelper.ResultSetFor<string>().ToList();
            return res.FirstOrDefault();
        }

        public IEnumerable<Item> GetAllItems()
        {
            var sqlHelper = SqlHelper.ExcuteProcedure("usp_GetAllItems");
            var res = sqlHelper.ResultSetFor<Item>().ToList();
            return res;
        }

        public Item GetItemDetails(int id)
        {
            var sqlHelper = SqlHelper.ExcuteProcedure("usp_GetItemDetails @id", new SqlParameter("@id", id));
            var res = sqlHelper.ResultSetFor<Item>().ToList();
            return res.FirstOrDefault();
        }
    }
}
