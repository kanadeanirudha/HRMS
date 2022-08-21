using AERP.Base.DTO;
using AERP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace AERP.Business.BusinessAction
{
    public interface IDashboardBA
    {
        IBaseEntityResponse<Dashboard> ApproveAllCompensatoryLeaveApplication(Dashboard item);
        IBaseEntityCollectionResponse<Dashboard> GetDashboardContentListByAdminRoleID(DashboardSearchRequest searchRequest);
        IBaseEntityCollectionResponse<Dashboard> GetDeshboardAllocationBySearch(DashboardSearchRequest searchRequest);
        IBaseEntityResponse<Dashboard> DeleteContaintAllocateStatus(Dashboard item);
        IBaseEntityResponse<Dashboard> InsertContaintAllocateStatus(Dashboard item);

        IBaseEntityResponse<Dashboard> InsertDashboard(Dashboard item);

        IBaseEntityCollectionResponse<Dashboard> GetByRequestApprovalField(DashboardSearchRequest searchRequest);
        IBaseEntityCollectionResponse<Dashboard> GetDashboardRoleCodeList(DashboardSearchRequest searchRequest);
        IBaseEntityCollectionResponse<Dashboard> GetGeneralTaskModelListByPersonID(DashboardSearchRequest searchRequest);

        IBaseEntityCollectionResponse<Dashboard> GetBySearch(DashboardSearchRequest searchRequest);

        IBaseEntityResponse<Dashboard> ApproveAllLeaveApplication(Dashboard item);

        IBaseEntityResponse<Dashboard> InformativeNotificationsReadInsert(Dashboard item);

        IBaseEntityCollectionResponse<Dashboard> GetInformativeNotificationListBySearch(DashboardSearchRequest searchRequest);

        IBaseEntityResponse<Dashboard> ApproveAllManualAttendanceApplication(Dashboard item);

        IBaseEntityCollectionResponse<Dashboard> GetGeneralRequestBySearch(DashboardSearchRequest searchRequest);

        IBaseEntityResponse<Dashboard> ApproveAllAttendanceSpecialRequestApplication(Dashboard item);


    }
}
