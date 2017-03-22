using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo.Model;
using Demo.IBLL;
using Demo.IDAL;

namespace Demo.BLL
{
    public partial class OrderService : BaseService<Order>, IOrderService
    {
        private IOrderDAL OrderDAL = DALContainer.Container.Resolve<IOrderDAL>();
        public override void SetDal()
        {
            Dal = OrderDAL;
        }
    }
}
