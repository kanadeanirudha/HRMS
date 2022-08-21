using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessRules
{
    public interface IGeneralHolidaysBR
    {
        IValidateBusinessRuleResponse InsertGeneralHolidaysValidate(GeneralHolidays item);
        IValidateBusinessRuleResponse UpdateGeneralHolidaysValidate(GeneralHolidays item);
        IValidateBusinessRuleResponse DeleteGeneralHolidaysValidate(GeneralHolidays item);
    }
}
