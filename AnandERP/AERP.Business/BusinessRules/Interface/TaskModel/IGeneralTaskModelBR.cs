using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessRules
{
    public interface IGeneralTaskModelBR
    {
        IValidateBusinessRuleResponse InsertGeneralTaskModelValidate(GeneralTaskModel item);
        IValidateBusinessRuleResponse UpdateGeneralTaskModelValidate(GeneralTaskModel item);
        IValidateBusinessRuleResponse DeleteGeneralTaskModelValidate(GeneralTaskModel item);
    }
}
