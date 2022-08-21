using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessAction
{
    public interface ISaleContractMachineTransactionBA
    {
        /// <summary>
        /// business action interface of insert new record of SaleContractMachineTransaction.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<SaleContractMachineTransaction> InsertSaleContractMachineTransaction(SaleContractMachineTransaction item);

        /// <summary>
        /// business action interface of update record of SaleContractMachineTransaction.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<SaleContractMachineTransaction> UpdateSaleContractMachineTransaction(SaleContractMachineTransaction item);

        /// <summary>
        /// business action interface of dalete record of SaleContractMachineTransaction.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<SaleContractMachineTransaction> DeleteSaleContractMachineTransaction(SaleContractMachineTransaction item);

        /// <summary>
        /// business action interface of select all record of SaleContractMachineTransaction.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<SaleContractMachineTransaction> GetBySearch(SaleContractMachineTransactionSearchRequest searchRequest);

        /// <summary>
        /// business action interface of select all record of SaleContractMachineTransaction.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<SaleContractMachineTransaction> GetBySearchList(SaleContractMachineTransactionSearchRequest searchRequest);

        /// <summary>
        /// business action interface of select one record of SaleContractMachineTransaction.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<SaleContractMachineTransaction> SelectByID(SaleContractMachineTransaction item);
        IBaseEntityCollectionResponse<SaleContractMachineTransaction> GetMachineMasterBySearchWord(SaleContractMachineTransactionSearchRequest searchRequest);


        IBaseEntityCollectionResponse<SaleContractMachineTransaction> GetListSaleContractMachineTransaction(SaleContractMachineTransactionSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SaleContractMachineTransaction> GetListSaleContractMachineAttendance(SaleContractMachineTransactionSearchRequest searchRequest);

        IBaseEntityResponse<SaleContractMachineTransaction> RemoveSaleContractMachineTransaction(SaleContractMachineTransaction item);
        IBaseEntityResponse<SaleContractMachineTransaction> AddMachineInSaleContract(SaleContractMachineTransaction item); 
    }
}
