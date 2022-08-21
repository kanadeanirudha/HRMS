using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface IPurchaseRequisitionMasterDataProvider
    {
        IBaseEntityResponse<PurchaseRequisitionMaster> InsertPurchaseRequisitionMaster(PurchaseRequisitionMaster item);
        IBaseEntityResponse<PurchaseRequisitionMaster> InsertApprovedPurchaseRequisitionRecord(PurchaseRequisitionMaster item);
        IBaseEntityResponse<PurchaseRequisitionMaster> UpdatePurchaseRequisitionMaster(PurchaseRequisitionMaster item);
        IBaseEntityResponse<PurchaseRequisitionMaster> DeletePurchaseRequisitionMaster(PurchaseRequisitionMaster item);
        IBaseEntityCollectionResponse<PurchaseRequisitionMaster> GetPurchaseRequisitionMasterBySearch(PurchaseRequisitionMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<PurchaseRequisitionMaster> GetPurchaseRequisitionMasterList(PurchaseRequisitionMasterSearchRequest searchRequest);
        IBaseEntityResponse<PurchaseRequisitionMaster> GetPurchaseRequisitionMasterByID(PurchaseRequisitionMaster item);
        IBaseEntityCollectionResponse<PurchaseRequisitionMaster> GetPurchaseRequisitionMasterListForBelowSafetyLevel(PurchaseRequisitionMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<PurchaseRequisitionMaster> GetPurchaseRequisitionMasterDetailLists(PurchaseRequisitionMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<PurchaseRequisitionMaster> GetPurchaseRequisitionForApproval(PurchaseRequisitionMasterSearchRequest searchRequest);

        //Method For Get UoM details with Its Purchase Price 
        IBaseEntityCollectionResponse<PurchaseRequisitionMaster> GetUomDetailsForSTOWithPurchasePrice(PurchaseRequisitionMasterSearchRequest searchRequest);

        //Method For Get UoMWisePurchasePrice on change of UOM Drop down 
        IBaseEntityCollectionResponse<PurchaseRequisitionMaster> GetUomWisePurchasePrice(PurchaseRequisitionMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<PurchaseRequisitionMaster> GetItemAndLocationWiseBatchQuantity(PurchaseRequisitionMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<PurchaseRequisitionMaster> GetItemwiseRequirmentForDataList(PurchaseRequisitionMasterSearchRequest searchRequest);
    }
}
