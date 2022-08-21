using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessRules
{
    public interface ISaleContractManPowerItemBR
    {
        /// <summary>
        /// business rule interface of insert new record of SaleContractManPowerItem.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse InsertSaleContractManPowerItemValidate(SaleContractManPowerItem item);

        /// <summary>
        /// business rule interface of update record of SaleContractManPowerItem.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse UpdateSaleContractManPowerItemValidate(SaleContractManPowerItem item);

        /// <summary>
        /// business rule interface of dalete record of SaleContractManPowerItem.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse DeleteSaleContractManPowerItemValidate(SaleContractManPowerItem item);
    }
}

