using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface IVendorMasterDataProvider
    {
        IBaseEntityResponse<VendorMaster> InsertVendorMaster(VendorMaster item);
        IBaseEntityResponse<VendorMaster> UpdateVendorMaster(VendorMaster item);
        IBaseEntityResponse<VendorMaster> DeleteVendorMaster(VendorMaster item);
        IBaseEntityResponse<VendorMaster> InsertVendorMasterExcel(VendorMaster item);

        IBaseEntityCollectionResponse<VendorMaster> GetVendorMasterBySearch(VendorMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<VendorMaster> GetVendorMasterSearchList(VendorMasterSearchRequest searchRequest);
        IBaseEntityResponse<VendorMaster> GetVendorMasterByID(VendorMaster item);
       // IBaseEntityResponse<VendorMaster> GetReplenishmentDataByVendorNumber(VendorMaster item);
        IBaseEntityResponse<VendorMaster> GetGeneralDataByVendorNumber(VendorMaster item);
        IBaseEntityResponse<VendorMaster> GetFinanceDataByVendorNumber(VendorMaster item);
        IBaseEntityResponse<VendorMaster> GetLeadTimeByVendorID(VendorMaster item);
        IBaseEntityCollectionResponse<VendorMaster> GetReplenishmentDataByVendorNumber(VendorMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<VendorMaster> GetContactPersonDetailsForVendorMaster(VendorMasterSearchRequest searchRequest);
        IBaseEntityResponse<VendorMaster> GetDataValidationListsForExcel(VendorMaster item);
    }
}
