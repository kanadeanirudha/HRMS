using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.DataProvider
{
    public interface ITD_DailyActivityReport_Web_API_DataProvider
    {
        IBaseEntityResponse<DailyActivityReport> InsertDailyActivityReport(DailyActivityReport item);
        IBaseEntityResponse<DailyActivityReport> InsertScheduleActivity(DailyActivityReport item);
        IBaseEntityCollectionResponse<DailyActivityReport> GetWorkHistory(DailyActivityReport item);
        IBaseEntityCollectionResponse<DailyActivityReport> GetWorkDetails(DailyActivityReport item);
    }

}
