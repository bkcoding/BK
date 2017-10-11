using BK.Models;
using BK.IBLL;
using BK.IDAL;

namespace BK.BLL
{
    public class ReleaseBLL:BaseBLL<release>, IReleaseBLL
    {
        private IReleaseDAL _dal = DALContainer.Container.Resolve<IReleaseDAL>();

        public override void SetDAL()
        {
            DAL = _dal;
        }
    }
}
