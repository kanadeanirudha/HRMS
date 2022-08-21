using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessRules
{
    public interface ISaleContractMasterBR
    {
        /// <summary>
        /// business rule interface of insert new record of SaleContractMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse InsertSaleContractMasterValidate(SaleContractMaster item);

        /// <summary>
        /// business rule interface of update record of SaleContractMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse UpdateSaleContractMasterValidate(SaleContractMaster item);

        /// <summary>
        /// business rule interface of dalete record of SaleContractMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse DeleteSaleContractMasterValidate(SaleContractMaster item);
    }
}

