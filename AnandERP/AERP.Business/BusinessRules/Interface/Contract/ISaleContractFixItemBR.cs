using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessRules
{
    public interface ISaleContractFixItemBR
    {
        /// <summary>
        /// business rule interface of insert new record of SaleContractFixItem.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse InsertSaleContractFixItemValidate(SaleContractFixItem item);

        /// <summary>
        /// business rule interface of update record of SaleContractFixItem.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse UpdateSaleContractFixItemValidate(SaleContractFixItem item);

        /// <summary>
        /// business rule interface of dalete record of SaleContractFixItem.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse DeleteSaleContractFixItemValidate(SaleContractFixItem item);
    }
}

