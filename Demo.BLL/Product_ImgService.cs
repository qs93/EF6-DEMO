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
    public partial class Product_ImgService : BaseService<Product_Img>, IProduct_ImgService
    {
        private IProduct_ImgDAL Product_ImgDAL = DALContainer.Container.Resolve<IProduct_ImgDAL>();
        public override void SetDal()
        {
            Dal = Product_ImgDAL;
        }
    }
}
