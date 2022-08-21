using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AERP.Base.DTO;
using AERP.DTO;
namespace AERP.Business.BusinessRules
{
   public interface ICCRMCustomerSegementBR
    {
        /// <summary>
        /// business rule interface of insert new record of General City Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse InsertCCRMCustomerSegementValidate(CCRMCustomerSegement item);

        /// <summary>
        /// business rule interface of update record of General City Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse UpdateCCRMCustomerSegementValidate(CCRMCustomerSegement item);

        /// <summary>
        /// business rule interface of dalete record of General City Master.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse DeleteCCRMCustomerSegementValidate(CCRMCustomerSegement item);
    }
}
