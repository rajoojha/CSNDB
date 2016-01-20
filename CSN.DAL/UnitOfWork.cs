
using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
 
namespace CSN.DAL
{
  
 
  public  class UnitOfWork : IDisposable
  {
   
       private CSNDBEntities context = new CSNDBEntities();
 
              private Repository<TblAccountList> tblaccountlistsRepository ;
              private Repository<tblAccountType> tblaccounttypesRepository ;
              private Repository<TblAccountTypeMaster> tblaccounttypemastersRepository ;
              private Repository<TblAcctStatu> tblacctstatusRepository ;
              private Repository<TblContactStatu> tblcontactstatusRepository ;
              private Repository<TblCSNGroup> tblcsngroupsRepository ;
              private Repository<TblCSNList> tblcsnlistsRepository ;
              private Repository<TBLCSNRoleAccess> tblcsnroleaccessesRepository ;
              private Repository<TblCSNType> tblcsntypesRepository ;
              private Repository<TblCustType> tblcusttypesRepository ;
              private Repository<TblDivision> tbldivisionsRepository ;
              private Repository<TblGeneralActivitie> tblgeneralactivitiesRepository ;
              private Repository<TblInitiativeList> tblinitiativelistsRepository ;
              private Repository<TblInitiativeResult> tblinitiativeresultsRepository ;
              private Repository<TblInitStatu> tblinitstatusRepository ;
              private Repository<TblInitType> tblinittypesRepository ;
              private Repository<tblLineStatu> tbllinestatusRepository ;
              private Repository<TblMfgContactMaster> tblmfgcontactmastersRepository ;
              private Repository<TblMfgList> tblmfglistsRepository ;
              private Repository<TBLMfgPlatform> tblmfgplatformsRepository ;
              private Repository<TblMfg> tblmfgsRepository ;
              private Repository<TblMfgState> tblmfgstatesRepository ;
              private Repository<TblPlatform> tblplatformsRepository ;
              private Repository<TblResponseType> tblresponsetypesRepository ;
              private Repository<tblRoleMaster> tblrolemastersRepository ;
              private Repository<TblState> tblstatesRepository ;
              private Repository<TblTerritory> tblterritoriesRepository ;
              private Repository<SeeAccountsWithNOTerritory> seeaccountswithnoterritoriesRepository ;
              private Repository<SeeBuyersLinesThatdoNOtexistInMFGList> seebuyerslinesthatdonotexistinmfglistsRepository ;
              private Repository<SeeGeneralActivitiesWithNoContact> seegeneralactivitieswithnocontactsRepository ;
              private Repository<Vw_CSN_Account_Buyers> vw_csn_account_buyersRepository ;
              private Repository<Vw_Mfg_CSN_Account_Buyer> vw_mfg_csn_account_buyerRepository ;
              private Repository<Vw_Mfg_Initiative_List> vw_mfg_initiative_listRepository ;
              private Repository<vwAccountList> vwaccountlistsRepository ;
              private Repository<vwBuyersList> vwbuyerslistsRepository ;
              private Repository<vwMFGAccount> vwmfgaccountsRepository ;
              private Repository<vwMFGContact> vwmfgcontactsRepository ;
              private Repository<VwMfgPlatform> vwmfgplatformsRepository ;
              private Repository<tblPageMaster> tblpagemastersRepository ;
              private Repository<TblRolePageMapping> tblrolepagemappingsRepository ;
              private Repository<TblpkInitResult> tblpkinitresultsRepository ;
              private Repository<TblContactMaster> tblcontactmastersRepository ;
              private Repository<TblBuyersLineCarry> tblbuyerslinecarriesRepository ;
           #region UnitOfWork Members
 
     
      
