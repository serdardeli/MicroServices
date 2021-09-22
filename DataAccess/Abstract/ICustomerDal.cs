using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    using Core.DataAccess;

    using Entities;


    public interface ICustomerDal : IEntityRepository<Customer>
    {
    }
}
