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
    public class EmployeeReportForm5MonthlyBA : IEmployeeReportForm5MonthlyBA
    {
        IEmployeeReportForm5MonthlyDataProvider _EmployeeReportForm5MonthlyDataProvider;
        private ILogger _logException;

        public EmployeeReportForm5MonthlyBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _EmployeeReportForm5MonthlyDataProvider = new EmployeeReportForm5MonthlyDataProvider();
        }

        public IBaseEntityCollectionResponse<EmployeeReportForm5Monthly> GetEmployeeReportForm5MonthlyDataList(EmployeeReportForm5MonthlySearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeeReportForm5Monthly> EmployeeReportForm5MonthlyCollection = new BaseEntityCollectionResponse<EmployeeReportForm5Monthly>();
            try
            {
                if (_EmployeeReportForm5MonthlyDataProvider != null)
                    EmployeeReportForm5MonthlyCollection = _EmployeeReportForm5MonthlyDataProvider.GetEmployeeReportForm5MonthlyDataList(searchRequest);
                else
                {
                    EmployeeReportForm5MonthlyCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EmployeeReportForm5MonthlyCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EmployeeReportForm5MonthlyCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                EmployeeReportForm5MonthlyCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EmployeeReportForm5MonthlyCollection;
        }


    }
}