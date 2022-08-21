using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessAction
{
    public interface ISaleContractFixItemBA
    {
        /// <summary>
        /// business action interface of insert new record of SaleContractFixItem.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<SaleContractFixItem> InsertSaleContractFixItem(SaleContractFixItem item);

        /// <summary>
        /// business action interface of update record of SaleContractFixItem.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<SaleContractFixItem> UpdateSaleContractFixItem(SaleContractFixItem item);

        /// <summary>
        /// business action interface of dalete record of SaleContractFixItem.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<SaleContractFixItem> DeleteSaleContractFixItem(SaleContractFixItem item);

        /// <summary>
        /// business action interface of select all record of SaleContractFixItem.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<SaleContractFixItem> GetBySearch(SaleContractFixItemSearchRequest searchRequest);

        /// <summary>
        /// business action interface of select all record of SaleContractFixItem.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<SaleContractFixItem> GetBySearchList(SaleContractFixItemSearchRequest searchRequest);

        /// <summary>
        /// business action interface of select one record of SaleContractFixItem.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<SaleContractFixItem> SelectByID(SaleContractFixItem item);
        IBaseEntityCollectionResponse<SaleContractFixItem> GetFixItemBySearchWord(SaleContractFixItemSearchRequest searchRequest);
    }
}
