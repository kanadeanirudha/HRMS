using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessRules
{
   public interface ICCRMSymptomMasterBR
    {
        IValidateBusinessRuleResponse InsertCCRMSymptomMasterValidate(CCRMSymptomMaster item);
        IValidateBusinessRuleResponse UpdateCCRMSymptomTypeValidate(CCRMSymptomMaster item);
        IValidateBusinessRuleResponse DeleteCCRMSymptomMasterValidate(CCRMSymptomMaster item);
    }
}
