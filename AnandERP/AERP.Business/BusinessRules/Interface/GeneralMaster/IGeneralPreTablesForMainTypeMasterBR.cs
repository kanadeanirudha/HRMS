using AMS.Base.DTO;
using AMS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AMS.Business.BusinessRules
{
    public interface IGeneralPreTablesForMainTypeMasterBR
    {
        IValidateBusinessRuleResponse InsertGeneralPreTablesForMainTypeMasterValidate(GeneralPreTablesForMainTypeMaster item);
        IValidateBusinessRuleResponse UpdateGeneralPreTablesForMainTypeMasterValidate(GeneralPreTablesForMainTypeMaster item);
        IValidateBusinessRuleResponse DeleteGeneralPreTablesForMainTypeMasterValidate(GeneralPreTablesForMainTypeMaster item);
    }
}
