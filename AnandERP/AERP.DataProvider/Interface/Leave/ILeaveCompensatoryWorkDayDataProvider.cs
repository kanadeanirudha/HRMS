using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.DataProvider
{
    public interface ILeaveCompensatoryWorkDayDataProvider
    {
        IBaseEntityResponse<LeaveCompensatoryWorkDay> InsertLeaveCompensatoryWorkDay(LeaveCompensatoryWorkDay item);
        IBaseEntityResponse<LeaveCompensatoryWorkDay> UpdateLeaveCompensatoryWorkDay(LeaveCompensatoryWorkDay item);
        IBaseEntityResponse<LeaveCompensatoryWorkDay> DeleteLeaveCompensatoryWorkDay(LeaveCompensatoryWorkDay item);
        IBaseEntityCollectionResponse<LeaveCompensatoryWorkDay> GetLeaveCompensatoryWorkDayBySearch(LeaveCompensatoryWorkDaySearchRequest searchRequest);
        IBaseEntityResponse<LeaveCompensatoryWorkDay> GetLeaveCompensatoryWorkDayByID(LeaveCompensatoryWorkDay item);       
        IBaseEntityResponse<LeaveCompensatoryWorkDay> GetCompensatoryOffDayApplicationDetailsByID(LeaveCompensatoryWorkDay item);
        IBaseEntityResponse<LeaveCompensatoryWorkDay> InsertApprovedCompensatoryWorkDayRecord(LeaveCompensatoryWorkDay item);
        IBaseEntityCollectionResponse<LeaveCompensatoryWorkDay> GetCompensatoryWorkDayDataByEmployeeAndLeaveSessionID(LeaveCompensatoryWorkDaySearchRequest searchRequest);
        
    }
}
