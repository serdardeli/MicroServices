using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    using Core.DataAccess.EntityFramework;

    using DataAccess.Abstract;
    using DataAccess.Concrete.EntityFramework.Contexts;

    using Entities;


    public class EfCustomerDal : EfEntityRepositoryBase<Customer, NorthwindContext>, ICustomerDal
    {
    }
}
