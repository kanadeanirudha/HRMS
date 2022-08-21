using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessRules
{
    public interface IPFChallanRemittanceBR
    {
        /// <summary>
        /// business rule interface of insert new record of PFChallanRemittance.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse InsertPFChallanRemittanceValidate(PFChallanRemittance item);

        /// <summary>
        /// business rule interface of update record of PFChallanRemittance.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse UpdatePFChallanRemittanceValidate(PFChallanRemittance item);

        /// <summary>
        /// business rule interface of dalete record of PFChallanRemittance.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse DeletePFChallanRemittanceValidate(PFChallanRemittance item);
    }
}

