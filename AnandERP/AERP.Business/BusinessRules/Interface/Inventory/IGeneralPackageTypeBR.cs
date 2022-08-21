using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessRules
{
    public interface IGeneralPackageTypeBR
    {
        IValidateBusinessRuleResponse InsertGeneralPackageTypeValidate(GeneralPackageType item);
        IValidateBusinessRuleResponse UpdateGeneralPackageTypeValidate(GeneralPackageType item);
        IValidateBusinessRuleResponse DeleteGeneralPackageTypeValidate(GeneralPackageType item);
    }
}
