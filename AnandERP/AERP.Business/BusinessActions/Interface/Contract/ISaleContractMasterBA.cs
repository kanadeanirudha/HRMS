using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessAction
{
    public interface ISaleContractMasterBA
    {
        IBaseEntityCollectionResponse<SaleContractMaster> GetSaleContractMasterBySearch(SaleContractMasterSearchRequest searchRequest);

        IBaseEntityResponse<SaleContractMaster> InsertSaleContractMaster(SaleContractMaster item);
        IBaseEntityCollectionResponse<SaleContractMaster> GetContractNumberSearchList(SaleContractMasterSearchRequest searchRequest);
        IBaseEntityResponse<SaleContractMaster> GetGeneralContractDetails(SaleContractMaster item);
        IBaseEntityResponse<SaleContractMaster> GetTermDetailsData(SaleContractMaster item);
        IBaseEntityCollectionResponse<SaleContractMaster> GetManPowerItemList(SaleContractMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SaleContractMaster> GetAssignedEmployeeList(SaleContractMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SaleContractMaster> GetContractMaterialList(SaleContractMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SaleContractMaster> GetMachineMasterList(SaleContractMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SaleContractMaster> GetJobWorkItemList(SaleContractMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SaleContractMaster> GetFixItemList(SaleContractMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SaleContractMaster> GetServiceChargeList(SaleContractMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SaleContractMaster> GetServiceChargeOnAllowanceList(SaleContractMasterSearchRequest searchRequest); 
        IBaseEntityCollectionResponse<SaleContractMaster> GetOverTimeList(SaleContractMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SaleContractMaster> GetOverTimeFixList(SaleContractMasterSearchRequest searchRequest); 
        IBaseEntityCollectionResponse<SaleContractMaster> GetServiceItemList(SaleContractMasterSearchRequest searchRequest); 
        IBaseEntityCollectionResponse<SaleContractMaster> GetContractNumberSearchListByCustomer(SaleContractMasterSearchRequest searchRequest);

        IBaseEntityResponse<SaleContractMaster> ModifySaleContractMaster(SaleContractMaster item);
        IBaseEntityResponse<SaleContractMaster> ExtendSaleContractMaster(SaleContractMaster item);
        IBaseEntityResponse<SaleContractMaster> SaleContractMasterShiftEmployee(SaleContractMaster item);
        IBaseEntityResponse<SaleContractMaster> RenewSaleContractMaster(SaleContractMaster item); 
    }
}
