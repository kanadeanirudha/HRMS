using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AERP.Base.DTO;
using AERP.DTO;

namespace AERP.Business.BusinessRules
{
   public interface ICCRMBillTypeMasterBR
    {
        IValidateBusinessRuleResponse InsertCCRMBillTypeMasterValidate(CCRMBillTypeMaster item);
        IValidateBusinessRuleResponse UpdateCCRMBillTypeMasterValidate(CCRMBillTypeMaster item);
        IValidateBusinessRuleResponse DeleteCCRMBillTypeMasterValidate(CCRMBillTypeMaster item);
    }
}
