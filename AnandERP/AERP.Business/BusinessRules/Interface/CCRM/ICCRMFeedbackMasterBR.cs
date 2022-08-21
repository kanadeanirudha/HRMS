using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AERP.Base.DTO;
using AERP.DTO;

namespace AERP.Business.BusinessRules
{
  public  interface ICCRMFeedbackMasterBR
    {
        IValidateBusinessRuleResponse InsertCCRMFeedbackMasterValidate(CCRMFeedbackMaster item);
        IValidateBusinessRuleResponse UpdateCCRMFeedbackMasterValidate(CCRMFeedbackMaster item);
        IValidateBusinessRuleResponse DeleteCCRMFeedbackMasterValidate(CCRMFeedbackMaster item);
    }
}
