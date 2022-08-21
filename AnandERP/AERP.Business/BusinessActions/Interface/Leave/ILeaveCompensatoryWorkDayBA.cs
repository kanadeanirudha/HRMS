using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessAction
{
    public interface ILeaveCompensatoryWorkDayBA
    {
        IBaseEntityResponse<LeaveCompensatoryWorkDay> InsertLeaveCompensatoryWorkDay(LeaveCompensatoryWorkDay item);
        IBaseEntityResponse<LeaveCompensatoryWorkDay> UpdateLeaveCompensatoryWorkDay(LeaveCompensatoryWorkDay item);
        IBaseEntityResponse<LeaveCompensatoryWorkDay> DeleteLeaveCompensatoryWorkDay(LeaveCompensatoryWorkDay item);
        IBaseEntityCollectionResponse<LeaveCompensatoryWorkDay> GetBySearch(LeaveCompensatoryWorkDaySearchRequest searchRequest);
        IBaseEntityResponse<LeaveCompensatoryWorkDay> SelectByID(LeaveCompensatoryWorkDay item);       
        IBaseEntityResponse<LeaveCompensatoryWorkDay> GetCompensatoryOffDayApplicationDetailsByID(LeaveCompensatoryWorkDay item);
        IBaseEntityResponse<LeaveCompensatoryWorkDay> InsertApprovedCompensatoryWorkDayRecord(LeaveCompensatoryWorkDay item);
        IBaseEntityCollectionResponse<LeaveCompensatoryWorkDay> GetCompensatoryWorkDayDataByEmployeeAndLeaveSessionID(LeaveCompensatoryWorkDaySearchRequest searchRequest);
        
    }
}
