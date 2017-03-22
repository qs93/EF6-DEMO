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
    public partial class ReceiverService : BaseService<Receiver>, IReceiverService
    {
        private IReceiverDAL ReceiverDAL = DALContainer.Container.Resolve<IReceiverDAL>();
        public override void SetDal()
        {
            Dal = ReceiverDAL;
        }
    }
}
