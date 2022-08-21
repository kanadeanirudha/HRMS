using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessRules
{
  public  interface ICCRMCauseMasterBR
    {
        IValidateBusinessRuleResponse InsertCCRMCauseMasterValidate(CCRMCauseMaster item);
        IValidateBusinessRuleResponse UpdateCCRMCauseTypeValidate(CCRMCauseMaster item);
        IValidateBusinessRuleResponse DeleteCCRMCauseMasterValidate(CCRMCauseMaster item);
    }
}
