using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessRules
{
  public  interface ICCRMMIFMasterAndDetailsBR
    {
        IValidateBusinessRuleResponse InsertCCRMMIFMasterAndDetailsValidate(CCRMMIFMasterAndDetails item);
        //IValidateBusinessRuleResponse InsertCCRMMIFMasterAndDetailsContactDetailsValidate(CCRMMIFMasterAndDetails item);
        //IValidateBusinessRuleResponse InsertCCRMMIFMasterAndDetailsBranchDetailsValidate(CCRMMIFMasterAndDetails item);
        IValidateBusinessRuleResponse UpdateCCRMMIFMasterAndDetailsValidate(CCRMMIFMasterAndDetails item);
        IValidateBusinessRuleResponse DeleteCCRMMIFMasterAndDetailsValidate(CCRMMIFMasterAndDetails item);
    }
}
