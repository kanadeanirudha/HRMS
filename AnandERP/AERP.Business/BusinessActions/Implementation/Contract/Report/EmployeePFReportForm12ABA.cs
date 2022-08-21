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
    public class EmployeePFReportForm12ABA : IEmployeePFReportForm12ABA
    {
        IEmployeePFReportForm12ADataProvider _EmployeePFReportForm12ADataProvider;
        private ILogger _logException;

        public EmployeePFReportForm12ABA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _EmployeePFReportForm12ADataProvider = new EmployeePFReportForm12ADataProvider();
        }

        public IBaseEntityCollectionResponse<EmployeePFReportForm12A> GetEmployeePFReportForm12ADataList(EmployeePFReportForm12ASearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeePFReportForm12A> EmployeePFReportForm12ACollection = new BaseEntityCollectionResponse<EmployeePFReportForm12A>();
            try
            {
                if (_EmployeePFReportForm12ADataProvider != null)
                    EmployeePFReportForm12ACollection = _EmployeePFReportForm12ADataProvider.GetEmployeePFReportForm12ADataList(searchRequest);
                else
                {
                    EmployeePFReportForm12ACollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EmployeePFReportForm12ACollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EmployeePFReportForm12ACollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                EmployeePFReportForm12ACollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EmployeePFReportForm12ACollection;
        }


    }
}