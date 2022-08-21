using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface IGeneralWeekDaysDataProvider
    {
        /// <summary>
        /// data provider interface of insert new record of GeneralWeekDays.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralWeekDays> InsertGeneralWeekDays(GeneralWeekDays item);

        /// <summary>
        /// data provider interface of update record of GeneralWeekDays.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralWeekDays> UpdateGeneralWeekDays(GeneralWeekDays item);

        /// <summary>
        /// data provider interface of dalete record of GeneralWeekDays.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralWeekDays> DeleteGeneralWeekDays(GeneralWeekDays item);

        /// <summary>
        /// data provider interface of select all record of GeneralWeekDays.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralWeekDays> GetGeneralWeekDaysBySearch(GeneralWeekDaysSearchRequest searchRequest);

        /// <summary>
        /// data provider interface of select all record of GeneralWeekDays.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityCollectionResponse<GeneralWeekDays> GetGeneralWeekDayList(GeneralWeekDaysSearchRequest searchRequest);        

        /// <summary>
        /// data provider interface of select one record of GeneralWeekDays.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        IBaseEntityResponse<GeneralWeekDays> GetGeneralWeekDaysByID(GeneralWeekDays item);
    }
}
