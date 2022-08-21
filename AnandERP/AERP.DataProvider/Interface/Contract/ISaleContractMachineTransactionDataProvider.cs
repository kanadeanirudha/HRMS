using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface ISaleContractMachineTransactionDataProvider
    {

        /// <summary>
        /// data provider interface of select all record of SaleContractMachineTransaction.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<SaleContractMachineTransaction> GetSaleContractMachineTransactionBySearch(SaleContractMachineTransactionSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select all record of SaleContractMachineTransaction.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<SaleContractMachineTransaction> GetSaleContractMachineTransactionGetBySearchList(SaleContractMachineTransactionSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select one record of SaleContractMachineTransaction.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<SaleContractMachineTransaction> GetSaleContractMachineTransactionByID(SaleContractMachineTransaction item);

        /// <summary>
        /// data provider interface of insert new record of SaleContractMachineTransaction.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<SaleContractMachineTransaction> InsertSaleContractMachineTransaction(SaleContractMachineTransaction item);

        /// <summary>
        /// data provider interface of update record of SaleContractMachineTransaction.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<SaleContractMachineTransaction> UpdateSaleContractMachineTransaction(SaleContractMachineTransaction item);

        /// <summary>
        /// data provider interface of dalete record of SaleContractMachineTransaction.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<SaleContractMachineTransaction> DeleteSaleContractMachineTransaction(SaleContractMachineTransaction item);
        IBaseEntityCollectionResponse<SaleContractMachineTransaction> GetMachineMasterBySearchWord(SaleContractMachineTransactionSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SaleContractMachineTransaction> GetListSaleContractMachineTransaction(SaleContractMachineTransactionSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SaleContractMachineTransaction> GetListSaleContractMachineAttendance(SaleContractMachineTransactionSearchRequest searchRequest);

        IBaseEntityResponse<SaleContractMachineTransaction> RemoveSaleContractMachineTransaction(SaleContractMachineTransaction item);
        IBaseEntityResponse<SaleContractMachineTransaction> AddMachineInSaleContract(SaleContractMachineTransaction item);
    }
}
