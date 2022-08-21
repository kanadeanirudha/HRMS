using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessAction
{
    public interface ISaleContractEmployeeAdvancesBA
    {
        /// <summary>
        /// business action interface of insert new record of SaleContractEmployeeAdvances.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<SaleContractEmployeeAdvances> InsertSaleContractEmployeeAdvances(SaleContractEmployeeAdvances item);

        /// <summary>
        /// business action interface of update record of SaleContractEmployeeAdvances.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<SaleContractEmployeeAdvances> UpdateSaleContractEmployeeAdvances(SaleContractEmployeeAdvances item);

        /// <summary>
        /// business action interface of dalete record of SaleContractEmployeeAdvances.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<SaleContractEmployeeAdvances> DeleteSaleContractEmployeeAdvances(SaleContractEmployeeAdvances item);

        /// <summary>
        /// business action interface of select all record of SaleContractEmployeeAdvances.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<SaleContractEmployeeAdvances> GetBySearch(SaleContractEmployeeAdvancesSearchRequest searchRequest);

        /// <summary>
        /// business action interface of select all record of SaleContractEmployeeAdvances.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<SaleContractEmployeeAdvances> GetBySearchList(SaleContractEmployeeAdvancesSearchRequest searchRequest);

        /// <summary>
        /// business action interface of select one record of SaleContractEmployeeAdvances.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<SaleContractEmployeeAdvances> SelectByID(SaleContractEmployeeAdvances item);
        IBaseEntityCollectionResponse<SaleContractEmployeeAdvances> GetFixItemBySearchWord(SaleContractEmployeeAdvancesSearchRequest searchRequest);
    }
}
