using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessAction
{
    public interface ISaleContractMachineMasterBA
    {
        /// <summary>
        /// business action interface of insert new record of SaleContractMachineMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<SaleContractMachineMaster> InsertSaleContractMachineMaster(SaleContractMachineMaster item);

        /// <summary>
        /// business action interface of update record of SaleContractMachineMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<SaleContractMachineMaster> UpdateSaleContractMachineMaster(SaleContractMachineMaster item);

        /// <summary>
        /// business action interface of dalete record of SaleContractMachineMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<SaleContractMachineMaster> DeleteSaleContractMachineMaster(SaleContractMachineMaster item);

        /// <summary>
        /// business action interface of select all record of SaleContractMachineMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<SaleContractMachineMaster> GetBySearch(SaleContractMachineMasterSearchRequest searchRequest);

        /// <summary>
        /// business action interface of select all record of SaleContractMachineMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<SaleContractMachineMaster> GetBySearchList(SaleContractMachineMasterSearchRequest searchRequest);

        /// <summary>
        /// business action interface of select one record of SaleContractMachineMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<SaleContractMachineMaster> SelectByID(SaleContractMachineMaster item);
        IBaseEntityCollectionResponse<SaleContractMachineMaster> GetMachineMasterBySearchWord(SaleContractMachineMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SaleContractMachineMaster> GetMachineMasterBySearchWordAll(SaleContractMachineMasterSearchRequest searchRequest);
    }
}
