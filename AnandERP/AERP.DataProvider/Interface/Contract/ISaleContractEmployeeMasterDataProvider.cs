using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface ISaleContractEmployeeMasterDataProvider
    {

        /// <summary>
        /// data provider interface of select all record of SaleContractEmployeeMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<SaleContractEmployeeMaster> GetSaleContractEmployeeMasterBySearch(SaleContractEmployeeMasterSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select all record of SaleContractEmployeeMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<SaleContractEmployeeMaster> GetSaleContractEmployeeMasterGetBySearchList(SaleContractEmployeeMasterSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select one record of SaleContractEmployeeMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<SaleContractEmployeeMaster> GetSaleContractEmployeeMasterByID(SaleContractEmployeeMaster item);

        /// <summary>
        /// data provider interface of insert new record of SaleContractEmployeeMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<SaleContractEmployeeMaster> InsertSaleContractEmployeeMaster(SaleContractEmployeeMaster item);

        /// <summary>
        /// data provider interface of update record of SaleContractEmployeeMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<SaleContractEmployeeMaster> UpdateSaleContractEmployeeMaster(SaleContractEmployeeMaster item);

        /// <summary>
        /// data provider interface of dalete record of SaleContractEmployeeMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<SaleContractEmployeeMaster> DeleteSaleContractEmployeeMaster(SaleContractEmployeeMaster item);
        IBaseEntityCollectionResponse<SaleContractEmployeeMaster> GetSaleContractEmployeeMasterBySearchWord(SaleContractEmployeeMasterSearchRequest searchRequest);

        IBaseEntityResponse<SaleContractEmployeeMaster> InsertSaleContractEmployeeMasterExcelUpload(SaleContractEmployeeMaster item);
        IBaseEntityResponse<SaleContractEmployeeMaster> GetDataValidationListsForEmployeeMasterExcel(SaleContractEmployeeMaster item);
        IBaseEntityCollectionResponse<SaleContractEmployeeMaster> GetSaleContractEmployeeMasterBySearchWordForReports(SaleContractEmployeeMasterSearchRequest searchRequest);
    }
}
