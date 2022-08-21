using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface ISaleContractJobWorkItemDataProvider
    {

        /// <summary>
        /// data provider interface of select all record of SaleContractJobWorkItem.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<SaleContractJobWorkItem> GetSaleContractJobWorkItemBySearch(SaleContractJobWorkItemSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select all record of SaleContractJobWorkItem.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<SaleContractJobWorkItem> GetSaleContractJobWorkItemGetBySearchList(SaleContractJobWorkItemSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select one record of SaleContractJobWorkItem.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<SaleContractJobWorkItem> GetSaleContractJobWorkItemByID(SaleContractJobWorkItem item);

        /// <summary>
        /// data provider interface of insert new record of SaleContractJobWorkItem.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<SaleContractJobWorkItem> InsertSaleContractJobWorkItem(SaleContractJobWorkItem item);

        /// <summary>
        /// data provider interface of update record of SaleContractJobWorkItem.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<SaleContractJobWorkItem> UpdateSaleContractJobWorkItem(SaleContractJobWorkItem item);

        /// <summary>
        /// data provider interface of dalete record of SaleContractJobWorkItem.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<SaleContractJobWorkItem> DeleteSaleContractJobWorkItem(SaleContractJobWorkItem item);
        IBaseEntityCollectionResponse<SaleContractJobWorkItem> GetJobWorkItemBySearchWord(SaleContractJobWorkItemSearchRequest searchRequest);
    }
}
