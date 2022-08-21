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
    public class EmployeePFReportForm10BA : IEmployeePFReportForm10BA
    {
        IEmployeePFReportForm10DataProvider _EmployeePFReportForm10DataProvider;
        private ILogger _logException;

        public EmployeePFReportForm10BA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _EmployeePFReportForm10DataProvider = new EmployeePFReportForm10DataProvider();
        }

        public IBaseEntityCollectionResponse<EmployeePFReportForm10> GetEmployeePFReportForm10DataList(EmployeePFReportForm10SearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeePFReportForm10> EmployeePFReportForm10Collection = new BaseEntityCollectionResponse<EmployeePFReportForm10>();
            try
            {
                if (_EmployeePFReportForm10DataProvider != null)
                    EmployeePFReportForm10Collection = _EmployeePFReportForm10DataProvider.GetEmployeePFReportForm10DataList(searchRequest);
                else
                {
                    EmployeePFReportForm10Collection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EmployeePFReportForm10Collection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EmployeePFReportForm10Collection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                EmployeePFReportForm10Collection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EmployeePFReportForm10Collection;
        }


    }
}