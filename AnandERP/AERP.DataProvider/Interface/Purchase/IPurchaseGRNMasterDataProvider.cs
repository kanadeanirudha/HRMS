using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface IPurchaseGRNMasterDataProvider
    {

        /// <summary>
        /// data provider interface of select all record of PurchaseGRNMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<PurchaseGRNMaster> GetPurchaseGRNMasterBySearch(PurchaseGRNMasterSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select all record of PurchaseGRNMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<PurchaseGRNMaster> GetPurchaseGRNMasterGetBySearchList(PurchaseGRNMasterSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select one record of PurchaseGRNMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<PurchaseGRNMaster> GetPurchaseGRNMasterByID(PurchaseGRNMaster item);

        /// <summary>
        /// data provider interface of insert new record of PurchaseGRNMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<PurchaseGRNMaster> InsertPurchaseGRNMaster(PurchaseGRNMaster item);

        /// <summary>
        /// data provider interface of update record of PurchaseGRNMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<PurchaseGRNMaster> UpdatePurchaseGRNMaster(PurchaseGRNMaster item);

        /// <summary>
        /// data provider interface of dalete record of PurchaseGRNMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<PurchaseGRNMaster> DeletePurchaseGRNMaster(PurchaseGRNMaster item);

        IBaseEntityCollectionResponse<PurchaseGRNMaster> GetPurchaseOrderMasterListForGRN(PurchaseGRNMasterSearchRequest searchRequest);

        IBaseEntityCollectionResponse<PurchaseGRNMaster> GetBatchList(PurchaseGRNMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<PurchaseGRNMaster> GetPurchaseGRNDetailsByID(PurchaseGRNMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<PurchaseGRNMaster> GetPurchaseGrnMasterListForPDF(PurchaseGRNMasterSearchRequest searchRequest);
    }
}
