using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AERP.Base.DTO;
using AERP.DTO;

namespace AERP.Business.BusinessRules
{
   public interface ICCRMBrokenCallReasonMasterBR
    {
        IValidateBusinessRuleResponse InsertCCRMBrokenCallReasonMasterValidate(CCRMBrokenCallReasonMaster item);
        IValidateBusinessRuleResponse UpdateCCRMBrokenCallReasonMasterValidate(CCRMBrokenCallReasonMaster item);
        IValidateBusinessRuleResponse DeleteCCRMBrokenCallReasonMasterValidate(CCRMBrokenCallReasonMaster item);
    }
}
