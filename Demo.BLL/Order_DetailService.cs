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
    public partial class Order_DetailService : BaseService<Order_Detail>, IOrder_DetailService
    {
        private IOrder_DetailDAL Order_DetailDAL = DALContainer.Container.Resolve<IOrder_DetailDAL>();
        public override void SetDal()
        {
            Dal = Order_DetailDAL;
        }
    }
}
