using BK.Models;
using BK.IBLL;
using BK.IDAL;

namespace BK.BLL
{
    public class MfcBLL : BaseBLL<mfc>, IMfcBLL
    {
        private IMfcDAL _dal = DALContainer.Container.Resolve<IMfcDAL>();

        public override void SetDAL()
        {
            DAL = _dal;
        }
    }
}
