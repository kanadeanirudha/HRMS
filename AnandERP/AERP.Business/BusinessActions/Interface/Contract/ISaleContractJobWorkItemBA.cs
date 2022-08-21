using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessAction
{
    public interface ISaleContractJobWorkItemBA
    {
        /// <summary>
        /// business action interface of insert new record of SaleContractJobWorkItem.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<SaleContractJobWorkItem> InsertSaleContractJobWorkItem(SaleContractJobWorkItem item);

        /// <summary>
        /// business action interface of update record of SaleContractJobWorkItem.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<SaleContractJobWorkItem> UpdateSaleContractJobWorkItem(SaleContractJobWorkItem item);

        /// <summary>
        /// business action interface of dalete record of SaleContractJobWorkItem.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<SaleContractJobWorkItem> DeleteSaleContractJobWorkItem(SaleContractJobWorkItem item);

        /// <summary>
        /// business action interface of select all record of SaleContractJobWorkItem.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<SaleContractJobWorkItem> GetBySearch(SaleContractJobWorkItemSearchRequest searchRequest);

        /// <summary>
        /// business action interface of select all record of SaleContractJobWorkItem.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<SaleContractJobWorkItem> GetBySearchList(SaleContractJobWorkItemSearchRequest searchRequest);

        /// <summary>
        /// business action interface of select one record of SaleContractJobWorkItem.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<SaleContractJobWorkItem> SelectByID(SaleContractJobWorkItem item);
        IBaseEntityCollectionResponse<SaleContractJobWorkItem> GetJobWorkItemBySearchWord(SaleContractJobWorkItemSearchRequest searchRequest);
    }
}
