using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AERP.Base.DTO;
using AERP.DTO;

namespace AERP.Business.BusinessRules
{
   public interface ICCRMServiceMasterBR
    {
        IValidateBusinessRuleResponse InsertCCRMServiceMasterValidate(CCRMServiceMaster item);
        IValidateBusinessRuleResponse UpdateCCRMServiceMasterValidate(CCRMServiceMaster item);
        IValidateBusinessRuleResponse DeleteCCRMServiceMasterValidate(CCRMServiceMaster item);
    }
}
