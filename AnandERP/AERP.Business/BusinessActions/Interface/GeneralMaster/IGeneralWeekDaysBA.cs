using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessAction
{
    public interface IGeneralWeekDaysBA
    {
        /// <summary>
        /// business action interface of insert new record of GeneralWeekDays.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralWeekDays> InsertGeneralWeekDays(GeneralWeekDays item);

        /// <summary>
        /// business action interface of update record of GeneralWeekDays.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralWeekDays> UpdateGeneralWeekDays(GeneralWeekDays item);

        /// <summary>
        /// business action interface of dalete record of GeneralWeekDays.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralWeekDays> DeleteGeneralWeekDays(GeneralWeekDays item);

        /// <summary>
        /// business action interface of select all record of GeneralWeekDays.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralWeekDays> GetBySearch(GeneralWeekDaysSearchRequest searchRequest);

        /// <summary>
        /// business action interface of select all record of GeneralWeekDays.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralWeekDays> GetGeneralWeekDayList(GeneralWeekDaysSearchRequest searchRequest);        

        IBaseEntityResponse<GeneralWeekDays> SelectByID(GeneralWeekDays item);
    }
}
