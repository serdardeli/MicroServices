using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    using Business.Abstract;
    using Cassandra;
    using Core.MongoDB;
    using DataAccess.Concrete.EntityFramework;
    using Entities;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Options;
    using MongoDB.Driver;
    using System.Threading;

    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IMongoCollection<Customer> _customer;
        private readonly CustomerConfiguration _settings;
        CancellationTokenSource tokenSource = new CancellationTokenSource();



        public CustomersController(ICustomerService customerService, IOptions<CustomerConfiguration> settings)
        {
            _customerService  = customerService;
            _settings = settings.Value;
            var client = new MongoClient(_settings.ConnectionString);
            var database = client.GetDatabase(_settings.DatabaseName);
            _customer = database.GetCollection<Customer>(_settings.CustomerCollectionName);
         
        }



        //[Authorize(Roles = "Product.List")]

        [HttpGet("getall")]
        public async Task<IActionResult> GetList()
        {
            
            CancellationToken cancellationToken = HttpContext.RequestAborted;

            cancellationToken = tokenSource.Token;
            if (cancellationToken.IsCancellationRequested)
            {
                 var result = _customerService.Get();
                return Ok(result);
            }

            return Ok();
        }
        /* [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _customerService.GetById(id);

            return Ok(result);
        }
        */


        [HttpPost]
        public IActionResult Create(Customer customer)
        {

            var customers = _customer.Database.GetCollection<Customer>("Customer");
            Customer newCustomer = new Customer()
            {
                Id = customer.Id,
               FirstName=customer.FirstName,
               LastName=customer.LastName,
               PhoneNumber=customer.PhoneNumber,
               Address=customer.Address,
               CreatedDate=customer.CreatedDate
               
            };
            customers.InsertOne(newCustomer);
            return Ok(customers);

        }
        [HttpPut]
        public IActionResult Update(int id, Customer customerData)
        {
            var result = _customer.ReplaceOne(item => item.Id == id, customerData);
            return Ok(result);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var result = _customerService.Delete(id);
            return Ok(value: result);
        }
       
    }
}
