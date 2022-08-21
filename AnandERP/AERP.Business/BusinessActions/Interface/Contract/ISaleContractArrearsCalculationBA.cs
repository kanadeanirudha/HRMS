using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessAction
{
    public interface ISaleContractArrearsCalculationBA
    {
        IBaseEntityCollectionResponse<SaleContractArrearsCalculation> GetSaleContractArrearsCalculationBySearch(SaleContractArrearsCalculationSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SaleContractArrearsCalculation> GetSalaryTransactionForGeneration(SaleContractArrearsCalculationSearchRequest searchRequest);
        IBaseEntityResponse<SaleContractArrearsCalculation> GenerateSaleContractArrearsCalculation(SaleContractArrearsCalculation item);
        IBaseEntityCollectionResponse<SaleContractArrearsCalculation> GetSalaryTransactionDetailsByID(SaleContractArrearsCalculationSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SaleContractArrearsCalculation> GetSalaryTransactionForBulkGeneration(SaleContractArrearsCalculationSearchRequest searchRequest);
        IBaseEntityResponse<SaleContractArrearsCalculation> GenerateSaleContractBulkSalaryTransaction(SaleContractArrearsCalculation item);
        IBaseEntityCollectionResponse<SaleContractArrearsCalculation> GetSalaryTransactionDetailsForSalarySheet(SaleContractArrearsCalculationSearchRequest searchRequest);
        IBaseEntityCollectionResponse<SaleContractArrearsCalculation> GetListSaleContractArrearsCalculationDeduction(SaleContractArrearsCalculationSearchRequest searchRequest);
        IBaseEntityResponse<SaleContractArrearsCalculation> AddSaleContractArrearsCalculationDeduction(SaleContractArrearsCalculation item);
        IBaseEntityCollectionResponse<SaleContractArrearsCalculation> GetSalaryTransactionDetailsForNRSheet(SaleContractArrearsCalculationSearchRequest searchRequest);

        IBaseEntityResponse<SaleContractArrearsCalculation> AddSaleContractArrearsAttendance(SaleContractArrearsCalculation item);

        IBaseEntityCollectionResponse<SaleContractArrearsCalculation> GetSaleContractArrearsAttendanceSpanWise(SaleContractArrearsCalculationSearchRequest searchRequest);

        IBaseEntityCollectionResponse<SaleContractArrearsCalculation> GetAttendanceListForSpanWise(SaleContractArrearsCalculationSearchRequest searchRequest); 
    }
}
