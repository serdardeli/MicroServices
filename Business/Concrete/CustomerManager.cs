using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    using System.Linq;
    using System.Threading;

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
    using MongoDB.Driver;

    public class CustomerManager : ICustomerService
    {
        private readonly IMongoCollection<Customer> _customer;
        private readonly CustomerConfiguration _settings;
        public CustomerManager(IOptions<CustomerConfiguration> settings)
        {
            _settings = settings.Value;
            var client = new MongoClient(_settings.ConnectionString);
            var database = client.GetDatabase(_settings.DatabaseName);
            _customer = database.GetCollection<Customer>(_settings.CustomerCollectionName);
        }
        public List<Customer> Get() => _customer.Find(customer => true).ToList();
        public Customer GetById(int id) => _customer.Find(customer => customer.Id == id).FirstOrDefault();
        public Object Update(int id, Customer updatedCustomer) => _customer.ReplaceOne(customer => customer.Id == id, updatedCustomer);
        public Object Delete(int id) => _customer.DeleteOne(customer => customer.Id == id);
    }
}
