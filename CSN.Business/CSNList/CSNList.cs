using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSN.DAL;
using CSN.ViewModel;
namespace CSN.Business
{
    public interface ICSNList
    {
        IQueryable<TblCSNListVM> GetCSNList();
    }
    public class CSNList : ICSNList
    {
        private UnitOfWork unitOfWork = new UnitOfWork();
        public IQueryable<TblCSNListVM> GetCSNList()
        {
            IQueryable<TblCSNListVM> TblCSNList = (from objCSNList in unitOfWork.TblCSNListsRepository.Get().Where(d => d.IsActive == "1")
                                                  
                                                   select new TblCSNListVM
                                                   {
                                                       FirstName = objCSNList.FirstName,
                                                       LastName = objCSNList.LastName,
                                                       FullName = objCSNList.FullName,
                                                       Title = objCSNList.Title,
                                                       Dept = objCSNList.Dept,
                                                       DirEmail = objCSNList.DirEmail,
                                                       Email = objCSNList.Email,
                                                       Fax = objCSNList.Fax,
                                                       Phone = objCSNList.Phone,
                                                       Ext = objCSNList.Ext,
                                                       Cell = objCSNList.Cell,
                                                       AltNumber = objCSNList.AltNumber,
                                                       Address1 = objCSNList.Address1,
                                                       Address2 = objCSNList.Address2,
                                                       City = objCSNList.City,
                                                       State = objCSNList.State,
                                                       Zip = objCSNList.Zip,
                                                       Country = objCSNList.Country,
                                                       SAddress1 = objCSNList.SAddress1,
                                                       SAddress2 = objCSNList.SAddress2,
                                                       SCity = objCSNList.SCity,
                                                       SState = objCSNList.SState,
                                                       SZip = objCSNList.SZip,
                                                       SCountry = objCSNList.SCountry ,
                                                       PrimaryAddress = objCSNList.Address1 + " " + objCSNList.Address2 + " " + objCSNList.City + " " + objCSNList.State + " " + objCSNList.Zip + " " + objCSNList.Country,
                                                       SecondaryAddress = objCSNList.SAddress1 + " " + objCSNList.SAddress2 + " " + objCSNList.SCity + " " + objCSNList.SState + " " + objCSNList.SZip + " " + objCSNList.SCountry
                                                   });
            return TblCSNList;
        }

    }
}
