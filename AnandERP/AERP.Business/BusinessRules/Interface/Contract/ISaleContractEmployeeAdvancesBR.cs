using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessRules
{
    public interface ISaleContractEmployeeAdvancesBR
    {
        /// <summary>
        /// business rule interface of insert new record of SaleContractEmployeeAdvances.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse InsertSaleContractEmployeeAdvancesValidate(SaleContractEmployeeAdvances item);

        /// <summary>
        /// business rule interface of update record of SaleContractEmployeeAdvances.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse UpdateSaleContractEmployeeAdvancesValidate(SaleContractEmployeeAdvances item);

        /// <summary>
        /// business rule interface of dalete record of SaleContractEmployeeAdvances.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse DeleteSaleContractEmployeeAdvancesValidate(SaleContractEmployeeAdvances item);
    }
}

