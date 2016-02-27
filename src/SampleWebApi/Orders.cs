using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Driver;
using NLog;

namespace SampleWebApi
{
    public static class Orders
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private static readonly IMongoCollection<Order> OrdersCollection;

        static Orders()
        {
            Logger.Info("Bootstrapping Orders");

            var client = new MongoClient("mongodb://development:27017");
            var database = client.GetDatabase("ordering");

            OrdersCollection = database.GetCollection<Order>("orders");
        }

        public static async Task<Order> StoreAsync(Order order)
        {
            Logger.Trace("Storing new Order {0}", order.Id);

            await OrdersCollection.InsertOneAsync(order).ConfigureAwait(false);

            return order;
        }

        public static async Task<List<Order>> GetAsync()
        {
            Logger.Trace("Getting orders");

            return await OrdersCollection.Find(o => true).ToListAsync().ConfigureAwait(false);
        }
    }

    public class Order
    {
        public Guid Id { get; set; }
        public string Customer { get; set; }
        public decimal Amount { get; set; }
    }
}