using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessRules
{
    public interface IGeneralRequestMasterBR
    {
        IValidateBusinessRuleResponse InsertGeneralRequestMasterValidate(GeneralRequestMaster item);
        IValidateBusinessRuleResponse UpdateGeneralRequestMasterValidate(GeneralRequestMaster item);
        IValidateBusinessRuleResponse DeleteGeneralRequestMasterValidate(GeneralRequestMaster item);
    }
}