    public Repository<TblAccountList> TblAccountListsRepository
    {
        get
        {
            if (this.tblaccountlistsRepository == null)
            {
                this.tblaccountlistsRepository = new Repository<TblAccountList>(context);
            }
            return tblaccountlistsRepository;
        }
    }
     
      
    public Repository<tblAccountType> tblAccountTypesRepository
    {
        get
        {
            if (this.tblaccounttypesRepository == null)
            {
                this.tblaccounttypesRepository = new Repository<tblAccountType>(context);
            }
            return tblaccounttypesRepository;
        }
    }
     
      
    public Repository<TblAccountTypeMaster> TblAccountTypeMastersRepository
    {
        get
        {
            if (this.tblaccounttypemastersRepository == null)
            {
                this.tblaccounttypemastersRepository = new Repository<TblAccountTypeMaster>(context);
            }
            return tblaccounttypemastersRepository;
        }
    }
     
      
    public Repository<TblAcctStatu> TblAcctStatusRepository
    {
        get
        {
            if (this.tblacctstatusRepository == null)
            {
                this.tblacctstatusRepository = new Repository<TblAcctStatu>(context);
            }
            return tblacctstatusRepository;
        }
    }
     
      
    public Repository<TblContactStatu> TblContactStatusRepository
    {
        get
        {
            if (this.tblcontactstatusRepository == null)
            {
                this.tblcontactstatusRepository = new Repository<TblContactStatu>(context);
            }
            return tblcontactstatusRepository;
        }
    }
     
      
    public Repository<TblCSNGroup> TblCSNGroupsRepository
    {
        get
        {
            if (this.tblcsngroupsRepository == null)
            {
                this.tblcsngroupsRepository = new Repository<TblCSNGroup>(context);
            }
            return tblcsngroupsRepository;
        }
    }
     
      
    public Repository<TblCSNList> TblCSNListsRepository
    {
        get
        {
            if (this.tblcsnlistsRepository == null)
            {
                this.tblcsnlistsRepository = new Repository<TblCSNList>(context);
            }
            return tblcsnlistsRepository;
        }
    }
     
      
    public Repository<TBLCSNRoleAccess> TBLCSNRoleAccessesRepository
    {
        get
        {
            if (this.tblcsnroleaccessesRepository == null)
            {
                this.tblcsnroleaccessesRepository = new Repository<TBLCSNRoleAccess>(context);
            }
            return tblcsnroleaccessesRepository;
        }
    }
     
      
    public Repository<TblCSNType> TblCSNTypesRepository
    {
        get
        {
            if (this.tblcsntypesRepository == null)
            {
                this.tblcsntypesRepository = new Repository<TblCSNType>(context);
            }
            return tblcsntypesRepository;
        }
    }
     
      
    public Repository<TblCustType> TblCustTypesRepository
    {
        get
        {
            if (this.tblcusttypesRepository == null)
            {
                this.tblcusttypesRepository = new Repository<TblCustType>(context);
            }
            return tblcusttypesRepository;
        }
    }
     
      
    public Repository<TblDivision> TblDivisionsRepository
    {
        get
        {
            if (this.tbldivisionsRepository == null)
            {
                this.tbldivisionsRepository = new Repository<TblDivision>(context);
            }
            return tbldivisionsRepository;
        }
    }
     
      
    public Repository<TblGeneralActivitie> TblGeneralActivitiesRepository
    {
        get
        {
            if (this.tblgeneralactivitiesRepository == null)
            {
                this.tblgeneralactivitiesRepository = new Repository<TblGeneralActivitie>(context);
            }
            return tblgeneralactivitiesRepository;
        }
    }
     
      
    public Repository<TblInitiativeList> TblInitiativeListsRepository
    {
        get
        {
            if (this.tblinitiativelistsRepository == null)
            {
                this.tblinitiativelistsRepository = new Repository<TblInitiativeList>(context);
            }
            return tblinitiativelistsRepository;
        }
    }
     
      
    public Repository<TblInitiativeResult> TblInitiativeResultsRepository
    {
        get
        {
            if (this.tblinitiativeresultsRepository == null)
            {
                this.tblinitiativeresultsRepository = new Repository<TblInitiativeResult>(context);
            }
            return tblinitiativeresultsRepository;
        }
    }
     
      
    public Repository<TblInitStatu> TblInitStatusRepository
    {
        get
        {
            if (this.tblinitstatusRepository == null)
            {
                this.tblinitstatusRepository = new Repository<TblInitStatu>(context);
            }
            return tblinitstatusRepository;
        }
    }
     
      
    public Repository<TblInitType> TblInitTypesRepository
    {
        get
        {
            if (this.tblinittypesRepository == null)
            {
                this.tblinittypesRepository = new Repository<TblInitType>(context);
            }
            return tblinittypesRepository;
        }
    }
     
      
    public Repository<tblLineStatu> tblLineStatusRepository
    {
        get
        {
            if (this.tbllinestatusRepository == null)
            {
                this.tbllinestatusRepository = new Repository<tblLineStatu>(context);
            }
            return tbllinestatusRepository;
        }
    }
     
      
    public Repository<TblMfgContactMaster> TblMfgContactMastersRepository
    {
        get
        {
            if (this.tblmfgcontactmastersRepository == null)
            {
                this.tblmfgcontactmastersRepository = new Repository<TblMfgContactMaster>(context);
            }
            return tblmfgcontactmastersRepository;
        }
    }
     
      
    public Repository<TblMfgList> TblMfgListsRepository
    {
        get
        {
            if (this.tblmfglistsRepository == null)
            {
                this.tblmfglistsRepository = new Repository<TblMfgList>(context);
            }
            return tblmfglistsRepository;
        }
    }
     
      
    public Repository<TBLMfgPlatform> TBLMfgPlatformsRepository
    {
        get
        {
            if (this.tblmfgplatformsRepository == null)
            {
                this.tblmfgplatformsRepository = new Repository<TBLMfgPlatform>(context);
            }
            return tblmfgplatformsRepository;
        }
    }
     
      
    public Repository<TblMfg> TblMfgsRepository
    {
        get
        {
            if (this.tblmfgsRepository == null)
            {
                this.tblmfgsRepository = new Repository<TblMfg>(context);
            }
            return tblmfgsRepository;
        }
    }
     
      
    public Repository<TblMfgState> TblMfgStatesRepository
    {
        get
        {
            if (this.tblmfgstatesRepository == null)
            {
                this.tblmfgstatesRepository = new Repository<TblMfgState>(context);
            }
            return tblmfgstatesRepository;
        }
    }
     
      
    public Repository<TblPlatform> TblPlatformsRepository
    {
        get
        {
            if (this.tblplatformsRepository == null)
            {
                this.tblplatformsRepository = new Repository<TblPlatform>(context);
            }
            return tblplatformsRepository;
        }
    }
     
      
    public Repository<TblResponseType> TblResponseTypesRepository
    {
        get
        {
            if (this.tblresponsetypesRepository == null)
            {
                this.tblresponsetypesRepository = new Repository<TblResponseType>(context);
            }
            return tblresponsetypesRepository;
        }
    }
     
      
    public Repository<tblRoleMaster> tblRoleMastersRepository
    {
        get
        {
            if (this.tblrolemastersRepository == null)
            {
                this.tblrolemastersRepository = new Repository<tblRoleMaster>(context);
            }
            return tblrolemastersRepository;
        }
    }
     
      
    public Repository<TblState> TblStatesRepository
    {
        get
        {
            if (this.tblstatesRepository == null)
            {
                this.tblstatesRepository = new Repository<TblState>(context);
            }
            return tblstatesRepository;
        }
    }
     
      
    public Repository<TblTerritory> TblTerritoriesRepository
    {
        get
        {
            if (this.tblterritoriesRepository == null)
            {
                this.tblterritoriesRepository = new Repository<TblTerritory>(context);
            }
            return tblterritoriesRepository;
        }
    }
     
      
    public Repository<SeeAccountsWithNOTerritory> SeeAccountsWithNOTerritoriesRepository
    {
        get
        {
            if (this.seeaccountswithnoterritoriesRepository == null)
            {
                this.seeaccountswithnoterritoriesRepository = new Repository<SeeAccountsWithNOTerritory>(context);
            }
            return seeaccountswithnoterritoriesRepository;
        }
    }
     
      
    public Repository<SeeBuyersLinesThatdoNOtexistInMFGList> SeeBuyersLinesThatdoNOtexistInMFGListsRepository
    {
        get
        {
            if (this.seebuyerslinesthatdonotexistinmfglistsRepository == null)
            {
                this.seebuyerslinesthatdonotexistinmfglistsRepository = new Repository<SeeBuyersLinesThatdoNOtexistInMFGList>(context);
            }
            return seebuyerslinesthatdonotexistinmfglistsRepository;
        }
    }
     
      
    public Repository<SeeGeneralActivitiesWithNoContact> SeeGeneralActivitiesWithNoContactsRepository
    {
        get
        {
            if (this.seegeneralactivitieswithnocontactsRepository == null)
            {
                this.seegeneralactivitieswithnocontactsRepository = new Repository<SeeGeneralActivitiesWithNoContact>(context);
            }
            return seegeneralactivitieswithnocontactsRepository;
        }
    }
     
      
    public Repository<Vw_CSN_Account_Buyers> Vw_CSN_Account_BuyersRepository
    {
        get
        {
            if (this.vw_csn_account_buyersRepository == null)
            {
                this.vw_csn_account_buyersRepository = new Repository<Vw_CSN_Account_Buyers>(context);
            }
            return vw_csn_account_buyersRepository;
        }
    }
     
      
    public Repository<Vw_Mfg_CSN_Account_Buyer> Vw_Mfg_CSN_Account_BuyerRepository
    {
        get
        {
            if (this.vw_mfg_csn_account_buyerRepository == null)
            {
                this.vw_mfg_csn_account_buyerRepository = new Repository<Vw_Mfg_CSN_Account_Buyer>(context);
            }
            return vw_mfg_csn_account_buyerRepository;
        }
    }
     
      
    public Repository<Vw_Mfg_Initiative_List> Vw_Mfg_Initiative_ListRepository
    {
        get
        {
            if (this.vw_mfg_initiative_listRepository == null)
            {
                this.vw_mfg_initiative_listRepository = new Repository<Vw_Mfg_Initiative_List>(context);
            }
            return vw_mfg_initiative_listRepository;
        }
    }
     
      
    public Repository<vwAccountList> vwAccountListsRepository
    {
        get
        {
            if (this.vwaccountlistsRepository == null)
            {
                this.vwaccountlistsRepository = new Repository<vwAccountList>(context);
            }
            return vwaccountlistsRepository;
        }
    }
     
      
    public Repository<vwBuyersList> vwBuyersListsRepository
    {
        get
        {
            if (this.vwbuyerslistsRepository == null)
            {
                this.vwbuyerslistsRepository = new Repository<vwBuyersList>(context);
            }
            return vwbuyerslistsRepository;
        }
    }
     
      
    public Repository<vwMFGAccount> vwMFGAccountsRepository
    {
        get
        {
            if (this.vwmfgaccountsRepository == null)
            {
                this.vwmfgaccountsRepository = new Repository<vwMFGAccount>(context);
            }
            return vwmfgaccountsRepository;
        }
    }
     
      
    public Repository<vwMFGContact> vwMFGContactsRepository
    {
        get
        {
            if (this.vwmfgcontactsRepository == null)
            {
                this.vwmfgcontactsRepository = new Repository<vwMFGContact>(context);
            }
            return vwmfgcontactsRepository;
        }
    }
     
      
    public Repository<VwMfgPlatform> VwMfgPlatformsRepository
    {
        get
        {
            if (this.vwmfgplatformsRepository == null)
            {
                this.vwmfgplatformsRepository = new Repository<VwMfgPlatform>(context);
            }
            return vwmfgplatformsRepository;
        }
    }
     
      
    public Repository<tblPageMaster> tblPageMastersRepository
    {
        get
        {
            if (this.tblpagemastersRepository == null)
            {
                this.tblpagemastersRepository = new Repository<tblPageMaster>(context);
            }
            return tblpagemastersRepository;
        }
    }
     
      
    public Repository<TblRolePageMapping> TblRolePageMappingsRepository
    {
        get
        {
            if (this.tblrolepagemappingsRepository == null)
            {
                this.tblrolepagemappingsRepository = new Repository<TblRolePageMapping>(context);
            }
            return tblrolepagemappingsRepository;
        }
    }
     
      
    public Repository<TblpkInitResult> TblpkInitResultsRepository
    {
        get
        {
            if (this.tblpkinitresultsRepository == null)
            {
                this.tblpkinitresultsRepository = new Repository<TblpkInitResult>(context);
            }
            return tblpkinitresultsRepository;
        }
    }
     
      
    public Repository<TblContactMaster> TblContactMastersRepository
    {
        get
        {
            if (this.tblcontactmastersRepository == null)
            {
                this.tblcontactmastersRepository = new Repository<TblContactMaster>(context);
            }
            return tblcontactmastersRepository;
        }
    }
     
      
    public Repository<TblBuyersLineCarry> TblBuyersLineCarriesRepository
    {
        get
        {
            if (this.tblbuyerslinecarriesRepository == null)
            {
                this.tblbuyerslinecarriesRepository = new Repository<TblBuyersLineCarry>(context);
            }
            return tblbuyerslinecarriesRepository;
        }
    }
       
    
    public void Save()
    {
              context.SaveChanges();
    }
 
    private bool disposed = false;
 
    protected virtual void Dispose(bool disposing)
    {
              if (!this.disposed)
                     {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
    }
 
   public void Dispose()
   {
              Dispose(true);
        GC.SuppressFinalize(this);
   }
 
    #endregion
  }
}
