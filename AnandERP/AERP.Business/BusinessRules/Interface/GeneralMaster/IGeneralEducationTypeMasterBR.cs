using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessRules
{
    public interface IGeneralEducationTypeMasterBR
    {
        IValidateBusinessRuleResponse InsertGeneralEducationTypeMasterValidate(GeneralEducationTypeMaster item);

        IValidateBusinessRuleResponse UpdateGeneralEducationTypeMasterValidate(GeneralEducationTypeMaster item);

        IValidateBusinessRuleResponse DeleteGeneralEducationTypeMasterValidate(GeneralEducationTypeMaster item);
    }
}
