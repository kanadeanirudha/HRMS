using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface ISaleContractMachineMasterDataProvider
    {

        /// <summary>
        /// data provider interface of select all record of SaleContractMachineMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<SaleContractMachineMaster> GetSaleContractMachineMasterBySearch(SaleContractMachineMasterSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select all record of SaleContractMachineMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<SaleContractMachineMaster> GetSaleContractMachineMasterGetBySearchList(SaleContractMachineMasterSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select one record of SaleContractMachineMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<SaleContractMachineMaster> GetSaleContractMachineMasterByID(SaleContractMachineMaster item);

        /// <summary>
        /// data provider interface of insert new record of SaleContractMachineMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<SaleContractMachineMaster> InsertSaleContractMachineMaster(SaleContractMachineMaster item);

        /// <summary>
        /// data provider interface of update record of SaleContractMachineMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<SaleContractMachineMaster> UpdateSaleContractMachineMaster(SaleContractMachineMaster item);

        /// <summary>
        /// data provider interface of dalete record of SaleContractMachineMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<SaleContractMachineMaster> DeleteSaleContractMachineMaster(SaleContractMachineMaster item);
        IBaseEntityCollectionResponse<SaleContractMachineMaster> GetMachineMasterBySearchWord(SaleContractMachineMasterSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SaleContractMachineMaster> GetMachineMasterBySearchWordAll(SaleContractMachineMasterSearchRequest searchRequest);
    }
}
