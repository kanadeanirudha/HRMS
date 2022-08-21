using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AERP.Base.DTO;
using AERP.DTO;

namespace AERP.Business.BusinessRules
{
   public interface ICCRMComplaintLoggingMasterBR
    {
        IValidateBusinessRuleResponse InsertCCRMComplaintLoggingMasterValidate(CCRMComplaintLoggingMaster item);
        IValidateBusinessRuleResponse UpdateCCRMComplaintLoggingMasterValidate(CCRMComplaintLoggingMaster item);
        IValidateBusinessRuleResponse DeleteCCRMComplaintLoggingMasterValidate(CCRMComplaintLoggingMaster item);
    }
}
