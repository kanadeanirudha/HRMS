using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Business.BusinessRules
{
    public interface IGeneralMainTypeMasterBR
    {
        /// business rule interface of insert new record of GeneralMainTypeMaster.
        IValidateBusinessRuleResponse InsertGeneralMainTypeMasterValidate(GeneralMainTypeMaster item);

        /// business rule interface of update record of GeneralCountryMaster.
        IValidateBusinessRuleResponse UpdateGeneralMainTypeMasterValidate(GeneralMainTypeMaster item);

        /// business rule interface of dalete record of GeneralMainTypeMaster.
        IValidateBusinessRuleResponse DeleteGeneralMainTypeMasterValidate(GeneralMainTypeMaster item);
    }
}
