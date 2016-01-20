using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSN.DAL;
using System.Web;
using CSN.ViewModel;
namespace CSN.Business 
{
    public interface IInitiativeEntry
    {
        IEnumerable<SelectListVM> GetCNSList(int RoleID);
        DataSet InitiativeEntryList(dynamic values);
    }
    public class InitiativeEntry : IInitiativeEntry
    {
        UnitOfWork unitOfWork = new UnitOfWork();
        public DataSet InitiativeEntryList(dynamic values)
        {
            ManageInitiative objManageInitiative = new ManageInitiative();
            return objManageInitiative.InitiativeEntryList(values);
        }

        public IEnumerable<SelectListVM> GetCNSList(int p_CSNID)
        {
            IEnumerable<SelectListVM> objCSNList = null;
            var CSNDetails = unitOfWork.TblCSNListsRepository.GetByID(p_CSNID);

            if (CSNDetails != null)
            {
                if (CSNDetails.Roleid == 28 || CSNDetails.Roleid == 1)
                {

                    objCSNList = (from csnList in unitOfWork.TblCSNListsRepository.Get().Where(d => d.IsActive == "Y")
                                  select new SelectListVM
                                  {
                                      Value = csnList.CSNID,
                                      Text = csnList.FullName
                                  });
                }
                else
                {
                    objCSNList = (from csnList in unitOfWork.TblCSNListsRepository.Get().Where(d => d.IsActive == "Y" && d.CSNID == p_CSNID)
                                  select new SelectListVM
                                  {
                                      Value = csnList.CSNID,
                                      Text = csnList.FullName
                                  });
                }

            }
        

          return objCSNList;




        }
    }
}
