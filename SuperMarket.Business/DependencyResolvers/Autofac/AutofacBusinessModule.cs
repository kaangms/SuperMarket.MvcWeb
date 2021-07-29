using Autofac;
using Core.Utilities.Security.Jwt;
using SuperMarket.Business.Abstract;
using SuperMarket.Business.Concrete;
using SuperMarket.DataAccess.Abstract;
using SuperMarket.DataAccess.Concrete.EntityFramework;

namespace SuperMarket.Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<OrderDetailManager>().As<IOrderDetailService>();
            builder.RegisterType<EfOrderDetailDal>().As<IOrderDetailDal>();

            builder.RegisterType<OrderManager>().As<IOrderService>();
            builder.RegisterType<EfOrderDal>().As<IOrderDal>();

            builder.RegisterType<BasketDetailManager>().As<IBasketDetailService>();
            builder.RegisterType<EfBasketDetailDal>().As<IBasketDetailDal>();

            builder.RegisterType<BasketManager>().As<IBasketService>();
            builder.RegisterType<EfBasketDal>().As<IBasketDal>();

            builder.RegisterType<EfOrderDal>().As<IOrderDal>();
            builder.RegisterType<EfOrderDetailDal>().As<IOrderDetailDal>();

            builder.RegisterType<ProductManager>().As<IProductService>();
            builder.RegisterType<EfProductDal>().As<IProductDal>();

            builder.RegisterType<EfUserDal>().As<IUserDal>();
            builder.RegisterType<UserManager>().As<IUserService>();

            builder.RegisterType<JwtHelper>().As<ITokenHelper>();
            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
        }
    }
}
