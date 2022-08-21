using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessRules
{
    public interface ISaleContractJobWorkItemBR
    {
        /// <summary>
        /// business rule interface of insert new record of SaleContractJobWorkItem.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse InsertSaleContractJobWorkItemValidate(SaleContractJobWorkItem item);

        /// <summary>
        /// business rule interface of update record of SaleContractJobWorkItem.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse UpdateSaleContractJobWorkItemValidate(SaleContractJobWorkItem item);

        /// <summary>
        /// business rule interface of dalete record of SaleContractJobWorkItem.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse DeleteSaleContractJobWorkItemValidate(SaleContractJobWorkItem item);
    }
}

