using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessRules
{
    public interface ISaleContractSalaryTransactionBR
    {
        /// <summary>
        /// business rule interface of insert new record of SaleContractSalaryTransaction.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse InsertSaleContractSalaryTransactionValidate(SaleContractSalaryTransaction item);

        /// <summary>
        /// business rule interface of update record of SaleContractSalaryTransaction.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse UpdateSaleContractSalaryTransactionValidate(SaleContractSalaryTransaction item);

        /// <summary>
        /// business rule interface of dalete record of SaleContractSalaryTransaction.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse DeleteSaleContractSalaryTransactionValidate(SaleContractSalaryTransaction item);
    }
}

