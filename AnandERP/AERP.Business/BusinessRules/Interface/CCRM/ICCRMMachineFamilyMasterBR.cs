using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AERP.Base.DTO;
using AERP.DTO;

namespace AERP.Business.BusinessRules
{
  public  interface ICCRMMachineFamilyMasterBR
    {
        IValidateBusinessRuleResponse InsertCCRMMachineFamilyMasterValidate(CCRMMachineFamilyMaster item);
        IValidateBusinessRuleResponse UpdateCCRMMachineFamilyMasterValidate(CCRMMachineFamilyMaster item);
        IValidateBusinessRuleResponse DeleteCCRMMachineFamilyMasterValidate(CCRMMachineFamilyMaster item);
    }
}
    