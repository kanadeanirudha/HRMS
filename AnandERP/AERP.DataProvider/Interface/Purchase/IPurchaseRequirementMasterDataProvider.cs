using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
	public interface IPurchaseRequirementMasterDataProvider
	{
		IBaseEntityResponse<PurchaseRequirementMaster> InsertPurchaseRequirementMaster(PurchaseRequirementMaster item);
        IBaseEntityResponse<PurchaseRequirementMaster> InsertApprovedPurchaseRequirementRecord(PurchaseRequirementMaster item);
		IBaseEntityResponse<PurchaseRequirementMaster> UpdatePurchaseRequirementMaster(PurchaseRequirementMaster item);
		IBaseEntityResponse<PurchaseRequirementMaster> DeletePurchaseRequirementMaster(PurchaseRequirementMaster item);
		IBaseEntityCollectionResponse<PurchaseRequirementMaster> GetPurchaseRequirementMasterBySearch(PurchaseRequirementMasterSearchRequest searchRequest);
		IBaseEntityResponse<PurchaseRequirementMaster> GetPurchaseRequirementMasterByID(PurchaseRequirementMaster item);
        IBaseEntityCollectionResponse<PurchaseRequirementMaster> GetPurchaseRequirementMasterDetailList(PurchaseRequirementMasterSearchRequest searchRequest);
        IBaseEntityResponse<PurchaseRequirementMaster> InsertPurchaseRequirementMasterByExcel(PurchaseRequirementMaster item);
        IBaseEntityCollectionResponse<PurchaseRequirementMaster> GetPurchaseRequirementForApproval(PurchaseRequirementMasterSearchRequest searchRequest);
        IBaseEntityResponse<PurchaseRequirementMaster> GetBlockForProcurementByLocationID(PurchaseRequirementMaster item);

	}
}
