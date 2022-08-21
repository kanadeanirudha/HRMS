using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AERP.Base.DTO;
using AERP.DTO;


namespace AERP.Business.BusinessRules
{
   public interface ICCRMLocationTypeMasterBR
    {
        IValidateBusinessRuleResponse InsertCCRMLocationTypeMasterValidate(CCRMLocationTypeMaster item);
        IValidateBusinessRuleResponse UpdateCCRMLocationTypeMasterValidate(CCRMLocationTypeMaster item);
        IValidateBusinessRuleResponse DeleteCCRMLocationTypeMasterValidate(CCRMLocationTypeMaster item);
    }
}
