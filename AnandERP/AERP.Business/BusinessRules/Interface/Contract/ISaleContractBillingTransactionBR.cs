using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessRules
{
    public interface ISaleContractBillingTransactionBR
    {
        /// <summary>
        /// business rule interface of insert new record of SaleContractBillingTransaction.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse InsertSaleContractBillingTransactionValidate(SaleContractBillingTransaction item);

        /// <summary>
        /// business rule interface of update record of SaleContractBillingTransaction.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse UpdateSaleContractBillingTransactionValidate(SaleContractBillingTransaction item);

        /// <summary>
        /// business rule interface of dalete record of SaleContractBillingTransaction.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse DeleteSaleContractBillingTransactionValidate(SaleContractBillingTransaction item);
    }
}

