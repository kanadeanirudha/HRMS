using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessRules
{
    public interface IESICZoneMasterBR
    {
        IValidateBusinessRuleResponse InsertESICZoneMasterValidate(ESICZoneMaster item);
        IValidateBusinessRuleResponse UpdateESICZoneMasterValidate(ESICZoneMaster item);
        IValidateBusinessRuleResponse DeleteESICZoneMasterValidate(ESICZoneMaster item);
    }
}
