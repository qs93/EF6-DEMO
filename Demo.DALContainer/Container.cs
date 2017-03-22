using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Demo.DAL;
using Demo.IDAL;

namespace Demo.DALContainer
{
    public class Container
    {
        /// <summary>
        /// IOC 容器
        /// </summary>
        public static IContainer container = null;

        /// <summary>
        /// 獲取IDAL的實例化對象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Resolve<T>()
        {
            try
            {
                if (container == null)
                {
                    Initialise();
                }
            }
            catch (System.Exception ex)
            {
                throw new System.Exception("IOC實例化出錯!" + ex.Message);
            }

            return container.Resolve<T>();
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public static void Initialise()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ClassDAL>().As<IClassDAL>().InstancePerLifetimeScope();
            builder.RegisterType<MemberDAL>().As<IMemberDAL>().InstancePerLifetimeScope();
            builder.RegisterType<Order_DetailDAL>().As<IOrder_DetailDAL>().InstancePerLifetimeScope();
            builder.RegisterType<OrderDAL>().As<IOrderDAL>().InstancePerLifetimeScope();
            builder.RegisterType<Product_ImgDAL>().As<IProduct_ImgDAL>().InstancePerLifetimeScope();
            builder.RegisterType<ProductDAL>().As<IProductDAL>().InstancePerLifetimeScope();
            builder.RegisterType<ReceiverDAL>().As<IReceiverDAL>().InstancePerLifetimeScope();
            builder.RegisterType<StoreDAL>().As<IStoreDAL>().InstancePerLifetimeScope();
            container = builder.Build();
        }
    }
}
