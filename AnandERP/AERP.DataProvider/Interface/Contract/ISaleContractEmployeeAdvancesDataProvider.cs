using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface ISaleContractEmployeeAdvancesDataProvider
    {

        /// <summary>
        /// data provider interface of select all record of SaleContractEmployeeAdvances.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<SaleContractEmployeeAdvances> GetSaleContractEmployeeAdvancesBySearch(SaleContractEmployeeAdvancesSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select all record of SaleContractEmployeeAdvances.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<SaleContractEmployeeAdvances> GetSaleContractEmployeeAdvancesGetBySearchList(SaleContractEmployeeAdvancesSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select one record of SaleContractEmployeeAdvances.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<SaleContractEmployeeAdvances> GetSaleContractEmployeeAdvancesByID(SaleContractEmployeeAdvances item);

        /// <summary>
        /// data provider interface of insert new record of SaleContractEmployeeAdvances.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<SaleContractEmployeeAdvances> InsertSaleContractEmployeeAdvances(SaleContractEmployeeAdvances item);

        /// <summary>
        /// data provider interface of update record of SaleContractEmployeeAdvances.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<SaleContractEmployeeAdvances> UpdateSaleContractEmployeeAdvances(SaleContractEmployeeAdvances item);

        /// <summary>
        /// data provider interface of dalete record of SaleContractEmployeeAdvances.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<SaleContractEmployeeAdvances> DeleteSaleContractEmployeeAdvances(SaleContractEmployeeAdvances item);
        IBaseEntityCollectionResponse<SaleContractEmployeeAdvances> GetFixItemBySearchWord(SaleContractEmployeeAdvancesSearchRequest searchRequest);
    }
}
