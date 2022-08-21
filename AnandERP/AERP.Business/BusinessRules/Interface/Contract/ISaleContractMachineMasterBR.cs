using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessRules
{
    public interface ISaleContractMachineMasterBR
    {
        /// <summary>
        /// business rule interface of insert new record of SaleContractMachineMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse InsertSaleContractMachineMasterValidate(SaleContractMachineMaster item);

        /// <summary>
        /// business rule interface of update record of SaleContractMachineMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse UpdateSaleContractMachineMasterValidate(SaleContractMachineMaster item);

        /// <summary>
        /// business rule interface of dalete record of SaleContractMachineMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse DeleteSaleContractMachineMasterValidate(SaleContractMachineMaster item);
    }
}

