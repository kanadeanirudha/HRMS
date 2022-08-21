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
    public class EmployeeFormIIWagesSheetReportBA : IEmployeeFormIIWagesSheetReportBA
    {
        IEmployeeFormIIWagesSheetReportDataProvider _EmployeeFormIIWagesSheetReportDataProvider;
        private ILogger _logException;

        public EmployeeFormIIWagesSheetReportBA()
        {
            _logException = new ExceptionManager.ExceptionManager(); //This need to change later
            _EmployeeFormIIWagesSheetReportDataProvider = new EmployeeFormIIWagesSheetReportDataProvider();
        }

        public IBaseEntityCollectionResponse<EmployeeFormIIWagesSheetReport> GetEmployeeFormIIWagesSheetReportDataList(EmployeeFormIIWagesSheetReportSearchRequest searchRequest)
        {
            IBaseEntityCollectionResponse<EmployeeFormIIWagesSheetReport> EmployeeFormIIWagesSheetReportCollection = new BaseEntityCollectionResponse<EmployeeFormIIWagesSheetReport>();
            try
            {
                if (_EmployeeFormIIWagesSheetReportDataProvider != null)
                    EmployeeFormIIWagesSheetReportCollection = _EmployeeFormIIWagesSheetReportDataProvider.GetEmployeeFormIIWagesSheetReportDataList(searchRequest);
                else
                {
                    EmployeeFormIIWagesSheetReportCollection.Message.Add(new MessageDTO
                    {
                        ErrorMessage = Resources.Null_Object_Exception,
                        MessageType = MessageTypeEnum.Error
                    });
                    EmployeeFormIIWagesSheetReportCollection.CollectionResponse = null;
                }
            }
            catch (Exception ex)
            {
                EmployeeFormIIWagesSheetReportCollection.Message.Add(new MessageDTO
                {
                    ErrorMessage = ex.Message,
                    MessageType = MessageTypeEnum.Error
                });
                EmployeeFormIIWagesSheetReportCollection.CollectionResponse = null;
                if (_logException != null)
                {
                    _logException.Error(ex.Message);
                }
            }
            return EmployeeFormIIWagesSheetReportCollection;
        }


    }
}