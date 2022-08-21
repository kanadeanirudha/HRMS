using AERP.Base.DTO;
using AERP.Business.BusinessRules;
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
    public class LeaveEmployeeApplicationStatusReportBA : ILeaveEmployeeApplicationStatusReportBA
    {
        ILeaveEmployeeApplicationStatusReportDataProvider _LeaveEmployeeApplicationStatusReportDataProvider;
        private ILogger _logException;
        public LeaveEmployeeApplicationStatusReportBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _LeaveEmployeeApplicationStatusReportDataProvider = new LeaveEmployeeApplicationStatusReportDataProvider();
        }
      
        public IBaseEntityCollectionResponse<LeaveEmployeeApplicationStatusReport> GetBySearch(LeaveEmployeeApplicationStatusReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<LeaveEmployeeApplicationStatusReport> LeaveEmployeeApplicationStatusReportCollection = new BaseEntityCollectionResponse<LeaveEmployeeApplicationStatusReport>();
            try
            {
                if (_LeaveEmployeeApplicationStatusReportDataProvider != null)
                    LeaveEmployeeApplicationStatusReportCollection = _LeaveEmployeeApplicationStatusReportDataProvider.GetLeaveEmployeeApplicationStatusReportBySearch(searchRequest);
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
