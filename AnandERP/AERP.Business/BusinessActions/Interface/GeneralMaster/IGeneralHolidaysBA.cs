using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessAction
{
    public interface IGeneralHolidaysBA
    {
        IBaseEntityResponse<GeneralHolidays> InsertGeneralHolidays(GeneralHolidays item);
        IBaseEntityResponse<GeneralHolidays> UpdateGeneralHolidays(GeneralHolidays item);
        IBaseEntityResponse<GeneralHolidays> DeleteGeneralHolidays(GeneralHolidays item);
        IBaseEntityCollectionResponse<GeneralHolidays> GetBySearch(GeneralHolidaysSearchRequest searchRequest);
        IBaseEntityResponse<GeneralHolidays> SelectByID(GeneralHolidays item);
        IBaseEntityCollectionResponse<GeneralHolidays> GetHolidayAndWeeklyOffDayByEmployeeID(GeneralHolidaysSearchRequest searchRequest);

        IBaseEntityCollectionResponse<GeneralHolidays> GetListCheckInCheckOutTime(GeneralHolidaysSearchRequest searchRequest);
    }
}
