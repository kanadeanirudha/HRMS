using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessAction
{
    public interface IEmployeeSalaryTransactionBA
    {
        IBaseEntityCollectionResponse<EmployeeSalaryTransaction> GetEmployeeSalaryTransactionBySearch(EmployeeSalaryTransactionSearchRequest searchRequest);
        IBaseEntityCollectionResponse<EmployeeSalaryTransaction> GetSalaryTransactionForGeneration(EmployeeSalaryTransactionSearchRequest searchRequest);
        IBaseEntityResponse<EmployeeSalaryTransaction> GenerateEmployeeSalaryTransaction(EmployeeSalaryTransaction item);
        IBaseEntityCollectionResponse<EmployeeSalaryTransaction> GetSalaryTransactionDetailsByID(EmployeeSalaryTransactionSearchRequest searchRequest);
        IBaseEntityCollectionResponse<EmployeeSalaryTransaction> GetSalaryTransactionForBulkGeneration(EmployeeSalaryTransactionSearchRequest searchRequest);
        IBaseEntityResponse<EmployeeSalaryTransaction> GenerateSaleContractBulkSalaryTransaction(EmployeeSalaryTransaction item);
        IBaseEntityCollectionResponse<EmployeeSalaryTransaction> GetSalaryTransactionDetailsForSalarySheet(EmployeeSalaryTransactionSearchRequest searchRequest);
        IBaseEntityCollectionResponse<EmployeeSalaryTransaction> GetListEmployeeSalaryTransactionDeduction(EmployeeSalaryTransactionSearchRequest searchRequest);
        IBaseEntityResponse<EmployeeSalaryTransaction> AddEmployeeSalaryTransactionDeduction(EmployeeSalaryTransaction item);
        IBaseEntityCollectionResponse<EmployeeSalaryTransaction> GetSalaryTransactionDetailsForNRSheet(EmployeeSalaryTransactionSearchRequest searchRequest);
        IBaseEntityCollectionResponse<EmployeeSalaryTransaction> GetEmployeeSalaryDetailsForExcel(EmployeeSalaryTransactionSearchRequest searchRequest);
        IBaseEntityResponse<EmployeeSalaryTransaction> AddSaleContractSalaryTransactionDeduction(EmployeeSalaryTransaction item);
        IBaseEntityResponse<EmployeeSalaryTransaction> DeleteEmployeeSalary(EmployeeSalaryTransaction item);

    }
}
