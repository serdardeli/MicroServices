using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    using Core.Utilities.Results;

    using Entities;
    using MongoDB.Bson;
    using System.Threading.Tasks;

    public interface IOrderService
    {
        List<Order> Get();
        Order GetById(string id);
        Object Update(string id, Order UpdatedOrder);
        Object Delete(string id);
     
  
    }
}
