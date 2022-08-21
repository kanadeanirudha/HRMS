using AERP.Base.DTO;
using AERP.Common;
using AERP.DataProvider;
using AERP.DTO;
using AERP.ExceptionManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AERP.Business.BusinessAction
{
    public class ManualAttendanceStatusReportBA : IManualAttendanceStatusReportBA
    {
        IManualAttendanceStatusReportDataProvider _IManualAttendanceStatusReportDataProvider;
        private ILogger _logException;
        public ManualAttendanceStatusReportBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _IManualAttendanceStatusReportDataProvider = new ManualAttendanceStatusReportDataProvider();
        }
        public IBaseEntityCollectionResponse<ManualAttendanceStatusReport> GetBySearch(ManualAttendanceStatusReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<ManualAttendanceStatusReport> LeaveEmployeeApplicationStatusReportCollection = new BaseEntityCollectionResponse<ManualAttendanceStatusReport>();
            try
            {
                if (_IManualAttendanceStatusReportDataProvider != null)
                    LeaveEmployeeApplicationStatusReportCollection = _IManualAttendanceStatusReportDataProvider.GetLeaveEmployeeApplicationStatusReportBySearch(searchRequest);
                else
                {
                    LeaveEmployeeApplicationStatusReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    LeaveEmployeeApplicationStatusReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                LeaveEmployeeApplicationStatusReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                LeaveEmployeeApplicationStatusReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return LeaveEmployeeApplicationStatusReportCollection;
        }
    }
}
