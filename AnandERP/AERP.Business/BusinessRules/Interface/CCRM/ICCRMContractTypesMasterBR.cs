using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessRules
{
   public interface ICCRMContractTypesMasterBR
    {
        IValidateBusinessRuleResponse InsertCCRMContractTypesMasterValidate(CCRMContractTypesMaster item);
        IValidateBusinessRuleResponse UpdateCCRMContractTypesMasterValidate(CCRMContractTypesMaster item);
        IValidateBusinessRuleResponse DeleteCCRMContractTypesMasterValidate(CCRMContractTypesMaster item);
    }
}
