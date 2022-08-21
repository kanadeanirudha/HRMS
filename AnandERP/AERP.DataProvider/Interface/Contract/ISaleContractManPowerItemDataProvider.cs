using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface ISaleContractManPowerItemDataProvider
    {

        /// <summary>
        /// data provider interface of select all record of SaleContractManPowerItem.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<SaleContractManPowerItem> GetSaleContractManPowerItemBySearch(SaleContractManPowerItemSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select all record of SaleContractManPowerItem.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<SaleContractManPowerItem> GetSaleContractManPowerItemGetBySearchList(SaleContractManPowerItemSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select one record of SaleContractManPowerItem.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<SaleContractManPowerItem> GetSaleContractManPowerItemByID(SaleContractManPowerItem item);

        /// <summary>
        /// data provider interface of insert new record of SaleContractManPowerItem.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<SaleContractManPowerItem> InsertSaleContractManPowerItem(SaleContractManPowerItem item);

        /// <summary>
        /// data provider interface of update record of SaleContractManPowerItem.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<SaleContractManPowerItem> UpdateSaleContractManPowerItem(SaleContractManPowerItem item);

        /// <summary>
        /// data provider interface of dalete record of SaleContractManPowerItem.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<SaleContractManPowerItem> DeleteSaleContractManPowerItem(SaleContractManPowerItem item);
        IBaseEntityResponse<SaleContractManPowerItem> InsertSaleContractManPowerItemRules(SaleContractManPowerItem item);
        IBaseEntityResponse<SaleContractManPowerItem> ViewSaleContractManPowerItemRules(SaleContractManPowerItem item);
        IBaseEntityResponse<SaleContractManPowerItem> DeleteSaleContractManPowerItemRules(SaleContractManPowerItem item);
        IBaseEntityResponse<SaleContractManPowerItem> UpdateSaleContractManPowerItemRules(SaleContractManPowerItem item);
        IBaseEntityCollectionResponse<SaleContractManPowerItem> GetSaleContractManPowerItemRules(SaleContractManPowerItemSearchRequest searchRequest);

        IBaseEntityCollectionResponse<SaleContractManPowerItem> GetSaleContractManPowerItemBySearchWord(SaleContractManPowerItemSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SaleContractManPowerItem> GetSaleContractManPowerItemAllowancesBySearchWord(SaleContractManPowerItemSearchRequest searchRequest);
    }
}
