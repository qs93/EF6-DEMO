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
    public partial class MemberService : BaseService<Member>, IMemberService
    {
        private IMemberDAL MemberDAL = DALContainer.Container.Resolve<IMemberDAL>();
        public override void SetDal()
        {
            Dal = MemberDAL;
        }
    }
}
