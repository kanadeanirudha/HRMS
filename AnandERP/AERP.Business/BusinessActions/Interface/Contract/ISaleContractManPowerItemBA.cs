using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessAction
{
    public interface ISaleContractManPowerItemBA
    {
        /// <summary>
        /// business action interface of insert new record of SaleContractManPowerItem.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<SaleContractManPowerItem> InsertSaleContractManPowerItem(SaleContractManPowerItem item);

        /// <summary>
        /// business action interface of update record of SaleContractManPowerItem.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<SaleContractManPowerItem> UpdateSaleContractManPowerItem(SaleContractManPowerItem item);

        /// <summary>
        /// business action interface of dalete record of SaleContractManPowerItem.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<SaleContractManPowerItem> DeleteSaleContractManPowerItem(SaleContractManPowerItem item);

        /// <summary>
        /// business action interface of select all record of SaleContractManPowerItem.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<SaleContractManPowerItem> GetBySearch(SaleContractManPowerItemSearchRequest searchRequest);

        /// <summary>
        /// business action interface of select all record of SaleContractManPowerItem.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<SaleContractManPowerItem> GetBySearchList(SaleContractManPowerItemSearchRequest searchRequest);

        /// <summary>
        /// business action interface of select one record of SaleContractManPowerItem.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<SaleContractManPowerItem> SelectByID(SaleContractManPowerItem item);
        IBaseEntityResponse<SaleContractManPowerItem> InsertSaleContractManPowerItemRules(SaleContractManPowerItem item);
        IBaseEntityResponse<SaleContractManPowerItem> ViewSaleContractManPowerItemRules(SaleContractManPowerItem item);
        IBaseEntityResponse<SaleContractManPowerItem> DeleteSaleContractManPowerItemRules(SaleContractManPowerItem item);
        IBaseEntityResponse<SaleContractManPowerItem> UpdateSaleContractManPowerItemRules(SaleContractManPowerItem item); 
        IBaseEntityCollectionResponse<SaleContractManPowerItem> GetSaleContractManPowerItemRules(SaleContractManPowerItemSearchRequest searchRequest); 

        IBaseEntityCollectionResponse<SaleContractManPowerItem> GetSaleContractManPowerItemBySearchWord(SaleContractManPowerItemSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SaleContractManPowerItem> GetSaleContractManPowerItemAllowancesBySearchWord(SaleContractManPowerItemSearchRequest searchRequest); 
    }
}
