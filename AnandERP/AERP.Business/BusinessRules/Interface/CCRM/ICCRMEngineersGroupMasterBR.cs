using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessRules
{
    public interface ICCRMEngineersGroupMasterBR
    {
        IValidateBusinessRuleResponse InsertCCRMEngineersGroupMasterValidate(CCRMEngineersGroupMaster item);
        IValidateBusinessRuleResponse UpdateCCRMEngineersGroupMasterValidate(CCRMEngineersGroupMaster item);
        IValidateBusinessRuleResponse DeleteCCRMEngineersGroupMasterValidate(CCRMEngineersGroupMaster item);
    }
}
