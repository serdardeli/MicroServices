using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    using Core.Utilities.Results;

    using Entities;


    public interface ICustomerService
    {
        List<Customer> Get();
        Customer GetById(int id);
        Object Update(int id, Customer UpdatedCustomer);
        Object Delete(int id);

    }
}
