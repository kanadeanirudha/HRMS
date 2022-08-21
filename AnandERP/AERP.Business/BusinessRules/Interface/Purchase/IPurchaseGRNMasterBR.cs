using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessRules
{
    public interface IPurchaseGRNMasterBR
    {
        /// <summary>
        /// business rule interface of insert new record of PurchaseGRNMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse InsertPurchaseGRNMasterValidate(PurchaseGRNMaster item);

        /// <summary>
        /// business rule interface of update record of PurchaseGRNMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse UpdatePurchaseGRNMasterValidate(PurchaseGRNMaster item);

        /// <summary>
        /// business rule interface of dalete record of PurchaseGRNMaster.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse DeletePurchaseGRNMasterValidate(PurchaseGRNMaster item);
    }
}

