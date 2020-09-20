using ShopBridge.Model;
using ShopBridge.Service;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ShopBridge.Api.Controllers
{
    
    public class ItemController : ApiController
    {
        ItemService _itemService = new ItemService();


        [Route("api/Item/GetAllItems")]
        public async Task<HttpResponseMessage> GetAllItems()
        {
            try
            {
                return await Task.FromResult(Request.CreateResponse(HttpStatusCode.OK, _itemService.GetAllItems()));
            }
            catch (Exception ex)
            {

                return await Task.FromResult(Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message));
            }
        }

        [Route("api/Item/AddItem")]
        [HttpPost]
        public async Task<HttpResponseMessage> AddItem(Item item)
        {
            try
            {
                return await Task.FromResult(Request.CreateResponse(HttpStatusCode.OK, _itemService.AddItem(item)));
            }
            catch (Exception ex)
            {

                return await Task.FromResult(Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message));
            }
        }

        [Route("api/Item/GetItemDetails/{id}")]
        public async Task<HttpResponseMessage> GetItemDetails(int id)
        {
            try
            {
                return await Task.FromResult(Request.CreateResponse(HttpStatusCode.OK, _itemService.GetItemDetails(id)));
            }
            catch (Exception ex)
            {

                return await Task.FromResult(Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message));
            }
        }

        [Route("api/Item/DeleteItem/{id}")]
        [HttpGet]
        public async Task<HttpResponseMessage> DeleteItem(int id)
        {
            try
            {
                return await Task.FromResult(Request.CreateResponse(HttpStatusCode.OK, _itemService.DeleteItem(id)));
            }
            catch (Exception ex)
            {

                return await Task.FromResult(Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message));
            }
        }

    }
}
