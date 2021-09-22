using Cassandra;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
   public class TestDataAccess
    {
        public string RequestId { get; set; }
        public bool ShowRequestId { get; set; }
        public static List<Customer> stdRecords = new List<Customer>();
        public TestDataAccess()
        {
            try
            {
                var cluster = Cluster.Builder()
                  .AddContactPoint("127.0.0.1").Build();
                var session = cluster.Connect("dbofmicroserviceforuser");
                var results = session.Execute("select * from customer");
                Customer customer = null;
                foreach (var result in results.GetRows())
                {
                    customer = new Customer();
                    customer.Id = result.GetValue<int>("id");
                    customer.FirstName = result.GetValue<string>("firstname");
                    customer.LastName = result.GetValue<string>("lastname");
                    customer.PhoneNumber = result.GetValue<string>("phonenumber");
                    customer.Address = result.GetValue<string>("address");
                    // customer.CreatedDate = result.GetValue<DateTime>("createddate");
                    stdRecords.Add(customer);
                }
                }
            catch (Exception ex)
            {

                int dummy=1;
            }
        }
        public static List<Customer> FeedData()
        {
            var cluster = Cluster.Builder()
                .AddContactPoint("127.0.0.1").Build();
            var session = cluster.Connect("dbofmicroserviceforuser");
            var results = session.Execute("select * from customer");
            Customer customer = null;
            foreach (var result in results.GetRows())
            {
                customer = new Customer();
                customer.Id = result.GetValue<int>("id");
                customer.FirstName = result.GetValue<string>("firstname");
                customer.LastName = result.GetValue<string>("lastname");
                customer.PhoneNumber = result.GetValue<string>("phonenumber");
                customer.Address = result.GetValue<string>("address");
               // customer.CreatedDate = result.GetValue<DateTime>("createddate");
                stdRecords.Add(customer);

            }
            return stdRecords;
        }
    }
}
