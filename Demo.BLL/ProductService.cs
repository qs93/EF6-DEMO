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
    public partial class ProductService : BaseService<Product>, IProductService
    {
        private IProductDAL ProductDAL = DALContainer.Container.Resolve<IProductDAL>();
        public override void SetDal()
        {
            Dal = ProductDAL;
        }
    }
}
