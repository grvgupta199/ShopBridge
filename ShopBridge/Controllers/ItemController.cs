using ShopBridge.ApiServices;
using ShopBridge.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ShopBridge.Controllers
{
    [RoutePrefix("Item")]
    public class ItemController : Controller
    {

        [Route("~/")]
        [Route("Index"), HttpGet]
        public async Task<ActionResult> Index()
        {
            Task<ViewResult> task = Task.Factory.StartNew(() =>
            {
                var itemList = ApiService.Get<IEnumerable<Item>>("Item/GetAllItems");
                return View(itemList);
            });
            return await task;
        }

        [Route("AddItem")]
        [HttpPost]
        public async Task<ActionResult> AddItem(Item item)
        {
            Task<JsonResult> task = Task.Factory.StartNew(() =>
            {
                if (item.Image != null)
                {
                    item.ImagePath = UploadImage(item.Image);
                    item.Image = null;
                }
                var res = ApiService.Post<Item, string>("Item/AddItem", item);
               return Json(res,JsonRequestBehavior.AllowGet);
                
            });
            return await task;
        }

        [Route("GetAllItems")]
        public async Task<ActionResult> GetAllItems()
        {
            Task<PartialViewResult> task = Task.Factory.StartNew(() =>
            {
                var itemList = ApiService.Get<IEnumerable<Item>>("Item/GetAllItems");
                return PartialView("_ItemList", itemList);
            });
            return await task;
        }

        [Route("GetItemDetails")]
        public async Task<ActionResult> GetItemDetails(int id)
        {
            Task<ViewResult> task = Task.Factory.StartNew(() =>
            {
                var itemList = ApiService.Get<Item>("Item/GetItemDetails/"+ id);
                return View("ItemDetails", itemList);
            });
            return await task;
        }

        [Route("DeleteItem")]
        [HttpPost]
        public async Task<ActionResult> DeleteItem(int id)
        {
            Task<JsonResult> task = Task.Factory.StartNew(() =>
            {
                var res = ApiService.Get<string>("Item/DeleteItem/" + id);
                return Json(res,JsonRequestBehavior.AllowGet);
            });
            return await task;
        }


        private string UploadImage(HttpPostedFileBase file)
        {
            string basePath = Server.MapPath("~/");
            string folderPath = "/Uploads/";
            string fileName = Path.GetFileNameWithoutExtension(file.FileName);
            string fileExtension = Path.GetExtension(file.FileName);
            string timeStamp = "_" + DateTime.Now.Ticks.ToString();
            string fullPath = basePath + folderPath + fileName + timeStamp + fileExtension;

            file.SaveAs(fullPath);
            return (folderPath + fileName + timeStamp + fileExtension);
        }
    }
}