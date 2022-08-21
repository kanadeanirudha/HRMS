using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AERP.Base.DTO;
using AERP.DTO;

namespace AERP.Business.BusinessRules
{
  public  interface ICCRMAreaPatchMasterBR
    {
        IValidateBusinessRuleResponse InsertCCRMAreaPatchMasterValidate(CCRMAreaPatchMaster item);
        IValidateBusinessRuleResponse UpdateCCRMAreaPatchMasterValidate(CCRMAreaPatchMaster item);
        IValidateBusinessRuleResponse DeleteCCRMAreaPatchMasterValidate(CCRMAreaPatchMaster item);
    }
}
