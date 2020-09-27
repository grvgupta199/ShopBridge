
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using ShopBridge.Controllers;
using ShopBridge.Model;
using ShopBridge.Service;
using System.Linq;
using System.Web.Mvc;

namespace ShopBridge.Tests
{
    [TestClass]
    public class ItemCotrollerTest
    {
        private ItemController _itemController = new ItemController();
        private IItemService _itemService = new ItemService();
        [TestMethod]
        public void Test_Index()
        {
            var actual = (_itemController.Index().Result as ViewResult).Model;
            var expected = _itemService.GetAllItems();

            Assert.AreEqual(JsonConvert.SerializeObject(expected), JsonConvert.SerializeObject(actual));

        }

        [TestMethod]
        public void Test_GetItemDetails()
        {
            var item = _itemService.GetAllItems().FirstOrDefault();
            if (item != null)
            {
                var actual = (_itemController.GetItemDetails(item.Id).Result as ViewResult).Model;
                var expected = _itemService.GetItemDetails(item.Id);

                Assert.AreEqual(JsonConvert.SerializeObject(expected), JsonConvert.SerializeObject(actual));
            }


        }

        [TestMethod]
        public void Test_GetAllItems()
        {
            var actual = (_itemController.GetAllItems().Result as PartialViewResult).Model;
            var expected = _itemService.GetAllItems();

            Assert.AreEqual(JsonConvert.SerializeObject(expected), JsonConvert.SerializeObject(actual));

        }
        [TestMethod]
        public void Test_AddItem()
        {
            var model = new Item()
            {
                Name = "John Doe",
                Price = 50,
                Description = "This is demo description",
            };
            var result = (_itemController.AddItem(model).Result as JsonResult).Data;

            Assert.AreEqual("success", result);

        }

        [TestMethod]
        public void Test_DeleteItem()
        {
            var item = _itemService.GetAllItems().FirstOrDefault();
            if (item != null)
            {
                var result = (_itemController.DeleteItem(item.Id).Result as JsonResult).Data;

                Assert.AreEqual("success", result);
            }


        }





    }
}

