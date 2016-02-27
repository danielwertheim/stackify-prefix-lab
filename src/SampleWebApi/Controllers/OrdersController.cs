using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace SampleWebApi.Controllers
{
    [RoutePrefix("api/orders")]
    public class OrdersController : ApiController
    {
        [Route]
        [HttpPost]
        public async Task<Order> PostAsync()
        {
            var order = new Order
            {
                Id = Guid.NewGuid(),
                Amount = new Random().Next(1000, 10000) / 100M,
                Customer = "Joe"
            };

            await Orders.StoreAsync(order).ConfigureAwait(false);

            return order;
        }

        [Route]
        [HttpGet]
        public async Task<List<Order>> GetAsync()
        {
            return await Orders.GetAsync().ConfigureAwait(false);
        }
    }
}