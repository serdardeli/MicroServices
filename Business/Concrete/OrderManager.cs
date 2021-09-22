using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Business.Abstract;
    using Business.Constants;


    using Core.Aspects.Autofac.Caching;
    using Core.Aspects.Autofac.Logging;
    using Core.Aspects.Autofac.Performance;
    using Core.Aspects.Autofac.Transaction;
    using Core.Aspects.Autofac.Validation;
    using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
    using Core.MongoDB;
    using Core.Utilities.Business;
    using Core.Utilities.Results;

    using DataAccess.Abstract;

    using Entities;
    using Microsoft.Extensions.Options;
    using MongoDB.Bson;
    using MongoDB.Driver;

    public class OrderManager : IOrderService
    {
        private readonly IMongoCollection<Order> _order;
        private readonly OrderConfiguration _settings;
      
        public OrderManager(IOptions<OrderConfiguration> settings)
        {
            _settings = settings.Value;
            var client = new MongoClient(_settings.ConnectionString);
            var database = client.GetDatabase(_settings.DatabaseName);
            _order = database.GetCollection<Order>(_settings.OrderCollectionName);
        }
     
        public List<Order> Get() => _order.Find(order => true).ToList();
        public Order GetById(string id) => _order.Find(order => order.Id == id).FirstOrDefault();
        public Object Update(string id, Order updatedOrder) =>_order.ReplaceOne(order => order.Id == id, updatedOrder);
        public Object Delete(string id) => _order.DeleteOne(order => order.Id == id);
        


    }
}
