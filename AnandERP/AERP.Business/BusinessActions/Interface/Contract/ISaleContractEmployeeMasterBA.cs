using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessAction
{
    public interface ISaleContractEmployeeMasterBA
    {
        /// <summary>
        /// business action interface of insert new record of SaleContractEmployeeMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<SaleContractEmployeeMaster> InsertSaleContractEmployeeMaster(SaleContractEmployeeMaster item);

        /// <summary>
        /// business action interface of update record of SaleContractEmployeeMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<SaleContractEmployeeMaster> UpdateSaleContractEmployeeMaster(SaleContractEmployeeMaster item);

        /// <summary>
        /// business action interface of dalete record of SaleContractEmployeeMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<SaleContractEmployeeMaster> DeleteSaleContractEmployeeMaster(SaleContractEmployeeMaster item);

        /// <summary>
        /// business action interface of select all record of SaleContractEmployeeMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<SaleContractEmployeeMaster> GetBySearch(SaleContractEmployeeMasterSearchRequest searchRequest);

        /// <summary>
        /// business action interface of select all record of SaleContractEmployeeMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<SaleContractEmployeeMaster> GetBySearchList(SaleContractEmployeeMasterSearchRequest searchRequest);

        /// <summary>
        /// business action interface of select one record of SaleContractEmployeeMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<SaleContractEmployeeMaster> SelectByID(SaleContractEmployeeMaster item);
        IBaseEntityCollectionResponse<SaleContractEmployeeMaster> GetSaleContractEmployeeMasterBySearchWord(SaleContractEmployeeMasterSearchRequest searchRequest);
        IBaseEntityResponse<SaleContractEmployeeMaster> InsertSaleContractEmployeeMasterExcelUpload(SaleContractEmployeeMaster item);

        IBaseEntityResponse<SaleContractEmployeeMaster> GetDataValidationListsForEmployeeMasterExcel(SaleContractEmployeeMaster item);
        IBaseEntityCollectionResponse<SaleContractEmployeeMaster> GetSaleContractEmployeeMasterBySearchWordForReports(SaleContractEmployeeMasterSearchRequest searchRequest);
    }
}
