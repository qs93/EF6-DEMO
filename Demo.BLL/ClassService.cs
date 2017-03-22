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
    public partial class ClassService : BaseService<Class>, IClassService
    {
        private IClassDAL ClassDAL = DALContainer.Container.Resolve<IClassDAL>();
        public override void SetDal()
        {
            Dal = ClassDAL;
        }
    }
}
