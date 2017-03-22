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
    public partial class StoreService : BaseService<Store>, IStoreService
    {
        private IStoreDAL StoreDAL = DALContainer.Container.Resolve<IStoreDAL>();
        public override void SetDal()
        {
            Dal = StoreDAL;
        }
    }
}
