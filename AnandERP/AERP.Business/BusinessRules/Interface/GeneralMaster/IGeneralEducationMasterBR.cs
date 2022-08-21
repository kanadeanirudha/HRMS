using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessRules
{
    public interface IGeneralEducationMasterBR
    {
        IValidateBusinessRuleResponse InsertGeneralEducationMasterValidate(GeneralEducationMaster item);

        IValidateBusinessRuleResponse UpdateGeneralEducationMasterValidate(GeneralEducationMaster item);

        IValidateBusinessRuleResponse DeleteGeneralEducationMasterValidate(GeneralEducationMaster item);
    }
}
