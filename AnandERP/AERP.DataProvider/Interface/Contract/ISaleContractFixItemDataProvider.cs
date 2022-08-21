using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface ISaleContractFixItemDataProvider
    {

        /// <summary>
        /// data provider interface of select all record of SaleContractFixItem.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<SaleContractFixItem> GetSaleContractFixItemBySearch(SaleContractFixItemSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select all record of SaleContractFixItem.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<SaleContractFixItem> GetSaleContractFixItemGetBySearchList(SaleContractFixItemSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select one record of SaleContractFixItem.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<SaleContractFixItem> GetSaleContractFixItemByID(SaleContractFixItem item);

        /// <summary>
        /// data provider interface of insert new record of SaleContractFixItem.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<SaleContractFixItem> InsertSaleContractFixItem(SaleContractFixItem item);

        /// <summary>
        /// data provider interface of update record of SaleContractFixItem.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<SaleContractFixItem> UpdateSaleContractFixItem(SaleContractFixItem item);

        /// <summary>
        /// data provider interface of dalete record of SaleContractFixItem.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<SaleContractFixItem> DeleteSaleContractFixItem(SaleContractFixItem item);
        IBaseEntityCollectionResponse<SaleContractFixItem> GetFixItemBySearchWord(SaleContractFixItemSearchRequest searchRequest);
    }
}
