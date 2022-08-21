using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessRules
{
    public interface IGeneralWeekDaysBR
    {
        /// <summary>
        /// business rule interface of insert new record of GeneralWeekDays.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse InsertGeneralWeekDaysValidate(GeneralWeekDays item);

        /// <summary>
        /// business rule interface of update record of GeneralWeekDays.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse UpdateGeneralWeekDaysValidate(GeneralWeekDays item);

        /// <summary>
        /// business rule interface of dalete record of GeneralWeekDays.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IValidateBusinessRuleResponse DeleteGeneralWeekDaysValidate(GeneralWeekDays item);
    }
}
