using Autofac;
using System;
using System.Collections.Generic;
using System.Text;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.Jwt;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace Business.DependencyResolvers.Autofac
{
    using Core.DataAccess;
    using Core.DataAccess.EntityFramework;

    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
     

            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();

          

            /*  builder.RegisterType<AddressManager>().As<IAddressService>();
              builder.RegisterType<EfAddressDal>().As<IAddressDal>();*/

       

          /*  builder.RegisterType<CityManager>().As<ICityService>();
            builder.RegisterType<EfCityDal>().As<ICityDal>();*/

           /* builder.RegisterType<CountryManager>().As<ICountryService>();
            builder.RegisterType<EfCountryDal>().As<ICountryDal>();*/

            builder.RegisterType<CustomerManager>().As<ICustomerService>();
            builder.RegisterType<EfCustomerDal>().As<ICustomerDal>();
            builder.RegisterType<OrderManager>().As<IOrderService>();
          

            /*  builder.RegisterType<DistrictManager>().As<IDistrictService>();
              builder.RegisterType<EfDistrictDal>().As<IDistrictDal>();
            */
            /*  builder.RegisterType<EmployeeManager>().As<IEmployeeService>();
              builder.RegisterType<EfEmployeeDal>().As<IEmployeeDal>();*/



            /*  builder.RegisterType<OrderDetailManager>().As<IOrderDetailService>();
              builder.RegisterType<EfOrderDetailDal>().As<IOrderDetailDal>();
            */


            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
}
