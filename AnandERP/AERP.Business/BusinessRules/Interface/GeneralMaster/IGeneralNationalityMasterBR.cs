using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessRules
{
    public interface IGeneralNationalityMasterBR
    {
        IValidateBusinessRuleResponse InsertGeneralNationalityMasterValidate(GeneralNationalityMaster item);

        IValidateBusinessRuleResponse UpdateGeneralNationalityMasterValidate(GeneralNationalityMaster item);

        IValidateBusinessRuleResponse DeleteGeneralNationalityMasterValidate(GeneralNationalityMaster item);
    }
}
