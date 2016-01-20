using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSN.DAL;
using CSN.ViewModel;
namespace CSN.Business
{
    public interface ILogin
    {
        TblCSNListVM ValidateUser(string p_UserName, string p_Password);
        IEnumerable<TblPageMasterVM> GetNavigation(int pCNSID);
      
    }
    public class Login : ILogin
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        public TblCSNListVM ValidateUser(string p_UserName, string p_Password)
        {
            TblCSNListVM TblCSNList = (from objCSNList in unitOfWork.TblCSNListsRepository.Get().Where(d=>d.IsActive=="1")
                            where objCSNList.UserName == p_UserName && objCSNList.Password == p_Password && objCSNList.IsActive == "1"
                            select new TblCSNListVM
                            {
                                CSNID = objCSNList.CSNID,
                                FirstName=objCSNList.FirstName,
                                LastName = objCSNList.LastName,
                                FullName = objCSNList.FullName,
                                UserName = p_UserName,
                                Roleid=objCSNList.Roleid

                            }).FirstOrDefault();

            return TblCSNList;
        }

        public IEnumerable<TblPageMasterVM> GetNavigation(int pCNSID)
        {
            var objPageParentList = (from PM in unitOfWork.tblPageMastersRepository.Get()
                                                       join RPM in unitOfWork.TblRolePageMappingsRepository.Get() on PM.Page_Id equals RPM.Page_Id 
                                                       join CSN in unitOfWork.TblCSNListsRepository.Get() on RPM.Role_Id equals (int)CSN.Roleid
                                                       where CSN.CSNID == pCNSID
                                                       select new
                                                       {
                                                           PM.ParentID
                                                       }).Distinct();

            IEnumerable<TblPageMasterVM> objPageList = (from PM in unitOfWork.tblPageMastersRepository.Get()
                                                       join pageParent in objPageParentList on PM.Page_Id equals pageParent.ParentID
                                                       select new TblPageMasterVM
                                                       {
                                                           PageID = (int)PM.Page_Id,
                                                           PageName = PM.PageName,
                                                           ParentID = PM.ParentID,
                                                           Controller = PM.Controller,
                                                           Action = PM.Action,
                                                           DisplayOrder = PM.DisplayOrder
                                                       }).OrderBy(d=>d.DisplayOrder).Distinct();
            var objPageListDetails = objPageList.ToList().OrderBy(d=>d.DisplayOrder);
            if (objPageListDetails.Count() > 0)
            {
                
                foreach (var page in objPageListDetails)
                {

                    page.TblPageMasterList = GetSubNavigation((int)pCNSID, (int)page.PageID);
                }
            }


            return objPageListDetails;
        }

        public IEnumerable<TblPageMasterVM> GetSubNavigation(int pCNSID, int pParentID)
        {

            IEnumerable<TblPageMasterVM> objPageList = (from PM in unitOfWork.tblPageMastersRepository.Get()
                                     join RPM in unitOfWork.TblRolePageMappingsRepository.Get() on PM.Page_Id equals RPM.Page_Id
                                     join CSN in unitOfWork.TblCSNListsRepository.Get() on RPM.Role_Id equals (int)CSN.Roleid
                                     where CSN.CSNID == pCNSID && PM.ParentID == pParentID
                                     select new TblPageMasterVM
                                     {
                                         PageID = (int)PM.Page_Id,
                                         PageName = PM.PageName,
                                         ParentID = PM.ParentID,
                                         Controller = PM.Controller,
                                         Action = PM.Action,
                                         DisplayOrder = PM.DisplayOrder
                                     }).OrderBy(d => d.DisplayOrder);

            return objPageList;
        }



    }
}
