using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AERP.Base.DTO;
using AERP.DTO;

namespace AERP.Business.BusinessRules
{
   public interface ICCRMBankMasterBR
    {
        IValidateBusinessRuleResponse InsertCCRMBankMasterValidate(CCRMBankMaster item);
        IValidateBusinessRuleResponse UpdateCCRMBankMasterValidate(CCRMBankMaster item);
        IValidateBusinessRuleResponse DeleteCCRMBankMasterValidate(CCRMBankMaster item);
    }
}
