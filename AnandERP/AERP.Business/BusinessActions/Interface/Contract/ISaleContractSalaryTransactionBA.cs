using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessAction
{
    public interface ISaleContractSalaryTransactionBA
    {
        IBaseEntityCollectionResponse<SaleContractSalaryTransaction> GetSaleContractSalaryTransactionBySearch(SaleContractSalaryTransactionSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SaleContractSalaryTransaction> GetSalaryTransactionForGeneration(SaleContractSalaryTransactionSearchRequest searchRequest);
        IBaseEntityResponse<SaleContractSalaryTransaction> GenerateSaleContractSalaryTransaction(SaleContractSalaryTransaction item);
        IBaseEntityCollectionResponse<SaleContractSalaryTransaction> GetSalaryTransactionDetailsByID(SaleContractSalaryTransactionSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SaleContractSalaryTransaction> GetSalaryTransactionForBulkGeneration(SaleContractSalaryTransactionSearchRequest searchRequest);
        IBaseEntityResponse<SaleContractSalaryTransaction> GenerateSaleContractBulkSalaryTransaction(SaleContractSalaryTransaction item);
        IBaseEntityCollectionResponse<SaleContractSalaryTransaction> GetSalaryTransactionDetailsForSalarySheet(SaleContractSalaryTransactionSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SaleContractSalaryTransaction> GetListSaleContractSalaryTransactionDeduction(SaleContractSalaryTransactionSearchRequest searchRequest);
        IBaseEntityResponse<SaleContractSalaryTransaction> AddSaleContractSalaryTransactionDeduction(SaleContractSalaryTransaction item);
        IBaseEntityCollectionResponse<SaleContractSalaryTransaction> GetSalaryTransactionDetailsForNRSheet(SaleContractSalaryTransactionSearchRequest searchRequest);

        IBaseEntityResponse<SaleContractSalaryTransaction> SaveSaleContractSalaryTransaction(SaleContractSalaryTransaction item);
        IBaseEntityResponse<SaleContractSalaryTransaction> SaveSaleContractBulkSalaryTransaction(SaleContractSalaryTransaction item);
        IBaseEntityCollectionResponse<SaleContractSalaryTransaction> GetSalaryTransactionDetailsForAllEmployeeinExcel(SaleContractSalaryTransactionSearchRequest searchRequest);

    }
}
