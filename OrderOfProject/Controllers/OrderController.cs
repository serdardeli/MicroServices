using Business.Abstract;
using Core.MongoDB;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderSideOfProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMongoCollection<Order> _order;
        private readonly OrderConfiguration _settings;
   
        public OrderController(IOrderService orderService, IOptions<OrderConfiguration> settings)
        {
            _orderService = orderService;
            _settings = settings.Value;
            var client = new MongoClient(_settings.ConnectionString);
            var database = client.GetDatabase(_settings.DatabaseName);
            _order = database.GetCollection<Order>(_settings.OrderCollectionName);

        }
        [HttpGet("getall")]
        public IActionResult GetList()
        {
            var result = _orderService.Get();
            return Ok(result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetById(string id)
        {
            var result = _orderService.GetById(id);

            return Ok(result);
        }
        [HttpPost("add")]
        public  IActionResult Add(Order order)
        {

            var orders = _order.Database.GetCollection<Order>("Order");
            Order newOrder = new Order()
            {
                Id = order.Id,
                CustomerId = order.CustomerId,
                CreatedDate = order.CreatedDate,
                Freight = order.Freight,
                ModifiedDate = order.ModifiedDate,
                OrderDate = order.OrderDate,
                ProductId = order.ProductId,
                ShipAddress = order.ShipAddress,
                ShipCity = order.ShipCity,
                ShipCountry = order.ShipCountry,
                ShipName = order.ShipName,
                ShippedDate = order.ShippedDate,
                ShipPostalCode = order.ShipPostalCode,
                ShipRegion = order.ShipRegion,
                ShipVia = order.ShipVia

            };
            orders.InsertOne(newOrder);
            return Ok(orders);
                
        }
        [HttpPost("Update")]
        public IActionResult Update(string id, Order orderData)
        {
            var result=_order.ReplaceOne(item => item.Id == id, orderData);
            return Ok(result);
        }
       
        [HttpPost("delete")]
        public IActionResult Delete(string id)
        {
            var result = _orderService.Delete(id);
            return Ok(value: result);
        }
    }
}
